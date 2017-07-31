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
        GroupBox[] playerBoxes = new GroupBox[4];
        Die die;
        List<Player> players = new List<Player>();
        BindingList<Style> styles = new BindingList<Style>();        
        bool theEnd = false;
        int turns =0;
        int battle = 0;

        public Main()
        {
            InitializeComponent();
            toolStripButton2.Enabled = false;
            toolStripComboBox1.SelectedIndex = 0;

            playerBoxes[0] = groupBox1;
            groupBox1.Controls.SetChildIndex(hpBox1, 0);
            groupBox1.Controls.SetChildIndex(apBox1, 1);
            groupBox1.Controls.SetChildIndex(styleBox1, 2);
            groupBox1.Controls.SetChildIndex(lvlBox1, 3);
            groupBox1.Controls.SetChildIndex(actionBox1, 4);
            groupBox1.Controls.SetChildIndex(targetBox1, 5);
            groupBox1.Controls.SetChildIndex(checkBox1, 6);
            playerBoxes[1] = groupBox2;
            groupBox2.Controls.SetChildIndex(hpBox2, 0);
            groupBox2.Controls.SetChildIndex(apBox2, 1);
            groupBox2.Controls.SetChildIndex(styleBox2, 2);
            groupBox2.Controls.SetChildIndex(lvlBox2, 3);
            groupBox2.Controls.SetChildIndex(actionBox2, 4);
            groupBox2.Controls.SetChildIndex(targetBox2, 5);
            groupBox2.Controls.SetChildIndex(checkBox2, 6);
            playerBoxes[2] = groupBox3;
            groupBox3.Controls.SetChildIndex(hpBox3, 0);
            groupBox3.Controls.SetChildIndex(apBox3, 1);
            groupBox3.Controls.SetChildIndex(styleBox3, 2);
            groupBox3.Controls.SetChildIndex(lvlBox3, 3);
            groupBox3.Controls.SetChildIndex(actionBox3, 4);
            groupBox3.Controls.SetChildIndex(targetBox3, 5);
            groupBox3.Controls.SetChildIndex(checkBox3, 6);
            playerBoxes[3] = groupBox4;
            groupBox4.Controls.SetChildIndex(hpBox4, 0);
            groupBox4.Controls.SetChildIndex(apBox4, 1);
            groupBox4.Controls.SetChildIndex(styleBox4, 2);
            groupBox4.Controls.SetChildIndex(lvlBox4, 3);
            groupBox4.Controls.SetChildIndex(actionBox4, 4);
            groupBox4.Controls.SetChildIndex(targetBox4, 5);
            groupBox4.Controls.SetChildIndex(checkBox4, 6);

            styles.Add(new Classic());
            styles.Add(new Savage());

            styleBox1.ValueMember = null;
            styleBox1.DisplayMember = "styleName";
            styleBox1.DataSource = styles;

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
                for (int i = 0; i < players.Count; ++i)
                {
                    playerBoxes[i].Controls[0].Text = players[i].HP.ToString();
                }
                break;
            }
        }

        public bool CheckEnd()
        {
            for (int i = 0; i < players.Count; ++i)
                if (players[i].HP <= 0)
                {
                    EndGame();
                    return true;
                }                    
            return false;
        }

        public void EndGame()
        {
            toolStripButton1.Enabled = true;
            for (int i = 0; i < players.Count; ++i)
            {
                playerBoxes[i].Controls[0].ResetText();
                playerBoxes[i].Controls[1].Text = "";
            }                
            players.Clear();
        }

        public void InitRoll()
        {
            for (int i = 0; i < players.Count; ++i)
            {
                int roll1 = die.Roll();
                int roll2 = die.Roll();
                players[i].AP = roll1 + roll2;
                DisplayText("Player " + players[i].Count + " rolled: " + roll1 + " + " + roll2);
                DisplayText("Player " + players[i].Count + " team is: " + players[i].Team);
                playerBoxes[i].Controls[1].Text = players[i].AP.ToString();

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
            battle++;
            DisplayText("The battle #" + battle + " has started!");
            PreGameInit(toolStripComboBox1.SelectedIndex + 2);
            Game();
            toolStripButton1.Enabled = false;
            toolStripButton2.Enabled = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            EndGame();
            DisplayText("The battle #" + battle + " has ended!");
        }
    }
}
