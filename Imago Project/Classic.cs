using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imago_Project
{
    class Classic : Style   
    {
        public Classic(int PlayerID, int Level)
        {
            this.styleID = PlayerID;
            this.styleName = "Classic";
            this.level = Level;
        }

        public int Attack()
        {
            return 0;
        }
    }
}
