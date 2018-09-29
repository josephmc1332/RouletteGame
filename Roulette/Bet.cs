using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Roulette
{
    class Bet
    {
        private int myBetAmount;

        public int MyBetAmount
        {
            get { return myBetAmount; }
            set { if (value > 0) myBetAmount = value; }
        }

        public int BetSelect { get; set; }

        private int myBalance = 100;

        public int GuessNumber { get; set; }

        public int MyBalance
        {
            get { return myBalance; }
            set { if (value > 0) myBalance = value; }
        }

        Table table = new Table();

        public void BetAmount()
        {
            Console.WriteLine($"Your balance is {MyBalance}");
            if (MyBalance <= 0)
            {
                Console.WriteLine("You lose");
                Console.ReadLine();
                Environment.Exit(0);
            }
            Console.WriteLine("How much would you like to bet?\n" +
                "Increments of 10 only\n" +
                "10 is minimum bet");
            MyBetAmount = Convert.ToInt32(Console.ReadLine());

            if (MyBetAmount > MyBalance)
            { Console.WriteLine("You don't have enough money"); BetAmount(); }

            Console.Clear();

            BetMenu();          
        }

        public void BetMenu()
        {
            Console.WriteLine("\t-----Bet Menu-----\n" +
                "\t\t 1. Numbers\n" +
                "\t\t 2. Evens/Odds\n" +
                "\t\t 3. Reds/Blacks\n" +
                "\t\t 4. Lows/Highs\n" +
                "\t\t 5. Dozens\n" +
                "\t\t 6. Columns\n" +
                "\t\t 7. Street\n" +
                "\t\t 8. 6 Numbers\n" +
                "\t\t 9. Split\n" +
                "\t\t 10. Corner");

            Console.WriteLine();

            Console.WriteLine($"Your bet amount: {MyBetAmount}. Please select your bet");
            int BetSelect = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            if (BetSelect == 1)
                Straight();
            if (BetSelect == 2)
                EvenOdds();
            if (BetSelect == 3)
                RedBlack();
            if (BetSelect == 4)
                LowsHighs();
            if (BetSelect == 5)
                Dozens();
            if (BetSelect == 6)
                Columns();
            if (BetSelect == 7)
                Street();
            if (BetSelect == 8)
                SixNumbers();
            if (BetSelect == 9)
                Split();
            if (BetSelect == 10)
                Corner();
        }

        public void Straight()
        {
            Console.WriteLine("What is your number?");
            GuessNumber = Convert.ToInt32(Console.ReadLine());

            table.SpinWheel();

            if (GuessNumber == table.MyNumber)
            {
                Console.WriteLine($"You won {MyBetAmount * 35} \n" +
                    $"You now have a balance of {MyBalance = MyBalance + (MyBetAmount * 35)}");

            }
            else
            {
                Console.WriteLine($"You lost\n" +
                    $"-{MyBetAmount} from your current balance\n" +
                    $"\t Your new balance is {MyBalance = MyBalance - MyBetAmount}");
            }
            //STRAIGHT
            if (GuessNumber != table.MyNumber)
            {
                Console.WriteLine($"Straight: {table.MyNumber}");
            }
            WinningBets();
            Console.ReadLine();
            Console.Clear();
            BetAmount();
        }

        public void EvenOdds()

        {
            Console.WriteLine("Evens or odds?");
            string response = Console.ReadLine();

            table.SpinWheel();
            Console.ReadLine();

            if(response == "evens")
            {
                if(table.MyNumber % 2 == 0)
                {
                    MyBalance = MyBalance + MyBetAmount;
                    Console.WriteLine($"You won {MyBetAmount}\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"\t Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }
            if (response == "odds")
            {
                if (table.MyNumber % 2 != 0)
                {
                    MyBalance = MyBalance + MyBetAmount;

                    Console.WriteLine($"You won {MyBetAmount}\n " +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();

                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"\t Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }

                

            }
            
        }

        public void RedBlack()
        {
            Console.WriteLine("Red or Black?");
            string response = Console.ReadLine();

            Console.Clear();

            table.SpinWheel();

            if(table.MyColor == response)
            {
                Console.WriteLine($"You won {MyBetAmount}");
                MyBalance = MyBalance + MyBetAmount;
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }
            else
            {
                Console.WriteLine($"You lost\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"\t Your new balance is {MyBalance = MyBalance - MyBetAmount}");
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }
        }

        public void LowsHighs()
        {
            Console.WriteLine("Low or High?");
            string response = Console.ReadLine();

            Console.Clear();

            table.SpinWheel();

            Console.WriteLine();

            if (response == "low" || response == "Low")
            {
                if(table.MyNumber <= 18)
                {
                    MyBalance = MyBalance + MyBetAmount;
                    Console.WriteLine($"You won {MyBetAmount}\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }
            if (response == "high" || response == "High")
            {
                if (table.MyNumber >= 19)
                {
                    MyBalance = MyBalance + MyBetAmount;
                    Console.WriteLine($"You won {MyBetAmount}\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();                    
                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }
            
        }

        public void Dozens()
        {
            Console.WriteLine("Pick your third: 1 – 12, 13 – 24, 25 – 36\n" +
                "Follow format: Number '-' Number");
            string response = Console.ReadLine();

            Console.Clear();

            table.SpinWheel();

            Console.WriteLine();

            if (response == "1 - 12")
            {
                if (table.MyNumber < 13)
                {
                    MyBalance = MyBalance + (MyBetAmount * 2);
                    Console.WriteLine($"You won {MyBetAmount * 2}\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost!\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }

            if (response == "13 - 24")
            {
                if (table.MyNumber > 12 && table.MyNumber < 25)
                {
                    MyBalance = MyBalance + (MyBetAmount * 2);
                    Console.WriteLine($"You won {MyBetAmount * 2}\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost!\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }

            if (response == "25 - 36")
            {
                if (table.MyNumber > 24)
                {
                    MyBalance = MyBalance + (MyBetAmount * 2);
                    Console.WriteLine($"You won {MyBetAmount * 2}\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
                else
                {
                    MyBalance = MyBalance - MyBetAmount;
                    Console.WriteLine($"You lost!\n" +
                        $"-{MyBetAmount} from your current balance\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }           
        }

        public void Columns()
        {
            Console.WriteLine("Pick your column\n" +
                              "\tColumn 1: \n" +
                              "\tColumn 2: \n" +
                              "\tColumn 3: ");
            int response = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            table.SpinWheel();

            Console.WriteLine();

            if (response == 1)
            {
                int[] Column1 = new int[12];
                Column1[0] = 1;

                for (int i = 1; i < Column1.Length; i++)
                {
                    Column1[i] = Column1[i - 1] + 3; 
                    
                }
                for(int i = 0; i < 12; i++)
                {              
                    if (table.MyNumber == Column1[i])
                    {
                        MyBalance = MyBalance + (MyBetAmount * 2);
                        Console.WriteLine($"You won {MyBetAmount * 2}\n" +
                            $"Your new balance is {MyBalance}");
                        Console.ReadLine();
                        WinningBets();
                        Console.ReadLine();
                        Console.Clear();
                        BetAmount();
                    }
                }
                MyBalance = MyBalance - MyBetAmount;
                Console.WriteLine($"You lost!\n" +
                    $"-{MyBetAmount} from your current balance\n" +
                    $"Your new balance is {MyBalance}");
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }

            if (response == 2)
            {
                int[] Column = new int[12];
                Column[0] = 2;

                for (int i = 1; i < Column.Length; i++)
                {
                    Column[i] = Column[i - 1] + 3;

                }
                for(int i = 0; i < 12; i++)
                {
                    if (table.MyNumber == Column[i])
                    {
                        MyBalance = MyBalance + (MyBetAmount * 2);
                        Console.WriteLine($"You won {MyBetAmount * 2}\n" +
                            $"Your new balance is {MyBalance}");
                        Console.ReadLine();
                        WinningBets();
                        Console.ReadLine();
                        Console.Clear();
                        BetAmount();
                    }
                }
                MyBalance = MyBalance - MyBetAmount;
                Console.WriteLine($"You lost!\n" +
                    $"-{MyBetAmount} from your current balance\n" +
                    $"Your new balance is {MyBalance}");
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }

            if (response == 3)
            {
                int[] Column = new int[12];
                Column[0] = 3;

                for (int i = 1; i < Column.Length; i++)
                {
                    Column[i] = Column[i - 1] + 3;

                }
                for(int i = 0; i < 12; i++)
                {
                    if (table.MyNumber == Column[i])
                    {
                        MyBalance = MyBalance + (MyBetAmount * 2);
                        Console.WriteLine($"You won {MyBetAmount * 2}\n" +
                            $"Your new balance is {MyBalance}");
                        Console.ReadLine();
                        WinningBets();
                        Console.ReadLine();
                        Console.Clear();
                        BetAmount();
                    }
                }
                MyBalance = MyBalance - MyBetAmount;
                Console.WriteLine($"You lost!\n" +
                    $"-{MyBetAmount} from your current balance\n" +
                    $"Your new balance is {MyBalance}");
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }
        }

        public void Street()
        {
            Console.WriteLine("What're your numbers? One at a time(lowest number first)");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());       
            int num3 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

            table.SpinWheel();

            Console.WriteLine();

            int[] column1 = new int[12];
            column1[0] = 1;
            int[] column2 = new int[12];
            column2[0] = 2;
            int[] column3 = new int[12];
            column3[0] = 3;

            for (int i = 1; i < 12; i++)
            {
                column1[i] = column1[i - 1] + 3;
                column2[i] = column2[i - 1] + 3;
                column3[i] = column3[i - 1] + 3;
            }
            for (int i = 0; i < 12; i++)
            {
                if (column1[i] == num1 && column2[i] == num2 && column3[i] == num3)
                {
                    if (table.MyNumber == num1 || table.MyNumber == num2 || table.MyNumber == num3)
                    {
                        MyBalance = MyBalance + (MyBetAmount * 11);
                        Console.WriteLine($"You won {MyBetAmount * 11}!\n" +
                            $"Your new balance is {MyBalance}");
                        Console.ReadLine();
                        WinningBets();
                        Console.ReadLine();
                        Console.Clear();
                        BetAmount();
                    }
                    else
                    {
                        MyBalance = MyBalance - MyBetAmount;
                        Console.WriteLine($"You lost!\n" +
                            $"-{MyBetAmount} you current balance\n" +
                            $"Your new balance is {MyBalance}");
                        Console.ReadLine();
                        WinningBets();
                        Console.ReadLine();
                        Console.Clear();
                        BetAmount();
                    }
                }
            }
                
                Console.WriteLine("That is not a valid street\n" +
                    "1-3\n" +
                    "4-6\n" +
                    "7-9\n" +
                    "10-12\n" +
                    "13-15\n" +
                    "16-18\n" +
                    "19-21\n" +
                    "22-24\n" +
                    "25-27\n" +
                    "28-30\n" +
                    "31-33\n" +
                    "34-36");
                Console.ReadLine();
                Console.Clear();
                BetAmount();
                
            
      
        }

        public void SixNumbers()
        {

            Console.WriteLine("What is the low number for your Double Street?");
            int lowNumber = Convert.ToInt32(Console.ReadLine());

            if (lowNumber > 30 || lowNumber < 1)
            {
                Console.WriteLine("That is not a valid double street low number.");
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }

            int[] doubleStreet = new int[6];

            for (int i = 0; i < 5; i++)
            {                
                doubleStreet[i] = lowNumber;

                for (int j = 1; j < 6; j++)
                {
                    doubleStreet[j] = doubleStreet[j - 1] + 1;
                }
                break;
            }

            Console.Clear();

            table.SpinWheel();

            Console.WriteLine();

            int[] column1 = new int[12];
            column1[0] = 1;
            int[] column2 = new int[12];
            column2[0] = 2;
            int[] column3 = new int[12];
            column3[0] = 3;

            for (int i = 1; i < 12; i++)
            {
                column1[i] = column1[i - 1] + 3;
                column2[i] = column2[i - 1] + 3;
                column3[i] = column3[i - 1] + 3;
            }
            for (int i = 0; i < 12; i++)
            {
                

                for (int j = 0; j < 6; j++)
                {
                    if (doubleStreet[j] == column1[i] && doubleStreet[j + 1] == column2[i] && doubleStreet[j + 2] == column3[i] &&
                        doubleStreet[j + 3] == column1[i + 1] && doubleStreet[j + 4] == column2[i + 1] && doubleStreet[j + 5] == column3[i + 1])
                    {
                        if (table.MyNumber == doubleStreet[i])
                        {
                            MyBalance = MyBalance + (MyBetAmount * 5);
                            Console.WriteLine($"You won {MyBetAmount * 5}\n" +
                                $"Your new balance is {MyBalance}");
                            Console.ReadLine();
                            WinningBets();
                            Console.ReadLine();
                            Console.Clear();
                            BetAmount();
                        }
                        else
                        {
                            MyBalance = MyBalance - MyBetAmount;
                            Console.WriteLine($"You lost!\n" +
                                $"-{MyBetAmount} from your current balance\n" +
                                $"Your new balance is {MyBalance}");
                            Console.ReadLine();
                            WinningBets();
                            Console.ReadLine();
                            Console.Clear();
                            BetAmount();
                        }
                    }                    
                }
                break;
            }          
           
                    
            Console.WriteLine("That is not a valid double street low number");
            Console.ReadLine();
            Console.Clear();
            BetAmount();
            
        }

        public void Split()
        {
            Console.WriteLine("What is your split? One at a time(Press Enter)");
            int split1 = Convert.ToInt32(Console.ReadLine());
            int split2 = Convert.ToInt32(Console.ReadLine());

            int[] column1 = new int[12];
            column1[0] = 1;
            int[] column2 = new int[12];
            column2[0] = 2;
            int[] column3 = new int[12];
            column3[0] = 3;
            
            for (int j = 1; j < 12; j++)
            {
                column3[j] = column3[j - 1] + 3;
                column1[j] = column1[j - 1] + 3;

                if (split1 == column1[j] && split2 == column3[j] || split2 - split1 != Math.Abs(1) && split2 - split1 != Math.Abs(3))
                {
                    Console.WriteLine("This is not a valid split");
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }           

            table.SpinWheel();

            if (split1 == table.MyNumber || split2 == table.MyNumber)
            {
                MyBalance = MyBalance + (MyBetAmount * 17);
                Console.WriteLine($"You won {MyBetAmount * 17}\n" +
                    $"Your new balance is {MyBalance}");
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }
            else
            {
                MyBalance = MyBalance - MyBetAmount;
                Console.WriteLine($"You lose!\n" +
                    $"-{MyBetAmount} from your current balance\n" +
                    $"your new balance is {MyBalance}");
                Console.ReadLine();
                WinningBets();
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }
        }

        public void Corner()
        {
            Console.WriteLine("What is the low number for your corner?");

            int c1 = Convert.ToInt32(Console.ReadLine());

            if (c1 % 3 == 0)
            {
                Console.WriteLine("That is not a valid corner");
                Console.ReadLine();
                Console.Clear();
                BetAmount();
            }

            int[] corner = new int[4];
            corner[0] = c1;

            for(int i = 1; i < 4; i++)
            {
               corner[i] = corner[i - 1] + 1;
               
            }
            corner[2] = corner[2] + 1;
            corner[3] = corner[2] + 1;

            table.SpinWheel();

            foreach (int co in corner)
            {
                if (table.MyNumber == co)
                {
                    MyBalance = MyBalance + (MyBetAmount * 8);
                    Console.WriteLine($"You won {MyBetAmount * 8}!\n" +
                        $"Your new balance is {MyBalance}");
                    Console.ReadLine();
                    WinningBets();
                    Console.ReadLine();
                    Console.Clear();
                    BetAmount();
                }
            }                                
            MyBalance = MyBalance - MyBetAmount;
            Console.WriteLine($"You lost!\n" +
                $"-{MyBetAmount} from your current balance\n" +
                $"Your new balance is {MyBalance}");
            Console.ReadLine();
            WinningBets();
            Console.ReadLine();
            Console.Clear();
            BetAmount();
                
                                              
        }

        public void WinningBets()
        {
            Console.WriteLine("You would have won with any of the following bets: ");
            Console.WriteLine();
            //evens or odds
            if (table.MyNumber % 2 == 0)
            {
                Console.WriteLine("Even/Odds Bet: Evens");
            }
            else
            {
                Console.WriteLine("Even/Odds Bet: Odds");
            }
            //low high
            if (table.MyNumber < 17)
            {
                Console.WriteLine("Low/High Bet: Low");
            }
            else
            {
                Console.WriteLine("Low/High Bet: High");
            }
            //red or black
            if (table.MyColor == "Black" || table.MyColor == "black")
            {
                Console.WriteLine("Color Bet: Black");
            }
            else
            {
                Console.WriteLine("Color Bet: Red");
            }

            //dozens
            if (table.MyNumber < 13)
            {
                Console.WriteLine("Dozens: 1 - 13");
            }
            if (table.MyNumber > 12 && table.MyNumber < 25)
            {
                Console.WriteLine("Dozens: 13 - 24");
            }
            if (table.MyNumber > 24 && table.MyNumber < 37)
            {
                Console.WriteLine("Dozens: 25 - 36");
            }
            //Columns
            int[] column1 = new int[12];
            column1[0] = 1;
            int[] column2 = new int[12];
            column2[0] = 2;
            int[] column3 = new int[12];
            column3[0] = 3;
            for (int i = 1; i < 12; i++)
            {
                column1[i] = column1[i - 1] + 3;
                column2[i] = column2[i - 1] + 3;
                column3[i] = column3[i - 1] + 3;
            }
            for (int i = 1; i < 12; i++)
            {
                if (column1[i] == table.MyNumber)
                {
                    Console.WriteLine("Column Bet: Column 1");
                }
                if (column2[i] == table.MyNumber)
                {
                    Console.WriteLine("Column Bet: Column 2");
                }
                if (column3[i] == table.MyNumber)
                {
                    Console.WriteLine("Column Bet: Column 3");
                }
            }
            //street
            int first = 0;
            int last = 0;
            for (int i = 0; i < 12; i++)
            {
                if (table.MyNumber == column1[i] || table.MyNumber == column2[i] || table.MyNumber == column3[i])
                {
                    first = column1[i];
                    last = column3[i];
                    Console.WriteLine($"Street: {first} - {last}");
                }
            }
            //6 numbers
            for (int i = 0; i < 12; i++)
            {
                if (table.MyNumber == column1[i] || table.MyNumber == column2[i] || table.MyNumber == column3[i])
                {
                    first = column1[i];
                    last = column3[i + 1];
                    if (first != 34)
                    {
                        Console.WriteLine($"Double Street: {first} - {last}");
                    }
                    first = column1[i - 1];
                    last = column3[i];
                    if (table.MyNumber != 1 || table.MyNumber != 2 || table.MyNumber != 3)
                    {
                        Console.WriteLine($"Double Street: {first} - {last}");
                    }

                }
            }
            //Split
            for (int i = 0; i < 12; i++)
            {
                if (table.MyNumber == column1[i])
                {

                    first = column1[i - 1];
                    int second = column2[i];
                    last = column1[i + 1];
                    if (table.MyNumber == 1)
                    {
                        Console.WriteLine($"Split: {column1[i]}/{second}, {column1[i]}/{last}");
                    }
                    else if (table.MyNumber == 34)
                    {
                        Console.WriteLine($"Split: {first}/{column1[i]}, {column1[i]}/{second}, {column1[i]}/{last}");
                    }
                    else
                    {
                        Console.WriteLine($"Split: {first}/{column1[i]}, {column1[i]}/{second}, {column1[i]}/{last}");
                    }
                }

                if (table.MyNumber == column2[i])
                {
                    first = column1[i];
                    int newsecond = column3[i];
                    int third = column2[i - 1];
                    last = column2[i + 1];
                    if (table.MyNumber == 2)
                    {
                        Console.WriteLine($"Split: {first}/{column2[i]}, {column2[i]}/{newsecond}, {last}/{column2[i]}");
                    }
                    if (table.MyNumber == 35)
                    {
                        Console.WriteLine($"Split: {first}/{column2[i]}, {column2[i]}/{newsecond}, {third}/{column2[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"Split: {first}/{column2[i]}, {column2[i]}/{newsecond}, {last}/{column2[i]}, {third}/{column2[i]}");
                    }
                }
                if (table.MyNumber == column3[i])
                {
                    first = column2[i];
                    int newsecond = column3[i + 1];
                    int third = column3[i - 1];
                    if (table.MyNumber == 3)
                    {
                        Console.WriteLine($"Split: {first}/{column3[i]}, {column3[i]}/{newsecond}");
                    }
                    if (table.MyNumber == 36)
                    {
                        Console.WriteLine($"Split: {first}/{column3[i]}, {third}/{column3[i]}");
                    }
                    else
                    {
                        Console.WriteLine($"Split: {first}/{column3[i]}, {third}/{column3[i]}, {newsecond}/{column3[i]}")
;
                    }
                }

            }
            //corners
            for (int i = 0; i < 12; i++)
            {

                if (table.MyNumber == column2[i])
                {
                    int downCenter = column2[i + 1];
                    int left = column1[i];
                    int right = column3[i];
                    int crossLeftDown = column1[i + 1];
                    int crossRightDown = column3[i + 1];
                    int crossUpLeft = column1[i - 1];
                    int crossupRight = column3[i - 1];
                    int upCenter = column2[i - 1];
                    if (table.MyNumber == 2)
                    {
                        Console.WriteLine($"Corner: {left}/{table.MyNumber}/{crossLeftDown}/{downCenter} or " +
                            $"{table.MyNumber}/{right}/{downCenter}/{crossRightDown}");
                    }
                    if (table.MyNumber == 35)
                    {
                        Console.WriteLine($"Corner: {crossUpLeft}/{upCenter}/{left}/{table.MyNumber} or " +
                            $"{upCenter}/{crossupRight}/{table.MyNumber}/{right}");
                    }
                    else
                    {
                        Console.WriteLine($"Corner: {crossUpLeft}/{upCenter}/{left}/{table.MyNumber} or " +
                            $"{upCenter}/{crossupRight}/{table.MyNumber}/{right} or " +
                            $"{left}/{table.MyNumber}/{crossLeftDown}/{downCenter} or " +
                            $"{table.MyNumber}/{right}/{downCenter}/{crossRightDown}");
                    }
                }
                if (table.MyNumber == column1[i])
                {
                    int up = column1[i - 1];
                    int down = column1[i + 1];
                    int right = column2[i];
                    int crossRightDown = column2[i + 1];
                    int crossupRight = column2[i - 1];


                    if (table.MyNumber == 1)
                    {
                        Console.WriteLine($"Corner: {table.MyNumber}/{right}/{down}/{crossRightDown}");
                    }
                    if (table.MyNumber == 34)
                    {
                        Console.WriteLine($"Corner: {up}/{crossupRight}/{table.MyNumber}/{right}");
                    }
                    else
                    {
                        Console.WriteLine($"Corner: {table.MyNumber}/{right}/{down}/{crossRightDown} or " +
                            $"{up}/{crossupRight}/{table.MyNumber}/{right}");
                    }
                }
                if (table.MyNumber == column3[i])
                {
                    int up = column3[i - 1];
                    int down = column3[i + 1];
                    int left = column2[i];
                    int crossLeftDown = column2[i + 1];
                    int crossupLeft = column2[i - 1];
                    if (table.MyNumber == 3)
                    {
                        Console.WriteLine($"Corner: {left}/{table.MyNumber}/{crossLeftDown}/{down}");
                    }
                    if (table.MyNumber == 36)
                    {
                        Console.WriteLine($"Corner: {crossupLeft}/{up}/{left}/{table.MyNumber}");
                    }
                    else
                    {
                        Console.WriteLine($"Corner: {left}/{table.MyNumber}/{crossLeftDown}/{down} or " +
                            $" {crossupLeft}/{up}/{left}/{table.MyNumber}");
                    }
                }
            }


        }
    }
}
