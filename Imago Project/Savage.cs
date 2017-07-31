using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imago_Project
{
    class Savage : Style
    {
        public Savage()
        {
            this.styleName = "Savage";
            this.actions.Add(new Action(1, "Impetuous assault", 6, false));
            this.actions.Add(new Action(2, "Unrelenting strike", 7, false));
            this.actions.Add(new Action(3, "Rough blow", 3, false));
            this.actions.Add(new Action(4, "Berserks's impulse", 6, true));
            this.actions.Add(new Action(5, "Cry of hatred", 2, false));
        }

        public Savage(int PlayerID, int Level)
        {
            this.styleID = PlayerID;
            this.styleName = "Savage";
            this.level = Level;
            this.actions.Add(new Action(1, "Impetuous assault", 6, false));
            this.actions.Add(new Action(2, "Unrelenting strike", 7, false));
            this.actions.Add(new Action(3, "Rough blow", 3, false));
            this.actions.Add(new Action(4, "Berserks's impulse", 6, true));
            this.actions.Add(new Action(5, "Cry of hatred", 2, false));
        }
        


    }
}
