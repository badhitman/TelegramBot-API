////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents the content of a venue message to be sent as the result of an inline query.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InputVenueMessageContentClass: InputMessageContentClass
    {
        /// <summary>
        /// Latitude of the venue in degrees
        /// </summary>
        [DataMember]
        public float latitude;

        /// <summary>
        /// Longitude of the venue in degrees
        /// </summary>
        [DataMember]
        public float longitude;

        /// <summary>
        /// Name of the venue
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// Address of the venue
        /// </summary>
        [DataMember]
        public string address;

        /// <summary>
        /// Optional.Foursquare identifier of the venue, if known
        /// </summary>
        [DataMember]
        public string foursquare_id;
    }
}
