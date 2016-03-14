using System;
using SagePay.IntegrationKit.Messages;
using System.Text;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Diagnostics;

namespace SagePay.IntegrationKit
{
    public class SagePayIntegration
    {
        public string RequestQueryString { get; set; }
        public string ResponseQueryString { get; set; }

        protected static NameValueCollection mapCols = new NameValueCollection();

        public SagePayIntegration()
        {
            if (mapCols.Count == 0)
            {
                mapCols.Add("3DSecureStatus", "ThreeDSecureStatus");
                mapCols.Add("VPSTxId", "VpsTxId");
                mapCols.Add("VPSProtocol", "VpsProtocol");
                mapCols.Add("TxType", "TransactionType");
                mapCols.Add("AVSCV2", "AvsCv2");
                mapCols.Add("CV2Result", "Cv2Result");
                mapCols.Add("CAVV", "Cavv");
                mapCols.Add("SuccessURL", "SuccessUrl");
                mapCols.Add("FailureURL", "FailureUrl");
                mapCols.Add("CustomerEMail", "CustomerEmail");
                mapCols.Add("VendorEMail", "VendorEmail");
                mapCols.Add("SendEMail", "SendEmail");
                mapCols.Add("eMailMessage", "EmailMessage");
                mapCols.Add("ApplyAVSCV2", "ApplyAvsCv2");
                mapCols.Add("Apply3DSecure", "Apply3dSecure");
                mapCols.Add("ReferrerID", "ReferrerId");
                mapCols.Add("NotificationURL", "NotificationUrl");
                mapCols.Add("NextURL", "NextUrl");
                mapCols.Add("CV2", "Cv2");
                mapCols.Add("ClientIPAddress", "ClientIpAddress");
                mapCols.Add("RelatedVPSTxId", "RelatedVpsTxId");
                mapCols.Add("BasketXML", "BasketXml");
                mapCols.Add("CustomerXML", "CustomerXml");
                mapCols.Add("SurchargeXML", "SurchargeXml");
                mapCols.Add("RedirectURL", "RedirectUrl");
                mapCols.Add("MD", "Md");
                mapCols.Add("ACSURL", "AcsUrl");
                mapCols.Add("PAReq", "PaReq");
                mapCols.Add("PayPalCallbackURL", "PayPalCallbackUrl");
                mapCols.Add("PayPalRedirectURL", "PayPalRedirectUrl");
                mapCols.Add("token", "Token");
                mapCols.Add("PARes", "PaRes");

                mapCols.Add("FiRecipientAcctNumber", "FiRecipientAccountNumber");
                mapCols.Add("FiRecipientDob", "FiRecipientDateOfBirth");
                mapCols.Add("FiRecipientPostCode", "FiRecipientPostCode");
                mapCols.Add("FiRecipientSurname", "FiRecipientSurname");
            }
        }

