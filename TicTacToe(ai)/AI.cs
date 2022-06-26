using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe_ai_
{
    
    public class AI
    {
        Char ai,enemy;
        int weight = 0;
        public AI(Char p) 
        {
            ai = p;
            if (ai == 'X') { enemy = 'O'; }
            else { enemy = 'X'; }
        }
        

        public System.Drawing.Point BestMove(Game g)
        {
            double best_score = -999999999;
            System.Drawing.Point best_move = new System.Drawing.Point();
            weight = 0;
            for (int i = 0; i < g.N; i++)
            {
                for (int j = 0; j < g.N; j++)
                {
                    if (g.Board[i, j] != 'X' && g.Board[i, j] != 'O')
                    {
                        g.Board[i, j] = ai;
                        double score = minimax(g, 1, false);
                        g.Board[i, j] = '-';
                        if (score > best_score) 
                        { best_score = score;
                            best_move.X = i;
                            best_move.Y = j;
                        }
                    }
                }
            }
            System.Console.WriteLine(weight);
            return best_move;
        }

        public double minimax(Game g,int depth,bool maximazing) 
        {
            weight++;
            if(g.N > 3) { if (depth > 3) { return 0; } }
            bool win = g.IsWin(ai);
            bool lose = g.IsWin(enemy);
            if(win){return 10/depth;}
            else if (lose) { return -10/depth; }
            else if (g.isTie()) { return 0; }
            

            if (maximazing)
            {
                double best_score = -999999999;
                for (int i = 0;i <g.N;i++)
                {
                    for(int j= 0; j<g.N; j++)
                    {
                        if(g.Board[i,j]!= 'X'&& g.Board[i, j] !='O')
                        {
                            
                            g.Board[i, j] = ai;
                            double score = minimax(g,depth + 1, false);
                            g.Board[i, j] = '-';
                            if (score>best_score){best_score = score;}
                        }
                    }
                }
                return best_score;
            } 
            else 
            {
                double best_score = 999999999;
                for (int i = 0; i < g.N; i++)
                {
                    for (int j = 0; j < g.N; j++)
                    {
                        if (g.Board[i, j] != 'X' && g.Board[i, j] != 'O')
                        {
                            g.Board[i, j] = enemy;
                            double score = minimax(g, depth + 1, true);
                            g.Board[i, j] = '-';
                            if (score < best_score) { best_score = score; }
                        }
                    }
                }
                return best_score;
            }

            
        }

    }
}
