using Api.PriceOil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.PriceOil.DTO
{
    public class RequestPriceOil : IPriceOil
    {
        public DateTime Start_date { get; set; } 
        public DateTime End_date { get; set; } 
    }

    public class ResponsePriceOil : IResponseBase
    {
        public List<Error> Errors { get ; set ; }
        public List<Prices> Prices { get; set; }
    }


    public interface IResponseBase
    {
        List<Error> Errors { get; set; }
    }

    
}
