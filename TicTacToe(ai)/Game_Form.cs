using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe_ai_
{
    public partial class Game_Form : Form
    {
        int N;
        bool Bot;
        Game game;
        char turn;
        Button[,] buttons;

        public Game_Form(int n,bool bot)
        {
            InitializeComponent();
            N = n;
            Bot = bot;
        }

        private void Game_Form_Load(object sender, EventArgs e)
        {
            NewGame();
        }

        private void Game_Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button_Click(object sender, EventArgs e)
        {
            // get sender button
            Button btn = (Button)sender;
            // disable button
            btn.Enabled = false;

            int x = 0;
            int y = 0;

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (buttons[i, j] == btn)
                    {
                        x = i;
                        y = j;
                        break;
                    }
                }
            }

            Play(x, y);
        }
        void NewGame()
        {

            game = new Game(N, 'X', 'O');

            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowStyles.Clear();
            turn = 'X';

            float cellSize = 100 / N;
            buttons = new Button[N, N];
            // add buttons in 2D array
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Button btn = new Button();
                    btn.Font = new Font("Times New Roman", 24, FontStyle.Bold);
                    btn.Text = "-";
                    btn.Width = (int)cellSize * 10;
                    btn.Height = (int)cellSize * 10;
                    btn.Click += button_Click;

                    buttons[i, j] = btn;
                }
            }


            tableLayoutPanel1.RowCount = N;
            tableLayoutPanel1.ColumnCount = N;

            tableLayoutPanel1.RowStyles.Clear();
            tableLayoutPanel1.ColumnStyles.Clear();

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, cellSize));
                    tableLayoutPanel1.Controls.Add(buttons[i, j], j, i);
                }
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, cellSize));
            }
        }

        void PlayAgain() 
        {
            DialogResult result = MessageBox.Show("Do you want to play again?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) { NewGame(); }
            else { Application.Exit(); }
        }

        void Play(int x, int y)
        {
            // disable button
            buttons[x, y].Enabled = false;

            buttons[x, y].Text = turn.ToString();
            game.MarkBoard(x, y, turn);



            if (game.IsWin(turn))
            {
                MessageBox.Show(turn + ": Won!!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlayAgain();
            }
            else if (game.isTie())
            {
                MessageBox.Show("Game is Tie!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlayAgain();
            }
            else
            {
                // change turn
                if (turn == 'X')
                {
                    turn = 'O';
                   
                        if (Bot)
                        {
                            AIPLAY('O');
                        }
                    
                }
                else
                {
                    turn = 'X';
                }
            }

        }

        void AIPLAY(char p) 
        {
            AI ai = new AI(p);
            System.Drawing.Point move = ai.BestMove(game);
            int x = move.X;
            int y = move.Y;
            Play(x, y);
        }

    }
}
