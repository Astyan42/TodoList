using System;
using DomainObject.Interfaces.Business;
using DomainObject.Models.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers.Abstract
{
    public class AbstractController<T, TH> : Controller where T:Entity where TH : IAbstractHandler<T>
    {
        protected readonly TH _handler;
        public AbstractController(TH handler) : base()
        {
            _handler = handler;
        }
    }
}
