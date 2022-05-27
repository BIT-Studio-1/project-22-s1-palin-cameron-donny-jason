using System;

namespace Group_Project
{
    internal class Program
    {
        public static string[] inventory = { " ", " ", " " };

        static void Main(string[] args)
        {
          
            Intro();
            RoomA();
        }
        public static void Intro()
        {
            Console.WriteLine(@"




)"
              
            //Put an intro here!
        }
        public static void RoomA()
        {
            bool fail, keyTaken = false;
            string temp;
            do
            {
                Console.WriteLine("You are standing in a themed place. You are facing north. \nThere is a door to your left and a passage to your right. Where do you go?");
                if (keyTaken == false)
                {
                    Console.WriteLine("There is also a key on the floor");
                }
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "key":
                    case "pick up":
                        if (keyTaken == false)
                        {
                            PickUp("Key");
                            keyTaken = true;
                        }
                        else
                        {
                            Console.WriteLine("You have already picked up the key");
                        }
                        fail = true;
                        break;
                    case "left":
                    case "west":
                    case "door":
                    case "open door":
                    case "go through door": //Listing cases. Can change depending on the theme.
                        RoomB();            //Go to room B
                        break;
                    case "right":
                    case "east":
                    case "passage":
                    case "go through passage": //Ditto
                        RoomC();
                        break;
                    case "?":
                    case "help":                //If they ask for help
                        Help();                 //Sending them to the help menu
                        fail = true;            //Making sure it loops again
                        break;
                    default:
                        Console.WriteLine("I can't understand that input. Please try again or type help for tips."); //Default if they don't put anything userful in
                        fail = true;            //Making sure it loops again
                        break;
                }
            } while (fail == true);             //Looping again if needed
        }
        public static void RoomB()
        {
            Console.WriteLine("You are in room B");
            Pause();
            //This is just here to ensure that you have made it to room b. Fill out later
        }
        public static void RoomC()
        {
            Console.WriteLine("You are in room C");
            Pause();
            //This is just here to ensure that you have made it to room c. Fill out later
        }
        public static void PickUp(string item)
        {
            bool full = true, added = false;
            for (int i = 0; i < inventory.Length; i++)
            {
                if ((inventory[i] == " ") && (added != true))
                {
                    inventory[i] = item;
                    added = true;
                    full = false;
                    Console.WriteLine($"{item} added to inventory.");
                }
            }
            if (full == true)
            {
                Console.WriteLine("Your inventory is full.");
                for (int i = 0; i < inventory.Length; i++)
                {
                    Console.WriteLine($"Slot {i + 1}: {inventory[i]}");
                }
                bool again = false;
                do
                {
                    Console.WriteLine("Would you like to drop slot 1, slot 2, slot 3, or nothing: ");
                    string drop = Console.ReadLine().ToLower();
                    switch (drop)
                    {
                        case "1":
                            Console.WriteLine($"Dropping {inventory[0]}");
                            inventory[0] = item;
                            break;
                        case "2":
                            Console.WriteLine($"Dropping {inventory[1]}");
                            inventory[1] = item;
                            break;
                        case "3":
                            Console.WriteLine($"Dropping {inventory[2]}");
                            inventory[2] = item;
                            break;
                        case "nothing":
                            Console.WriteLine($"Keeping the same inventory");
                            break;
                        default:
                            Console.WriteLine("Error. Input not recognized. Please try again.");
                            again = true;
                            break;
                    }
                } while (again == true);

            }
        }
        public static void Help()
        {
            Console.WriteLine("You are in the help area");
            Console.WriteLine("Press any key to continue");
            Pause();
            Console.Clear();
            //Have some general guidance for what stuff the program is looking for
        }
        public static void Pause() //Because I'm lazy and Pause(); is faster to type and doesn't cause issues if I use it multiple times.
        {
            _ = Console.ReadKey();
        }
    }
}
