using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        List<Point> wall = new List<Point>();
        List<Point> coin = new List<Point>();
        List<Point> key = new List<Point>();
        List<Point> door = new List<Point>();
        Player player = new Player(1,1);
        Map map1;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = 
                {


                "##############",
                "#PC0000000000#",
                "#C#0####00####",
                "#C#0#0K#00000#",
                "#C00#0##0###0#",
                "#CCCCCCCCKC00D",
                "##############"
                };
            
            int rows = lines.Length;
            int cols = lines[0].Length;
            char[,] map = new char[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    map[i, j] = lines[i][j];
                }
            }

            map1 = new Map(map);
            DisplayMap(map1);
        }
        private void DisplayMap(Map map1) 
        {
            int rows = map1.map.GetLength(0);
            int cols = map1.map.GetLength(1);
            int cellSize = 30;
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.AutoSize = true;
            tableLayoutPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel.RowCount = rows;
            tableLayoutPanel.ColumnCount = cols;

            for (int i = 0; i < rows; i++) 
            {
                tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, cellSize));
            }
            for(int i = 0; i < cols; i++)
            {
                tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, cellSize));
            }




            for(int i = 0; i < rows; i++)
            {
                for(int j = 0;j < cols; j++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Dock = DockStyle.Fill;
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    char symbol = map1.map[i, j];
                    char currentSymbol = symbol;
                    map1.map[player.X, player.Y] = 'P';
                    pictureBox.BackColor = GetColorForSymbol(symbol,i,j);
                    pictureBox.Tag = symbol;
                    tableLayoutPanel.Controls.Add(pictureBox, j, i);
                }
            }



            this.Controls.Clear();
            this.Controls.Add(tableLayoutPanel);
            this.Controls.Add(coinLabel);
            this.Controls.Add(keyLabel);






            this.Controls.Add(buttonUp);
            this.Controls.Add(buttonDown);
            this.Controls.Add(buttonLeft);
            this.Controls.Add(buttonRight);




            keyLabel.Text = "Ключей: " + map1.key;
            coinLabel.Text = "Монет: " + map1.coin;


        }
        public void DrawMap()
        {

        }
        public Color GetColorForSymbol(char symbol, int i, int j)
        {
            switch (symbol)
            {
                case 'P':
                    return Color.Red;
                case '#':
                    wall.Add(new Point(i, j));
                    return Color.Black;
                case '0':
                    return Color.LightGray;
                case 'K':
                    key.Add(new Point(i, j));
                    return Color.Blue;
                case 'D':
                    door.Add(new Point(i, j));
                    return Color.Green;
                case 'C':
                    coin.Add(new Point(i, j));
                    return Color.Gold;
                
                default: return Color.White;
            }
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (map1.map[player.Y-1,player.X] != '#')
            {
                if (map1.map[player.Y-1, player.X] == 'C')
                {
                    map1.coin++;
                }
                if (map1.map[player.Y-1, player.X] == 'K')
                {
                    map1.key++;
                }
                if (map1.map[player.Y-1, player.X] == 'D' && map1.key != 0)
                {
                    MessageBox.Show("ВЫ ВЫЙГРАЛИ!");
                }
                player.Y--;
            }
            map1.map[player.Y, player.X] = 'P';
            keyLabel.Text = "Ключей: " + map1.key;
            coinLabel.Text = "Монет: " + map1.coin;
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (map1.map[player.Y + 1, player.X] != '#')
            {
                if (map1.map[player.Y + 1, player.X] == 'C')
                {
                    map1.coin++;
                }
                if (map1.map[player.Y + 1, player.X] == 'K')
                {
                    map1.key++;
                }
                if (map1.map[player.Y + 1, player.X] == 'D' && map1.key != 0)
                {
                    MessageBox.Show("ВЫ ВЫЙГРАЛИ!");
                }
                player.Y++;
            }
            map1.map[player.Y, player.X] = 'P';
            keyLabel.Text = "Ключей: " + map1.key;
            coinLabel.Text = "Монет: " + map1.coin;
        }

        private void buttonRight_Click(object sender, EventArgs e)
        {
            if (map1.map[player.Y, player.X+1] != '#')
            {
                if (map1.map[player.Y, player.X+1] == 'C')
                {
                    map1.coin++;
                }
                if (map1.map[player.Y, player.X+1] == 'K')
                {
                    map1.key++;
                }
                if (map1.map[player.Y, player.X+1] == 'D' && map1.key != 0)
                {
                    MessageBox.Show("ВЫ ВЫЙГРАЛИ!");
                }
                player.X++;
            }
            map1.map[player.Y, player.X] = 'P';
            keyLabel.Text = "Ключей: " + map1.key;
            coinLabel.Text = "Монет: " + map1.coin;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (map1.map[player.Y, player.X - 1] != '#')
            {
                if (map1.map[player.Y, player.X - 1] == 'C')
                {
                    map1.coin++;
                }
                if (map1.map[player.Y, player.X - 1] == 'K')
                {
                    map1.key++;
                }
                if (map1.map[player.Y, player.X - 1] == 'D' && map1.key != 0)
                {
                    MessageBox.Show("ВЫ ВЫЙГРАЛИ!");
                }
                player.X--;
            }
            map1.map[player.Y, player.X] = 'P';
            keyLabel.Text = "Ключей: " + map1.key;
            coinLabel.Text = "Монет: " + map1.coin;
        }
    }
}