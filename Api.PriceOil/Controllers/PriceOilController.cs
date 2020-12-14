using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Api.PriceOil.Controllers;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Api.PriceOil.Service;
using Api.PriceOil.DTO;
using System.Globalization;

namespace Api.PriceOil.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class PriceOilController : DefaultController<PriceOilController>
    {
        private protected ServicePriceOil _service;
        public PriceOilController(DTO.SupportStructure.Configuration conf, ILogger<PriceOilController> logger, IHttpContextAccessor Context) : base(conf, logger, Context)
        {
            _service = new ServicePriceOil(conf, logger);
            _conf = conf;
            _context = Context;
        }

        [HttpGet]
        public async Task<ResponsePriceOil> GetOilPriceTrend(string _start_date,string _end_date)

        {
            ResponsePriceOil ret = new ResponsePriceOil();

           
            var _checkrequest = _service.Checkdate(_start_date.ToString(), _end_date.ToString());

            if (_checkrequest.Errors.Count == 0)
            {
                var _r = new RequestPriceOil() { Start_date = Convert.ToDateTime(_start_date), End_date = Convert.ToDateTime(_end_date) };

                try
                {
                    ret = await Task.Run(() => _service.GetOilPriceTrend(_r));
                }
                catch (Exception ex)
                {
                    ret.Errors = new List<Error>() { new Error() { Code = "'1", Description = ex.Message } };
                    _logger.LogError($"Errore GetOilPriceTrend: {ex}");

                    throw;
                }


            }
            else { ret = _checkrequest; }

            return ret;
        }
    }
}
