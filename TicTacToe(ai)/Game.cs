using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ai_
{
    public class Game
    {
        public int N;
        private char[,] board;
        private int turnsPlayed;
        public char P1, P2;
        public char[,] Board { get => board; set => board = value; }

        public Game(int n, char p1, char p2)
        {
            this.N = n;
            this.P1 = p1;
            this.P2 = p2;
            board = new char[N, N];
            // initialize baord entry by -
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    board[i, j] = '-';
                }
            }
            turnsPlayed = 0;
        }

        public void MarkBoard(int i, int j, char turn)
        {
            board[i, j] = turn;
            turnsPlayed++;
        }
        public bool isTie()
        {
            int marks = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == 'X'|| board[i, j] == 'O') { marks++; }
                }
            }

            if (marks == N * N) { return true; }
            return false;
        }
        public bool IsWin(char player)
        {
            int total = 0;
            // check row-wise
            for (int i = 0; i < N; i++)
            {
                total = 0;
                for (int j = 0; j < N; j++)
                {
                    if (board[i, j] == player) { total++; }
                }

                if (total == N)
                {
                    return true;
                }
            }

            // check column-wise
            for (int j = 0; j < N; j++)
            {
                total = 0;
                for (int i = 0; i < N; i++)
                {
                    if (board[i, j] == player) { total++; }
                }
                if (total == N)
                {
                    return true;
                }
            }

            // check diagonal-wise
            total = 0;
            for (int i = 0; i < N; i++)
            {
                if (board[i, i] == player) { total++; }
            }

            if (total == N)
            {
                return true;
            }

            total = 0;
            for (int i = 0; i < N; i++)
            {
                if (board[i, N - i - 1] == player) { total++; }
            }

            if (total == N)
            {
                return true;
            }

            return false;
        
        }
    }
}
