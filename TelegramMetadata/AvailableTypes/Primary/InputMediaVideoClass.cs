////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// Represents a video to be sent.
    /// </summary>
    [DataContract]
    public class InputMediaVideoClass: InputMediaPhotoClass
    {
        /// <summary>
        /// Optional.Video width
        /// </summary>
        [DataMember]
        public int width;

        /// <summary>
        /// Optional.Video height
        /// </summary>
        [DataMember]
        public int height;

        /// <summary>
        /// Optional.Video duration
        /// </summary>
        [DataMember]
        public int duration;
    }
}
