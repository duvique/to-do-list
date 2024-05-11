using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoList.API.Controllers
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        protected readonly ISender Sender;

        public ApiController(ISender sender)
        {
            Sender = sender;
        }
    }
}
