////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a photo stored on the Telegram servers. By default, this photo will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the photo.
    /// </summary>
    [DataContract]
    public class InlineQueryResultCachedPhotoClass : InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be photo
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string id;

        /// <summary>
        /// A valid file identifier of the photo
        /// </summary>
        public string photo_file_id;

        /// <summary>
        /// Optional.Title for the result
        /// </summary>
        public string title;

        /// <summary>
        /// Optional.Short description of the result
        /// </summary>
        public string description;

        /// <summary>
        /// Optional.Caption of the photo to be sent, 0-200 characters
        /// </summary>
        public string caption;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the photo
        /// </summary>
       public InputMessageContentClass input_message_content;
    }
}
