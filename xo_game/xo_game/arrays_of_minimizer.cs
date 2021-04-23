using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xo_game
{
    class arrays_of_minimizer
    {
        public int[][] all_arrays = new int[9][];
        public int size;
        public playstate[] ps = new playstate[9];
        public arrays_of_minimizer()
        {
            size = 0;
            for(int i=0; i<9;i++)
            {
                all_arrays[i] = new int[9];
            }
        }
        public arrays_of_minimizer copy()
        {
            arrays_of_minimizer am = new arrays_of_minimizer();
            for(int i=0; i<9;i++)
            {
                for(int j=0; j<9;j++)
                {
                    am.all_arrays[i][j] = this.all_arrays[i][j];
                }
            }
            for(int i=0; i<this.size;i++)
            {
                am.ps[i] = this.ps[i].copy();
            }
            am.size = this.size;
            return am;
        }
    }
}
