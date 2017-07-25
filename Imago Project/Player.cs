using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imago_Project
{
    class Player
    {
        int count;
        int team;
        int hp;
        int ap = 0;
        bool fatum;
        Style playerStyle;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int Team
        {
            get { return team; }
            set { team = value; }
        }

        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }

        public int AP
        {
            get { return ap; }
            set { ap = value; }
        }

        public bool Fatum
        {
            get { return fatum; }
            set { fatum = value; }
        }

        public Player(int Count, int Team, bool Fatum)
        {
            this.count = Count;
            this.team = Team;
            this.fatum = Fatum;
            if (Fatum)
                this.hp = 12;
            else this.hp = 10;

        }


    }
}
