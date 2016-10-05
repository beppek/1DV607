
using System;
using _1dv607Design.controller;
using _1dv607Design.view;

namespace _1dv607Design
{
    public class Program
    {
        private static MemberController _memberCtrl;
        private static RegistryView _view;

        private static void Main()
        {
            Console.Title = "Member Registry";

            _memberCtrl = new MemberController();
            _view = new RegistryView();

            MainMenu();
            
        }

        private static void MainMenu()
        {
            _view.Welcome();

            var key = Console.ReadLine();
            int input;
            while (!int.TryParse(key, out input) || input > 3 || input < 1)
            {
                _view.RenderWrongInput();
                key = Console.ReadLine();
                _view.Welcome();
            }
            while (input != 3)
            {
                switch (input)
                {
                    case 1:
                        ListMembers();
                        break;
                    case 2:
                        _view.DisplayCreateMember();
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

                        _memberCtrl.Create(name, personalNumber);
                        Console.Clear();
                        Console.WriteLine("Member successfully created!");
                        Console.WriteLine("Hit any key to go back to the menu...");
                        Console.ReadLine();
                        break;
                    default:
                        break;
                }

                _view.Welcome();
                key = Console.ReadLine();
                while (!int.TryParse(key, out input) || input > 3 || input < 1)
                {
                    _view.RenderWrongInput();
                    key = Console.ReadLine();
                    _view.Welcome();
                }

            }

            Environment.Exit(0);
        }

        private static void ListMembers()
        {
            Console.Clear();
            Console.WriteLine(
                            "How do you want to display the members? " +
                            "\n(V)erbose or (C)ompact?"
                            );
            var typeInput = Console.ReadLine();
            while (typeInput == null || (typeInput.ToLower() != "v" && typeInput.ToLower() != "c"))
            {
                _view.RenderWrongInput();
                typeInput = Console.ReadLine();
            }
            var listType = typeInput.ToLower() == "v" ? ListType.Verbose : ListType.Compact;
            var members = _memberCtrl.RetrieveAll(listType);
            if (listType == ListType.Compact)
            {
                _view.DisplayMembersCompact(members);
            }
            else
            {
                _view.DisplayMembersVerbose(members);
            }

            var idInput = Console.ReadLine();
            int id;
            while (!string.IsNullOrWhiteSpace(idInput) && (!int.TryParse(idInput, out id)))
            {
                _view.RenderWrongInput();
                idInput = Console.ReadLine();
            }

            if (idInput != null && (int.TryParse(idInput, out id)))
            {
                ViewMember(id);
            }
            
        }

        private static void ViewMember(int id)
        {
            var member = _memberCtrl.Retrieve(id);
            _view.DisplayMemberInfo(member.ToString(ListType.Verbose));

            var key = Console.ReadLine();
            int input;
            while (!int.TryParse(key, out input) || input > 7 || input < 1)
            {
                _view.RenderWrongInput();
                key = Console.ReadLine();
            }
            switch (input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    ListMembers();
                    break;
                case 7:
                    MainMenu();
                    break;
                default:
                    break;
            }
        }
    }
}
