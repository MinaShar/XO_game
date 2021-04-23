using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo_game
{
    class solve
    {
        int[] array;
        public solve(int [] arr)
        {
            array = arr;
        }
        public int[] choose_next_play(int[] arr)
        {
            test_play_effichency my_test_play_effichincy;
            int index_of_array_of_test_play_effichincy = 0; 
            int winner;
            int loser;
            int[] newarray = copy(arr);
            
                    playstate[] ps = new playstate[500000];
                    int index_of_ps = 0;
                    maximizer(new playstate(newarray,0,states.nothing,-1),ps,ref index_of_ps);
                    my_test_play_effichincy = new test_play_effichency(ps, index_of_ps);
               
            int play_here=get_index_best_play(my_test_play_effichincy);
            newarray[play_here] = 1;
            return newarray;
        }
        public int[] copy(int [] arr)
        {
            int[] newarray = new int[9];
            for(int i=0; i<9;i++)
            {
                newarray[i] = arr[i];
            }
            return newarray;
        }
        public int win_next_play(int[] arr, out int win_next_step)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[i] == 2)
                {
                    arr[i] = 1;
                    int result = check(arr);
                    if (result == 1)
                    {
                        arr[i] = 2;
                        win_next_step = i;
                        return 1;
                    }
                    arr[i] = 2;
                }
            }
            win_next_step = -1;
            return 0;
        }
        public int lose_next_play(int[] arr, out int lose_next_step)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[i] == 2)
                {
                    arr[i] = 0;
                    int result = check(arr);
                    if (result == -1)
                    {
                        arr[i] = 2;
                        lose_next_step = i;
                        return 1;
                    }
                    arr[i] = 2;
                }
            }
            lose_next_step = -1;
            return 0;
        }
        public void maximizer(playstate current,playstate[] ps,ref int index_of_ps)
        {
            int winner;
            int loser;
            int[] newarray = copy(current.array_till_now);
            if (current.result==states.nothing&&win_next_play(newarray, out winner) == 1)
            {
                ps[index_of_ps] = new playstate(copy(newarray), current.numberofplays+1, states.win,current.if_i_played_here==-1?winner:current.if_i_played_here);
                ps[index_of_ps++].play_here = winner;
                return;
            }
            if (current.result==states.nothing&&lose_next_play(newarray, out loser) == 1)
            {
                ps[index_of_ps] = new playstate(copy(newarray), current.numberofplays+2, states.lose,current.if_i_played_here==-1?loser:current.if_i_played_here);
                ps[index_of_ps++].play_here = loser;
                return;
            }
            arrays_of_minimizer all_minimizer_arrays=null;
            for (int i=0; i<9;i++)
            {
                if(newarray[i]==2)
                {
                    newarray[i] = 1;
                    if (current.if_i_played_here == -1)
                    {
                        all_minimizer_arrays = minimizer(new playstate(copy(newarray), current.numberofplays + 1, states.nothing, i));
                        ///arrays_of_minimizer new_minimizer_arrays = all_minimizer_arrays.copy();
                        for (int j = 0; j< all_minimizer_arrays.size; j++)
                        {
                            if (all_minimizer_arrays.ps[j].result == states.nothing)
                            {
                                maximizer(new playstate(copy(all_minimizer_arrays.all_arrays[j]), all_minimizer_arrays.ps[j].numberofplays, states.nothing, all_minimizer_arrays.ps[j].if_i_played_here), ps, ref index_of_ps);
                            }
                        }
                    }
                    else {
                        all_minimizer_arrays = minimizer(new playstate(copy(newarray), current.numberofplays + 1, states.nothing, current.if_i_played_here));
                        ///arrays_of_minimizer new_minimizer_arrays = all_minimizer_arrays.copy();
                        for (int j = 0; j < all_minimizer_arrays.size; j++)
                        {
                            if (all_minimizer_arrays.ps[j].result == states.nothing)
                            {
                                maximizer(new playstate(copy(all_minimizer_arrays.all_arrays[j]), all_minimizer_arrays.ps[j].numberofplays, states.nothing, all_minimizer_arrays.ps[j].if_i_played_here), ps, ref index_of_ps);
                            }
                        }
                    }
                    newarray[i] = 2;
                }
            }
        }
        public arrays_of_minimizer minimizer(playstate ps)
        {
            arrays_of_minimizer ar = new arrays_of_minimizer();
            for (int i=0; i<9;i++)
            {
                int[] newarray = copy(ps.array_till_now);
                if (newarray[i]==2)
                {
                    newarray[i] = 0;
                    ar.all_arrays[ar.size] = newarray;
                    int[] newnewarray = copy(newarray);
                    ar.ps[ar.size++] = new playstate(newnewarray, ps.numberofplays +1, states.nothing, ps.if_i_played_here);
                }
            }
            return ar;
        }
        public int check(int [] arr)
        {
            for(int i=0; i<9;i+=3)
            {
                if(arr[i]==arr[i+1]&&arr[i+2]==arr[i]&&arr[i]!=2)
                {
                    if (arr[i] == 0)
                        return -1;
                    if (arr[i] == 1)
                        return 1;
                }
            }
            for(int i=0; i<3;i++)
            {
                if(arr[i]==arr[i+3]&&arr[i]==arr[i+6])
                {
                    if (arr[i] == 0)
                        return -1;
                    if (arr[i] == 1)
                        return 1;
                }
            }
            if(arr[0]==arr[4]&&arr[0]==arr[8]&&arr[0]!=2)
            {
                if (arr[0] == 0)
                    return -1;
                if (arr[0] == 1)
                    return 1;
            }
            if (arr[2] == arr[4] && arr[2] == arr[6] && arr[2] != 2)
            {
                if (arr[2] == 0)
                    return -1;
                if (arr[2] == 1)
                    return 1;
            }
            return 5;
        }
        public int get_index_best_play(test_play_effichency ps)
        {
            int play_here=-1;
            int here;

            if (ps.get_minimum_number_of_plays_for_action(out here) >=3)
            {
                play_here = ps.get_play_with_maximum_number_of_wins();
                return play_here;
            }
            else if (play_here==-1)
            {
                ps.get_minimum_number_of_plays_for_action(out here);
                play_here = here;
            }
            
            return play_here;
        }
    }
}
