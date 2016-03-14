using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography;
using System.IO;
using System.Web;

namespace SagePay.IntegrationKit
{
    public class Cryptography
    {

         //**************************************************************************************************
        // Global Definitions for this site
        //**************************************************************************************************
        public static string[] arrBase64EncMap = new string[65];
        public static int[] arrBase64DecMap = new int[128];

        const string BASE_64_MAP_INIT = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/";

        //** ASP has no inbuild URLDecode function, so here's on in case we need it **
        public static string URLDecode(string strString)
        {

            int lngPos = 0;
            string strUrlDecode = "";

            for (lngPos = 1; lngPos <= Strings.Len(strString); lngPos++)
            {
                if (Strings.Mid(strString, lngPos, 1) == "%")
                {
                    strUrlDecode = strUrlDecode + Strings.Chr((int)Microsoft.VisualBasic.Conversion.Val("&H" + Strings.Mid(strString, lngPos + 1, 2)));
                    lngPos = lngPos + 2;
                }
                else if (Strings.Mid(strString, lngPos, 1) == "+")
                {
                    strUrlDecode = strUrlDecode + " ";
                }
                else
                {
                    strUrlDecode = strUrlDecode + Strings.Mid(strString, lngPos, 1);
                }
            }

            return strUrlDecode;

        }

        //** There is a URLEncode function, but wrap it up so keep the code clean **
        public static string URLEncode(string strString)
        {

            return HttpUtility.UrlEncode(strString);

        }

