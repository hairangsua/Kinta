using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    class CheckSudoku
    {

        //        var sample1 = new int[][]
        //{
        //                  new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9},
        //                  new int[] { 2, 3, 1, 5, 6, 4, 8, 9, 7},
        //                  new int[] { 3, 1, 2, 6, 4, 5, 9, 7, 8},
        //                  new int[] { 4, 5, 6, 7, 8, 9, 1, 2, 3},
        //                  new int[] { 5, 6, 4, 8, 9, 7, 2, 3, 1},
        //                  new int[] { 6, 4, 5, 9, 7, 8, 3, 1, 2},
        //                  new int[] { 7, 8, 9, 1, 2, 3, 4, 5, 6},
        //                  new int[] { 8, 9, 7, 2, 3, 1, 5, 6, 4},
        //                  new int[] { 9, 7, 8, 3, 1, 2, 6, 4, 5}
        //};

        //        var sample2 = new int[][]
        //                {
        //                      new int[] { 1, 2, 6, 3, 4, 7, 5, 9, 8},
        //                      new int[] { 7, 3, 5, 8, 1, 9, 6, 4, 2},
        //                      new int[] { 1, 9, 4, 2, 6, 5, 8, 7, 3},
        //                      new int[] { 3, 1, 7, 5, 8, 4, 2, 6, 9},
        //                      new int[] { 6, 5, 9, 1, 7, 2, 4, 3, 8},
        //                      new int[] { 4, 8, 2, 9, 3, 6, 7, 1, 5},
        //                      new int[] { 9, 4, 8, 7, 5, 1, 3, 2, 6},
        //                      new int[] { 5, 6, 1, 4, 2, 3, 9, 8, 7},
        //                      new int[] { 2, 7, 3, 6, 9, 8, 1, 5, 4}
        //                };


        //        var str = DoneOrNot(sample1);
        //        //var str2 = DoneOrNot(sample2);
        public static string DoneOrNot(int[][] board)
        {
            decimal GIAI_THUA = 1 * 2 * 3 * 4 * 5 * 6 * 7 * 8 * 9;
            var msg = "Try again!";

            if (board.Length > 9)
            {
                return msg;
            }

            decimal rowMulti = 1;
            decimal colsMulti = 1;
            for (int i = 0; i <= 8; i++)
            {
                if (board[i].Length > 9)
                {
                    return "Try again!";
                }
                for (int j = 0; j <= 8; j++)
                {
                    if (board[i][j] == 0)
                    {
                        return "Try again!";
                    }
                    var ngangele = board[i][j];
                    var docele = board[j][i];
                    rowMulti *= board[i][j];
                    colsMulti *= board[j][i];
                }
                if (rowMulti == GIAI_THUA && colsMulti == GIAI_THUA)
                {
                    msg = "Finished!";
                }
                else
                {
                    return "Try again!";
                }
                rowMulti = 1;
                colsMulti = 1;
            }

            return msg;
        }
    }
}
