using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        #region Mine related Variables
        int[][] MinePos = new int[6][];
      
        #endregion
        #region Finding random cell position
        //We designed 9*5 matrix
        //According to our android game, it should have 6 mines

        private void GetMinePositions()
        {
            int[] CoOrds = new int[2];
            #region MinePos Initialization
            for (int m = 0; m < MinePos.Length; m++)
            {
                MinePos[m] = new int[2];
            }
            #endregion
            for (int i = 0; i < MinePos.Length; i++)
            {
                if (GetUniqueMinePositions(i, ref MinePos, out CoOrds))//No need to make this method boolean
                {
                    MinePos[i] = CoOrds;
                }
            }
        }

        private bool GetUniqueMinePositions(int index, ref int[][] minePos, out int[] pos)
        {
            pos = new int[2];
            if (index == 0) //Don't check for repeatition among entire minePos
            {
                pos = GetTwoRandomNumbers();
                return true;
            }
            else
            {
                pos = CheckForRepeatetion(ref minePos);
            }
            return true;
        }

        private int[] CheckForRepeatetion(ref int[][] minePos)
        {
            int[] tempPos = new int[2];
            here:
            tempPos = GetTwoRandomNumbers();
            for (int j = 0; j < minePos.Length; j++)
            {
                bool IsFirstMatched = false;

                for (int k = 0; k < minePos[j].Length; k++)
                {
                    if (minePos[j][k] == tempPos[k])
                    {
                        if (!IsFirstMatched && k == 0)
                            IsFirstMatched = true;
                        else if (IsFirstMatched)
                        {
                            IsFirstMatched = true;
                            break;
                        }
                        else
                            IsFirstMatched = false;
                    }
                    else
                        IsFirstMatched = false;
                }

                if (IsFirstMatched)
                {
                    goto here;
                }
            }
            return tempPos;
        }

        private int[] GetTwoRandomNumbers()
        {
            int[] RamndomNumbers = new int[2];
            Random random = new Random();
            for (int i = 0; i < RamndomNumbers.Length; i++)
            {
                if (i == 0) //To find rowindex
                {
                    RamndomNumbers[i] = random.Next(0,8);
                }
                else //To find columnindex
                {
                    RamndomNumbers[i] = random.Next(0, 4);
                }
            }

            return RamndomNumbers;
        }

        #endregion

        private void Form1_Load(object sender, EventArgs e)
        {
            GetMinePositions();
        }
    }
}
