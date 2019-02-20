////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.Primary
{
    /// <summary>
    /// This object represents an inline keyboard (https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating) that appears right next to the message it belongs to.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will display unsupported message.
    /// </summary>
    [DataContract]
    public class InlineKeyboardMarkupClass
    {
        [DataMember]
        public InlineKeyboardButtonClass[] inline_keyboard;
    }
}
