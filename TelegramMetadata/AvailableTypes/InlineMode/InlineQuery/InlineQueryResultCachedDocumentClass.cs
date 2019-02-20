////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a file stored on the Telegram servers. By default, this file will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the file.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultCachedDocumentClass : InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be document
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string id;

        /// <summary>
        /// Title for the result
        /// </summary>
        public string title;

        /// <summary>
        /// A valid file identifier for the file
        /// </summary>
        public string document_file_id;

        /// <summary>
        /// Optional.Short description of the result
        /// </summary>
        public string description;

        /// <summary>
        /// Optional.Caption of the document to be sent, 0-200 characters
        /// </summary>
        public string caption;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the file
        /// </summary>
       public InputMessageContentClass input_message_content;
    }
}
