using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasApp.Infra.Storage.Settings
{
    public class MongoDbSettings
    {
        public string? Host { get; set; }
        public string? Database { get; set; }
        public bool IsSSL { get; set; }
    }
}