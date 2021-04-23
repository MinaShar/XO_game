using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo_game
{
    class test_play_effichency
    {
        public playstate[] ps;
        public int index_ps;
        public test_play_effichency(playstate[] ps,int index_ps)
        {
            this.ps = ps;
            this.index_ps = index_ps;
        }
        public int get_minimum_number_of_plays_for_action(out int here)
        {
            int minimum_number_of_plays = 100;
            here = -1;
            for(int i=0; i<index_ps;i++)
            {
                if (ps[i].result != states.nothing&&ps[i].numberofplays<minimum_number_of_plays)
                {
                    minimum_number_of_plays = ps[i].numberofplays;
                    if (minimum_number_of_plays <= 2)
                    {
                        here = ps[i].play_here;
                    }
                    else
                    {
                        here = ps[i].if_i_played_here;
                    }
                }
                    
            }
            return minimum_number_of_plays;
        }
        public bool test_if_minimum_number_of_plays_is_for_lose(int minimum_number_of_plays_for_action,out int play_here)
        {
            for (int i = 0; i < index_ps; i++)
            {
                if(ps[i].result==states.lose&&ps[i].numberofplays==minimum_number_of_plays_for_action)
                {
                    play_here = ps[i].play_here;
                    return true;
                }
            }
            play_here = -1;
            return false;
        }
        public int get_play_with_maximum_number_of_wins()
        {
            int[] number_of_wins = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for(int i=0; i<index_ps;i++)
            {
                if (ps[i].result == states.win)
                {
                    number_of_wins[ps[i].if_i_played_here] += 1;
                }
                if(ps[i].result==states.lose)
                {
                    number_of_wins[ps[i].if_i_played_here] -= 1;
                }
            }
            int minimum = -1000000;
            int play_here = -1;
            for(int i=0; i<9;i++)
            {
                if(number_of_wins[i]!=0&&number_of_wins[i]>minimum)
                {
                    minimum = number_of_wins[i];
                    play_here = i;
                }
            }
            return play_here;
        }
    }
}
