using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace _1dv607Design.model
{
    public class Database
    {
        private readonly List<Member> _members;

        /// <summary>
        /// Read in text file
        /// </summary>
        public Database()
        {
            string json;
            using (var reader = new StreamReader(@"..\..\Data\RegistryData.json"))
            {
                json = reader.ReadToEnd();
            }

            _members = JsonConvert.DeserializeObject<List<Member>>(json);

        }

        public void Add(Member member)
        {
            _members.Add(member);
            Save();
        }

        public void Delete(int id)
        {
            foreach (var member in _members.Reverse<Member>())
            {
                if (member.Id == id)
                {
                    _members.Remove(member);
                }
            }
            Save();
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }

        public List<Member> RetrieveAll()
        {
            return _members;
        }

        public Member Retrieve(int id)
        {
            return _members.FirstOrDefault(member => member.Id == id);
        }

        public int GetUniqueId()
        {
            var highestId = 0;
            foreach (var member in _members)
            {
                if (member.Id > highestId)
                {
                    highestId = member.Id;
                }
            }
            return highestId + 1;
        }

        public void Save()
        {
            Console.WriteLine("Saving data");
        }
    }
}