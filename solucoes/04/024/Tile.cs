using System;

namespace _024
{
    public class Tile
    {
        public int DefensePoints { get; private set; }
        public int EssentialPoints { get; private set; }
        public int LuxuryPoints { get; private set; }
        private TileType tileType;
        private TileSpecialization tileSpec;
        private static readonly Random rnd = new Random();

        public Tile()
        {

            Array type = Enum.GetValues(typeof(TileType));
            tileType = (TileType)type.GetValue(rnd.Next(type.Length));
            type = Enum.GetValues(typeof(TileSpecialization));
            tileSpec = (TileSpecialization)type.GetValue(rnd.Next(type.Length));
            SetPoints(tileSpec, tileType);
        }

        private void SetPoints(TileSpecialization tileSpec, TileType tileType)
        {
            switch (tileType)
            {
                case TileType.Desert:
                    DefensePoints = -1;
                    EssentialPoints = 0;
                    LuxuryPoints = 1;
                    break;
                case TileType.Grassland:
                    DefensePoints = 0;
                    EssentialPoints = 3;
                    LuxuryPoints = 0;
                    break;
                case TileType.Jungle:
                    DefensePoints = 1;
                    EssentialPoints = 1;
                    LuxuryPoints = 1;
                    break;
                case TileType.Mountain:
                    DefensePoints = 3;
                    EssentialPoints = 1;
                    LuxuryPoints = 1;
                    break;
            }


            switch (tileSpec)
            {
                case TileSpecialization.Fortress:
                    DefensePoints += 3;
                    LuxuryPoints -= 1;
                    break;
                case TileSpecialization.Gold:
                    LuxuryPoints += 4;
                    break;
                case TileSpecialization.Sheep:
                    EssentialPoints += 3;
                    break;
                case TileSpecialization.Vineyard:
                    EssentialPoints += 1;
                    LuxuryPoints += 1;
                    break;
            }
        }


        public override string ToString()
        {
            return $"Tile: {tileType} and {tileSpec}. \nDefense Points: {DefensePoints}. \nEssential Points: {EssentialPoints}. \nLuxury Points: {LuxuryPoints}.";
        }
    }
}
