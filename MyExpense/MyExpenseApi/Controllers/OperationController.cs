using Application.Operations.Commands.CreateOperation;
using Application.Operations.Queries.GetOperations;
using Microsoft.AspNetCore.Mvc;

namespace MyExpenseApi.Controllers
{
    public class OperationController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<OperationDto>> GetOperation()
        {
            return await Mediator.Send(new GetOperationsQuery());
        }

        [HttpPost]
        public async Task<Guid> CreateOperation(CreateOperationCommand createOperationCommand)
        {
            return await Mediator.Send(createOperationCommand);
        }
    }
}