using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.PriceOil.DTO.SupportStructure
{

 
    public class Configuration
    {
        private protected string _env;
        private protected string _pathOil;
        public Configuration(IConfiguration configuration)
        {
            _env = configuration.GetSection("AppSettings").GetValue<string>("ENVIRONMENT");
            _pathOil= configuration.GetSection("UrlPath").GetValue<string>("path_oil");
        }

        public string env { get { return _env; } }
        public string path_ooil { get { return _pathOil; } }
    }
}
