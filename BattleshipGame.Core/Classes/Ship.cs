using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BattleshipGame.Core.Classes
{
    public abstract class Ship
    {
        public string Name { get; private set; }
        public string FirstLetterOfName => string.IsNullOrEmpty(Name)? string.Empty : Name.First().ToString();
        public int Size { get; private set; }
        public List<HitPosition> MaintainedPositions { get; set; } = new List<HitPosition>();

        public Ship(string name, int size)
        {
            Name = name;
            Size = size;
        }

        public bool HasBeenSunk()
        {
            return MaintainedPositions.TrueForAll(x => x.HasBeenHit);
        }

        public bool HasBattleshipBeenHit(int x, int y)
        {
            var position = new HitPosition(x, y);

            var positionHit = MaintainedPositions
                .Where(x => x.HasBeenHit == false && position.Equals(x))
                .FirstOrDefault();

            if (positionHit != null)
            {
                positionHit.HasBeenHit = true;
                return true;
            }

            return false;
        }

        public void AddMaintainedPositions(int x, int y)
        {
            if (Size <= MaintainedPositions.Count())
            {
                throw new IndexOutOfRangeException();
            }

            var position = new HitPosition(x, y);

            if (MaintainedPositions.Any(x => x.Equals(position)))
            {
                throw new InvalidOperationException();
            }

            MaintainedPositions.Add(position);
        }

        public void ResetMaintainedPosition()
        {
            MaintainedPositions = new List<HitPosition>();
        }
    }
}
