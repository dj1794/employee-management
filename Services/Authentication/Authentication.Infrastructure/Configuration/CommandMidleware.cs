using BuildingBlock.Contract;
using Authentication.Infrastructure.Configuration.Database;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Configuration
{
    public class CommandMidleware<TCommand, TCommandResponse> : IPipelineBehavior<TCommand, TCommandResponse> where TCommand : ICommand<TCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommandMidleware(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TCommandResponse> Handle(TCommand request, RequestHandlerDelegate<TCommandResponse> next, CancellationToken cancellationToken)
        {
            using(var unitOfWork = _unitOfWork)
            {
                try
                {
                    await unitOfWork.StartTransaction();
                    var result = await next();
                    await unitOfWork.SaveChangesAsync();
                    await unitOfWork.CommitTransaction();
                    return result;
                }catch (Exception ex)
                {
                    await unitOfWork.RollbackTransaction();
                    throw new Exception (ex.ToString ());
                }
            }
        }
    }
}
