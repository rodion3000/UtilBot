using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using UtilBot.Services;

namespace UtilBot.Functions
{
    public class FunctionExecuter
    {
        private readonly IStorage _memoryStorage;
        private readonly Dictionary<string, IOInterface> _operationDict = new Dictionary<string, IOInterface>
    {
        { "Текст", new Text() },
        { "Числа", new SumN() },
    };
        public FunctionExecuter(IStorage memoryStorage)
        {
            _memoryStorage = memoryStorage;
        }
        public string S(Message message)
        {
            var session = _memoryStorage.GetSession(message.Chat.Id);
            return _operationDict[session.LanguageCode].Execute(message.Text);
        }
    }
}
