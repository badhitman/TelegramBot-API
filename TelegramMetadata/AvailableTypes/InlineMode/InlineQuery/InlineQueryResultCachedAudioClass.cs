////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to an mp3 audio file stored on the Telegram servers. By default, this audio file will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultCachedAudioClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be audio
        /// </summary>
        [DataMember]
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        [DataMember]
        public string id;

        /// <summary>
        /// A valid file identifier for the audio file
        /// </summary>
        [DataMember]
        public string audio_file_id;

        /// <summary>
        /// Optional.Caption, 0-200 characters
        /// </summary>
        [DataMember]
        public string caption;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
        [DataMember]
        public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the audio
        /// </summary>
        [DataMember]
        public InputMessageContentClass input_message_content;
    }
}
