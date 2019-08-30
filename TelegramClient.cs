////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using SimpleWebClient;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Web;
using TelegramBot.TelegramMetadata.AvailableTypes;
using TelegramBot.TelegramMetadata.AvailableTypes.InlineMode;
using TelegramBot.TelegramMetadata.AvailableTypes.Primary;
using TelegramBot.TelegramMetadata.AvailableTypes.Stickers;
using TelegramBot.TelegramMetadata.GettingUpdates;
using TelegramBot.TelegramMetadata.Methods.Metadata;
using TelegramBot.TelegramMetadata.MethodsMetadata.Metadata;
using static TelegramBot.TelegramMetadata.AvailableTypes.MessageClass;

namespace TelegramBot.TelegramMetadata
{
    /// <summary>
    /// Типы данных сообщения
    /// </summary>
    public enum TelegramDataTypes
    {
        /// <summary>
        /// Признак того что к сообщению прикреплена локация
        /// </summary>
        Location,

        /// <summary>
        /// Признак того что в сообщении есть локация
        /// </summary>
        LocationText,

        /// <summary>
        /// Признак того что к сообщению прикреплено фото
        /// </summary>
        Photo,

        /// <summary>
        /// Признак того что к сообщению прикреплено видео
        /// </summary>
        Video,

        /// <summary>
        /// Признак того что к сообщению прикреплено аудио
        /// </summary>
        Audio,

        /// <summary>
        /// Признак того что к сообщению прикреплен документ
        /// </summary>
        Document,

        /// <summary>
        /// Признак того что у сообщения назначено описание медиа-данных
        /// </summary>
        Caption,

        /// <summary>
        /// Признак того что в сообщении есть текст
        /// </summary>
        Text,

        /// <summary>
        /// Признак того данное сообщение-уведомление говорит о том что в групу добавлен новый учасник
        /// </summary>
        NewChatMembers
    }

    /// <summary>
    /// Все методы в Bot API нечувствительны к регистру. Мы поддерживаем методы HTTP GET и POST.
    /// Для передачи параметров в запросах Bot API используйте URL запросы (https://en.wikipedia.org/wiki/Query_string)
    /// или application/json или application/x-www-form-urlencoded или multipart/form-data
    /// При успешном вызове возвращается JSON-объект, содержащий результат.
    /// 
    /// Authorizing your bot
    /// 
    /// Each bot is given a unique authentication token when it is created.The token looks something like 123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11, but we'll use simply <token> in this document instead. You can learn about obtaining tokens and generating new ones in this document.
    /// Making requests
    /// 
    /// All queries to the Telegram Bot API must be served over HTTPS and need to be presented in this form: https://api.telegram.org/bot<token>/METHOD_NAME. Like this for example:
    /// 
    /// https://api.telegram.org/bot123456:ABC-DEF1234ghIkl-zyx57W2v1u123ew11/getMe
    /// 
    /// We support GET and POST HTTP methods.We support four ways of passing parameters in Bot API requests:
    /// 
    /// URL query string
    /// application/x-www-form-urlencoded
    /// application/json (except for uploading files)
    /// multipart/form-data (use to upload files)
    /// 
    /// The response contains a JSON object, which always has a Boolean field ‘ok’ and may have an optional String field ‘description’ with a human-readable description of the result. If ‘ok’ equals true, the request was successful and the result of the query can be found in the ‘result’ field. In case of an unsuccessful request, ‘ok’ equals false and the error is explained in the ‘description’. An Integer ‘error_code’ field is also returned, but its contents are subject to change in the future. Some errors may also have an optional field ‘parameters’ of the type ResponseParameters, which can help to automatically handle the error.
    /// 
    /// All methods in the Bot API are case-insensitive.
    /// All queries must be made using UTF-8.
    /// </summary>
    public class TelegramClient
    {
        public enum LogMode { Info, Ok, Err, Alert, Trace };

        public delegate void onLogReceivedEvent(string msg, LogMode lm);
        public event onLogReceivedEvent onLogEvent;

        private string http_response_raw = "";
        public long offset;

        public string HttpRrequestStatus => MyWebClient.HttpRrequestStatus;

        public UserClass Me;
        private string apiUrl { get { return "https://api.telegram.org/bot" + api_bot_token; } }
        private string apiFileUrl { get { return "https://api.telegram.org/file/bot" + api_bot_token + "/"; } }
        private string api_bot_token;

        public TelegramClient(string _api_bot_token)
        {
            api_bot_token = _api_bot_token;
            Me = getMe();
        }

        internal void onLogReceivedCall(string msg_txt, LogMode lm)
        {
            if (onLogEvent != null)
                onLogEvent(msg_txt, lm);
        }

        private void SendRequest(string api_bot_method_name, NameValueCollection request_param, InputFileClass file_post)
        {
            http_response_raw = "";
            if (request_param != null && !string.IsNullOrEmpty(request_param["captiom"]) && string.IsNullOrWhiteSpace(request_param["parse_mode"]))
                request_param["captiom"] = HttpUtility.UrlEncode(request_param["captiom"]);

            http_response_raw = MyWebClient.SendRequest(apiUrl + "/" + api_bot_method_name, HttpMethod.Post, request_param, new List<PostedFile>() { new PostedFile() { Data = file_post.Data, FieldName = file_post.FieldName, FileName = file_post.FileName } }, MyWebClient.RequestContentTypes.MultipartFormData);

        }

        private void SendRequest(string api_bot_method_name, NameValueCollection request_param)
        {
            http_response_raw = "";
            if (request_param != null && !string.IsNullOrEmpty(request_param["text"]) && string.IsNullOrWhiteSpace(request_param["parse_mode"]))
                request_param["text"] = HttpUtility.UrlEncode(request_param["text"]);

            http_response_raw = MyWebClient.SendRequest(apiUrl + "/" + api_bot_method_name, HttpMethod.Post, request_param, null, MyWebClient.RequestContentTypes.ApplicationXWwwFormUrlencoded);
        }

