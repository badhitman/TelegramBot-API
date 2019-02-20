////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a voice message stored on the Telegram servers. By default, this voice message will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the voice message.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultCachedVoiceClass : InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be voice
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string id;

        /// <summary>
        /// A valid file identifier for the voice message
        /// </summary>
        public string voice_file_id;

        /// <summary>
        /// Voice message title
        /// </summary>
        public string title;

        /// <summary>
        /// Optional.Caption, 0-200 characters
        /// </summary>
        public string caption;

        /// <summary>
        /// Optional.Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional. Content of the message to be sent instead of the voice message
        /// </summary>
       public InputMessageContentClass input_message_content;
    }
}
