////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents a venue.
    /// </summary>
    [DataContract]
    public class VenueClass
    {
        /// <summary>
        /// Venue location
        /// </summary>
        [DataMember]
        public LocationClass location;

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
        /// Optional.Foursquare identifier of the venue
        /// </summary>
        [DataMember]
        public string foursquare_id;
    }
}