        public static DataObject ConvertToSagePayMessage(string stringMessage)
        {
            DataObject dataObject = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(stringMessage);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                    propInfo.SetValue(dataObject, val, null);
                }
                else
                {
                    propInfo.SetValue(dataObject, Convert.ChangeType(msgResponse.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }

            return dataObject;
        }

        public static NameValueCollection ConvertSagePayMessageToNameValueCollection(ProtocolMessage protocolMessage, Type type, IMessage message, ProtocolVersion protocolVersion)
        {
            var msg = new NameValueCollection();

            foreach (var field in protocolMessage.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = message.GetType().GetProperty(propName);
                if (propName.Equals("VpsProtocol"))
                    msg.Add(field.CanonicalName(), protocolVersion.VersionString());
                else
                {
                    if (CheckSagePayProtocolVersion(type, propName, protocolVersion))
                        msg.Add(field.CanonicalName(), propInfo.GetValue(message, null).ToString());
                }
            }

            foreach (var field in protocolMessage.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = message.GetType().GetProperty(propName);
                if (propInfo.GetValue(message, null) == null) continue;

                if (CheckSagePayProtocolVersion(type, propName, protocolVersion))
                    msg.Add(field.CanonicalName(), propInfo.GetValue(message, null).ToString());
            }

            return msg;
        }

        public static bool CheckSagePayProtocolVersion(Type type, string propertyName, ProtocolVersion protocolVersion)
        {
            var interfaces = type.GetInterfaces();

            foreach (var @interface in interfaces)
            {
                foreach (var interfaceProperty in @interface.GetProperties())
                {
                    if (interfaceProperty.Name != propertyName) continue;
                    if (!interfaceProperty.GetCustomAttributes(typeof(SagePayProtocolVersion), true).Any())
                        continue;

                    var sagepayProtocolVersion = (SagePayProtocolVersion)interfaceProperty.GetCustomAttributes(typeof(SagePayProtocolVersion), true).FirstOrDefault();
                    return sagepayProtocolVersion != null && (protocolVersion.VersionInt() >= sagepayProtocolVersion.Min.VersionInt());
                }
                return CheckSagePayProtocolVersion(@interface, propertyName, protocolVersion);
            }
            return true;
        }

        public NameValueCollection Validation(ProtocolMessage protocolMessage, Type type, IMessage message, ProtocolVersion protocolVersion)
        {
            var errorMessages = new NameValueCollection();

            foreach (var field in protocolMessage.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = message.GetType().GetProperty(propName);

                if (propName.Equals("VpsProtocol")) continue;

                if (CheckSagePayProtocolVersion(type, propName, protocolVersion))
                    Validate(field, errorMessages, (propInfo.GetValue(message, null) != null ? propInfo.GetValue(message, null).ToString() : string.Empty), true);
            }

            foreach (var field in protocolMessage.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = message.GetType().GetProperty(propName);

                if (propInfo.GetValue(message, null) == null ||
                    propInfo.GetValue(message, null).ToString() == string.Empty) continue;

                if (CheckSagePayProtocolVersion(type, propName, protocolVersion))
                    Validate(field, errorMessages, (propInfo.GetValue(message, null) != null ? propInfo.GetValue(message, null).ToString() : string.Empty), false);
            }

            return errorMessages;
        }


        public void Validate(ProtocolField field, NameValueCollection errorMessages, string value, bool required)
        {
            if (field.DataType().Type() != null)
            {
                if (!Enum.IsDefined(field.DataType().Type(), value))
                {
                    errorMessages.Add(field.CanonicalName(), field.DataType().Type().ToString());
                }
            }
            else
            {
                var r = new Regex(field.DataType().ApiRegex().Pattern());

                if (!r.IsMatch(value))
                {
                    errorMessages.Add(field.CanonicalName(), field.DataType().ApiRegex().Pattern());
                }
            }
        }

        public IServerPaymentResult GetServerPaymentResult(string resultQueryString)
        {
            IServerPaymentResult paymentResult = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);

                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(paymentResult, val, null);
                    }
                    else
                    {
                        var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                        propInfo.SetValue(paymentResult, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(paymentResult,
                        propName.Equals("PaReq")
                            ? Convert.ChangeType(msgResponse.Get(i).Replace(" ", "+"), propInfo.PropertyType)
                            : Convert.ChangeType(msgResponse.Get(i),
                                Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return paymentResult;
        }


        public IServerTokenRegisterResult GetServerTokenRegisterResult(string resultQueryString)
        {
            IServerTokenRegisterResult paymentResult = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;
                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(paymentResult, val, null);
                    }
                    else
                    {
                        object val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                        propInfo.SetValue(paymentResult, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(paymentResult,
                        propName.Equals("PaReq")
                            ? Convert.ChangeType(msgResponse.Get(i).Replace(" ", "+"), propInfo.PropertyType)
                            : Convert.ChangeType(msgResponse.Get(i),
                                Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return paymentResult;
        }

        public IServerNotificationRequest GetServerNotificationRequest()
        {
            IServerNotificationRequest message = new DataObject();

            var requestFormsValues = HttpContext.Current.Request.Form;

            for (var i = 0; i < requestFormsValues.Count; i++)
            {
                var propName = mapCols[requestFormsValues.GetKey(i)] ?? requestFormsValues.GetKey(i);

                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo == null) continue;

                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + requestFormsValues.Get(i).Replace(".", ""));
                        propInfo.SetValue(message, val, null);
                    }
                    else
                    {
                        var val = Enum.Parse(propInfo.PropertyType, requestFormsValues.Get(i));
                        propInfo.SetValue(message, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(message, Convert.ChangeType(requestFormsValues.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }

            return message;
        }

        public IServerPayment ServerPaymentRequest()
        {
            IServerPayment serverPaymentRequest = new DataObject();
            return serverPaymentRequest;
        }

        public IServerTokenRegisterRequest ServerTokenRegisterRequest()
        {
            IServerTokenRegisterRequest serverTokenRegisterRequest = new DataObject();
            return serverTokenRegisterRequest;
        }

        public IServerTokenRegisterResult GetServerTokenRegisterRequest(IServerTokenRegisterRequest serverPaymentRequest, string url)
        {
            var msg = new NameValueCollection();

            foreach (var field in ProtocolMessage.SERVER_TOKEN_REGISTER.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? serverPaymentRequest.VpsProtocol.VersionString()
                        : propInfo.GetValue(serverPaymentRequest, null).ToString());
            }

            foreach (var field in ProtocolMessage.SERVER_TOKEN_REGISTER.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.GetValue(serverPaymentRequest, null) != null)
                    msg.Add(field.CanonicalName(), propInfo.GetValue(serverPaymentRequest, null).ToString());
            }

            RequestQueryString = BuildQueryString(msg);
            ResponseQueryString = ProcessWebRequestToSagePay(url, RequestQueryString);
            return GetServerTokenRegisterResult(ResponseQueryString);
        }

        public IServerPaymentResult GetServerPaymentRequest(IServerPayment serverPaymentRequest, string url)
        {
            var msg = new NameValueCollection();
            foreach (var field in ProtocolMessage.SERVER_PAYMENT.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? serverPaymentRequest.VpsProtocol.VersionString()
                        : propInfo.GetValue(serverPaymentRequest, null).ToString());
            }

            foreach (var field in ProtocolMessage.SERVER_PAYMENT.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.GetValue(serverPaymentRequest, null) != null)
                    msg.Add(field.CanonicalName(), propInfo.GetValue(serverPaymentRequest, null).ToString());
            }

            RequestQueryString = BuildQueryString(msg);
            ResponseQueryString = ProcessWebRequestToSagePay(url, RequestQueryString);
            return GetServerPaymentResult(ResponseQueryString);
        }

        public string BuildQueryString(NameValueCollection msg)
        {
            var sb = new StringBuilder();
            foreach (var key in msg.AllKeys)
            {
                if (sb.Length > 0) sb.AppendFormat("&");
                sb.AppendFormat("{0}={1}", key, msg[key]);      // NB : we don't encode the value bit -- this is for historic backward compatibility
            }
            return sb.ToString();
        }

        public string BuildQueryString(IMessage request, ProtocolMessage protocolMessage, ProtocolVersion protocolVersion)
        {
            var msg = new NameValueCollection();

            foreach (var field in protocolMessage.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? protocolVersion.VersionString()
                        : propInfo.GetValue(request, null).ToString());
            }

            if (protocolMessage.Optional() == null) return BuildQueryString(msg);

            foreach (var field in protocolMessage.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? protocolVersion.VersionString()
                        : propInfo.GetValue(request, null).ToString());
            }

            return BuildQueryString(msg);
        }


        public IDirectPayment DirectPaymentRequest()
        {
            IDirectPayment request = new DataObject();
            return request;
        }

        public IPayPalCompleteRequest PayPalCompleteRequest()
        {
            IPayPalCompleteRequest request = new DataObject();
            return request;
        }

        public IDirectTokenRegisterRequest DirectTokenRequest()
        {
            IDirectTokenRegisterRequest request = new DataObject();
            return request;
        }

        public IDirectPaymentResult ProcessDirectPaymentRequest(IDirectPayment paymentRequest, string directPaymentUrl)
        {
            var msg = new NameValueCollection();

            foreach (var field in ProtocolMessage.DIRECT_PAYMENT.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? paymentRequest.VpsProtocol.VersionString()
                        : propInfo.GetValue(paymentRequest, null).ToString());
            }

            foreach (var field in ProtocolMessage.DIRECT_PAYMENT.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                if (propInfo.GetValue(paymentRequest, null) != null)
                    msg.Add(field.CanonicalName(), propInfo.GetValue(paymentRequest, null).ToString());
            }

            RequestQueryString = BuildQueryString(msg);
            ResponseQueryString = ProcessWebRequestToSagePay(directPaymentUrl, RequestQueryString);
            return GetDirectPaymentResult(ResponseQueryString);
        }

