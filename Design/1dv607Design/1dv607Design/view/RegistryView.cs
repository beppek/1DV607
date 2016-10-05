using System;
using System.Collections.Generic;

namespace _1dv607Design.view
{
    public class RegistryView
    {

        /// <summary>
        /// Display welcome message
        /// </summary>
        public void Welcome()
        {
            Console.Clear();
            Console.WriteLine(
                "Welcome to the boat club member registry. " +
                "\nSelect from the menu below by inputting corresponding number." +
                "\n1 Display Member List" +
                "\n2 Display Member by id" +
                "\n3 Add New Member" +
                "\n4 Delete Member by id" +
                "\n5 Update Member by id" +
                "\n6 Exit Program"
              );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberList"></param>
        public void DisplayMembersCompact(List<string> memberList)
        {
            Console.Clear();
            Console.WriteLine($"{"|Name|", 15} {"|ID|", 21} {"|Number of Boats|", 24}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var member in memberList)
            {
                Console.WriteLine($"{member}\n");
            }
        }

        public void DisplayMembersVerbose(List<string> memberList)
        {
            Console.Clear();
            Console.WriteLine($"{"|Name|",15} {"|Personal Number|",25} {"|Number of Boats|",20} {"|Boats|", 10}");
            Console.WriteLine("--------------------------------------------------------------------------------");
            foreach (var member in memberList)
            {
                Console.WriteLine($"{member}\n");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        public void DisplayMemberInfo(string member)
        {
            Console.WriteLine(member);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boat"></param>
        public void DisplayBoatInfo(string boat)
        {
            Console.WriteLine(boat);
        }

        public void DisplayCreateMember()
        {
            Console.Clear();
            Console.WriteLine(
                "Create New Member" +
                "\nInput member name and personal number below"
                );
        }
    }
}