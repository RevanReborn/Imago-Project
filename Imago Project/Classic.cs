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
