using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace TerramonMod.Pokemon
{
    public class PkmnData
    {
        //public int pkmn = -1;
        public string pkmn = null;
        public string Nickname = null;
        public bool isShiny = false;
        public int level = 1;

        public void Evolve()
        {
            if (IsEvolveReady() != 1)
                return;

            var info = GetInfo();
            pkmn = GetInfo().evolveInto;
            Main.NewText($"Congratulations! Your {info.Name} evolved into {GetInfo().Name}!", Color.Yellow);
        }

        public int IsEvolveReady()
        {
            var info = GetInfo();
            if (info.evolveAt == -1 || info.evolveInto == null)
                return -1;
            else if (level >= info.evolveAt)
                return 1;

            return 0;
        }

        public bool LevelUp(int howMany = 1)
        {
            if (level == 100)
                return false;

            level += howMany;
            if (level > 100)
                level = 100;
            return true;
        }

        public PkmnInfo GetInfo()
        {
            var poke = ModContent.Find<ModNPC>("TerramonMod", pkmn) as BasePkmn;
            //var poke = ModContent.GetModNPC(pkmn) as BasePkmn;
            return poke.info;
        }
        public string GetName()
        {
            if (Nickname == null)
                return GetInfo().Name;
            else
                return Nickname;
        }
        public override string ToString()
        {
            var info = GetInfo();

            string output = "";
            if (Nickname != null)
                output = $"{Nickname}: ";
            output += $"Level {level} {info.Name}. It is a {info.type1}";
            if (info.type2 != null)
                output += $"-{info.type2.Value}";
            output += " type.";
            return output;
        }
    }
}
