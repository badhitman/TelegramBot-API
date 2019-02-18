////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a photo. By default, this photo will be sent by the user with optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the photo.
    /// </summary>
    [DataContract]
    public class InlineQueryResultPhotoClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be photo
        /// </summary>
        [DataMember]
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// A valid URL of the photo.Photo must be in jpeg format.Photo size must not exceed 5MB
        /// </summary>
        [DataMember]
        public string photo_url;

        /// <summary>
        /// URL of the thumbnail for the photo
        /// </summary>
        [DataMember]
        public string thumb_url;

        /// <summary>
        /// Optional.Width of the photo
        /// </summary>
        [DataMember]
        public int photo_width;

        /// <summary>
        /// Optional.Height of the photo
        /// </summary>
        [DataMember]
        public int photo_height;

        /// <summary>
        /// Optional.Title for the result
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// Optional.Short description of the result
        /// </summary>
        [DataMember]
        public string description;

        /// <summary>
        /// Optional. Caption of the photo to be sent, 0-200 characters
        /// </summary>
        [DataMember]
        public string caption;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the photo
        /// </summary>
        [DataMember]
        public InputMessageContentClass input_message_content;
    }
}