        //** Base 64 encoding routine.  Used to ensure the encrypted "crypt" field **
        //** can be safely transmitted over HTTP **
        public static string base64Encode(string strPlain)
        {
            string functionReturnValue = null;
            int iLoop = 0;
            int iBy3 = 0;
            string strReturn = null;
            int iIndex = 0;
            int iFirst = 0;
            int iSecond = 0;
            int iiThird = 0;
            if (strPlain.Length == 0)
            {
                functionReturnValue = "";
                return functionReturnValue;
            }

            //** Set up Base64 Encoding and Decoding Maps for when we need them ** 
            for (iLoop = 0; iLoop <= Strings.Len(BASE_64_MAP_INIT) - 1; iLoop++)
            {
                arrBase64EncMap[iLoop] = Strings.Mid(BASE_64_MAP_INIT, iLoop + 1, 1);
            }
            for (iLoop = 0; iLoop <= Strings.Len(BASE_64_MAP_INIT) - 1; iLoop++)
            {
                arrBase64DecMap[Strings.Asc(arrBase64EncMap[iLoop])] = iLoop;
            }

            //** Work out rounded down multiple of 3 bytes length for the unencoded text **
            iBy3 = (strPlain.Length / 3) * 3;
            strReturn = "";

            //** For each 3x8 byte chars, covert them to 4x6 byte representations in the Base64 map **
            iIndex = 1;
            while (iIndex <= iBy3)
            {
                iFirst = Strings.Asc(Strings.Mid(strPlain, iIndex + 0, 1));
                iSecond = Strings.Asc(Strings.Mid(strPlain, iIndex + 1, 1));
                iiThird = Strings.Asc(Strings.Mid(strPlain, iIndex + 2, 1));
                strReturn = strReturn + arrBase64EncMap[(iFirst / 4) & 63];
                strReturn = strReturn + arrBase64EncMap[((iFirst * 16) & 48) + ((iSecond / 16) & 15)];
                strReturn = strReturn + arrBase64EncMap[((iSecond * 4) & 60) + ((iiThird / 64) & 3)];
                strReturn = strReturn + arrBase64EncMap[iiThird & 63];
                iIndex = iIndex + 3;
            }

            //** Handle any trailing characters not in groups of 3 **
            //** Extend to multiple of 3 characters using = signs as per RFC **
            if (iBy3 < strPlain.Length)
            {
                iFirst = Strings.Asc(Strings.Mid(strPlain, iIndex + 0, 1));
                strReturn = strReturn + arrBase64EncMap[(iFirst / 4) & 63];
                if ((strPlain.Length % 3) == 2)
                {
                    iSecond = Strings.Asc(Strings.Mid(strPlain, iIndex + 1, 1));
                    strReturn = strReturn + arrBase64EncMap[((iFirst * 16) & 48) + ((iSecond / 16) & 15)];
                    strReturn = strReturn + arrBase64EncMap[(iSecond * 4) & 60];
                }
                else
                {
                    strReturn = strReturn + arrBase64EncMap[(iFirst * 16) & 48];
                    strReturn = strReturn + "=";
                }
                strReturn = strReturn + "=";
            }

            //** Return the encoded result string **
            functionReturnValue = strReturn;
            return functionReturnValue;
        }
        public static string base64Decode(string strEncoded)
        {
            string functionReturnValue = null;
            int iRealLength = 0;
            string strReturn = null;
            int iBy4 = 0;
            int iIndex = 0;
            int iFirst = 0;
            int iSecond = 0;
            int iThird = 0;
            int iFourth = 0;
            if (Strings.Len(strEncoded) == 0)
            {
                functionReturnValue = "";
                return functionReturnValue;
            }

            //** Base 64 encoded strings are right padded to 3 character multiples using = signs **
            //** Work out the actual length of data without the padding here **
            iRealLength = Strings.Len(strEncoded);
            while (Strings.Mid(strEncoded, iRealLength, 1) == "=")
            {
                iRealLength = iRealLength - 1;
            }

            //** Non standard extension to Base 64 decode to allow for + sign to space character substitution by **
            //** some web servers. Base 64 expects a +, not a space, so convert vack to + if space is found **
            while (Strings.InStr(strEncoded, " ") != 0)
            {
                strEncoded = Strings.Left(strEncoded, Strings.InStr(strEncoded, " ") - 1) + "+" + Strings.Mid(strEncoded, Strings.InStr(strEncoded, " ") + 1);
            }

            strReturn = "";
            //** Convert the base 64 4x6 byte values into 3x8 byte real values by reading 4 chars at a time **
            iBy4 = (iRealLength / 4) * 4;
            iIndex = 1;
            while (iIndex <= iBy4)
            {
                iFirst = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 0, 1))];
                iSecond = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 1, 1))];
                iThird = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 2, 1))];
                iFourth = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 3, 1))];
                strReturn = strReturn + Strings.Chr(((iFirst * 4) & 255) + ((iSecond / 16) & 3));
                strReturn = strReturn + Strings.Chr(((iSecond * 16) & 255) + ((iThird / 4) & 15));
                strReturn = strReturn + Strings.Chr(((iThird * 64) & 255) + (iFourth & 63));
                iIndex = iIndex + 4;
            }

            //** For non multiples of 4 characters, handle the = padding **
            if (iIndex < iRealLength)
            {
                iFirst = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 0, 1))];
                iSecond = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 1, 1))];
                strReturn = strReturn + Strings.Chr(((iFirst * 4) & 255) + ((iSecond / 16) & 3));
                if (iRealLength % 4 == 3)
                {
                    iThird = arrBase64DecMap[Strings.Asc(Strings.Mid(strEncoded, iIndex + 2, 1))];
                    strReturn = strReturn + Strings.Chr(((iSecond * 16) & 255) + ((iThird / 4) & 15));
                }
            }

            functionReturnValue = strReturn;
            return functionReturnValue;
        }

        //** Wrapper function do encrypt an encode a message **
        public static string EncryptAndEncode(string strIn, string encryptionPassword)
        {
            //** AES encryption, CBC blocking with PKCS5 padding then HEX encoding - DEFAULT **
            return "@" + byteArrayToHexString(aesEncrypt(strIn, encryptionPassword));
        }

        //** Wrapper function do decode then decrypt based on header of the encrypted field **
        public static string DecodeAndDecrypt(string strIn, string encryptionPassword)
        {
            string functionReturnValue = null;
            if (Strings.Left(strIn, 1) == "@")
            {
                //** HEX decoding then AES decryption, CBC blocking with PKCS5 padding - DEFAULT **
                functionReturnValue = aesDecrypt(hexStringToBytes(strIn.Substring(1)), encryptionPassword);
            } 
            else 
            {
                throw new Exception("Unable to Decrypt message");
            }

            return functionReturnValue;
        }

        /// <summary>
        /// Encrypts input string using Rijndael (AES) algorithm with CBC blocking and PKCS7 padding.
        /// </summary>
        /// <param name="inputText">text string to encrypt </param>
        /// <returns>Encrypted text in Byte array</returns>
        /// <remarks>The key and IV are the same, and use SagePaySettings.EncryptionPassword.</remarks>
        private static byte[] aesEncrypt(string inputText, string encryptionPassword)
        {

            RijndaelManaged AES = new RijndaelManaged();
            byte[] outBytes = null;

            //set the mode, padding and block size for the key
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
            AES.KeySize = 128;
            AES.BlockSize = 128;

            //convert key and plain text input into byte arrays
			System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
			byte[] keyAndIvBytes = encoding.GetBytes(encryptionPassword);
			byte[] inputBytes = encoding.GetBytes(inputText);

            //create streams and encryptor object
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, AES.CreateEncryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Write);

            //perform encryption
            cryptoStream.Write(inputBytes, 0, inputBytes.Length);
            cryptoStream.FlushFinalBlock();

            //get encrypted stream into byte array
            outBytes = memoryStream.ToArray();

            //close streams
            memoryStream.Close();
            cryptoStream.Close();
            AES.Clear();

            return outBytes;
        }

        /// <summary>
        /// Decrypts input string from Rijndael (AES) algorithm with CBC blocking and PKCS7 padding.
        /// </summary>
        /// <param name="inputBytes">Encrypted binary array to decrypt</param>
        /// <returns>string of Decrypted data</returns>
        /// <remarks>The key and IV are the same, and use SagePaySettings.EncryptionPassword.</remarks>
        private static string aesDecrypt(byte[] inputBytes, string encryptionPassword)
        {

            RijndaelManaged AES = new RijndaelManaged();
			System.Text.Encoding encoding = System.Text.Encoding.GetEncoding("iso-8859-1");
			byte[] keyAndIvBytes = encoding.GetBytes(encryptionPassword);
			byte[] outputBytes = new byte[inputBytes.Length + 1];

            //set the mode, padding and block size
            AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CBC;
            AES.KeySize = 128;
            AES.BlockSize = 128;

            //create streams and decryptor object
            dynamic memoryStream = new MemoryStream(inputBytes);
            dynamic cryptoStream = new CryptoStream(memoryStream, AES.CreateDecryptor(keyAndIvBytes, keyAndIvBytes), CryptoStreamMode.Read);

            //perform decryption
            cryptoStream.Read(outputBytes, 0, outputBytes.Length);

            //close streams
            memoryStream.Close();
            cryptoStream.Close();
            AES.Clear();

            //convert decryted data into string, assuming original text was UTF-8 encoded
			return encoding.GetString(outputBytes);

        }

        /// <summary>
        /// Converts a string of characters representing hexadecimal values into an array of bytes
        /// </summary>
        /// <param name="strInput">A hexadecimal string of characters to convert to binary.</param>
        /// <returns>A byte array</returns>
        public static byte[] hexStringToBytes(string strInput)
        {

            int numBytes = (strInput.Length / 2);
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x <= numBytes - 1; x++)
            {
                bytes[x] = System.Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;

        }

        /// <summary>
        /// Converts an array of bytes into a hexadecimal string representation.
        /// </summary>
        /// <param name="ba">Array of bytes to convert</param>
        /// <returns>String of hexadecimal values.</returns>
        public static string byteArrayToHexString(byte[] ba)
        {

            return BitConverter.ToString(ba).Replace("-", "");

        }
    }


}