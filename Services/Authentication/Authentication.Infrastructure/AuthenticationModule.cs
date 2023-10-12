using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuildingBlock.Contract;

namespace Authentication.Infrastructure
{
    public class AuthenticationModule
    {
        IMediator mediator;
        public AuthenticationModule(IMediator mediatR)
        {
            mediator = mediatR;
        }
        public Task<T> ExecuteCommandAsync<T>(ICommand<T> command)        {

           return mediator.Send(command);
        }
        public Task<T> ExecuteQueryAsync<T>(IQuery<T> query)
        {
           return mediator.Send(query);
        }
    }
}
