////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.Methods.Metadata
{
    /// <summary>
    /// Use this method to send information about a venue. On success, the sent Message is returned.
    /// </summary>
    [DataContract]
    public class sendVenueJSON : _AbstractMethodsManager
    {
        /// <summary>
        /// Integer or String 	Yes 	Unique identifier for the target chat or username of the target channel (in the format @channelusername)
        /// </summary>
        [DataMember]
        public string chat_id;

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
        /// String 	Yes 	Name of the venue
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// String 	Yes 	Address of the venue
        /// </summary>
        [DataMember]
        public string address;

        /// <summary>
        /// String 	Optional 	Foursquare identifier of the venue
        /// </summary>
        [DataMember]
        public string foursquare_id;

        /// <summary>
        /// String 	Optional 	Foursquare type of the venue, if known. (For example, “arts_entertainment/default”, “arts_entertainment/aquarium” or “food/icecream”.)
        /// </summary>
        [DataMember]
        public string foursquare_type;

        /// <summary>
        /// Optional 	Sends the message silently. Users will receive a notification with no sound.
        /// </summary>
        [DataMember]
        public bool disable_notification;

        /// <summary>
        /// Optional 	If the message is a reply, ID of the original message
        /// </summary>
        [DataMember]
        public long reply_to_message_id;

        /// <summary>
        /// InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply 	Optional 	
        /// Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard,
        /// instructions to remove reply keyboard or to force a reply from the user.
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;
    }
}
