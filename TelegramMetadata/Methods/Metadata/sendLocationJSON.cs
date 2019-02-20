////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.Methods.Metadata
{
    /// <summary>
    /// Use this method to send point on the map. On success, the sent Message is returned.
    /// </summary>
    [DataContract]
    class sendLocationJSON : _AbstractMethodsManager
    {
        /// <summary>
        /// Integer or String 	Yes 	Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [DataMember]
        public long chat_id;

        /// <summary>
        /// Float number 	Yes 	Latitude of the venue
        /// </summary>
        [DataMember]
        public double latitude;

        /// <summary>
        /// Float number 	Yes 	Longitude of the venue
        /// </summary>
        [DataMember]
        public double longitude;

        /// <summary>
        /// Integer 	Optional 	Period in seconds for which the location will be updated (see Live Locations, should be between 60 and 86400.
        /// </summary>
        [DataMember]
        public int live_period;
        /// <summary>
        /// Optional    Sends the message silently.Users will receive a notification with no sound.
        /// </summary>
        [DataMember]
        public bool disable_notification;

        /// <summary>
        /// Optional    If the message is a reply, ID of the original message
        /// </summary>
        [DataMember]
        public long reply_to_message_id;

        /// <summary>
        /// InlineKeyboardMarkupClass or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply
        /// Optional    Additional interface options. A JSON-serialized object for an inline keyboard, 
        /// custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;
    }
}
