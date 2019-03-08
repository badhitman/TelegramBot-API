////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;
using TelegramBot.TelegramMetadata.Games;

namespace TelegramBot.TelegramMetadata.AvailableTypes
{
    /// <summary>
    /// This object represents one button of an inline keyboard. You must use exactly one of the optional fields.
    /// </summary>
    [DataContract]
    public class InlineKeyboardButtonClass
    {
        /// <summary>
        /// Label text on the button
        /// </summary>
        [DataMember]
        public string text;

        /// <summary>
        /// Optional.HTTP url to be opened when button is pressed
        /// </summary>
        [DataMember]
        public string url;

        /// <summary>
        /// Optional. Data to be sent in a callback query (https://core.telegram.org/bots/api#callbackquery) to the bot when button is pressed, 1-64 bytes
        /// </summary>
        [DataMember]
        public string callback_data;

        /// <summary>
        /// Optional. If set, pressing the button will prompt the user to select one of their chats, open that chat and insert the bot‘s username and the specified inline query in the input field. Can be empty, in which case just the bot’s username will be inserted.
        /// Note: This offers an easy way for users to start using your bot in inline mode (https://core.telegram.org/bots/inline) when they are currently in a private chat with it. Especially useful when combined with switch_pm (https://core.telegram.org/bots/api#answerinlinequery) actions – in this case the user will be automatically returned to the chat they switched from, skipping the chat selection screen.
        /// </summary>
        [DataMember]
        public string switch_inline_query;

        /// <summary>
        /// Optional. If set, pressing the button will insert the bot‘s username and the specified inline query in the current chat's input field. Can be empty, in which case only the bot’s username will be inserted.
        /// This offers a quick way for the user to open your bot in inline mode in the same chat – good for selecting something from multiple options.
        /// </summary>
        [DataMember]
        public string switch_inline_query_current_chat;

        /// <summary>
        /// Optional. Description of the game that will be launched when the user presses the button.
        /// NOTE: This type of button must always be the first button in the first row.
        /// </summary>
        [DataMember]
        public CallbackGameClass callback_game;

        /// <summary>
        /// Optional. Specify True, to send a Pay button (https://core.telegram.org/bots/api#payments).
        /// NOTE: This type of button must always be the first button in the first row.
        /// </summary>
        [DataMember]
        public bool pay;
    }
}