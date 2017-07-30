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
    public partial class Main : Form
    {
        List<GroupBox> playerBoxes = new List<GroupBox>();
        Die die;
        List<Player> players = new List<Player>();
        bool theEnd = false;

        public Main()
        {
            InitializeComponent();
            playerBoxes.Add(groupBox2);
            groupBox2.Controls.SetChildIndex(textBox2, 0);
            groupBox2.Controls.SetChildIndex(textBox3, 1);
            playerBoxes.Add(groupBox3);
            groupBox3.Controls.SetChildIndex(textBox4, 0);
            groupBox3.Controls.SetChildIndex(textBox5, 1);
            playerBoxes.Add(groupBox4);
            playerBoxes.Add(groupBox5);

            /*for (int i = 0; i < groupBox2.Controls.Count; ++i)
            {
                DisplayText(groupBox2.Controls[i].Name);
            }

            for (int i = 0; i < playerBoxes.Count; ++i)
            {
                Array list = new List<System.ComponentModel.Container>();
                playerBoxes[i] = playerBoxes[i].Controls.CopyTo(list,0);
                    //OrderBy(c => c.Tag).ToList();
            }*/
        }

        public void Compose(GroupBox gBox)
        {

        }

        public void PreGameInit(int Count)
        {
            die = new Die();
            for (int i = 0; i < Count; ++i)
            {
                players.Add(new Player(i + 1, (i % 2) + 1));
            }            
        }


        public void Game()
        {
            while (!theEnd)
            {
                InitRoll();
                for (int i = 0; i < players.Count; ++i) Debug.Write(players[i].AP + " ");
                break;
            }
        }

        public bool CheckEnd()
        {
            for (int i = 0; i < players.Count; ++i)
                if (players[i].HP <= 0)
                {
                    toolStripButton1.Enabled = true;
                    players.Clear();
                    return true;
                }                    
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
                playerBoxes[i].Controls[0].Text = players[i].AP.ToString();

            }
            //Debug.Write("\n");
            players = players.OrderByDescending(p => p.AP).ToList();

        }

        public void DisplayText(string text)
        {
            BattleLog.Items.Add(new Label().Text = text);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            PreGameInit(toolStripComboBox1.SelectedIndex + 2);
            Game();
            toolStripButton1.Enabled = false;
        }
    }
}
