////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a link to an mp3 audio file. By default, this audio file will be sent by the user. Alternatively, you can use input_message_content to send a message with the specified content instead of the audio.
    /// Note: This will only work in Telegram versions released after 9 April, 2016. Older clients will ignore them.
    /// </summary>
    [DataContract]
    public class InlineQueryResultAudioClass: InlineQueryResultClass
    {
        /// <summary>
        /// Type of the result, must be audio
        /// </summary>
        public string type;

        /// <summary>
        /// Unique identifier for this result, 1-64 bytes
        /// </summary>
        public string id;

        /// <summary>
        /// A valid URL for the audio file
        /// </summary>
        public string audio_url;

        /// <summary>
        /// Title
        /// </summary>
        public string title;

        /// <summary>
        /// Optional.Caption, 0-200 characters
        /// </summary>
        public string caption;

        /// <summary>
        /// Optional.Performer
        /// </summary>
        public string performer;

        /// <summary>
        /// Optional.Audio duration in seconds
        /// </summary>
       public int audio_duration;

        /// <summary>
        /// Optional. Inline keyboard attached to the message
        /// </summary>
       public InlineKeyboardMarkupClass reply_markup;

        /// <summary>
        /// Optional.Content of the message to be sent instead of the audio
        /// </summary>
       public InputMessageContentClass input_message_content;
    }
}
