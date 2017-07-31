using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imago_Project
{
    abstract class Style
    {
        public int styleID;
        public string styleName;
        public int level = 1;
        public List<Action> actions = new List<Action>();
        public Die die;
    }
}
