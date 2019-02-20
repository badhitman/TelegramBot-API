////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to an animated GIF file. By default, this animated GIF file will be sent by the user with optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the animation.
    /// </summary>
    [DataContract]
    public class InlineQueryResultGifClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be gif
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string id;

        /// <summary>
        /// A valid URL for the GIF file.File size must not exceed 1MB
        /// </summary>
        public string gif_url;

        /// <summary>
        /// Optional.Width of the GIF
        /// </summary>
        public int gif_width;

        /// <summary>
        /// Optional. Height of the GIF
        /// </summary>
        public int gif_height;

        /// <summary>
        /// Optional.Duration of the GIF
        /// </summary>
        public int gif_duration;

        /// <summary>
        /// URL of the static thumbnail for the result(jpeg or gif)
        /// </summary>
        public string thumb_url;

        /// <summary>
        /// Optional.Title for the result
        /// </summary>
        public string title;

        /// <summary>
        /// Optional.Caption of the GIF file to be sent, 0-200 characters
        /// </summary>
        public string caption;

        /// <summary>
        /// Optional.Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional. Content of the message to be sent instead of the GIF animation
        /// </summary>
       public InputMessageContentClass input_message_content;
    }
}
