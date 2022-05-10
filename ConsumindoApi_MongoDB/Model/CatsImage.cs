using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumindoApi_MongoDB.Model
{
    /// <summary>
    /// Modelo do Schema para consumir as urls das imagens dos gatos, levando em consideração somente as informações para o projeto. 
    /// </summary>
    public class CatsImage
    {
        public string Id { get; set; }

        public string Url { get; set; }

    }
}
