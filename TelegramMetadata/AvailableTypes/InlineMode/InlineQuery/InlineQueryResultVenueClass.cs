////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a venue. By default, the venue will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the venue.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultVenueClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be venue
        /// </summary>
        [DataMember]
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 Bytes
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// Latitude of the venue location in degrees
        /// </summary>
        [DataMember]
        public float latitude;

        /// <summary>
        /// Longitude of the venue location in degrees
        /// </summary>
        [DataMember]
        public float longitude;

        /// <summary>
        /// Title of the venue
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// Address of the venue
        /// </summary>
        [DataMember]
        public string address;

        /// <summary>
        /// Optional.Foursquare identifier of the venue if known
        /// </summary>
        [DataMember]
        public string foursquare_id;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the venue
        /// </summary>
        [DataMember]
        public InputMessageContentClass input_message_content;

        /// <summary>
        /// Optional. Url of the thumbnail for the result
        /// </summary>
        [DataMember]
        public string thumb_url;

        /// <summary>
        /// Optional.Thumbnail width
        /// </summary>
        [DataMember]
        public int thumb_width;

        /// <summary>
        /// Optional.Thumbnail height
        /// </summary>
        [DataMember]
        public int thumb_height;
    }
}
