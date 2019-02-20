////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents a Telegram user or bot.
    /// </summary>
    [DataContract]
    public class UserClass : SerialiserJSON
    {
        /// <summary>
        /// Unique identifier for this user or bot
        /// </summary>
        [DataMember]
        public long id;

        /// <summary>
        /// True, if this user is a bot
        /// </summary>
        [DataMember]
        public bool is_bot;

        /// <summary>
        /// User‘s or bot’s first name
        /// </summary>
        [DataMember]
        public string first_name;

        /// <summary>
        /// Optional. User‘s or bot’s last name
        /// </summary>
        [DataMember]
        public string last_name;

        /// <summary>
        /// Optional. User‘s or bot’s username
        /// </summary>
        [DataMember]
        public string username;

        /// <summary>
        /// Optional. IETF (https://en.wikipedia.org/wiki/IETF_language_tag) language tag of the user's language
        /// </summary>
        [DataMember]
        public string language_code;
    }
}
