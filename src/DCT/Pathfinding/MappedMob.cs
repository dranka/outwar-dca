using System;

namespace DCT.Pathfinding
{
    internal class MappedMob : IComparable
    {
        internal string Name { get; private set; }
        internal int Room { get; private set; }
        internal long Id { get; private set; }
        internal long Level { get; private set; }
        internal long Rage { get; private set; }

        internal MappedMob(string token)
        {
            string[] parts = token.Split(new char[] {';'});

            Name = parts[0];
            Id = int.Parse(parts[1]);
            Room = int.Parse(parts[2]);
            Level = long.Parse(parts[3]);
            Rage = long.Parse(parts[4]);
        }

        public int CompareTo(object other)
        {
            if(other.GetType() != typeof(MappedMob))
            {
                throw new Exception("Invalid mob compare type: " + other.GetType());
            }
            MappedMob mb = (MappedMob) other;
            return Name.CompareTo(mb.Name);
        }
    }
}