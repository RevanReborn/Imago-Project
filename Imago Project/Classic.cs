using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imago_Project
{
    class Classic : Style   
    {
        //хочу тут в List actions добавлять, но он ведь на этом этапе даже "не создан", а создавать
        //тут тот же new Classic как-то тупо, не? И еще класс Класик не видит класс Экшон, правильно?
        //Но по плану должен

        public Classic()
        {
            styleName = "Classic";
            actions.Add(new Action(1, "Lunge attack", 4, false));
            actions.Add(new Action(2, "Counter-attack", 4, true));
            actions.Add(new Action(3, "Clean parry", 3, true));
            actions.Add(new Action(4, "Swing", 2, false));
            actions.Add(new Action(5, "Proper stance", 2, false));
        }

        public Classic(int PlayerID, int Level)
        {
            styleID = PlayerID;
            styleName = "Classic";
            level = Level;
            actions.Add(new Action(1, "Lunge attack", 4, false));
            actions.Add(new Action(2, "Counter-attack", 4, true));
            actions.Add(new Action(3, "Clean parry", 3, true));
            actions.Add(new Action(4, "Swing", 2, false));
            actions.Add(new Action(5, "Proper stance", 2, false));
        }

        public int Lunge()
        {
            int damage = 0;// Damage();
            return damage;
        }
    }
}
