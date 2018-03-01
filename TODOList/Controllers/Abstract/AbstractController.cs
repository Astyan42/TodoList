using System;
using DomainObject.Interfaces.Business;
using DomainObject.Models.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Service.Controllers.Abstract
{
    public class AbstractController<T, TH> : Controller where T:Entity where TH : IAbstractHandler<T>
    {
        protected readonly TH _handler;
        protected readonly ILogger _logger;
        public AbstractController(TH handler, ILogger logger) : base()
        {
            _handler = handler;
            _logger = logger;
        }
    }
}
