using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class KinglerNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kingler";

        public override float commodity => 1f;

        public override PkmnInfo info => KinglerInfo;

        public override int wildLevel => 1;

        public static PkmnInfo KinglerInfo = new PkmnInfo
        {
            Name = "Kingler",
            type1 = PkmnType.water,
            type2 = null,
            captureRate = (float)60 / 255,
            petType = ModContent.ProjectileType<KinglerPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class KinglerPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Kingler";
    }
}
