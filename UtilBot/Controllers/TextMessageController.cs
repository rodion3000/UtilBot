using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using UtilBot.Services;
using UtilBot.Functions;


namespace UtilBot.Controllers
{
    public class TextMessageController
    {
        private readonly IStorage _memoryStorage;
        private readonly ITelegramBotClient _telegramClient;
        private readonly FunctionExecuter _functionExecuter;

        public TextMessageController(ITelegramBotClient telegramBotClient, IStorage memoryStorage)
        {
            _telegramClient = telegramBotClient;
            _memoryStorage = memoryStorage;
            _functionExecuter = new FunctionExecuter(memoryStorage);

        }

        public async Task Handle(Message message, CancellationToken ct)
        {
            switch (message.Text)
            {
                case "/start":
                    var btns = CreateButtons();
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id,
                        $"{Environment.NewLine}Этот бот подсчитывает колличество символов в тексте и вычисляет суммы чисел. Выберите нужную вам функцию.{Environment.NewLine}", cancellationToken: ct, parseMode: ParseMode.Html, replyMarkup: new InlineKeyboardMarkup(btns));

                    break;
                default:
                    var returnedText = _functionExecuter.S(message);
                    await _telegramClient.SendTextMessageAsync(message.Chat.Id, returnedText, cancellationToken: ct);
                    break;
            }
        }

        private List<InlineKeyboardButton[]> CreateButtons()
        {
            var buttons = new List<InlineKeyboardButton[]>();
            buttons.Add(new[]
            {
                        InlineKeyboardButton.WithCallbackData($" Подсчитать колличество символов в тексте" , $"Текст"),
                        InlineKeyboardButton.WithCallbackData($" Вычеслить суммы чисел" , $"Числа")
                    });
            return buttons;
        }
    }
    }

