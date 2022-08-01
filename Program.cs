using System;
using System.IO;
using System.Threading;
namespace Group_Project
{
    internal class Program
    {
        public struct Item
        {
            public string item;
            public string location;
            public Item(string itm, string loc)
            {
                item = itm;
                location = loc;
            }
        }
        public static int playerHP = 20;
        public static string[] inventory = { " ", " ", " " };

        public static Item[] items = { new Item("key", "Office"),new Item ("knife", "Lounge"),new Item("lighter", "Lounge"), new Item("crowbar", "Attic"), new Item("evidence", "Safe"), new Item("fire extinguisher", "Electricity Distribution Room"),new Item("flashlight", "Electricity Distribution Room") };
        public static string name;
        public static bool safe = false;
        public static bool staff = true;
        public static bool death = false;

        static void Main(string[] args)
        {

            #pragma warning disable CA1416 // Validate platform compatibility  // Removes the pesky warnings.
            Console.SetWindowSize(140, 40);
            #pragma warning restore CA1416 // Validate platform compatibility
            string answer;
            bool repeat;
            do
            {
                repeat = false;
                NameWelcome();
                Intro();
                Office();
                if (death == true)
                {
                    Console.WriteLine("Well it looks like you tried something risky and you died!");
                }
                else if (safe == false)
                {
                    Console.WriteLine("You have escaped the house but never found the evidence you were searching for.");
                }
                else
                {                 
                    Console.WriteLine("As you dig inside the envelope to pull the evidence out a hand full of $100 notes appear");
                    Console.WriteLine("you run off through the yard to go turn the evidence in");
                }
                do
                {
                    Console.Write("Would you like to replay from the start (y/n): ");
                    answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        repeat = true;
                    }
                    else if (answer != "n")
                    {
                        Console.Write("Invalid Input!");
                        Pause();
                        Console.Clear();
                    }                                  
                } while ((answer != "y") && (answer != "n"));
            } while (repeat == true);
                   
        }
        public static void Intro()
        {
            Console.WriteLine("You find yourself inside a small office room, having sneaked through a slightly open bottom window.");
            Console.WriteLine("You scan the room for any signs of a hidden lock safe that will surely have the evidence you are looking for.");
            Console.WriteLine("Suddenly you hear loud a vehicle approach and pull up the driveway and moments later you hear voices outside the front door"); 
        }
    
