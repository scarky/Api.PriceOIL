using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.PriceOil.DTO;

namespace Api.PriceOil.Service
{
    interface IServicePriceOil
    {
       ResponsePriceOil GetOilPriceTrend(RequestPriceOil r);
    }
}
