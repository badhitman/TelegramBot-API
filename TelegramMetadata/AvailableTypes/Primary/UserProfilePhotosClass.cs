////////////////////////////////////////////////
// © https://github.com/badhitman 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represent a user's profile pictures.
    /// </summary>
    [DataContract]
    public class UserProfilePhotosClass
    {
        /// <summary>
        /// Total number of profile pictures the target user has
        /// </summary>
        [DataMember]
        public int total_count;

        /// <summary>
        /// Requested profile pictures(in up to 4 sizes each)
        /// </summary>
        [DataMember]
        public PhotoSizeClass[][] photos;
    }
}
