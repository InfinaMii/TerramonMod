using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KrabbyNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Krabby";

        public override float commodity => 1f;

        public override PkmnInfo info => KrabbyInfo;

        public override int wildLevel => 0;

        public static PkmnInfo KrabbyInfo = new PkmnInfo
        {
            Name = "Krabby",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)225 / 255,
            petType = ModContent.ProjectileType<KrabbyPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class KrabbyPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Krabby";
    }
}
