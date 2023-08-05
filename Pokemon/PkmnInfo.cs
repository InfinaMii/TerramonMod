using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon
{
    public class PkmnInfo
    {
        public int gen = 1;
        public string Name = null;
        public PkmnType type1 = PkmnType.normal;
        public PkmnType? type2 = null;
        public string evolveInto = null;
        public int petType = -1;
        public float captureRate = 0;
        public int evolveAt = -1;
        public PkmnEvo[] evolutionMethods;
    }

    public class PkmnEvo
    {
        public string pokemon = null;
        public int? level = null;
        public string item = null;
    }
}
