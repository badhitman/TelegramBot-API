////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to an article or web page.
    /// </summary>
    [DataContract]
    public class InlineQueryResultArticleClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be article
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 Bytes
        /// </summary>
        public string id;

        /// <summary>
        /// Title of the result
        /// </summary>
        public string title;

        /// <summary>
        /// Content of the message to be sent
        /// </summary>
       public InputMessageContentClass input_message_content;

        /// <summary>
        /// Optional.Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.URL of the result
        /// </summary>
        public string url;

        /// <summary>
        /// Optional.Pass True, if you don't want the URL to be shown in the message
        /// </summary>
       public bool hide_url;

        /// <summary>
        /// Optional.Short description of the result
        /// </summary>
        public string description;

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
