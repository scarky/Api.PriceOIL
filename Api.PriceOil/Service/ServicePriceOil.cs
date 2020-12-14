using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.PriceOil.DTO;
using Api.PriceOil.Controllers;
using Microsoft.Extensions.Logging;
using RestSharp;
using Api.PriceOil.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server;
using System.Globalization;

namespace Api.PriceOil.Service
{
    public class ServicePriceOil : IServicePriceOil


    {

        private readonly ILogger<PriceOilController> _logger;
        private readonly DTO.SupportStructure.Configuration _conf;
        private string[] formats = { "yyyy-MM-dd" };
        #region"costruttore"
        public ServicePriceOil(DTO.SupportStructure.Configuration conf, ILogger<PriceOilController> logger)
        {
            _logger = logger;
            _conf = conf;

        }
        #endregion

        public ResponsePriceOil GetOilPriceTrend(RequestPriceOil r)
        {
            _logger.LogInformation("Ingresso : GetOilPriceTrend");
            ResponsePriceOil ret = new ResponsePriceOil();
            try
            {
                List<Prices> lstprice = new List<Prices>();
                var _ReponcePrice = CallServicePriceOil(_conf.path_ooil);

                if (_ReponcePrice.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    // _logger.LogInformation($"r_ReponcePrice.Content : {_ReponcePrice.Content}");
                    lstprice = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Prices>>(_ReponcePrice.Content);

                    var rangeprice = lstprice.Where(x => x.date >= r.Start_date && x.date <= r.End_date).ToList();

                    if (rangeprice.Count > 0)
                    {
                        ret = new ResponsePriceOil()
                        {
                            
                            Prices = rangeprice
                        };
                    }
                    else
                    {
                        ret.Errors = new List<Error>() { new Error() { Code = "1002", Description = "Prices not available!" } };
                    }


                }
                else
                {
                    _logger.LogInformation($"response._ReponcePrice.StatusCode : {_ReponcePrice.StatusCode} ");
                    _logger.LogInformation($"response._ReponcePrice.ErrorMessage : {_ReponcePrice.ErrorMessage} ");

                }
            }
            catch (Exception ex)

            {
                ret.Errors = new List<Error>() { new Error() { Code = "'1", Description = ex.Message } };
                _logger.LogError($"Errore GetOilPriceTrend: {ex}");
                throw;
            }

            return ret;

        }


        private IRestResponse CallServicePriceOil(string endpoint)
        {
            _logger.LogInformation($"Callservice.endpoint : {endpoint}");
            var client = new RestClient(endpoint);
            var request = new RestRequest(Method.GET);

            IRestResponse response = client.Execute(request);
            return response;
        }

        public ResponsePriceOil Checkdate(string _startdate, string _enddate)
        {
            ResponsePriceOil ret = new ResponsePriceOil() { Errors = new List<Error>()};
            

            try
            {   if (!IsValid(_startdate) || !IsValid(_enddate))
                {
                    ret.Errors = new List<Error>() { new Error() { Code = "1001", Description = "Invalid date, please try again with a valid date in the format of YYYY-MM-DD" } };
                }
                
            }
            catch (Exception ex)
            {
                ret.Errors = new List<Error>() { new Error() { Code = "'1", Description = ex.Message } };
                _logger.LogError($"Errore Checkdate: {ex}");
               
                throw;
            }
            return ret;
        }
        private Boolean IsValid(string _date) =>
     DateTime.TryParseExact(_date.ToString(), "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out _)
         ? true
         : false;
        
    }
}
