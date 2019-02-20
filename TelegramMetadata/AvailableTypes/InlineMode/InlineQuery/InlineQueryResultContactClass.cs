////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a contact with a phone number. By default, this contact will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the contact.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultContactClass : InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be contact
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 Bytes
        /// </summary>
        public string id;

        /// <summary>
        /// Contact's phone number
        /// </summary>
        public string phone_number;

        /// <summary>
        /// Contact's first name
        /// </summary>
        public string first_name;

        /// <summary>
        /// Optional.Contact's last name
        /// </summary>
        public string last_name;

        /// <summary>
        /// Optional.Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the contact
        /// </summary>
       public InputMessageContentClass input_message_content;

        /// <summary>
        /// Optional.Url of the thumbnail for the result
        /// </summary>
        public string thumb_url;

        /// <summary>
        /// Optional.Thumbnail width
        /// </summary>
        public int thumb_width;

        /// <summary>
        /// Optional.Thumbnail height
        /// </summary>
        public int thumb_height;
    }
}
