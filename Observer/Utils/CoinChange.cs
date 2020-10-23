using System.Collections.Generic;

namespace VendingMachine.Observer.Utils
{
    public class CoinChange
    {
        private double []deno = {.1, .2, .5, 1,
               20, 50 };
        private int[] initalCapacity ={12,20,30,6,1,1};

        public CoinChange() { 
        }
        public List<double> CalculateChange(double remaining)
        {
            List<double> returnChanged =new List<double>();
            for(int i = deno.Length - 1;i>=0; i--)
            {
                while (true)
                {
                    double change = deno[i] - remaining;
                    int capacity = initalCapacity[i];
                    if (change > 0 && capacity > 0)
                    {
                        remaining = change;
                        initalCapacity[i]--;
                        returnChanged.Add(deno[i]);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (remaining != 0)
            {
                return new List<double>();
            }
            else
            {
                return returnChanged;
            }
        }

    }
}
