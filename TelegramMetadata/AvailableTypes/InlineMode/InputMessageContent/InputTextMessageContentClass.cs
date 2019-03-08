////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents the content of a text message to be sent as the result of an inline query.
    /// 
    /// </summary>
    [DataContract]
    public class InputTextMessageContentClass: InputMessageContentClass
    {
        /// <summary>
        /// Text of the message to be sent, 1-4096 characters
        /// </summary>
        [DataMember]
        public string message_text;

        /// <summary>
        /// Optional.Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message.
        /// </summary>
        [DataMember]
        public string parse_mode;

        /// <summary>
        /// Optional.Disables link previews for links in the sent message
        /// </summary>
        [DataMember]
        public bool disable_web_page_preview;
    }
}
