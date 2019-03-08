////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to a voice recording in an .ogg container encoded with OPUS. By default, this voice recording will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the the voice message.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultVoiceClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be voice
        /// </summary>
        [DataMember]
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// A valid URL for the voice recording
        /// </summary>
        [DataMember]
        public string voice_url;

        /// <summary>
        /// Recording title
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// Optional.Caption, 0-200 characters
        /// </summary>
        [DataMember]
        public string caption;

        /// <summary>
        /// Optional. Recording duration in seconds
        /// </summary>
        [DataMember]
        public int voice_duration;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the voice recording
        /// </summary>
        [DataMember]
        public InputMessageContentClass input_message_content;
    }
}
