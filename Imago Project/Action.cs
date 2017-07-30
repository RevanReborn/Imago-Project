using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imago_Project
{
    class Action : Style
    {
        private int id;
        private string name;
        private int cost;
        private bool reaction;
        Die die;

        public Action(int ID, string Name, int Cost, bool Reaction)
        {
            this.id = ID;
            this.name = Name;
            this.cost = Cost;
            this.reaction = Reaction;
        }

        public bool Test(Player executor, Player target)
        {
            int attemt = die.Roll() + die.Roll();
            int success = (6 + target.Skill) - (executor.Skill - 1);
            if (attemt >= success)
                return true;
            else return false;
        }
    }
}
