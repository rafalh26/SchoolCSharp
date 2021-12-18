// See https://aka.ms/new-console-template for more information


machine.MainMenu.mainMenu(); //inicialization



namespace machine
{    public class MainMenu
    {
        public static int[] itemPrice = new int[] { 32,28,0,51 };
        public static int userChoice = 0;
        public static int insertMoney = 0;
        public static int vendorMoney = 0;
        public static bool exitFlag = false;
        public static bool exitSubMenu = false;
        public static bool afterService = false;
        public static int[] availableCash = new int[] { 200, 100, 50, 20, 10} ;
        public static int[] coinCounter = new int[] {0,0,0,0,0} ;


        public static void mainMenu()
        {
            Console.WriteLine("Welcome to vending machine Freedome & Coke Joke! made by C#\n\n");

            userChoice = 0;

            Console.WriteLine("Insert Your Money");
            Console.WriteLine("\t\t\t\t\t\t This vending machine have accepts only"+availableCash[0]+", "+availableCash[1]+", " + availableCash[2] + ", " + availableCash[3] + ", " + availableCash[4] + " coins/bills");
             
            Vendor.userMoneyInput();
            


            while (exitFlag == false)
            {
                Console.WriteLine("\t\t\t\t\t\t\t\t\t money left:"+insertMoney);
                Console.WriteLine("What would U like to drink:");
                Console.WriteLine("1.) Coke and Code");
                Console.WriteLine("2.) C Empowered Struct Drink");
                Console.WriteLine("3.) C++ No better energy boost exist");
                Console.WriteLine("4.) Java me! Slow Mo turned on!");
                Console.WriteLine("5.) Tired of coding");
                //input exception handler
                try
                {
                    userChoice = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                switch (userChoice)
                {
                    case 1:
                        Console.WriteLine("Good choice however not the best");

                        Vendor.buyProduct(itemPrice[0]);
                        break;
                    case 2:
                        Console.WriteLine("Very good choice still not perfect");

                        Vendor.buyProduct(itemPrice[1]);
                        break;                            
                    case 3:
                        Console.WriteLine("Ur my Hero its best choice U could make");

                        Vendor.buyProduct(itemPrice[2]);
                        break;
                    case 4:
                        Console.WriteLine("Man try harder its ur worst choice");

                        Vendor.buyProduct(itemPrice[3]);
                        break;
                    case 5:
                        Console.WriteLine("- GET OUT OF MY SIGHT - there is never enough of coding");
                        exitFlag = true;
                        Vendor.mathVendor();
                        break;
                    case 552211:
                        Vendor.serviceStuff();
                        mainMenu();
                        break;
                    default:
                        Console.WriteLine("AM I A DUMB VENDING MACHINE? -> MAKE THE CORRECT CHOICE !!!");
                        continue;
                }
            }  
        }
    };
    public static class Vendor
    {
        public static void buyProduct(int productPrice)
        {
            Console.WriteLine("This product cost: "+ productPrice +"$");
            MainMenu.exitSubMenu = Vendor.yesNoProcessor(productPrice);
            if (MainMenu.exitSubMenu)
            {
                MainMenu.insertMoney -= productPrice;
            }
            else
            {
                Console.WriteLine("oreder canceled");
            }

        }
        public static void userMoneyInput()
        {
            try                 //input exception handler
            {
                int tmp = 0;
                Console.WriteLine("Enter amount of coin ur entering into vending machine:");
                Console.Write("200\t");
                tmp = int.Parse(Console.ReadLine());
                MainMenu.coinCounter[0] += tmp;
                tmp *= MainMenu.availableCash[0];
                MainMenu.insertMoney += tmp; tmp = 0;
                Console.Write("100\t");
                tmp = int.Parse(Console.ReadLine());
                MainMenu.coinCounter[1] += tmp;
                tmp *= MainMenu.availableCash[1];
                MainMenu.insertMoney += tmp; tmp = 0;
                Console.Write("50\t");
                tmp = int.Parse(Console.ReadLine());
                MainMenu.coinCounter[2] += tmp;
                tmp *= MainMenu.availableCash[2];
                MainMenu.insertMoney += tmp; tmp = 0;
                Console.Write("20\t");
                tmp = int.Parse(Console.ReadLine());
                MainMenu.coinCounter[3] += tmp;
                tmp *= MainMenu.availableCash[3];
                MainMenu.insertMoney += tmp; tmp = 0;
                Console.Write("10\t");
                tmp = int.Parse(Console.ReadLine());
                MainMenu.coinCounter[4] += tmp;
                tmp *= MainMenu.availableCash[4];
                MainMenu.insertMoney += tmp; tmp = 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Im not playing with you. Get out of my sight");
                MainMenu.exitFlag = true;
            }
        }
        public static bool yesNoProcessor(int price)
        {
            Console.WriteLine("\nDo U accept the price? Y/N");
            string choice;
            choice = Console.ReadLine();
            if ((MainMenu.insertMoney >= price) && (choice == "Y" || choice == "y" || choice == "YES" || choice == "yes" || choice == "Yes"))
            {
                return true;
            }
            else if (choice == "N" || choice == "n" || choice == "no" || choice == "NO" || choice == "No")
            {
                return false;
            }
            else if (MainMenu.insertMoney < price)
            {
                Console.WriteLine("Go to work and earn some cash! Then come back after I would love to eat ur money!!!");
                return false;
            }
            else
            {
                Console.WriteLine("AM I DUMB VENDING MACHINE? -> MAKE CORRECT CHOICE !!!");
                yesNoProcessor(0);
                return false;
            }
        }
        public static void serviceStuff()
        {
            short serviceChoice = 0;
            Console.WriteLine("Welcome my service boy what do U want me to do?");
            Console.WriteLine("1.) Withdraw Cash");
            Console.WriteLine("2.) Insert coins and restart machine");

            for (int i = 0; i < 5; i++) // to calc cash in machine
            {
                MainMenu.vendorMoney += MainMenu.coinCounter[i] * MainMenu.availableCash[i];
            }

            try
            {
                serviceChoice = short.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            switch (serviceChoice)
            {
                case 1:
                    Console.WriteLine("U received: "+MainMenu.vendorMoney);
                    Console.WriteLine("Thank You! Bye");
                    MainMenu.vendorMoney = 0;
                    MainMenu.insertMoney = 0;
                    for (int i = 0; i < 5; i++)
                    {
                        MainMenu.coinCounter[i] = 0;
                    }
                break;
                case 2:
                    Console.WriteLine("Enter amount of coin ur entering into vending machine:");
                    Console.Write("200\t");
                    MainMenu.coinCounter[0] += int.Parse(Console.ReadLine());
                    Console.Write("100\t");
                    MainMenu.coinCounter[1] += int.Parse(Console.ReadLine());
                    Console.Write("50\t");
                    MainMenu.coinCounter[2] += int.Parse(Console.ReadLine());
                    Console.Write("20\t");
                    MainMenu.coinCounter[3] += int.Parse(Console.ReadLine());
                    Console.Write("10\t");
                    MainMenu.coinCounter[4] += int.Parse(Console.ReadLine());

                    Console.WriteLine("Vendor have now: ");
                    for (int i = 0;i<5;i++)
                    {
                        Console.WriteLine(MainMenu.availableCash[i] + ": " + MainMenu.coinCounter[i]);
                    }
                break;
            }
        }
        public static void mathVendor() 
        {
            int[] gaveBack = { 0, 0, 0, 0, 0 };
            bool loopExit = false;

            while((loopExit==false)&&(MainMenu.insertMoney>=MainMenu.availableCash[4])&&(MainMenu.coinCounter[4]>0 || MainMenu.coinCounter[3]>0 || MainMenu.coinCounter[2]>0||MainMenu.coinCounter[1]>0||MainMenu.coinCounter[0]>0))
            {
                if(MainMenu.insertMoney>=MainMenu.availableCash[4] && MainMenu.insertMoney<MainMenu.availableCash[0] && (MainMenu.coinCounter[4] + MainMenu.coinCounter[3] + MainMenu.coinCounter[2] + MainMenu.coinCounter[1] == 0))
                {
                    loopExit = true;
                    break;
                }
                else if(MainMenu.insertMoney >= MainMenu.availableCash[4] && MainMenu.insertMoney < MainMenu.availableCash[1] && (MainMenu.coinCounter[4] + MainMenu.coinCounter[3] + MainMenu.coinCounter[2] == 0))
                {
                    loopExit=true;
                    break;
                }
                else if (MainMenu.insertMoney >= MainMenu.availableCash[4] && MainMenu.insertMoney < MainMenu.availableCash[2] && (MainMenu.coinCounter[4] + MainMenu.coinCounter[3] == 0))
                {
                    loopExit = true;
                    break;
                }
                else if (MainMenu.insertMoney >= MainMenu.availableCash[4] && MainMenu.insertMoney < MainMenu.availableCash[3] && MainMenu.coinCounter[4] == 0)
                {
                    loopExit = true;
                    break;
                }
                if (MainMenu.insertMoney>=MainMenu.availableCash[0] && MainMenu.coinCounter[0]>0)
                {
                    MainMenu.insertMoney -= MainMenu.availableCash[0];
                    gaveBack[0] += +1;
                    MainMenu.coinCounter[0] -= 1;
                }
                else if(MainMenu.insertMoney >= MainMenu.availableCash[1] && MainMenu.coinCounter[1] > 0)
                {
                    MainMenu.insertMoney -= MainMenu.availableCash[1];
                    gaveBack[1] += +1;
                    MainMenu.coinCounter[1] -= 1;
                }
                else if (MainMenu.insertMoney >= MainMenu.availableCash[2] && MainMenu.coinCounter[2] > 0)
                {
                    MainMenu.insertMoney -= MainMenu.availableCash[2];
                    gaveBack[2] += +1;
                    MainMenu.coinCounter[2] -= 1;
                }
                else if (MainMenu.insertMoney >= MainMenu.availableCash[3] && MainMenu.coinCounter[3] > 0)
                {
                    MainMenu.insertMoney -= MainMenu.availableCash[3];
                    gaveBack[3] += +1;
                    MainMenu.coinCounter[3] -= 1;
                }
                else if (MainMenu.insertMoney >= MainMenu.availableCash[4] && MainMenu.coinCounter[4] > 0)
                {
                    MainMenu.insertMoney -= MainMenu.availableCash[4];
                    gaveBack[4] += +1;
                    MainMenu.coinCounter[4] -= 1;
                }
            }





            System.Console.WriteLine("Here is Ur change: \n" + gaveBack[0] + " * " + MainMenu.availableCash[0]);
            System.Console.WriteLine(gaveBack[1] + " * " + MainMenu.availableCash[1]);
            System.Console.WriteLine(gaveBack[2] + " * " + MainMenu.availableCash[2]);
            System.Console.WriteLine(gaveBack[3] + " * " + MainMenu.availableCash[3]);
            System.Console.WriteLine(gaveBack[4] + " * " + MainMenu.availableCash[4]);
            Console.WriteLine("Also machine ate ur: "+MainMenu.insertMoney+" reson: Why do I need to explain anything? Im a boss here ur just a user ;)");
        }
    };
}