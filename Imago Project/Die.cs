using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Imago_Project
{
    
    class Die
    {
        private int sides = 6;
        Random rnd = new Random();
        public int Roll()
        {
            
            return rnd.Next(1, sides + 1);    // dice:  >= 1 and < 7
        }
    }
}
