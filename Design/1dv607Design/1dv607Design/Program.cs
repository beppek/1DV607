
using System;
using _1dv607Design.controller;
using _1dv607Design.model;
using _1dv607Design.view;

namespace _1dv607Design
{
    public class Program
    {
        //private static MemberController _memberCtrl;
        private static RegistryView _view;

        /// <summary>
        /// Main method
        /// </summary>
        private static void Main()
        {
            //_memberCtrl = new MemberController();
            _view = new RegistryView();

            var menuSelection = _view.MainMenu();

            while (menuSelection != MenuSelection.Exit)
            {
                switch (menuSelection)
                {
                    case MenuSelection.AddMember:
                        _view.AddMember();
                        break;
                    case MenuSelection.ListMembers:
                        _view.ListMembers();
                        break;
                }

                menuSelection = _view.MainMenu();
            }
        }
    }
}
