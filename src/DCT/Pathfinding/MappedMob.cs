using System;
using DCT.Outwar.World;

namespace DCT.Pathfinding
{
    internal class MappedMob : IComparable
    {
        internal string Name { get; private set; }
        internal int Room { get; private set; }
        internal long Id { get; private set; }
        internal long Level { get; private set; }
        internal long Rage { get; private set; }

        internal MappedMob(string name, long id, int room, long level, long rage)
        {
            Name = name;
            Id = id;
            Room = room;
            Level = level;
            Rage = rage;
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};", Name, Id, Room, Level, Rage);
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