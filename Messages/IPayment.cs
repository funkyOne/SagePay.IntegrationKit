using System;
using System.Text;
using SagePay.IntegrationKit;

namespace SagePay.IntegrationKit.Messages
{
    public interface IPayment : IMessage
    {
         ProtocolVersion VpsProtocol { get; set; }
         TransactionType TransactionType { get; set; }

         string Vendor { get; set; }
         string VendorTxCode { get; set; }

         decimal Amount { get; set; }
         string Currency { get; set; }
         string Description { get; set; }
         string CustomerEmail { get; set; }

         string BillingSurname { get; set; }
         string BillingFirstnames { get; set; }
         string BillingAddress1 { get; set; }
         string BillingAddress2 { get; set; }
         string BillingCity { get; set; }
         string BillingPostCode { get; set; }
         string BillingCountry { get; set; }
         string BillingState { get; set; }
         string BillingPhone { get; set; }

         string DeliveryFirstnames { get; set; }
         string DeliverySurname { get; set; }
         string DeliveryAddress1 { get; set; }
         string DeliveryAddress2 { get; set; }
         string DeliveryCity { get; set; }
         string DeliveryPostCode { get; set; }
         string DeliveryCountry { get; set; }
         string DeliveryState { get; set; }

         string DeliveryPhone { get; set; }
         string Basket { get; set; }
         int ApplyAvsCv2 { get; set; }
         int Apply3dSecure { get; set; }
         string BillingAgreement { get; set; }
         string ReferrerId { get; set; }

         [SagePayProtocolVersion(ProtocolVersion.V_300)]
         int CreateToken { get; set; }

         [SagePayProtocolVersion(ProtocolVersion.V_300)]
         string VendorData { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
	    string BasketXml{ get; set;}
	
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string CustomerXml { get; set; }
	
        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string SurchargeXml { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string FiRecipientAccountNumber { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string FiRecipientDateOfBirth { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string FiRecipientPostCode { get; set; }

        [SagePayProtocolVersion(ProtocolVersion.V_300)]
        string FiRecipientSurname { get; set; }

    }
}