        /// <summary>
        /// Скачать файл из облака Telegram
        /// </summary>
        /// <param name="t_file">Файл для загрузки</param>
        /// <returns>байты данных</returns>
        public byte[] DownloadTelegramFile(FileClass t_file)
        {
            onLogReceivedCall("Попытка загрузки файла: id[" + t_file.file_id + "] path[" + t_file.file_path + "]", LogMode.Trace);
            byte[] t_bytes_data = new byte[0];
            using (WebClient wc = new WebClient())
            {
                try
                {
                    t_bytes_data = wc.DownloadData(apiFileUrl + t_file.file_path);
                    onLogReceivedCall("OK. Файл загружен", LogMode.Ok);
                }
                catch (WebException we)
                {
                    onLogReceivedCall("Ошибка загрузкий файла: " + we.Message, LogMode.Err);
                }
            }
            return t_bytes_data;
        }

        /// <summary>
        /// Получить входящие обновления в бот
        /// </summary>
        /// <param name="_limit">Димит на получение данных</param>
        /// <returns></returns>
        public Update[] getUpdates(int _limit = 10)
        {
            getUpdatesJSON updates_filter = new getUpdatesJSON()
            {
                offset = offset + 1,
                limit = _limit,
                allowed_updates = new string[0]
            };

            SendRequest(nameof(getUpdates), updates_filter.GetFiealds(new string[0]));
            if (string.IsNullOrEmpty(http_response_raw))
                return new Update[0];

            if (string.IsNullOrEmpty(http_response_raw))
                return new Update[0];

            getUpdatesJSON.Result result = (getUpdatesJSON.Result)SerialiserJSON.ReadObject(typeof(getUpdatesJSON.Result), http_response_raw);
            return result.result;
        }

        #region basic