        public static void Office()
        {
            bool fail;
            string temp, room = "Office", items;
            string[] itemInRoom = new string[0];
            int tempInt;
            items = Items(room, ref itemInRoom);
            do
            {
                Console.WriteLine("In front of you is a staircase and a short hallway leading to the front door.");
                Console.WriteLine("To your right you can see a Electricity Distribution Room");
                Console.WriteLine("To your left you see a door leading to who knows what, and there is another door behind you\n");
                
                Console.WriteLine(items);
                Console.Write($"Where do you want to go {name}: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                    case "grab":
                    case "take":
                    case "key":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        } else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                            items = Items(room, ref itemInRoom);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up: ");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt-1], room);
                            items = Items(room, ref itemInRoom);
                        }
                        fail = true;
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;                 
                    case "left":
                    case "go left"://Listing cases. Can change depending on the theme.
                        Lounge();            //Go to room B
                        break;
                    case "right":
                    case "go right":
                        ElectricityDistributionRoom();
                        break;
                    case "behind":
                    case "back"://Ditto
                        Attic();
                        break;
                    case "hallway":
                    case "front door":
                        Console.WriteLine("You walk straight into the very surprised group of large thuggish looking men opening the front door, You been captured");
                        death = true;
                        break;
                    case "?":
                    case "help":                //If they ask for help
                        Help();                 //Sending them to the help menu
                        fail = true;            //Making sure it loops again
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("I can't understand that input. Please try again or type help for tips.\n"); //Default if they don't put anything userful in
                        fail = true;            //Making sure it loops again
                        break;
                }
            } while (fail == true);             //Looping again if needed
        }

        public static void ElectricityDistributionRoom()
        {
            
            bool fail;
            string temp, room = "Electricity Distribution Room", items;
            string[] itemInRoom = new string[0];
            int tempInt;
            items = Items(room, ref itemInRoom);
            Console.Clear();
            do
            {
                Console.WriteLine("You are in the Electricity Distribution Room. There is a fire extinguisher and a flashlight on the wall on the right side of the door.");
                if(staff == true)
                {
                    Console.WriteLine("There is a staff member working with his back to you .");
                }
                
                Console.WriteLine(items);
                Console.Write($"Where do you want to go {name}: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                    case "grab":
                    case "fire extinguisher":
                    case "flashlight":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                            items = Items(room, ref itemInRoom);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up: ");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt - 1], room);
                            items = Items(room, ref itemInRoom);
                        }
                        if(staff == true)
                        {
                            Console.WriteLine("The sound of you taking something makes the staff turn around, the found out you didn't belong in this office");
                            Console.WriteLine("The staff came to you with a wrench. You can only choose to fight.");
                            Attack(15);
                            staff = false;
                        }
                        if (!death)
                        {
                            fail = true;
                        }
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;
                    case "office":
                    case "go office":
                    case "behind":
                    case "back":
                    case "stairs":
                    case "down":
                        Office();
                        break;
                    case "?":
                    case "help":                //If they ask for help
                        Help();                 //Sending them to the help menu
                        fail = true;            //Making sure it loops again
                        break;
                    
                    default:
                        Console.Clear();
                        Console.WriteLine("I can't understand that input. Please try again or type help for tips.\n"); //Default if they don't put anything userful in
                        fail = true;            //Making sure it loops again
                        break;
                }
            } while (fail == true);             //Looping again if needed
        }

        public static void Lounge()
        {
            bool fail;
            string temp, room = "Lounge", items; //Rename. Remember to rename the array with items
            string[] itemInRoom = new string[0];
            int tempInt;
            items = Items(room, ref itemInRoom);
            Console.Clear();
            do
            {
                Console.WriteLine("You are in a lounge with a long table in the middle and a wardrobe next to the door.\n" +
                    "There is a door directly in front of you and a hallway to your left as well as the door you just came through");
                Console.WriteLine(items);
                Console.Write($"Where do you want to go {name}: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                    case "grab":
                    case "take":
                    case "lighter":
                    case "knife":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                            items = Items(room, ref itemInRoom);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up: ");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt-1], room);
                            items = Items(room, ref itemInRoom);
                        }
                        fail = true;
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;
                    case "office":
                    case "go back":
                    case "back":
                    case "behind":
                    case "go office"://Change to the cases you want
                        Office();
                        break;
                    case "left":
                    case "go left":
                    case "hallway"://Change to the cases you want
                        Study();
                        break;
                    case "door":
                    case "front":
                    case "forwards":
                        Laundry();
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

        public static void Laundry()
        {
            bool fail;
            string temp, room = "Laundry", items; //Rename. Remember to rename the array with items
            string[] itemInRoom = new string[0];
            int tempInt;
            items = Items(room, ref itemInRoom);
            Console.Clear();
            do
            {
                Console.WriteLine("You enter a small room at the end of the house with a washing machine and a dryer\n" +
                    "In front of you is a window that you think you can fit through but have you done everything you wanted to do in the house?\n" +
                    "The only way out is behind you where you came.");
                Console.WriteLine(items);
                Console.Write($"Where do you want to go {name}: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                    case "grab":
                    case "take":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                            items = Items(room, ref itemInRoom);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up: ");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt - 1], room);
                            items = Items(room, ref itemInRoom);
                        }
                        fail = true;
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;
                    case "lounge":
                    case "go back":
                    case "back":
                    case "behind":
                    case "go lounge"://Change to the cases you want
                        Lounge();
                        break;
                    case "outside":
                    case "window":
                    case "front"://Change to the cases you want
                        Console.WriteLine("You squeeze out of the window and get outside");
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
        public static void Attic()
        {
            bool fail;
            string temp, room = "Attic", items; //Rename. Remember to rename the array with items
            string[] itemInRoom = new string[0];
            int tempInt;
            items = Items(room, ref itemInRoom);
            Console.Clear();
            do
            {
                Console.WriteLine("Behind the door is a steep set of stairs heading upwards. You climb them and arrive in a low-ceilinged attic.\n" +
                    "There are several empty boxes.\n" +
                    "The only way our you can see is down the same stairs you just came up\n");
                Console.WriteLine(items);
                Console.Write("Where do you want to go: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                    case "grab":
                    case "take":
                    case "crowbar":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                            items = Items(room, ref itemInRoom);
                        }
                        else
                        {
                            Console.WriteLine("What number item do you want to pick up: ");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt-1], room);
                            items = Items(room, ref itemInRoom);
                        }
                        fail = true;
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;
                    case "office":
                    case "go office":
                    case "behind":
                    case "back":
                    case "stairs":
                    case "down":
                        Office();
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
        public static void Study()
        {
            bool fail;
            string temp, room = "Study", items;
            string[] itemInRoom = new string[0];
            int tempInt;
            items = Items(room, ref itemInRoom);
            Console.Clear();
            do
            {
                Console.WriteLine("You enter a study with a desk to one side and a small window on the other.");
                if (safe == false)
                {
                    Console.WriteLine("The desk is clean but you notice a panel in the wall behind that looks as if it could store the information you need\n" +
                        "You don't see any obvious keyholes or ways of opening it. You could look for a hidden switch or button in this room, or you could try to find a less subtle way of opening it");
                }
                else
                {
                    Console.WriteLine("There is an open space behind the desk that is now empty");
                }
                Console.WriteLine("The window is much to small to fit through so the only exit is back the way you came.");
                Console.WriteLine(items);
                Console.Write($"Where do you want to go: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                    case "grab":
                    case "take":
                    case "key":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                            items = Items(room, ref itemInRoom);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up?");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt - 1], room);
                            items = Items(room, ref itemInRoom);
                        }
                        fail = true;
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;
                    case "crowbar":
                    case "use crowbar":
                        if (safe == false)
                        {
                            for (int i = 0; i < inventory.Length; i++)
                            {
                                if (inventory[i] == "crowbar")
                                {
                                    Console.WriteLine("You use the crowbar to pry open the panel and reveal the space behind");
                                    Pause();
                                    Safe();
                                    safe = true;
                                    Pause();
                                }
                            }
                            if (safe == false)
                            {
                                Console.WriteLine("You do not have a crowbar");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The safe is already open");
                            Pause();
                        }
                        fail=true;
                        break;
                    case "table":
                    case "desk":
                        Console.WriteLine("You don't see anything useful on top of the table");
                        Pause();
                        fail = true;
                        break;
                    case "under table":
                    case "look under table":
                    case "look under the table":
                    case "under desk":
                    case "look under desk":
                    case "look under the desk":
                        if (safe == false)
                        {
                            Console.WriteLine("You look under the table and see a button. You press it and the panel slides back revealing the space behind");
                            Pause();
                            Safe();
                            safe = true;
                            Pause();
                        }
                        else
                        {
                            Console.WriteLine("The safe is already open");
                            Pause();
                        }
                        fail = true;
                        break;
                    case "behind":
                    case "door":
                    case "back":
                        Lounge();
                        break;
                    case "?":
                    case "help":                //If they ask for help
                        Help();                 //Sending them to the help menu
                        fail = true;            //Making sure it loops again
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("I can't understand that input. Please try again or type help for tips.\n"); //Default if they don't put anything userful in
                        fail = true;            //Making sure it loops again
                        break;
                }
            } while (fail == true);             //Looping again if needed
        }
        public static void Safe()
        {
            Console.WriteLine("Inside there is a stack of papers in an envelope. This must be what you were looking for. You grab it and stuff it in your bag");
            PickUp("evidence", "Safe");
        }
        public static void PickUp(string item, string room)
        {
            bool full = true, added = false;
            for (int i = 0; i < inventory.Length; i++)
            {
                if ((inventory[i] == " ") && (added != true))
                {
                    inventory[i] = item;
                    MovingItem(item, "Inventory");
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
                    Console.WriteLine("What would you like to do? ");
                    Console.WriteLine("[1] Drop Item 1");
                    Console.WriteLine("[2] Drop Item 2");
                    Console.WriteLine("[3] Drop Item 3");
                    Console.WriteLine("[4] Don't Pick Up Item");
                    string drop = Console.ReadLine().ToLower();

                    switch (drop)
                    {
                        case "1":
                            Console.WriteLine($"Dropping {inventory[0]}");
                            MovingItem(inventory[0], room);
                            MovingItem(item, "Inventory");
                            inventory[0] = item;
                            break;
                        case "2":
                            Console.WriteLine($"Dropping {inventory[1]}");
                            MovingItem(inventory[1], room);
                            MovingItem(item, "Inventory");
                            inventory[1] = item;
                            break;
                        case "3":
                            Console.WriteLine($"Dropping {inventory[2]}");
                            MovingItem(inventory[2], room);
                            MovingItem(item, "Inventory");
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
        public static void MovingItem(string item, string room)
        {
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].item == item)
                {
                    items[i].location = room;
                }
            }
        }
        public static void ItemsList(string[] itemInRoom)
        {
            for (int i = 0;i < itemInRoom.Length; i++)
            {
                Console.WriteLine($"Item {i+1}: {itemInRoom[i]}");
            }
        }
        public static string Items(string room, ref string[] ItemInRoom)
        {
            string ret = "";
            bool empty = true;
            Array.Resize(ref ItemInRoom, 0);
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].location == room)
                {
                    empty = false;
                    ret += $"There is a {items[i].item} in the room\n";
                    Array.Resize(ref ItemInRoom, ItemInRoom.Length + 1);
                    ItemInRoom[ItemInRoom.Length - 1] = items[i].item;
                }
            }
            if (empty == true)
            {
                Array.Resize(ref ItemInRoom, 0);
            }
            return ret;
        }

        public static void Help()
        {
            Console.WriteLine(@"
            Welcome to the help screen!

This program looks for simple keywords such as:
'Left', 'Right', 'Key', 'West', 'East', 'Door', 'Passage'.
If you are having issues with inputting commands you are probably
trying to do more complex things than the game is capable of.
Try to use basic one or two word commands.
To pick up items you can use 'Pick up' rather than the item name.");
            Console.WriteLine("\nPress any key to continue");
            Pause();
            Console.Clear();
        }

        public static void Pause() //Because I'm lazy and Pause(); is faster to type and doesn't cause issues if I use it multiple times.
        {
            _ = Console.ReadKey();
        }

        public static void Props()
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                Console.WriteLine($"Item {i + 1}: {inventory[i]}");
            }
            Console.WriteLine("Hit any key to continue");
            Pause();
            Console.Clear();
        }
            
        //This is the attack method. I have reworked it so that there is a global player health variable. This means the method can be used again if needed. It also takes input for the computer health now
        //The idea is at base level it is simply attack and defence with a higher roll needed to hit if you are attacking someone defending. You can also pick up the knife or the crowbar which increase your damage
        public static void Attack(int compHP)
        {
            bool done = false;
            int i = 0;
            string weapon;
            int playerDMG = 0;
            int compDMG = 4;
            int computerAction;
            int toHit;
            Random rand = new Random();
            do //The loop for checking if there is a weapon in players inventory. Both weapons do the same damage so the first one found is used
            {
                if (inventory[i] == "crowbar" || inventory[i] == "knife")
                {
                    weapon = "a " + inventory[i];
                    Console.WriteLine($"You have a {weapon} that can help you in the battle");
                    done = true;
                    playerDMG = 6;
                }
                i++;
                if (i > inventory.Length)
                { 
                    done = true;
                    weapon = "your fists";
                    playerDMG = 4;
                }
            } while (!done);

            done = false;
            do
            {
                computerAction = rand.Next(0,2); // 0 is attack, 1 is defend
                Console.WriteLine("Would you like to attack or defend?");
                switch (Console.ReadLine().ToLower())
                {
                    case "attack":
                        if (computerAction == 0) //Both attack
                        {
                            toHit = rand.Next(0, 4);
                            if (toHit >= 1)
                            {
                                Console.WriteLine("You strike your enemy and hit a solid blow");
                                compHP -= playerDMG;
                            }
                            else
                            {
                                Console.WriteLine("You swing and miss");
                            }
                            toHit = rand.Next(0, 4);
                            if (toHit >= 1)
                            {
                                Console.WriteLine("Your enemy strikes you and hits a solid blow");
                                playerHP -= compDMG;
                            }
                            else
                            {
                                Console.WriteLine("Your enemy swings and misses");
                            }
                        }
                        else //Human attack, computer defend
                        {
                            toHit = rand.Next(0, 4);
                            if (toHit >= 2)
                            {
                                Console.WriteLine("You strike your enemy and hit a glancing blow");
                                compHP -= playerDMG / 2;
                            }
                            else
                            {
                                Console.WriteLine("You swing and miss");
                            }
                        }
                        break;
                    case "defend":
                        if (computerAction == 0) //Computer attack, Human defend
                        {
                            toHit = rand.Next(0,4);
                            if (toHit >= 2)
                            {
                                Console.WriteLine("Your enemy strikes you and hits a glancing blow");
                                playerHP -= compDMG/2;
                            }
                            else
                            {
                                Console.WriteLine("Your enemy swings at you and misses");
                            }

                        } else //Both defend
                        {
                            Console.WriteLine("You both warily defend yourself");
                        }
                        break;
                    default:
                        Console.WriteLine("Unknown input. Please input again.");
                        break;
                }
                if (compHP <= 0)
                {
                    Console.WriteLine("You finally fight off your assailant and leave them unconcious on the ground. They will hopefully be alright and not give you more trouble.");
                    done = true;
                }
                else if (playerHP <= 0)
                {
                    death = true;
                    done = true;
                }
            } while (!done);
        }

        public static void NameWelcome()
        {
            Console.WriteLine("Welcome To The Game");
            Console.Write("Please Enter Your Player Name: ");
            name = Console.ReadLine();
            Console.Clear();
        }
        public static int EnterInt(string desc) //Inputting, checking, and converting ints. You have to customize the input when calling.
        {
            bool isNumber;
            int tempint;
            do
            {
                Console.Write($"{desc}: ");
                string temp = Console.ReadLine();
                isNumber = int.TryParse(temp, out tempint); //Testing if the string is an int
                if (isNumber == false)
                {
                    Console.WriteLine("Invalid input. Please input whole numbers only"); //Error message if it isn't
                }
            } while (isNumber == false);
            return tempint;
        }
    }

}
