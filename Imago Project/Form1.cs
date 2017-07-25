using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Diagnostics;

namespace Imago_Project
{
    public partial class Form1 : Form
    {
        
        Die die;
        List<Player> players = new List<Player>();
        bool theEnd = false;
        
        public Form1()
        {

            InitializeComponent();
            PreGameInit();
            Game();

        }


        public void PreGameInit()
        {
            die = new Die();
            players.Add(new Player(1, 1, true));
            players.Add(new Player(2, 2, true));
            players.Add(new Player(2, 2, true));
            players.Add(new Player(2, 2, true));
            players.Add(new Player(2, 2, true));

        }


        public void Game()
        {
            while (!theEnd)
            {
                InitRoll();
                InitRoll();
                InitRoll();
                InitRoll();
                for (int i =0; i < players.Count;  ++i) Debug.Write(players[i].AP + " ");
                break;
            }
        }

        public bool CheckEnd()
        {
            for (int i = 0; i < players.Count; ++i)
                if (players[i].HP <= 0) return true;
            return false;
        }

        public void InitRoll()
        {
            for (int i = 0; i < players.Count; ++i)
            {
                int roll1 = die.Roll();
                int roll2 = die.Roll();
                players[i].AP = roll1 + roll2;
                DisplayText("Player " + players[i].Count + " rolled: " + roll1 + " + " + roll2);
                
            }
            //Debug.Write("\n");
            players = players.OrderByDescending(p => p.AP).ToList();

        }

        public void DisplayText(string text)
        {
            BattleLog.Items.Add(new Label().Text = text);
        }
    }
}
