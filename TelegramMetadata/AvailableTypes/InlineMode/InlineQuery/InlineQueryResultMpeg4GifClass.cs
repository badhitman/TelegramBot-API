////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a video animation (H.264/MPEG-4 AVC video without sound). By default, this animated MPEG-4 file will be sent by the user with optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the animation.
    /// </summary>
    [DataContract]
    public class InlineQueryResultMpeg4GifClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be mpeg4_gif
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string id;

        /// <summary>
        /// A valid URL for the MP4 file.File size must not exceed 1MB
        /// </summary>
        public string mpeg4_url;

        /// <summary>
        /// Optional.Video width
        /// </summary>
        public int mpeg4_width;

        /// <summary>
        /// Optional. Video height
        /// </summary>
        public int mpeg4_height;

        /// <summary>
        /// Optional.Video duration
        /// </summary>
        public int mpeg4_duration;

        /// <summary>
        /// URL of the static thumbnail(jpeg or gif) for the result
        /// </summary>
        public string thumb_url;

        /// <summary>
        /// Optional.Title for the result
        /// </summary>
        public string title;

        /// <summary>
        /// Optional.Caption of the MPEG-4 file to be sent, 0-200 characters
        /// </summary>
        public string caption;

        /// <summary>
        /// Optional.Inline keyboard attached to the message
        /// </summary>
        public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional. Content of the message to be sent instead of the video animation
        /// </summary>
        public InputMessageContentClass input_message_content;
    }
}
