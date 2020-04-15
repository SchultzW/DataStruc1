using System;


namespace DataLab1
{
    class Program
    {
        public static ArrayInt myArray;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            int size = SetSize();
            myArray = new ArrayInt(size);
            Console.WriteLine("How many numbers do you want to put into your array? Whole numbers only...");
            int input = int.Parse(Console.ReadLine());
            FillArray(input);
            DisplayArray(myArray);
            TestGetAt();
            TestSetAt();
            TestGetSize();
            TestSetSize();
            TestAppend();
            TestInsertAt();
            TestRemoveAt();
            Console.WriteLine("Finished!");
            
        }
        public static int SetSize()
        {
            
            Console.WriteLine("How large an Array would you like to make?");
            try
            {
                
                string input= Console.ReadLine();
                int size=CheckSize(input);
                return size;
            }
            catch
            {
                return -1;
            }
        }
        public static int CheckSize(string input)
        {
            
            try
            {
                int size = int.Parse(input);
                return size;
            }
            catch
            {
                Console.WriteLine("Something went wrong...");
                SetSize();
            }
            return -1;
           
            
        }
        public static void FillArray(int size)
        {
            string test = "FillArray";
            Random random = new Random();
            try
            {
                
                for (int i = 0; i <= size-1; i++)
                {
                    int num = random.Next(1, 99);
                    myArray.SetAt(i, num);
                }
            }
            catch
            {
                Console.WriteLine("You broke me. All you had to do was type in a number what is so hard about that?");
                //Start process, friendly name is something like MyApp.exe (from current bin directory)
                TestAgain("FillArray");
            }
        }
        public static void DisplayArray(ArrayInt a)
        {
            string message = "";
            int j = 1;
            Console.WriteLine("Your array has:");
            for (int i = 0; i <= a.GetSize(); i++, j++)
            {
                if (j % 5 == 0)
                {
                    j = 0;
                    message += " " + a.GetAt(i).ToString() + System.Environment.NewLine;

                }
                else
                {

                    message += " " + a.GetAt(i).ToString() + " ";
                }
            }
            Console.Write(message + System.Environment.NewLine);
        }
        public static void TestGetAt()
        {
            string test = "GetAt";
            Console.WriteLine("We will test GetAt. Which Index Would you like to see?");
            try
            {
                int input = int.Parse(Console.ReadLine());
                int output = myArray.GetAt(input);
                Console.WriteLine("You selected index " + input + " which returned " + output);
                TestAgain(test);
                
            }
            catch
            {
                ErrorAsk(test);

            }
            
        }
        public static void TestAgain(string test)
        {
            Console.WriteLine("Would you like to try again? Yes or no");
            string input = Console.ReadLine();
            try
            {
                input = input.ToLower();
                input.Trim();
                if (input == "yes")
                {
                    switch(test)
                    {
                        case "GetAt":
                            TestGetAt();
                            break;
                        case "SetAt":
                            TestSetAt();
                            break;
                        case "GetSize":
                            TestGetSize();
                            break;
                        case "Append":
                            TestAppend();
                            break;
                        case "SetSize":
                            TestSetSize();
                            break;
                        case "InsertAt":
                            TestInsertAt();
                            break;
                        case "RemoveAt":
                            TestRemoveAt();
                            break;
                        case "FillArray":
                            SetSize();
                            break;
                        default:
                            Console.WriteLine("Case Statement Failure");
                            break;                          
                    }
                }
                else if (input == "no")
                {
                    Console.WriteLine("Moving to next test");
                    Console.WriteLine("////////////////////////////////////////////////////////////////");
                }
            }
            catch
            {
                Console.WriteLine("Something went wrong, its not you its me....");
                //Start process, friendly name is something like MyApp.exe (from current bin directory)
                System.Diagnostics.Process.Start(System.AppDomain.CurrentDomain.FriendlyName);

                //Close the current process
                Environment.Exit(0);
            }
        }
        public static void ErrorAsk(string test)
        {
            Console.WriteLine("Somthing is wrong with your input try again with a whole number.");
            switch (test)
            {
                case "GetAt":
                    TestGetAt();
                    break;
                case "SetAt":
                    TestSetAt();
                    break;
                case "GetSize":
                    TestGetSize();
                    break;
                case "Append":
                    TestAppend();
                    break;
                case "SetSize":
                    TestSetSize();
                    break;
                case "InsertAt":
                    TestInsertAt();
                    break;
                case "RemoveAt":
                    TestRemoveAt();
                    break;
                case "FillArray":
                    SetSize();
                    break;
                default:
                    Console.WriteLine("Case Statement Failure");
                    break;
            }

        }
        public static void TestSetAt()
        {
            string test = "SetAt";
            Console.WriteLine("We will test SetAt. Which Index Would you like to change?");
            DisplayArray(myArray);
            try
            {
                int index=int.Parse(Console.ReadLine());
                Console.WriteLine("What value?(between 1-99)");
                int val = int.Parse(Console.ReadLine());
                myArray.SetAt(index, val);
                Console.WriteLine("Here is your new array:");
                DisplayArray(myArray);
                TestAgain(test);
            }
            catch
            {
                
                ErrorAsk(test);
            
            }
        }
        public static void TestGetSize()
        {
            string test = "GetSize";
            Console.WriteLine("Now testing GetSize");
            try
            {
                int size = myArray.GetSize();
                Console.WriteLine("Your array's size is:" + size);
                DisplayArray(myArray);
                TestAgain(test);
            }
            catch
            {
                ErrorAsk(test);
            }
        }
        public static void TestAppend()
        {
            string test = "Append";
            Console.WriteLine("Now we will append a value to your array. Enter a number.");
            try
            {
               int val= int.Parse(Console.ReadLine());

                myArray.Append(val);
                DisplayArray(myArray);
                TestAgain(test);
            }
            catch
            {
                ErrorAsk(test);
            }
        }
        public static void TestInsertAt()
        {
            string test = "InsertAt";
            Console.WriteLine("We will now test InsertAt at a index location");
            try
            {
                Console.WriteLine("What number would you like to insert?");
                int val = int.Parse(Console.ReadLine());
                Console.WriteLine("What index would you like to insert?");
                int index= int.Parse(Console.ReadLine());
                myArray.InsertAt(index, val);
                DisplayArray(myArray);
                TestAgain(test);
            }
            catch
            {
                ErrorAsk(test);
            }
        }
        public static void TestSetSize()
        {
            string test = "SetSize";

            Console.WriteLine("We will change the size of the array. Currently your size is"+myArray.GetSize());
            try
            {
                Console.WriteLine("What is the new size?");
                int val = int.Parse(Console.ReadLine());
                myArray.SetSize(val);
                int size=myArray.GetSize();
                Console.WriteLine("Size is " + size);
                DisplayArray(myArray);
                TestAgain(test);
            }
            catch
            {
                ErrorAsk(test);
            }


        }
        public static void TestRemoveAt()
        {
            string test = "RemoveAt";

            Console.WriteLine("We will now remove a value at an index");
            try
            {
                Console.WriteLine("Where would you like to remove from?");
                int val = int.Parse(Console.ReadLine());
                int ele=myArray.RemoveAt(val);
                Console.WriteLine(ele + " was removed");
                DisplayArray(myArray);
                TestAgain(test);
            }
            catch
            {
                ErrorAsk(test);
            }
        }
    }
}
