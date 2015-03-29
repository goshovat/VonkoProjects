using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicShopManager.Models
{
    internal class BassGuitar :Guitar, IBassGuitar
    {
        internal BassGuitar(string make, string model, decimal price, 
            string color, string bodyWood, string fingerBoardWood):
            base(make, model, price, color, true, bodyWood, fingerBoardWood, 4)
        {

        }
    }
}