        public IDirectTokenResult ProcessDirectTokenRequest(IDirectTokenRegisterRequest request, string directTokenRegisterUrl)
        {
            var msg = new NameValueCollection();

            foreach (var field in ProtocolMessage.DIRECT_TOKEN_REGISTER.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? request.VpsProtocol.VersionString()
                        : propInfo.GetValue(request, null).ToString());
            }

            foreach (var field in ProtocolMessage.DIRECT_TOKEN_REGISTER.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                if (propInfo.GetValue(request, null) != null)
                    msg.Add(field.CanonicalName(), propInfo.GetValue(request, null).ToString());
            }

            RequestQueryString = BuildQueryString(msg);
            ResponseQueryString = ProcessWebRequestToSagePay(directTokenRegisterUrl, RequestQueryString);
            return GetDirectTokenResult(ResponseQueryString);
        }

        public IDirectPaymentResult ProcessDirectPayPalRequest(IPayPalCompleteRequest paymentRequest, string directPayPalCompleteUrl)
        {
            var msg = new NameValueCollection();

            foreach (var field in ProtocolMessage.PAY_PAL_COMPLETE_REQUEST.Required())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);

                msg.Add(field.CanonicalName(),
                    propName.Equals("VpsProtocol")
                        ? paymentRequest.VpsProtocol.VersionString()
                        : propInfo.GetValue(paymentRequest, null).ToString());
            }

            foreach (var field in ProtocolMessage.PAY_PAL_COMPLETE_REQUEST.Optional())
            {
                var propName = mapCols[field.CanonicalName()] ?? field.CanonicalName();
                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.GetValue(paymentRequest, null) != null)
                    msg.Add(field.CanonicalName(), propInfo.GetValue(paymentRequest, null).ToString());
            }

            RequestQueryString = BuildQueryString(msg);
            ResponseQueryString = ProcessWebRequestToSagePay(directPayPalCompleteUrl, RequestQueryString);
            return GetDirectPaymentResult(ResponseQueryString);
        }

        public IDirectPaymentResult GetDirectPaymentResult(string resultQueryString)
        {
            IDirectPaymentResult paymentResult = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;
                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(paymentResult, val, null);
                    }
                    else
                    {
                        if (propName.Equals("Status") && msgResponse.Get(i).Equals("3DAUTH"))
                        {
                            var val = Enum.Parse(propInfo.PropertyType, "THREEDAUTH");
                            propInfo.SetValue(paymentResult, val, null);
                        }
                        else
                        {
                            var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                            propInfo.SetValue(paymentResult, val, null);
                        }
                    }
                }
                else
                {
                    propInfo.SetValue(paymentResult, Convert.ChangeType(msgResponse.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return paymentResult;
        }

        public IDirectTokenResult GetDirectTokenResult(string resultQueryString)
        {
            IDirectTokenResult paymentResult = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(paymentResult, val, null);
                    }
                    else
                    {
                        if (propName.Equals("Status") && msgResponse.Get(i).Equals("3DAUTH"))
                        {
                            var val = Enum.Parse(propInfo.PropertyType, "THREEDAUTH");
                            propInfo.SetValue(paymentResult, val, null);
                        }
                        else
                        {
                            var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                            propInfo.SetValue(paymentResult, val, null);
                        }
                    }
                }
                else
                {
                    propInfo.SetValue(paymentResult, Convert.ChangeType(msgResponse.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return paymentResult;
        }

        public IPayPalNotificationRequest GetPayPalNotificationRequest()
        {
            IPayPalNotificationRequest message = new DataObject();

            var requestFormsValues = HttpContext.Current.Request.QueryString;

            for (var i = 0; i < requestFormsValues.Count; i++)
            {
                var propName = mapCols[requestFormsValues.GetKey(i)] ?? requestFormsValues.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo == null) continue;

                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + requestFormsValues.Get(i).Replace(".", ""));
                        propInfo.SetValue(message, val, null);
                    }
                    else
                    {
                        var val = Enum.Parse(propInfo.PropertyType, requestFormsValues.Get(i));
                        propInfo.SetValue(message, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(message, Convert.ChangeType(requestFormsValues.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }

            return message;
        }

        public string ProcessWebRequestToSagePay(string url, string postData)
        {
            Debug.WriteLine("To Gateway : {0} <= {1}", url, postData);

            var objUtfEncode = new UTF8Encoding();
            var objUri = new Uri(url);

            var objHttpRequest = (HttpWebRequest)WebRequest.Create(objUri);
            objHttpRequest.KeepAlive = false;
            objHttpRequest.Method = "POST";

            objHttpRequest.ContentType = "application/x-www-form-urlencoded";
            var arrRequest = objUtfEncode.GetBytes(postData);
            objHttpRequest.ContentLength = arrRequest.Length;
            var objStreamReq = objHttpRequest.GetRequestStream();
            objStreamReq.Write(arrRequest, 0, arrRequest.Length);
            objStreamReq.Close();

            //Get response
            var objHttpResponse = (HttpWebResponse)objHttpRequest.GetResponse();

            var stream = objHttpResponse.GetResponseStream();
            if (stream == null) return null;

            var objStreamRes = new StreamReader(stream, Encoding.ASCII);

            var returnResponse = objStreamRes.ReadToEnd();
            objStreamRes.Close();

            returnResponse = returnResponse.Replace("\r\n", "&");
            if (!string.IsNullOrEmpty(returnResponse) && returnResponse.Substring(returnResponse.Length - 1, 1) == "&")
                returnResponse = returnResponse.Remove(returnResponse.Length - 1, 1);
            return returnResponse;
        }


        public ICaptureResult ConvertToCaptureResult(string resultQueryString)
        {
            ICaptureResult result = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(result, val, null);
                    }
                    else
                    {
                        var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                        propInfo.SetValue(result, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(result, Convert.ChangeType(msgResponse.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return result;
        }

        public IRefundResult ConvertToRefundResult(string resultQueryString)
        {
            IRefundResult result = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(result, val, null);
                    }
                    else
                    {
                        var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                        propInfo.SetValue(result, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(result, Convert.ChangeType(msgResponse.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return result;
        }

        public IBasicResult ConvertToBasicResult(string resultQueryString)
        {
            IBasicResult result = new DataObject();

            var msgResponse = HttpUtility.ParseQueryString(resultQueryString);

            for (var i = 0; i < msgResponse.Count; i++)
            {
                var propName = mapCols[msgResponse.GetKey(i)] ?? msgResponse.GetKey(i);
                if (string.IsNullOrEmpty(propName)) continue;

                var propInfo = typeof(DataObject).GetProperty(propName);
                if (propInfo.PropertyType.IsEnum)
                {
                    if (propName.Equals("VpsProtocol"))
                    {
                        var val = Enum.Parse(propInfo.PropertyType, "V_" + msgResponse.Get(i).Replace(".", ""));
                        propInfo.SetValue(result, val, null);
                    }
                    else
                    {
                        var val = Enum.Parse(propInfo.PropertyType, msgResponse.Get(i));
                        propInfo.SetValue(result, val, null);
                    }
                }
                else
                {
                    propInfo.SetValue(result, Convert.ChangeType(msgResponse.Get(i), Nullable.GetUnderlyingType(propInfo.PropertyType) ?? propInfo.PropertyType), null);
                }
            }
            return result;
        }

    }
}