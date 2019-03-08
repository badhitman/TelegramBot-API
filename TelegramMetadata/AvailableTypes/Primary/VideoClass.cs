////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents a video file.
    /// </summary>
    [DataContract]
    public class VideoClass
    {
        /// <summary>
        ///  Unique identifier for this file
        /// </summary>
        [DataMember]
        public string file_id;

        /// <summary>
        /// Video width as defined by sender
        /// </summary>
        [DataMember]
        public int width;

        /// <summary>
        /// Video height as defined by sender
        /// </summary>
        [DataMember]
        public int height;

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
        /// Optional. Mime type of a file as defined by sender
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
