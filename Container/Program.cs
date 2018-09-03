using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] bars = new int[] { 3,0,0,2,0,4 };
            Console.WriteLine(FindWater(bars));
            Console.Read();
        }

        private static int FindWater(int[] bars)
        {
            if (bars.Length <= 0)
            {
                throw new ArgumentNullException("Invalid argument!..");
            }

            int[] leftTallestBar = new int[bars.Length];
            int[] rightTallestBar = new int[bars.Length];

            FindTallestLeftBar(bars, leftTallestBar);
            FindTallestRightBar(bars, rightTallestBar);
            return FindMaxWater(leftTallestBar, rightTallestBar, bars);
        }

        private static void FindTallestLeftBar(int[] bars, int[] leftTallestBar)
        {            
            leftTallestBar[0] = -1;
            for (int i = 1; i < bars.Length; i++)
            {
                leftTallestBar[i] = Math.Max(bars[i - 1], leftTallestBar[i - 1]);
            }
        }

        private static void FindTallestRightBar(int[] bars,int[] rightTallestBar)
        {
            int barsLength = bars.Length -2;
            rightTallestBar[bars.Length - 1] = -1;
            for (int i = barsLength; i >= 0; i--)
            {
                rightTallestBar[i] = Math.Max(bars[i + 1], rightTallestBar[i + 1]);
            }
        }

        private static int FindMaxWater(int[] leftTallestBar, int[] rightTallestBar, int[] bars)
        {
            int i = 1;
            int maxWater = 0;
            while (i < bars.Length -1)
            {
                int diff = Math.Min(leftTallestBar[i], rightTallestBar[i]) - bars[i];
                if (diff > 0)
                {
                    maxWater += diff;
                }
                i++;
            }

            return maxWater;
        }
    }
}
