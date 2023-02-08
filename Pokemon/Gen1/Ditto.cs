using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DittoNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ditto";

        public override float commodity => 1f;

        public override PkmnInfo info => DittoInfo;

        public override int wildLevel => 0;

        public static PkmnInfo DittoInfo = new PkmnInfo
        {
            Name = "Ditto",
            type1 = PkmnType.normal,
            type2 = null,
            captureRate = (float)35 / 255,
            petType = ModContent.ProjectileType<DittoPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class DittoPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Ditto";
    }
}
