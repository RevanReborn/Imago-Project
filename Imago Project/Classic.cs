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

        Die die;

        public Classic(int PlayerID, int Level)
        {
            this.styleID = PlayerID;
            this.styleName = "Classic";
            this.level = Level;
            this.actions.Add(new Action(1, "Атакуючий випад", 4, false));
            this.actions.Add(new Action(2, "Контратака", 4, true));
            this.actions.Add(new Action(3, "Чистий блок", 3, true));
            this.actions.Add(new Action(4, "Взмах", 2, false));
            this.actions.Add(new Action(5, "Правильна стійка", 2, false));
        }

        public int Attack()
        {
            int damage = die.Roll() + die.Roll();
            return damage;
        }
    }
}
