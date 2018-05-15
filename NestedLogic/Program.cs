using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NestedLogic
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] returned = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();
            int[] due = Console.ReadLine().Split(' ').Select(n => Convert.ToInt32(n)).ToArray();

            Console.WriteLine(GetLateFee(returned, due));
        }

        public static int GetLateFee(int[] returned, int[] due)
        {
            //If later calender year than year due then flat fee of 10000.
            //If earlier then returned early and no late fee.
            if (returned[2] - due[2] > 0 || returned[2] - due[2] < 0)
                return returned[2] - due[2] < 0 ? 0 : 10000;
            //If same year but later calender month that month due, fee is 500 * number of months late.
            //If ealier then returned early and no late fee
            if (returned[1] - due[1] > 0 || returned[1] - due[1] < 0)
                return returned[1] - due[1] < 0 ? 0 : (returned[1] - due[1]) * 500;
            //If same year and month but day is after due date then fee is 15 * days late.
            //If ealier then returned early and no late fee.
            if (returned[0] - due[0] > 0 || returned[0] - due[0] < 0)
                return returned[1] - due[1] < 0 ? 0 : (returned[0] - due[0]) * 15;
            //Else returned on due date and no fee.
            else
                return 0;

        }
    }
}
