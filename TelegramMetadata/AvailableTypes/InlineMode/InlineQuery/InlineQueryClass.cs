////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// This object represents an incoming inline query. When the user sends an empty query, your bot could return some default or trending results.
    /// </summary>
    [DataContract]
    public class InlineQueryClass
    {
        /// <summary>
        /// Unique identifier for this query
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// Sender
        /// </summary>
        [DataMember]
        public UserClass from;

        /// <summary>
        /// Optional.Sender location, only for bots that request user location
        /// </summary>
        [DataMember]
        public LocationClass location;

        /// <summary>
        /// Text of the query(up to 512 characters)
        /// </summary>
        [DataMember]
        public string query;

        /// <summary>
        /// Offset of the results to be returned, can be controlled by the bot
        /// </summary>
        [DataMember]
        public string offset;
    }
}
