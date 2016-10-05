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
        }

        public void Delete()
        {
            throw new System.NotImplementedException();
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
            return 3;
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}