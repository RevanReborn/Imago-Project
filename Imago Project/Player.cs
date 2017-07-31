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
        int hp = 10;
        int ap = 0;
        bool fatum;
        Style playerStyle;
        Classic baseStyle;
        int skill = 1;

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

        public int Skill
        {
            get { return skill; }
            set { skill = value; }
        }

        public Player(int Count, int Team)
        {
            this.count = Count;
            this.team = Team;
            baseStyle = new Classic(this.count, 1);
            this.skill = baseStyle.level;
        }

        public void SetFatum (bool Fatum)
        {
            this.fatum = Fatum;
            if (Fatum)
                this.hp = 12;
            else this.hp = 10;
        }


    }
}
