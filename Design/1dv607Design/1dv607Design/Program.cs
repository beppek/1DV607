
using System;
using _1dv607Design.controller;
using _1dv607Design.view;

namespace _1dv607Design
{
    public class Program
    {
        private static void Main(string[] args)
        {
            Console.Title = "Member Registry";

            var memberCtrl = new MemberController();
            var view = new RegistryView();

            view.Welcome();

            var key = Console.ReadLine();
            int input;
            while (!int.TryParse(key, out input) || input > 6 || input < 1)
            {
                Console.WriteLine("Wrong input, try again...");
                key = Console.ReadLine();
                view.Welcome();
            }
            while (input != 6)
            {
                switch (input)
                {
                    case 1:
                        Console.WriteLine("How do you want to display the members? " +
                                          "\n(V)erbose or (C)ompact?");
                        var typeInput = Console.ReadLine();
                        while (typeInput == null || (typeInput.ToLower() != "v" && typeInput.ToLower() != "c"))
                        {
                            Console.WriteLine("Wrong input, try again.");
                            typeInput = Console.ReadLine();
                        }
                        var listType = typeInput.ToLower() == "v" ? ListType.Verbose : ListType.Compact;
                        var members = memberCtrl.RetrieveAll(listType);
                        if (listType == ListType.Compact)
                        {
                            view.DisplayMembersCompact(members);
                        }
                        else
                        {
                            view.DisplayMembersVerbose(members);
                        }

                        break;
                    case 2:
                        Console.WriteLine("Which member would you like to display?" +
                                          "\nInput id below.");
                        var idInput = Console.ReadLine();
                        int id;
                        while (idInput == null || !int.TryParse(idInput, out id))
                        {
                            Console.WriteLine("Wrong input, try inputting a number...");
                            idInput = Console.ReadLine();
                            Console.Clear();
                        }
                        var member = memberCtrl.Retrieve(id);
                        Console.WriteLine(member.ToString(ListType.Compact));
                        break;
                    case 3:
                        view.DisplayCreateMember();
                        Console.WriteLine("Name:");
                        var name = Console.ReadLine();
                        Console.WriteLine("Personal Number (10 digits):");
                        var numberInput = Console.ReadLine();
                        long personalNumber;
                        while (!long.TryParse(numberInput, out personalNumber))
                        {
                            Console.WriteLine("No good, personal number must be a number!");
                            numberInput = Console.ReadLine();
                            Console.Clear();
                        }
                        
                        memberCtrl.Create(name, personalNumber);
                        Console.Clear();
                        Console.WriteLine("Member successfully created!");
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Continue...");
                Console.ReadLine();
                view.Welcome();
                key = Console.ReadLine();
                while (!int.TryParse(key, out input) || input > 6 || input < 1)
                {
                    Console.WriteLine("Wrong input, try again...");
                    key = Console.ReadLine();
                    view.Welcome();
                }

            }
            
            
        }
    }
}
