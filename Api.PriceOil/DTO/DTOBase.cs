using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.PriceOil.DTO
{
    public interface IPriceOil
    {
        DateTime Start_date { get; set; }

        DateTime End_date { get; set; }
    }

    /// <summary>
    /// Classe dedicata alla gestione degli errori
    /// </summary>
    public class Error
    {
        /// <summary>
        /// Codice dell'errore
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Descrizione dell'errore
        /// </summary>
        public string Description { get; set; }
    }
}
