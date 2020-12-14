using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.PriceOil.Controllers
{
    public abstract class DefaultController<C> : ControllerBase
    {

        private protected DTO.SupportStructure.Configuration _conf;
        private protected ILogger<C> _logger = null;
        private protected IHttpContextAccessor _context;
        public DefaultController(DTO.SupportStructure.Configuration conf, ILogger<C> logger, IHttpContextAccessor context)
        {
            _logger = logger;
            _conf = conf;
            _context = context;
          

         
        }

    }
}