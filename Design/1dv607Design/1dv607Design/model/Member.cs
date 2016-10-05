using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace _1dv607Design.model
{
    public class Member
    {
        //Make array of boats
        private readonly List<Boat> _boatsOwned;
        private long _personalNumber;

        /// <summary>
        /// Constructor for member
        /// </summary>
        /// <param name="name"></param>
        /// <param name="personalNumber"></param>
        /// <param name="id"></param>
        public Member(string name, long personalNumber, int id)
        {
            Name = name;
            PersonalNumber = personalNumber;
            Id = id;
            _boatsOwned = new List<Boat>();
        }

        /// <summary>
        /// Auto property for Name
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Property for name
        /// </summary>
        public long PersonalNumber
        {
            get { return _personalNumber; }

            set
            {
                if (value.ToString().Length != 10)
                {
                    throw new ArgumentException("Personal Number needs 10 digits");
                }
                _personalNumber = value;
            }
        }

        /// <summary>
        /// Auto property for Id
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// Make array of boats
        /// </summary>
        public IReadOnlyList<Boat> BoatsOwned => _boatsOwned.AsReadOnly();

        /// <summary>
        /// Register boat to user
        /// </summary>
        /// <param name="boat"></param>
        public void RegisterBoat(Boat boat)
        {
            _boatsOwned.Add(boat);
        }

        /// <summary>
        /// Delete boat
        /// </summary>
        /// <param name="boat"></param>
        public void DeleteBoat(Boat boat)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Update boat info
        /// </summary>
        /// <param name="boat"></param>
        public void UpdateBoat(Boat boat)
        {
            throw new System.NotImplementedException();
        }

        public string ToString(ListType listType)
        {
            if (listType == ListType.Compact)
            {
                return $"{Name, 20} {Id, 15} {BoatsOwned.Count, 14}";
            }
            var boats = string.Join("\n\t", BoatsToString());
            return $"Name: {Name}\n" +
                   $"Personal Number: {PersonalNumber}\n" +
                   $"ID: {Id}\n" +
                   $"Boats: \t{boats}";

        }

        public List<string> BoatsToString()
        {
            return BoatsOwned.Select(boat => boat.ToString()).ToList();
        }
    }
}