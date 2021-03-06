﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Common.Settings;
using Microsoft.Extensions.Hosting;

namespace CSC4151_ProfileService.ASB
{
    public class EndpointIntializer : BackgroundService
    {
        private readonly ServiceBusClient _client;

        public EndpointIntializer(ServiceBusClient client)
        {
            _client = client;
        }

        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            await _client.StartAsync();

            await base.StartAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {

            await _client.StopAsync();

            await base.StopAsync(cancellationToken);
        }
    }
}
