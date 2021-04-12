﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Lime.Protocol.Server;
using Serilog;
using Take.Blip.Client;

namespace Take.Blip.Client.WebTemplate
{
    /// <summary>
    /// Defines a type that is called once during the application initialization.
    /// </summary>
    public class BotStartup : IStartable
    {
        private readonly ISender _sender;
        private readonly Settings _settings;

        public BotStartup(ISender sender, Settings settings)
        {
            _sender = sender;
            _settings = settings;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Trace().CreateLogger();

            return Task.CompletedTask;
        }
    }
}