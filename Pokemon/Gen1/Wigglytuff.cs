using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class WigglytuffNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Wigglytuff";

        public override float commodity => 1f;

        public override PkmnInfo info => WigglytuffInfo;

        public override int wildLevel => 1;

        public static PkmnInfo WigglytuffInfo = new PkmnInfo
        {
            Name = "Wigglytuff",
            type1 = PkmnType.normal,
            type2 = PkmnType.fairy,
            captureRate = (float)50 / 255,
            petType = ModContent.ProjectileType<WigglytuffPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class WigglytuffPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Wigglytuff";
    }
}
