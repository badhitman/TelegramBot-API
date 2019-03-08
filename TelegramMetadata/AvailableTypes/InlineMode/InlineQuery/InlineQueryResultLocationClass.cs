////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a location on a map. By default, the location will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the location.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultLocationClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be location
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 Bytes
        /// </summary>
        public string id;

        /// <summary>
        /// Location latitude in degrees
        /// </summary>
        public float latitude;

        /// <summary>
        /// Location longitude in degrees
        /// </summary>
        public float longitude;

        /// <summary>
        /// Location title
        /// </summary>
        public string title;

        /// <summary>
        /// Optional.Period in seconds for which the location can be updated, should be between 60 and 86400.
        /// </summary>
        public int live_period;

        /// <summary>
        /// Optional.Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the location
        /// </summary>
       public InputMessageContentClass input_message_content;

        /// <summary>
        /// Optional. Url of the thumbnail for the result
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
