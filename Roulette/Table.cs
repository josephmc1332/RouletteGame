using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class Table
    {
      
        public int MyNumber { get; set; }
        public string MyColor { get; set; }


        string[] colors = new string[36];

        int[] numbers = new int[36];

        Random rdm = new Random();

        

        public void SpinWheel()
        {
            
            for (int i = 0; i < 36; i++)
            {
                numbers[i] = rdm.Next(0,35);
                
            }
            for (int i = 0; i < 17; i++)
            {
                colors[i] = "red";
            }
            for(int j = 17; j < 36; j++)
            {
                colors[j] = "black";
            }

            //Adding double 0 to number array
            numbers[rdm.Next(0, 35)] = 00;

            //throwing ball into wheel & receiving a random winning number
            MyNumber = numbers[rdm.Next(0, 35)];
            
            //Receives a random color from the wheel
            MyColor = colors[rdm.Next(0, 35)];

            //ensuring double 0 & 0 is green 
            if(MyNumber == 0 || MyNumber == 00)
            {
                MyColor = "Green";
            }

            //output of method
            Console.WriteLine($"You landed on {MyNumber}, {MyColor}");
        }


    }
}
