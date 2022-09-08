using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilBot.Functions
{
    public class Text: IOInterface
    {
        public string Execute(string message)
        {
            return $"Длина сообщения: {message.Length} знаков";
        }
    }
}
