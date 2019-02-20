////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents the content of a location message to be sent as the result of an inline query.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InputLocationMessageContentClass: InputMessageContentClass
    {
        /// <summary>
        /// Latitude of the location in degrees
        /// </summary>
        [DataMember]
        public float latitude;

        /// <summary>
        /// Longitude of the location in degrees
        /// </summary>
        [DataMember]
        public float longitude;

        /// <summary>
        /// Optional.Period in seconds for which the location can be updated, should be between 60 and 86400.
        /// </summary>
        [DataMember]
        public int live_period;
    }
}
