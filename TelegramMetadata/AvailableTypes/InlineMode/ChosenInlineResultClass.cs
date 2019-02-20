////////////////////////////////////////////////
// © https://github.com/badhitman - Telegram @fakegov 
////////////////////////////////////////////////
using System.Runtime.Serialization;

namespace TelegramBot.TelegramMetadata.AvailableTypes.InlineMode
{
    /// <summary>
    /// Represents a result of an inline query that was chosen by the user and sent to their chat partner.
    /// Note: It is necessary to enable inline feedback via @Botfather in order to receive these objects in updates.
    /// </summary>
    [DataContract]
    public class ChosenInlineResultClass
    {
        /// <summary>
        /// The unique identifier for the result that was chosen
        /// </summary>
        public string result_id;

        /// <summary>
        /// The user that chose the result
        /// </summary>
        public UserClass from;

        /// <summary>
        /// Optional.Sender location, only for bots that require user location
        /// </summary>
        public LocationClass location;

        /// <summary>
        /// Optional. Identifier of the sent inline message. Available only if there is an inline keyboard attached to the message.Will be also received in callback queries and can be used to edit the message.
        /// </summary>
        public string inline_message_id;

        /// <summary>
        /// The query that was used to obtain the result
        /// </summary>
        public string query;
    }
}
