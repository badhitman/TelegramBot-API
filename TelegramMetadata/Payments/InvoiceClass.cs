////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.Payments
{
    /// <summary>
    /// This object contains basic information about an invoice.
    /// </summary>
    [DataContract]
    public class InvoiceClass
    {
        /// <summary>
        ///  Product name
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// Product description
        /// </summary>
        [DataMember]
        public string description;

        /// <summary>
        /// Unique bot deep-linking parameter that can be used to generate this invoice
        /// </summary>
        [DataMember]
        public string start_parameter;

        /// <summary>
        /// Three-letter ISO 4217 currency code (https://core.telegram.org/bots/payments#supported-currencies)
        /// </summary>
        [DataMember]
        public string currency;

        /// <summary>
        /// Total price in the smallest units of the currency(integer, not float/double). For example, for a price of US$ 1.45 pass amount = 145.See the exp parameter in currencies.json (https://core.telegram.org/bots/payments/currencies.json), it shows the number of digits past the decimal point for each currency(2 for the majority of currencies).
        /// </summary>
        [DataMember]
        public int total_amount;
    }
}
