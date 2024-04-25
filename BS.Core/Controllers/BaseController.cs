using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BS.Core.Controllers
{
    public class BaseController(IServiceProvider serviceProvider) : ControllerBase
    {
        protected readonly IMediator Mediator = serviceProvider.GetService<IMediator>();

        protected readonly IMapper Mapper = serviceProvider.GetService<IMapper>();
    }
}
