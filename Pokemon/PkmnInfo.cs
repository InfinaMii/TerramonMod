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

        /*public string GetFileName()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Name.Length; i++)
            {
                if ((Name[i] >= 'A' && Name[i] <= 'z')) //Only add character to string if it's a letter (no spaces/special characters)
                {
                    sb.Append(Name[i]);
                }
            }

            return sb.ToString();
        }*/
    }
}