        /// <summary>
        /// A simple method for testing your bot's auth token. Requires no parameters.
        /// </summary>
        /// <returns>Returns basic information about the bot in form of a User (https://core.telegram.org/bots/api#user) object.</returns>
        public UserClass getMe()
        {
            SendRequest(nameof(getMe), null);
            if (string.IsNullOrEmpty(http_response_raw))
                return null;
            getMeJSON.Result result = (getMeJSON.Result)SerialiserJSON.ReadObject(typeof(getMeJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to send text messages.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="text">Optional	Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message.</param>
        /// <param name="parse_mode">Send Markdown (https://core.telegram.org/bots/api#markdown-style) or HTML (https://core.telegram.org/bots/api#html-style), if you want Telegram apps to show bold, italic, fixed-width text or inline URLs (https://core.telegram.org/bots/api#formatting-options) in your bot's message.
        /// Formatting options
        /// The Bot API supports basic formatting for messages. You can use bold and italic text, as well as inline links and pre-formatted code in your bots' messages. Telegram clients will render them accordingly. You can use either markdown-style or HTML-style formatting.
        /// 
        /// Note that Telegram clients will display an alert to the user before opening an inline link (‘Open this link?’ together with the full URL).
        /// 
        /// Links 'tg://user?id=<user_id>' can be used to mention a user by their id without using a username. Please note:
        /// 
        /// These links will work only if they are used inside an inline link.
        /// These mentions are only guaranteed to work if the user has contacted the bot in the past or is a member in the group where he was mentioned.
        /// Markdown style
        /// To use this mode, pass Markdown in the parse_mode field when using sendMessage. Use the following syntax in your message:
        /// 
        /// *bold text*
        /// _italic text_
        /// [inline URL](http://www.example.com/)
        /// [inline mention of a user](tg://user?id=123456789)
        /// `inline fixed-width code`
        /// ```block_language
        /// pre-formatted fixed-width code block
        /// ```
        /// HTML style
        /// To use this mode, pass HTML in the parse_mode field when using sendMessage. The following tags are currently supported:
        /// 
        /// <b>bold</b>, <strong>bold</strong>
        /// <i>italic</i>, <em>italic</em>
        /// <a href="http://www.example.com/">inline URL</a>
        /// <a href="tg://user?id=123456789">inline mention of a user</a>
        /// <code>inline fixed-width code</code>
        /// <pre>pre-formatted fixed-width code block</pre>
        /// Please note:
        /// 
        /// Only the tags mentioned above are currently supported.
        /// Tags must not be nested.
        /// All <, > and & symbols that are not a part of a tag or an HTML entity must be replaced with the corresponding HTML entities (< with &lt;, > with &gt; and & with &amp;).
        /// All numerical HTML entities are supported.
        /// The API currently supports only the following named HTML entities: &lt;, &gt;, &amp; and &quot;.
        /// </param>
        /// <param name="disable_web_page_preview">Optional	Disables link previews for links in this message</param>
        /// <param name="disable_notification">Optional	Sends the message silently (https://telegram.org/blog/channels-2-0#silent-messages). Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">Optional	If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply [Optional] Additional interface options. A JSON-serialized object for an inline keyboard (https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating), custom reply keyboard (https://core.telegram.org/bots#keyboards), instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message (https://core.telegram.org/bots/api#message) is returned.</returns>
        public MessageClass sendMessage(string chat_id, string text, ParseModes? parse_mode = null, bool disable_web_page_preview = false, bool disable_notification = false, long reply_to_message_id = 0, object reply_markup = null)
        {
            sendMessageJSON send_msg_json = new sendMessageJSON()
            {
                chat_id = chat_id,
                text = text
            };

            List<string> skip_fields = new List<string>();

            if (parse_mode is null)
                skip_fields.Add("parse_mode");
            else
                send_msg_json.parse_mode = parse_mode.ToString();

            if (!disable_notification)
                skip_fields.Add("disable_notification");

            if (reply_to_message_id == 0)
                skip_fields.Add("reply_to_message_id");
            else
                send_msg_json.reply_to_message_id = reply_to_message_id;

            if (reply_markup == null)
                skip_fields.Add("reply_markup");

            SendRequest(nameof(sendMessage), send_msg_json.GetFiealds(skip_fields.ToArray()));

            if (string.IsNullOrEmpty(http_response_raw))
                return null;
            sendMessageJSON.Result result = (sendMessageJSON.Result)SerialiserJSON.ReadObject(typeof(sendMessageJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to forward messages of any kind.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="from_chat_id">Unique identifier for the chat where the original message was sent (or channel username in the format @channelusername)</param>
        /// <param name="message_id">Message identifier in the chat specified in from_chat_id</param>
        /// <param name="disable_notification">Sends the message silently (https://telegram.org/blog/channels-2-0#silent-messages). Users will receive a notification with no sound.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass forwardMessage(string chat_id, string from_chat_id, long message_id, bool disable_notification = false)
        {
            forwardMessageJSON forward_msg_json = new forwardMessageJSON()
            {
                chat_id = chat_id,
                from_chat_id = from_chat_id,
                message_id = message_id
            };
            List<string> skip_fields = new List<string>();
            if (!disable_notification)
                skip_fields.Add("disable_notification");

            SendRequest(nameof(forwardMessage), forward_msg_json.GetFiealds(skip_fields.ToArray()));
            if (string.IsNullOrEmpty(http_response_raw))
                return null;
            forwardMessageJSON.Result result = (forwardMessageJSON.Result)SerialiserJSON.ReadObject(typeof(forwardMessageJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to send general files. On success, the sent Message is returned. Bots can currently send files of any type of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="document">File to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data. More info on Sending Files »</param>
        /// <param name="thumb">InputFile or String 	Optional 	Thumbnail of the file sent; can be ignored if thumbnail generation for the file is supported server-side. The thumbnail should be in JPEG format and less than 200 kB in size. A thumbnail‘s width and height should not exceed 320. Ignored if the file is not uploaded using multipart/form-data. Thumbnails can’t be reused and can be only uploaded as a new file, so you can pass “attach://<file_attach_name>” if the thumbnail was uploaded using multipart/form-data under <file_attach_name>. More info on Sending Files »</param>
        /// <param name="caption">Document caption (may also be used when resending documents by file_id), 0-200 characters</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply [Optional] Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned</returns>
        public MessageClass sendDocument(string chat_id, object document, string caption = null, object thumb = null, ParseModes? parse_mode = null, bool disable_notification = false, long reply_to_message_id = 0, object reply_markup = null)
        {
            sendDocumentJSON send_document_json = new sendDocumentJSON()
            {
                chat_id = chat_id
            };

            List<string> skip_fields = new List<string>() { "document", "thumb" };

            if (string.IsNullOrEmpty(caption))
                skip_fields.Add("caption");

            if (parse_mode is null)
                skip_fields.Add("parse_mode");
            else
                send_document_json.parse_mode = parse_mode.ToString();

            if (!disable_notification)
                skip_fields.Add("disable_notification");

            if (reply_to_message_id == 0)
                skip_fields.Add("reply_to_message_id");
            else
                send_document_json.reply_to_message_id = reply_to_message_id.ToString();

            if (reply_markup == null)
                skip_fields.Add("reply_markup");

            if (document is string || document is int)
            {
                SendRequest(nameof(sendDocument), send_document_json.GetFiealds(skip_fields.ToArray()));
                if (string.IsNullOrEmpty(http_response_raw))
                    return null;
            }
            else if (document is InputFileClass)
            {
                skip_fields.Add("document");
                SendRequest(nameof(sendDocument), send_document_json.GetFiealds(skip_fields.ToArray()), (InputFileClass)document);
                if (string.IsNullOrEmpty(http_response_raw))
                    return null;
            }
            sendDocumentJSON.Result result = (sendDocumentJSON.Result)SerialiserJSON.ReadObject(typeof(sendDocumentJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to send photos
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="photo">Photo to send. Pass a file_id as String to send a photo that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a photo from the Internet, or upload a new photo using multipart/form-data. More info on Sending Files » https://core.telegram.org/bots/api#sending-files </param>
        /// <param name="caption">Photo caption (may also be used when resending photos by file_id), 0-200 characters</param>
        /// <param name="disable_notification">Sends the message silently (https://telegram.org/blog/channels-2-0#silent-messages). Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply [Optional] Additional interface options. A JSON-serialized object for an inline keyboard (https://core.telegram.org/bots#inline-keyboards-and-on-the-fly-updating), custom reply keyboard (https://core.telegram.org/bots#keyboards), instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendPhoto(string chat_id, object photo, string caption = null, ParseModes? parse_mode = null, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            sendPhotoJSON send_photo_json = new sendPhotoJSON()
            {
                chat_id = chat_id
            };

            List<string> skip_fields = new List<string>();

            if (string.IsNullOrEmpty(caption))
                skip_fields.Add("caption");
            else
                send_photo_json.caption = caption;

            if (parse_mode is null)
                skip_fields.Add("parse_mode");
            else
                send_photo_json.parse_mode = parse_mode.ToString();

            if (!disable_notification)
                skip_fields.Add("disable_notification");

            if (reply_to_message_id == 0)
                skip_fields.Add("reply_to_message_id");
            else
                send_photo_json.reply_to_message_id = reply_to_message_id.ToString();

            if (reply_markup == null)
                skip_fields.Add("reply_markup");


            if (photo is string || photo is int)
            {
                SendRequest(nameof(sendPhoto), send_photo_json.GetFiealds(skip_fields.ToArray()));
                if (string.IsNullOrEmpty(http_response_raw))
                    return null;
            }
            else if (photo is InputFileClass)
            {
                skip_fields.Add("photo");
                SendRequest(nameof(sendPhoto), send_photo_json.GetFiealds(skip_fields.ToArray()), (InputFileClass)photo);
                if (string.IsNullOrEmpty(http_response_raw))
                    return null;
            }
            sendPhotoJSON.Result result = (sendPhotoJSON.Result)SerialiserJSON.ReadObject(typeof(sendPhotoJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to send a group of photos or videos as an album. 
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="media">A JSON-serialized array describing photos and videos to be sent, must include 2–10 items</param>
        /// <param name="disable_notification">Sends the messages silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the messages are a reply, ID of the original message</param>
        /// <returns>On success, an array of the sent Messages is returned.</returns>
        public MessageClass[] sendMediaGroup(string chat_id, object[] media, bool disable_notification = false, long reply_to_message_id = -1)
        {
            //sendMediaGroupJSON send_media_group_json = new sendMediaGroupJSON()
            //{
            //    chat_id = chat_id
            //};

            //List<string> skip_fields = new List<string>();
            //if (!disable_notification)
            //    skip_fields.Add("disable_notification");

            //if (reply_to_message_id == 0)
            //    skip_fields.Add("reply_to_message_id");
            //else
            //    send_media_group_json.reply_to_message_id = reply_to_message_id.ToString();

            //if (media is string[])
            //{

            //}
            //else if (media is InputFileClass[])
            //{
            //    skip_fields.Add("media");
            //    SendRequest(nameof(sendPhoto), send_media_group_json.GetFiealds(skip_fields.ToArray()), media as InputFileClass[]);
            //    if (string.IsNullOrEmpty(http_response_raw))
            //        return null;
            //}

            return null;
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display them in the music player. Your audio must be in the .mp3 format. Bots can currently send audio files of up to 50 MB in size, this limit may be changed in the future.
        /// For sending voice messages, use the sendVoice (https://core.telegram.org/bots/api#sendvoice) method instead.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="audio">InputFile or String	Yes	Audio file to send. Pass a file_id as String to send an audio file that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get an audio file from the Internet, or upload a new one using multipart/form-data. More info on Sending Files » https://core.telegram.org/bots/api#sending-files </param>
        /// <param name="caption">Audio caption, 0-200 characters</param>
        /// <param name="duration">Duration of the audio in seconds</param>
        /// <param name="performer">Performer</param>
        /// <param name="title">Track name</param>
        /// <param name="disable_notification">Sends the message silently (https://telegram.org/blog/channels-2-0#silent-messages). Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">reply_markup	InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply [Optional] Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendAudio(string chat_id, object audio, string caption = null, long duration = -1, string performer = null, string title = null, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {

            return null;
        }

        /// <summary>
        /// Use this method to send video files, Telegram clients support mp4 videos (other formats may be sent as Document). Bots can currently send video files of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="video">InputFile or String	Yes	Video to send. Pass a file_id as String to send a video that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a video from the Internet, or upload a new video using multipart/form-data. More info on Sending Files »</param>
        /// <param name="duration">Duration of sent video in seconds</param>
        /// <param name="width">Video width</param>
        /// <param name="height">Video height</param>
        /// <param name="caption">Video caption (may also be used when resending videos by file_id), 0-200 characters</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply	Optional	Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendVideo(string chat_id, object video, long duration = -1, int width = -1, int height = -1, string caption = null, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            return null;
        }

        /// <summary>
        /// Use this method to send audio files, if you want Telegram clients to display the file as a playable voice message. For this to work, your audio must be in an .ogg file encoded with OPUS (other formats may be sent as Audio or Document). Bots can currently send voice messages of up to 50 MB in size, this limit may be changed in the future.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="voice">InputFile or String	Yes	Audio file to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data. More info on Sending Files »</param>
        /// <param name="caption">Voice message caption, 0-200 characters</param>
        /// <param name="duration">Duration of the voice message in seconds</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply	Optional	Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendVoice(string chat_id, object voice, string caption = null, long duration = -1, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            return null;
        }

        /// <summary>
        /// As of v.4.0, Telegram clients support rounded square mp4 videos of up to 1 minute long. Use this method to send video messages.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="video_note">InputFile or String	Yes	Video note to send. Pass a file_id as String to send a video note that exists on the Telegram servers (recommended) or upload a new video using multipart/form-data. More info on Sending Files ». Sending video notes by a URL is currently unsupported</param>
        /// <param name="duration">Duration of sent video in seconds</param>
        /// <param name="length">Video width and height</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply	Optional	Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendVideoNote(string chat_id, object video_note, long duration = -1, long length = -1, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            return null;
        }

        /// <summary>
        /// Use this method to send point on the map.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="latitude">Latitude of the location</param>
        /// <param name="longitude">Longitude of the location</param>
        /// <param name="live_period">Period in seconds for which the location will be updated (see Live Locations, should be between 60 and 86400.</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply	Optional	Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendLocation(long chat_id, double latitude, double longitude, int live_period = -1, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            sendLocationJSON send_location_json = new sendLocationJSON()
            {
                chat_id = chat_id,
                latitude = latitude,
                longitude = longitude
            };

            List<string> skip_fields = new List<string>();

            if (live_period <= 0)
                skip_fields.Add("live_period");

            if (!disable_notification)
                skip_fields.Add("disable_notification");

            if (reply_to_message_id <= 0)
                skip_fields.Add("reply_to_message_id");

            if (reply_markup == null)
                skip_fields.Add("reply_markup");

            SendRequest(nameof(sendLocation), send_location_json.GetFiealds(skip_fields.ToArray()));
            if (string.IsNullOrEmpty(http_response_raw.Trim()))
                return null;
            sendMessageJSON.Result result = (sendMessageJSON.Result)SerialiserJSON.ReadObject(typeof(sendMessageJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to edit live location messages sent by the bot or via the bot (for inline bots https://core.telegram.org/bots/api#inline-mode). A location can be edited until its live_period expires or editing is explicitly disabled by a call to stopMessageLiveLocation (https://core.telegram.org/bots/api#stopmessagelivelocation).
        /// </summary>
        /// <param name="latitude">Latitude of new location</param>
        /// <param name="longitude">Longitude of new location</param>
        /// <param name="chat_id">Required if inline_message_id is not specified. Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="message_id">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="InlineKeyboardMarkup">A JSON-serialized object for a new inline keyboard.</param>
        /// <returns>On success, if the edited message was sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
        public object editMessageLiveLocation(float latitude, float longitude, string chat_id = null, long message_id = -1, string inline_message_id = null, InlineKeyboardMarkupClass InlineKeyboardMarkup = null)
        {
            return null;
        }

        /// <summary>
        /// Use this method to stop updating a live location message sent by the bot or via the bot (for inline bots) before live_period expires.
        /// </summary>
        /// <param name="chat_id">Required if inline_message_id is not specified. Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="message_id">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="reply_markup">A JSON-serialized object for a new inline keyboard.</param>
        /// <returns>On success, if the message was sent by the bot, the sent Message is returned, otherwise True is returned.</returns>
        public object stopMessageLiveLocation(string chat_id = null, long message_id = -1, string inline_message_id = null, InlineKeyboardMarkupClass reply_markup = null)
        {
            return null;
        }

        /// <summary>
        /// Use this method to send information about a venue.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="latitude">Latitude of the venue</param>
        /// <param name="longitude">Longitude of the venue</param>
        /// <param name="title">Name of the venue</param>
        /// <param name="address">Address of the venue</param>
        /// <param name="foursquare_id">Foursquare identifier of the venue</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply	Optional	Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendVenue(string chat_id, double latitude, double longitude, string title, string address, string foursquare_id = null, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            sendVenueJSON send_venue_json = new sendVenueJSON()
            {
                chat_id = chat_id,
                latitude = latitude,
                longitude = longitude,
                address = "adress test venue",
                foursquare_id = "Уникальнео имя места",
                foursquare_type = "Тип места",
                title = title
            };
            List<string> skip_fields = new List<string>();

            if (string.IsNullOrEmpty(foursquare_id))
                skip_fields.Add("foursquare_id");

            if (!disable_notification)
                skip_fields.Add("disable_notification");

            if (reply_to_message_id <= 0)
                skip_fields.Add("reply_to_message_id");

            if (reply_markup == null)
                skip_fields.Add("reply_markup");


            SendRequest(nameof(sendVenue), send_venue_json.GetFiealds(skip_fields.ToArray()));
            if (string.IsNullOrEmpty(http_response_raw))
                return null;
            sendMessageJSON.Result result = (sendMessageJSON.Result)SerialiserJSON.ReadObject(typeof(sendMessageJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to send phone contacts.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="phone_number">Contact's phone number</param>
        /// <param name="first_name">Contact's first name</param>
        /// <param name="last_name">Contact's last name</param>
        /// <param name="disable_notification">Sends the message silently. Users will receive a notification with no sound.</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply	Optional	Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendContact(string chat_id, string phone_number, string first_name, string last_name = null, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {
            return null;
        }

        /// <summary>
        /// Use this method when you need to tell the user that something is happening on the bot's side. The status is set for 5 seconds or less (when a message arrives from your bot, Telegram clients clear its typing status). 
        /// Example: The @ImageBot needs some time to process a request and upload the image. Instead of sending a text message along the lines of “Retrieving image, please wait…”, the bot may use sendChatAction with action = upload_photo. The user will see a “sending photo” status for the bot.
        /// We only recommend using this method when a response from the bot will take a noticeable amount of time to arrive.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="action">Type of action to broadcast. Choose one, depending on what the user is about to receive: typing for text messages, upload_photo for photos, record_video or upload_video for videos, record_audio or upload_audio for audio files, upload_document for general files, find_location for location data, record_video_note or upload_video_note for video notes.</param>
        /// <returns>Returns True on success.</returns>
        public bool sendChatAction(string chat_id, string action)
        {
            return false;
        }

        /// <summary>
        /// Use this method to get a list of profile pictures for a user. Returns a UserProfilePhotos object.
        /// </summary>
        /// <param name="user_id">Unique identifier of the target user</param>
        /// <param name="offset">Sequential number of the first photo to be returned. By default, all photos are returned.</param>
        /// <param name="limit">Limits the number of photos to be retrieved. Values between 1—100 are accepted. Defaults to 100.</param>
        /// <returns></returns>
        public UserProfilePhotosClass getUserProfilePhotos(long user_id, long offset = -1, long limit = -1)
        {
            return null;
        }

        /// <summary>
        /// Use this method to get basic info about a file and prepare it for downloading. For the moment, bots can download files of up to 20MB in size. The file can then be downloaded via the link https://api.telegram.org/file/bot<token>/<file_path>, where <file_path> is taken from the response. It is guaranteed that the link will be valid for at least 1 hour. When the link expires, a new one can be requested by calling getFile again.
        /// Note: This function may not preserve the original file name and MIME type. You should save the file's MIME type and name (if available) when the File object is received.
        /// </summary>
        /// <param name="file_id">File identifier to get info about</param>
        /// <returns>On success, a File object is returned.</returns>
        public FileClass getFile(string file_id)
        {
            getFileJSON get_file_json = new getFileJSON() { file_id = file_id };
            SendRequest(nameof(getFile), get_file_json.GetFiealds(new string[0]));
            if (string.IsNullOrEmpty(http_response_raw.Trim()))
                return null;
            getFileJSON.Result result = (getFileJSON.Result)SerialiserJSON.ReadObject(typeof(getFileJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to kick a user from a group, a supergroup or a channel. In the case of supergroups and channels, the user will not be able to return to the group on their own using invite links, etc., unless unbanned first. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Note: In regular groups (non-supergroups), this method will only work if the ‘All Members Are Admins’ setting is off in the target group. Otherwise members may only be removed by the group's creator or by the member that added them.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target group or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <param name="user_id">Unique identifier of the target user</param>
        /// <param name="until_date">Date when the user will be unbanned, unix time. If user is banned for more than 366 days or less than 30 seconds from the current time they are considered to be banned forever</param>
        /// <returns>Returns True on success.</returns>
        public bool kickChatMember(string chat_id, long user_id, long until_date = -1)
        {
            return false;
        }

        /// <summary>
        /// Use this method to unban a previously kicked user in a supergroup or channel. The user will not return to the group or channel automatically, but will be able to join via link, etc. The bot must be an administrator for this to work.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target group or username of the target supergroup or channel (in the format @username)</param>
        /// <param name="user_id">Unique identifier of the target user</param>
        /// <returns>Returns True on success.</returns>
        public bool unbanChatMember(string chat_id, long user_id)
        {
            return false;
        }

        /// <summary>
        /// Use this method to restrict a user in a supergroup. The bot must be an administrator in the supergroup for this to work and must have the appropriate admin rights. Pass True for all boolean parameters to lift restrictions from a user.
        /// </summary>
        /// <param name="chat_id">Yes	Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername)</param>
        /// <param name="user_id">Unique identifier of the target user</param>
        /// <param name="until_date">Date when restrictions will be lifted for the user, unix time. If user is restricted for more than 366 days or less than 30 seconds from the current time, they are considered to be restricted forever</param>
        /// <param name="can_send_messages">Pass True, if the user can send text messages, contacts, locations and venues</param>
        /// <param name="can_send_media_messages">Pass True, if the user can send audios, documents, photos, videos, video notes and voice notes, implies can_send_messages</param>
        /// <param name="can_send_other_messages">Pass True, if the user can send animations, games, stickers and use inline bots, implies can_send_media_messages</param>
        /// <param name="can_add_web_page_previews">Pass True, if the user may add web page previews to their messages, implies can_send_media_messages</param>
        /// <returns>Returns True on success.</returns>
        public bool restrictChatMember(string chat_id, long user_id, long until_date = -1, bool? can_send_messages = null, bool? can_send_media_messages = null, bool? can_send_other_messages = null, bool? can_add_web_page_previews = null)
        {
            return false;
        }

        /// <summary>
        /// Use this method to promote or demote a user in a supergroup or a channel. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Pass False for all boolean parameters to demote a user.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="user_id">Unique identifier of the target user</param>
        /// <param name="can_change_info">Pass True, if the administrator can change chat title, photo and other settings</param>
        /// <param name="can_post_messages">Pass True, if the administrator can create channel posts, channels only</param>
        /// <param name="can_edit_messages">Pass True, if the administrator can edit messages of other users and can pin messages, channels only</param>
        /// <param name="can_delete_messages">Pass True, if the administrator can delete messages of other users</param>
        /// <param name="can_invite_users">Pass True, if the administrator can invite new users to the chat</param>
        /// <param name="can_restrict_members">Pass True, if the administrator can restrict, ban or unban chat members</param>
        /// <param name="can_pin_messages">Pass True, if the administrator can pin messages, supergroups only</param>
        /// <param name="can_promote_members">Pass True, if the administrator can add new administrators with a subset of his own privileges or demote administrators that he has promoted, directly or indirectly (promoted by administrators that were appointed by him)</param>
        /// <returns>Returns True on success.</returns>
        public bool promoteChatMember(string chat_id, long user_id, bool? can_change_info = null, bool? can_post_messages = null, bool? can_edit_messages = null, bool? can_delete_messages = null, bool? can_invite_users = null, bool? can_restrict_members = null, bool? can_pin_messages = null, bool? can_promote_members = null)
        {

            return false;
        }

        /// <summary>
        /// Use this method to export an invite link to a supergroup or a channel. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <returns>Returns exported invite link as String on success.</returns>
        public Uri exportChatInviteLink(string chat_id)

        {

            return new Uri("http://localhost");
        }

        /// <summary>
        /// Use this method to set a new profile photo for the chat. Photos can't be changed for private chats. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="photo">New chat photo, uploaded using multipart/form-data</param>
        /// <returns>Returns True on success.</returns>
        public bool setChatPhoto(string chat_id, InputFileClass photo = null)
        {

            return false;
        }

        /// <summary>
        /// Use this method to delete a chat photo. Photos can't be changed for private chats. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Note: In regular groups (non-supergroups), this method will only work if the ‘All Members Are Admins’ setting is off in the target group.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <returns>Returns True on success.</returns>
        public bool deleteChatPhoto(string chat_id)
        {

            return false;
        }

        /// <summary>
        /// Use this method to change the title of a chat. Titles can't be changed for private chats. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// Note: In regular groups (non-supergroups), this method will only work if the ‘All Members Are Admins’ setting is off in the target group.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="title">New chat title, 1-255 characters</param>
        /// <returns>Returns True on success.</returns>
        public bool setChatTitle(string chat_id, string title)
        {

            return false;
        }

        /// <summary>
        /// Use this method to change the description of a supergroup or a channel. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="description">New chat description, 0-255 characters</param>
        /// <returns>Returns True on success.</returns>
        public bool setChatDescription(string chat_id, string description = null)
        {

            return false;
        }

        /// <summary>
        /// Use this method to pin a message in a supergroup or a channel. The bot must be an administrator in the chat for this to work and must have the ‘can_pin_messages’ admin right in the supergroup or ‘can_edit_messages’ admin right in the channel.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="message_id">Identifier of a message to pin</param>
        /// <param name="disable_notification">Pass True, if it is not necessary to send a notification to all chat members about the new pinned message. Notifications are always disabled in channels.</param>
        /// <returns>Returns True on success.</returns>
        public bool pinChatMessage(string chat_id, long message_id, bool disable_notification = false)
        {

            return false;
        }

        /// <summary>
        /// Use this method to unpin a message in a supergroup or a channel. The bot must be an administrator in the chat for this to work and must have the ‘can_pin_messages’ admin right in the supergroup or ‘can_edit_messages’ admin right in the channel.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <returns>Returns True on success.</returns>
        public bool unpinChatMessage(string chat_id)
        {

            return false;
        }

        /// <summary>
        /// Use this method for your bot to leave a group, supergroup or channel.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <returns>Returns True on success.</returns>
        public bool leaveChat(string chat_id)
        {

            return false;
        }

        /// <summary>
        /// Use this method to get up to date information about the chat (current name of the user for one-on-one conversations, current username of a user, group or channel, etc.).
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <returns>Returns a Chat object on success.</returns>
        public ChatClass getChat(string chat_id)
        {

            return null;
        }

        /// <summary>
        /// Use this method to get a list of administrators in a chat. If the chat is a group or a supergroup and no administrators were appointed, only the creator will be returned.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <returns>On success, returns an Array of ChatMember objects that contains information about all chat administrators except other bots.</returns>
        public ChatMemberClass[] getChatAdministrators(string chat_id)
        {
            getChatAdministratorsJSON get_chat_administrators_json = new getChatAdministratorsJSON() { chat_id = chat_id };
            SendRequest(nameof(getChatAdministrators), get_chat_administrators_json.GetFiealds(new string[0]));
            if (string.IsNullOrEmpty(http_response_raw.Trim()))
                return null;
            getChatAdministratorsJSON.Result result = (getChatAdministratorsJSON.Result)SerialiserJSON.ReadObject(typeof(getChatAdministratorsJSON.Result), http_response_raw);
            return result.result;
        }

        /// <summary>
        /// Use this method to get the number of members in a chat. 
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <returns>Returns Int on success.</returns>
        public int getChatMembersCount(string chat_id)
        {

            return -1;
        }

        /// <summary>
        /// Use this method to get information about a member of a chat.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup or channel (in the format @channelusername)</param>
        /// <param name="user_id">Unique identifier of the target user</param>
        /// <returns>Returns a ChatMember object on success.</returns>
        public ChatMemberClass getChatMember(string chat_id, long user_id)
        {

            return null;
        }

        /// <summary>
        /// Use this method to set a new group sticker set for a supergroup. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Use the field can_set_sticker_set optionally returned in getChat requests to check if the bot can use this method.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername)</param>
        /// <param name="sticker_set_name">Name of the sticker set to be set as the group sticker set</param>
        /// <returns>Returns True on success.</returns>
        public bool setChatStickerSet(string chat_id, string sticker_set_name)
        {

            return false;
        }

        /// <summary>
        /// Use this method to delete a group sticker set from a supergroup. The bot must be an administrator in the chat for this to work and must have the appropriate admin rights. Use the field can_set_sticker_set optionally returned in getChat requests to check if the bot can use this method.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target supergroup (in the format @supergroupusername)</param>
        /// <returns>Returns True on success.</returns>
        public bool deleteChatStickerSet(string chat_id)
        {

            return false;
        }

        /// <summary>
        /// Use this method to send answers to callback queries sent from inline keyboards. The answer will be displayed to the user as a notification at the top of the chat screen or as an alert.
        /// Alternatively, the user can be redirected to the specified Game URL. For this option to work, you must first create a game for your bot via @Botfather and accept the terms. Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.
        /// </summary>
        /// <param name="callback_query_id">Unique identifier for the query to be answered</param>
        /// <param name="text">Text of the notification. If not specified, nothing will be shown to the user, 0-200 characters</param>
        /// <param name="show_alert">If true, an alert will be shown by the client instead of a notification at the top of the chat screen. Defaults to false.</param>
        /// <param name="url">URL that will be opened by the user's client. If you have created a Game and accepted the conditions via @Botfather, specify the URL that opens your game – note that this will only work if the query comes from a callback_game button. Otherwise, you may use links like t.me/your_bot?start=XXXX that open your bot with a parameter.</param>
        /// <param name="cache_time">The maximum amount of time in seconds that the result of the callback query may be cached client-side. Telegram apps will support caching starting in version 3.14. Defaults to 0.</param>
        /// <returns>On success, True is returned.</returns>
        public bool answerCallbackQuery(string callback_query_id, string text = null, bool show_alert = false, string url = null, int cache_time = 0)
        {

            return false;
        }

        #endregion

        #region Stickers

        /// <summary>
        /// Use this method to send .webp stickers.
        /// </summary>
        /// <param name="chat_id">Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="sticker">InputFile or String. </param>
        /// <param name="disable_notification">Sticker to send. Pass a file_id as String to send a file that exists on the Telegram servers (recommended), pass an HTTP URL as a String for Telegram to get a .webp file from the Internet, or upload a new one using multipart/form-data. More info on Sending Files »</param>
        /// <param name="reply_to_message_id">If the message is a reply, ID of the original message</param>
        /// <param name="reply_markup">InlineKeyboardMarkup or ReplyKeyboardMarkup or ReplyKeyboardRemove or ForceReply [Optional] Additional interface options. A JSON-serialized object for an inline keyboard, custom reply keyboard, instructions to remove reply keyboard or to force a reply from the user.</param>
        /// <returns>On success, the sent Message is returned.</returns>
        public MessageClass sendSticker(string chat_id, object sticker, bool disable_notification = false, long reply_to_message_id = -1, object reply_markup = null)
        {

            return null;
        }

        /// <summary>
        /// Use this method to get a sticker set.
        /// </summary>
        /// <param name="name">Name of the sticker set</param>
        /// <returns>On success, a StickerSet object is returned.</returns>
        public StickerSetClass getStickerSet(string name)
        {

            return null;
        }

        /// <summary>
        /// Use this method to upload a .png file with a sticker for later use in createNewStickerSet and addStickerToSet methods (can be used multiple times).
        /// </summary>
        /// <param name="user_id">User identifier of sticker file owner</param>
        /// <param name="png_sticker">Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px. More info on Sending Files »</param>
        /// <returns>Returns the uploaded File on success.</returns>
        public FileClass uploadStickerFile(long user_id, InputFileClass png_sticker)
        {

            return null;
        }

        /// <summary>
        /// Use this method to create new sticker set owned by a user. The bot will be able to edit the created sticker set.
        /// </summary>
        /// <param name="user_id">User identifier of created sticker set owner</param>
        /// <param name="name">Short name of sticker set, to be used in t.me/addstickers/ URLs (e.g., animals). Can contain only english letters, digits and underscores. Must begin with a letter, can't contain consecutive underscores and must end in “_by_<bot username>”. <bot_username> is case insensitive. 1-64 characters.</param>
        /// <param name="title">Sticker set title, 1-64 characters</param>
        /// <param name="png_sticker">Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px. Pass a file_id as a String to send a file that already exists on the Telegram servers, pass an HTTP URL as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data. More info on Sending Files »</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker</param>
        /// <param name="contains_masks">Pass True, if a set of mask stickers should be created</param>
        /// <param name="mask_position">A JSON-serialized object for position where the mask should be placed on faces</param>
        /// <returns>Returns True on success.</returns>
        public bool createNewStickerSet(long user_id, string name, string title, object png_sticker, string emojis, bool contains_masks = false, MaskPositionClass mask_position = null)
        {

            return false;
        }

        /// <summary>
        /// Use this method to add a new sticker to a set created by the bot.
        /// </summary>
        /// <param name="user_id">User identifier of sticker set owner</param>
        /// <param name="name">Sticker set name</param>
        /// <param name="png_sticker">Png image with the sticker, must be up to 512 kilobytes in size, dimensions must not exceed 512px, and either width or height must be exactly 512px. Pass a file_id as a String to send a file that already exists on the Telegram servers, pass an HTTP URL as a String for Telegram to get a file from the Internet, or upload a new one using multipart/form-data. More info on Sending Files »</param>
        /// <param name="emojis">One or more emoji corresponding to the sticker</param>
        /// <param name="mask_position">A JSON-serialized object for position where the mask should be placed on faces</param>
        /// <returns>Returns True on success.</returns>
        public bool addStickerToSet(long user_id, string name, object png_sticker, string emojis, MaskPositionClass mask_position = null)
        {

            return false;
        }

        /// <summary>
        /// Use this method to move a sticker in a set created by the bot to a specific position.
        /// </summary>
        /// <param name="sticker">File identifier of the sticker</param>
        /// <param name="position">New sticker position in the set, zero-based</param>
        /// <returns>Returns True on success.</returns>
        public bool setStickerPositionInSet(string sticker, long position)
        {

            return false;
        }

        #endregion

        #region Inline mode

        /// <summary>
        /// Use this method to send answers to an inline query.
        /// No more than 50 results per query are allowed.
        /// </summary>
        /// <param name="inline_query_id">Unique identifier for the answered query</param>
        /// <param name="results">A JSON-serialized array of results for the inline query</param>
        /// <param name="cache_time">The maximum amount of time in seconds that the result of the inline query may be cached on the server. Defaults to 300.</param>
        /// <param name="is_personal">Pass True, if results may be cached on the server side only for the user that sent the query. By default, results may be returned to any user who sends the same query</param>
        /// <param name="next_offset">Pass the offset that a client should send in the next query with the same text to receive more results. Pass an empty string if there are no more results or if you don‘t support pagination. Offset length can’t exceed 64 bytes.</param>
        /// <param name="switch_pm_text">If passed, clients will display a button with specified text that switches the user to a private chat with the bot and sends the bot a start message with the parameter switch_pm_parameter</param>
        /// <param name="switch_pm_parameter">Deep-linking parameter for the /start message sent to the bot when user presses the switch button. 1-64 characters, only A-Z, a-z, 0-9, _ and - are allowed. Example: An inline bot that sends YouTube videos can ask the user to connect the bot to their YouTube account to adapt search results accordingly. To do this, it displays a ‘Connect your YouTube account’ button above the results, or even before showing any. The user presses the button, switches to a private chat with the bot and, in doing so, passes a start parameter that instructs the bot to return an oauth link. Once done, the bot can offer a switch_inline button so that the user can easily return to the chat where they wanted to use the bot's inline capabilities.</param>
        /// <returns>On success, True is returned.</returns>
        public bool answerInlineQuery(string inline_query_id, InlineQueryResultClass[] results, int cache_time = -1, bool? is_personal = null, string next_offset = null, string switch_pm_text = null, string switch_pm_parameter = null)
        {

            return false;
        }

        #endregion

        #region Payments

        #endregion

        #region Edit messages
        /// <summary>
        /// Use this method to edit text and game messages sent by the bot or via the bot (for inline bots).
        /// </summary>
        /// <param name="text">New text of the message</param>
        /// <param name="chat_id">Required if inline_message_id is not specified. Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="message_id">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="parse_mode">Send Markdown or HTML, if you want Telegram apps to show bold, italic, fixed-width text or inline URLs in your bot's message.</param>
        /// <param name="disable_web_page_preview">Disables link previews for links in this message</param>
        /// <param name="reply_markup">A JSON-serialized object for an inline keyboard.</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
        public object editMessageText(string text, string chat_id = null, long message_id = -1, string inline_message_id = null, string parse_mode = null, bool disable_web_page_preview = false, InlineKeyboardMarkupClass reply_markup = null)
        {

            return null;
        }

        /// <summary>
        /// Use this method to edit captions of messages sent by the bot or via the bot (for inline bots).
        /// </summary>
        /// <param name="chat_id">Required if inline_message_id is not specified. Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="message_id">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="caption">New caption of the message</param>
        /// <param name="reply_markup">A JSON-serialized object for an inline keyboard.</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
        public object editMessageCaption(string chat_id = null, string message_id = null, string inline_message_id = null, string caption = null, InlineKeyboardMarkupClass reply_markup = null)
        {

            return null;
        }

        /// <summary>
        /// Use this method to edit only the reply markup of messages sent by the bot or via the bot (for inline bots).
        /// </summary>
        /// <param name="chat_id">Required if inline_message_id is not specified. Unique identifier for the target chat or username of the target channel (in the format @channelusername)</param>
        /// <param name="message_id">Required if inline_message_id is not specified. Identifier of the sent message</param>
        /// <param name="inline_message_id">Required if chat_id and message_id are not specified. Identifier of the inline message</param>
        /// <param name="reply_markup">A JSON-serialized object for an inline keyboard.</param>
        /// <returns>On success, if edited message is sent by the bot, the edited Message is returned, otherwise True is returned.</returns>
        public object editMessageReplyMarkup(string chat_id = null, string message_id = null, string inline_message_id = null, InlineKeyboardMarkupClass reply_markup = null)
        {

            return null;
        }

        /// <summary>
        /// Use this method to delete a message, including service messages, with the following limitations:
        /// - A message can only be deleted if it was sent less than 48 hours ago.
        /// - Bots can delete outgoing messages in groups and supergroups.
        /// - Bots granted can_post_messages permissions can delete outgoing messages in channels.
        /// - If the bot is an administrator of a group, it can delete any message there.
        /// - If the bot has can_delete_messages permission in a supergroup or a channel, it can delete any message there.
        /// </summary>
        /// <param name="chat_id"></param>
        /// <param name="message_id"></param>
        /// <returns>Returns True on success.</returns>
        public bool deleteMessage(string chat_id, string message_id)
        {
            deleteMessageJSON forward_msg_json = new deleteMessageJSON()
            {
                chat_id = chat_id,
                message_id = message_id
            };
            SendRequest(nameof(deleteMessage), forward_msg_json.GetFiealds(new string[0]));
            if (string.IsNullOrEmpty(http_response_raw))
                return false;

            deleteMessageJSON.Result result = (deleteMessageJSON.Result)SerialiserJSON.ReadObject(typeof(deleteMessageJSON.Result), http_response_raw);
            return result.result;
        }
        #endregion
    }
}
