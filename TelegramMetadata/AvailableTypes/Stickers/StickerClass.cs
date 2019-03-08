////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.Stickers
{
    /// <summary>
    /// This object represents a sticker.
    /// </summary>
    [DataContract]
    public class StickerClass
    {
        /// <summary>
        /// Unique identifier for this file
        /// </summary>
        [DataMember]
        public string file_id;

        /// <summary>
        /// Sticker width
        /// </summary>
        [DataMember]
        public int width;

        /// <summary>
        /// Sticker height
        /// </summary>
        [DataMember]
        public int height;

        /// <summary>
        /// Optional.Sticker thumbnail in the.webp or.jpg format
        /// </summary>
        [DataMember]
        public PhotoSizeClass thumb;

        /// <summary>
        /// Optional.Emoji associated with the sticker
        /// </summary>
        [DataMember]
        public string emoji;

        /// <summary>
        /// Optional.Name of the sticker set to which the sticker belongs
        /// </summary>
        [DataMember]
        public string set_name;

        /// <summary>
        /// Optional.For mask stickers, the position where the mask should be placed
        /// </summary>
        [DataMember]
        public MaskPositionClass mask_position;

        /// <summary>
        /// Optional.File size
        /// </summary>
        [DataMember]
        public long file_size;
    }
}
