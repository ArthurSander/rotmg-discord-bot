﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotmgDiscordBot.Shared.Models.Configurations
{
    public class DefaultApplicationSettings : IApplicationSettings
    {
        public string BotName { get; set; }
        public string BotToken { get; set; }
    }
}
