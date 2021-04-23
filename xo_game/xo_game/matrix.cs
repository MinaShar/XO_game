using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo_game
{
    enum states
    {
        win,
        lose,
        nothing
    }
    class playstate
    {
        public int[] array_till_now;
        public int numberofplays;
        public states result;
        public int if_i_played_here;
        public int play_here;
        public playstate(int [] array_till_now,int number_of_plays,states result,int if_i_play_here)
        {
            this.array_till_now = new int[9];
            for(int i=0; i<9;i++)
            {
                this.array_till_now[i] = array_till_now[i];
            }
            numberofplays = number_of_plays;
            this.result = result;
            this.if_i_played_here = if_i_play_here;
        }
        public playstate copy()
        {
            return new playstate(this.array_till_now, this.numberofplays, this.result, this.if_i_played_here);
        }
    }
}
