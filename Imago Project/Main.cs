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
        BindingList<Style> styles = new BindingList<Style>();
        bool theEnd = false;
        int turns = 0;
        int battle = 0;

        public Main()
        {
            InitializeComponent();
            toolStripButton2.Enabled = false;
            toolStripComboBox1.SelectedIndex = 0;

            playerBoxes.Add(groupBox1);
            groupBox1.Controls.SetChildIndex(hpBox1, 0);
            groupBox1.Controls.SetChildIndex(apBox1, 1);
            groupBox1.Controls.SetChildIndex(styleBox1, 2);
            groupBox1.Controls.SetChildIndex(lvlBox1, 3);
            groupBox1.Controls.SetChildIndex(actionBox1, 4);
            groupBox1.Controls.SetChildIndex(targetBox1, 5);
            groupBox1.Controls.SetChildIndex(checkBox1, 6);
            playerBoxes.Add(groupBox2);
            groupBox2.Controls.SetChildIndex(hpBox2, 0);
            groupBox2.Controls.SetChildIndex(apBox2, 1);
            groupBox2.Controls.SetChildIndex(styleBox2, 2);
            groupBox2.Controls.SetChildIndex(lvlBox2, 3);
            groupBox2.Controls.SetChildIndex(actionBox2, 4);
            groupBox2.Controls.SetChildIndex(targetBox2, 5);
            groupBox2.Controls.SetChildIndex(checkBox2, 6);
            playerBoxes.Add(groupBox3);
            groupBox3.Controls.SetChildIndex(hpBox3, 0);
            groupBox3.Controls.SetChildIndex(apBox3, 1);
            groupBox3.Controls.SetChildIndex(styleBox3, 2);
            groupBox3.Controls.SetChildIndex(lvlBox3, 3);
            groupBox3.Controls.SetChildIndex(actionBox3, 4);
            groupBox3.Controls.SetChildIndex(targetBox3, 5);
            groupBox3.Controls.SetChildIndex(checkBox3, 6);
            playerBoxes.Add(groupBox4);
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

        }        

        public void PreGameInit(int Count)
        {
            die = new Die();
            for (int i = 0; i < Count; ++i)
            {
                players.Add(new Player(i + 1, (i % 2) + 1));
                playerBoxes[i].Enabled = true;
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
            DisplayText("The battle #" + battle + " has ended!");
            int n = 0;
            foreach (GroupBox gb in playerBoxes)
            {
                ++n;
                gb.Enabled = false;
            }
            players.Clear();
            ClearTable();
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
                DisplayOnTable(players[i]);
            }

            players = players.OrderByDescending(p => p.AP).ToList();

        }

        public void DisplayText(string text)
        {
            BattleLog.Items.Add(new Label().Text = text);
        }

        public void DisplayOnTable(Player player)
        {            
            int column = 13 - player.AP;
            int row = 13 - player.HP;
            if (player.Team == 1)
                tableLayoutPanel1.GetControlFromPosition(column, row).ForeColor = Color.Red;
            else
                tableLayoutPanel1.GetControlFromPosition(column, row).ForeColor = Color.Blue;
            tableLayoutPanel1.GetControlFromPosition(column, row).Enabled = true;
            if (tableLayoutPanel1.GetControlFromPosition(column, row).Text != "")
            {
                tableLayoutPanel1.GetControlFromPosition(column, row).ForeColor = Color.Black;
                tableLayoutPanel1.GetControlFromPosition(column, row).Text += ", " + player.Count.ToString();
            }
            else tableLayoutPanel1.GetControlFromPosition(column, row).Text = player.Count.ToString();
        }

        private void ClearTable()
        {
            for (int c = 1; c < tableLayoutPanel1.ColumnCount; ++c)
                for (int r = 1; r < tableLayoutPanel1.RowCount; ++r)
                {
                    tableLayoutPanel1.GetControlFromPosition(c, r).ResetText();
                    tableLayoutPanel1.GetControlFromPosition(c, r).Enabled = false;
                }            
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
        }

    }
}
