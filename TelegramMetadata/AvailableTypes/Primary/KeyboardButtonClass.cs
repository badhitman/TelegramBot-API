﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents one button of the reply keyboard. For simple text buttons String can be used instead of this object to specify text of the button. Optional fields are mutually exclusive.
    /// Note: request_contact and request_location options will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class KeyboardButtonClass
    {
        /// <summary>
        /// Text of the button.If none of the optional fields are used, it will be sent as a message when the button is pressed
        /// </summary>
        [DataMember]
        public string text;

        /// <summary>
        /// Optional. If True, the user's phone number will be sent as a contact when the button is pressed. Available in private chats only
        /// </summary>
        [DataMember]
        public bool request_contact;

        /// <summary>
        /// Optional.If True, the user's current location will be sent when the button is pressed. Available in private chats only
        /// </summary>
        [DataMember]
        public bool request_location;
    }
}
