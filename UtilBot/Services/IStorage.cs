using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilBot.Models;

namespace UtilBot.Services
{
    public interface IStorage
    {
        Session GetSession(long chatId);
    }
}
