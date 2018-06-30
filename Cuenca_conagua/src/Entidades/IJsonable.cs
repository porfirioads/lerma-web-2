using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuenca_conagua.src.Entidades
{
    interface IJsonable
    {
        /// <summary>
        /// Genera la cadena de la representación JSON del objeto.
        /// </summary>
        /// <returns>
        /// JSON del objeto.
        /// </returns>
        string ToJSON();
    }
}
