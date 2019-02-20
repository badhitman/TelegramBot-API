////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents the content of a contact message to be sent as the result of an inline query.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InputContactMessageContentClass: InputMessageContentClass
    {
        /// <summary>
        /// Contact's phone number
        /// </summary>
        [DataMember]
        public string phone_number;

        /// <summary>
        /// Contact's first name
        /// </summary>
        [DataMember]
        public string first_name;

        /// <summary>
        /// Optional.Contact's last name
        /// </summary>
        [DataMember]
        public string last_name;
    }
}
