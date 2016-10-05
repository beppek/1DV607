using System.Collections.Generic;
using System.Linq;
using _1dv607Design.model;

namespace _1dv607Design.controller
{
    public class MemberController
    {
        private readonly Database _db = new Database();
        public void Delete()
        {
            throw new System.NotImplementedException();
        }

        public void Create(string name, long personalNumber)
        {
            var id = _db.GetUniqueId();
            var member = new Member(name, personalNumber, id);
            _db.Add(member);
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public Member Retrieve(int id)
        {
            var member = _db.Retrieve(id);
            return member;
        }

        public List<string> RetrieveAll(ListType listType)
        {
            var members = _db.RetrieveAll();
            List<string> membersStringList = members.Select(member => member.ToString(listType)).ToList();

            return membersStringList;
        }
    }
}