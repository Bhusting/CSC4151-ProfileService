using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace CSC4151_ProfileService.Handlers
{
    public interface IMessageHandler 
    {

        Task Handle(string messageBody);

    }
}
