////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents a point on the map.
    /// </summary>
    [DataContract]
    public class LocationClass
    {
        /// <summary>
        /// Longitude as defined by sender
        /// </summary>
        [DataMember]
        public float longitude;

        /// <summary>
        /// Float Latitude as defined by sender
        /// </summary>
        [DataMember]
        public float latitude;

        public override string ToString()
        {
            return latitude.ToString().Replace(",",".") + ", " + longitude.ToString().Replace(",", ".");
        }
    }
}
