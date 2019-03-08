////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a page containing an embedded video player or a video file. By default, this video file will be sent by the user with an optional caption. Alternatively, you can use input_message_content to send a message with the specified content instead of the video.
    /// If an InlineQueryResultVideo message contains an embedded video (e.g., YouTube), you must replace its content using input_message_content.
    /// </summary>
    [DataContract]
    public class InlineQueryResultVideoClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be video
        /// </summary>
        [DataMember]
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// A valid URL for the embedded video player or video file
        /// </summary>
        [DataMember]
        public string video_url;

        /// <summary>
        /// Mime type of the content of video url, “text/html” or “video/mp4”
        /// </summary>
        [DataMember]
        public string mime_type;

        /// <summary>
        /// URL of the thumbnail(jpeg only) for the video
        /// </summary>
        [DataMember]
        public string thumb_url;

        /// <summary>
        /// Title for the result
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// Optional.Caption of the video to be sent, 0-200 characters
        /// </summary>
        [DataMember]
        public string caption;

        /// <summary>
        /// Optional.Video width
        /// </summary>
        [DataMember]
        public int video_width;

        /// <summary>
        /// Optional. Video height
        /// </summary>
        [DataMember]
        public int video_height;

        /// <summary>
        /// Optional.Video duration in seconds
        /// </summary>
        [DataMember]
        public int video_duration;

        /// <summary>
        /// Optional. Short description of the result
        /// </summary>
        [DataMember]
        public string description;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the video.This field is required if InlineQueryResultVideo is used to send an HTML-page as a result (e.g., a YouTube video).
        /// </summary>
        [DataMember]
        public InputMessageContentClass input_message_content;
    }
}
