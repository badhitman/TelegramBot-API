////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents a video message (https://telegram.org/blog/video-messages-and-telescope) (available in Telegram apps as of v.4.0).
    /// </summary>
    [DataContract]
    public class VideoNoteClass
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [DataMember]
        public string file_id;

        /// <summary>
        /// Video width and height as defined by sender
        /// </summary>
        [DataMember]
        public int length;

        /// <summary>
        /// Duration of the video in seconds as defined by sender
        /// </summary>
            [DataMember]
        public int duration;

        /// <summary>
        /// Optional.Video thumbnail
        /// </summary>
        [DataMember]
        public PhotoSizeClass thumb;

        /// <summary>
        /// Optional. File size
        /// </summary>
        [DataMember]
        public int file_size;
    }
}
