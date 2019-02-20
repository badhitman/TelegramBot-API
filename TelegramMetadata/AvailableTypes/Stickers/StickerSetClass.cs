////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.Stickers
{
    /// <summary>
    /// This object represents a sticker set.
    /// </summary>
    [DataContract]
    public class StickerSetClass
    {
        /// <summary>
        /// Sticker set name
        /// </summary>
        [DataMember]
        public string name;

        /// <summary>
        /// Sticker set title
        /// </summary>
        [DataMember]
        public string title;

        /// <summary>
        /// True, if the sticker set contains masks
        /// </summary>
        [DataMember]
        public bool contains_masks;

        /// <summary>
        /// List of all set stickers
        /// </summary>
        [DataMember]
        public StickerClass[] stickers;
    }
}
