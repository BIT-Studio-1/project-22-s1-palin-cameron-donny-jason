﻿using System;
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
        public static string[] inventory = { " ", " ", " " };
        public static Item[] items = { new Item("small key", "Office"), new Item("large key", "Room 3"), new Item("doorknob", "Room 4"), new Item("crowbar", "Room 5") };
        public static string name;
        public static bool[] roomstatus = new bool[10];

        static void Main(string[] args)
        {

            #pragma warning disable CA1416 // Validate platform compatibility  // Removes the pesky warnings.
            Console.SetWindowSize(140, 40);
            #pragma warning restore CA1416 // Validate platform compatibility

            Console.Clear();

            NameWelcome();
            Intro();
            Office();
        }
        public static void Intro()
        {
            Console.WriteLine(@"
                                                                                                                                                                                        
                 
                                                                                                                                
____________________________________________________________________________________________________________________________________________






");

            //Update intro when story is decided
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

                Console.WriteLine();
                Console.WriteLine("You find yourself inside a small office room, having slid through the slightly open bottom window");
                Console.WriteLine("as you are scanning the room for any signs of a hidden lock safe you hear a vehicle approach and pull up\n");
                Console.WriteLine("the front door begins to creak open");
                Console.WriteLine("the only space between you and the men is a staircase and with short hallway leading to the front door.");
                Console.WriteLine("to your left you see a door leading to who knows what, and one behind you\n");
                Console.WriteLine(items);
                Console.Write($"Quick where do you want to go " + name + ":");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed

                switch (temp)
                {
                    case "pick up":
                    case "item":
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
                            Console.WriteLine("What item do you want to pick up?");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt], room);
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
                    case "behind":
                    case "back"://Ditto
                        RoomC();
                        break;
                    case "hallway":
                    case "front door":
                        Console.WriteLine("You walk straight into the very surprised people opening the front door. You are caught without discovering anything. \nGame Over.");
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
            string temp, room = "Room 3"; //Rename. Remember to rename the array with items
            string[] itemInRoom = new string[0];
            int tempInt;
            do
            {
                Console.WriteLine();
                Console.WriteLine("You are in a lounge with a long table in the middle, a fruit knife and a lighter on the table, and a wardrobe next to the door."); 
                Items(room, ref itemInRoom);
                Console.Write("Where do you want to go: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up?");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt], room);
                        }
                        fail = true;
                        break;
                    case "inventory":
                    case "inv":
                        Props();
                        fail = true;
                        break;
                    case "office":
                    case "go office"://Change to the cases you want
                        Office();
                        break;
                    case "behind":
                    case "back"://Change to the cases you want
                        //Pick a room to go to
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
        public static void RoomC()
        {
            bool fail;
            string temp, room = "Room 2"; //Rename. Remember to rename the array with items
            string[] itemInRoom = new string[0];
            int tempInt;
            do
            {
                Console.WriteLine(""); //Add description
                Items(room, ref itemInRoom);
                Console.Write("Where do you want to go: ");
                temp = Console.ReadLine().ToLower(); //Gets the command
                fail = false; //Sets the do while loop to end unless this is changed
                switch (temp)
                {
                    case "pick up":
                    case "item":
                        if (itemInRoom.Length == 0)
                        {
                            Console.WriteLine("There are no items in the room");
                        }
                        else if (itemInRoom.Length == 1)
                        {
                            PickUp(itemInRoom[0], room);
                        }
                        else
                        {
                            Console.WriteLine("What item do you want to pick up?");
                            ItemsList(itemInRoom);
                            tempInt = EnterInt("Input");
                            PickUp(itemInRoom[tempInt], room);
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
                    case "behind":
                    case "back"://Ditto
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
                    Console.WriteLine("[2] Drop Item 1");
                    Console.WriteLine("[3] Drop Item 1");
                    Console.WriteLine("[4] Don't Pick Up Item");
                    string drop = Console.ReadLine().ToLower();

                    switch (drop)
                    {
                        case "1":
                            Console.WriteLine($"Dropping {inventory[0]}");
                            MovingItem(inventory[0], room);
                            inventory[0] = item;
                            break;
                        case "2":
                            Console.WriteLine($"Dropping {inventory[1]}");
                            MovingItem(inventory[1], room);
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
            Console.WriteLine("Hit any key to continue");
            Pause();
            Console.Clear();
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
            for (int i = 0; i < items.Length; i++)
            {
                if (items[i].location == room)
                {
                    empty = false;
                    ret += $"There is a {items[i].item} on the floor";
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
To pick up items you must use 'Pick Up' rather than the item name.");
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
                Console.WriteLine($"Item {i}: {inventory[i]}");
            }
            Console.WriteLine("Hit any key to continue");
            Pause();
            Console.Clear();
        }

        public static void NameWelcome()
        {
                                                            // commented out for testing !! change towards the end!!
//            Thread.Sleep(500);
//            Console.Clear();
//            Console.WriteLine(@"
//                           █████████                        
//                          ███░░░░░███                        
//                         ░███    ░███    
//                         ░███████████   
//                         ░███    ░███    
//                         █████   █████   
//                        ░░░░░   ░░░░░   
                                                                                                    
                                                                                                          
//");
//            Thread.Sleep(500);
//            Console.Clear();
//            Console.WriteLine(@"
//                           █████████      ███████████                █████                     
//                          ███░░░░░███    ░░███░░░░░███              ░░███                    
//                         ░███    ░███     ░███    ░███  ██████    ███████    
//                         ░███████████     ░██████████  ░░░░░███  ███░░███    
//                         ░███░░░░░███     ░███░░░░░███  ███████ ░███ ░███    
//                         ░███    ░███     ░███    ░███ ███░░███ ░███ ░███    
//                         █████   █████    ███████████ ░░████████░░████████   
//                        ░░░░░   ░░░░░    ░░░░░░░░░░░   ░░░░░░░░  ░░░░░░░░   
                                                                                                    
                                                                                                    
                                                                                                            
//");
//            Thread.Sleep(500);
//            Console.Clear();
//            Console.WriteLine(@"
//                           █████████      ███████████                █████    ██████████                       
//                          ███░░░░░███    ░░███░░░░░███              ░░███    ░░███░░░░███                      
//                         ░███    ░███     ░███    ░███  ██████    ███████     ░███   ░░███  ██████   █████ ████
//                         ░███████████     ░██████████  ░░░░░███  ███░░███     ░███    ░███ ░░░░░███ ░░███ ░███ 
//                         ░███░░░░░███     ░███░░░░░███  ███████ ░███ ░███     ░███    ░███  ███████  ░███ ░███ 
//                         ░███    ░███     ░███    ░███ ███░░███ ░███ ░███     ░███    ███  ███░░███  ░███ ░███ 
//                         █████   █████    ███████████ ░░████████░░████████    ██████████  ░░████████ ░░███████ 
//                        ░░░░░   ░░░░░    ░░░░░░░░░░░   ░░░░░░░░  ░░░░░░░░    ░░░░░░░░░░    ░░░░░░░░   ░░░░░███ 
//                                                                                                      ███ ░███ 
//                                                                                                     ░░██████  
//                                                                                                      ░░░░░░          
//");

//            Thread.Sleep(500);
//            Console.Clear();
//            Console.WriteLine(@"
//                           █████████      ███████████                █████    ██████████                       
//                          ███░░░░░███    ░░███░░░░░███              ░░███    ░░███░░░░███                      
//                         ░███    ░███     ░███    ░███  ██████    ███████     ░███   ░░███  ██████   █████ ████
//                         ░███████████     ░██████████  ░░░░░███  ███░░███     ░███    ░███ ░░░░░███ ░░███ ░███ 
//                         ░███░░░░░███     ░███░░░░░███  ███████ ░███ ░███     ░███    ░███  ███████  ░███ ░███ 
//                         ░███    ░███     ░███    ░███ ███░░███ ░███ ░███     ░███    ███  ███░░███  ░███ ░███ 
//                         █████   █████    ███████████ ░░████████░░████████    ██████████  ░░████████ ░░███████ 
//                        ░░░░░   ░░░░░    ░░░░░░░░░░░   ░░░░░░░░  ░░░░░░░░    ░░░░░░░░░░    ░░░░░░░░   ░░░░░███ 
//                                                                                                      ███ ░███ 
//                                                                                                     ░░██████  
//                                                                                                      ░░░░░░    
//                        ---------------------------------------------------------------------------------------
//");           

                          









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
