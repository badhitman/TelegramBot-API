////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents a voice note.
    /// </summary>
    [DataContract]
    public class VoiceClass
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [DataMember]
        public string file_id;

        /// <summary>
        /// Duration of the audio in seconds as defined by sender
        /// </summary>
        [DataMember]
        public int duration;

        /// <summary>
        /// Optional.MIME type of the file as defined by sender
        /// </summary>
        [DataMember]
        public string mime_type;

        /// <summary>
        /// Optional. File size
        /// </summary>
        [DataMember]
        public int file_size;
    }
}
