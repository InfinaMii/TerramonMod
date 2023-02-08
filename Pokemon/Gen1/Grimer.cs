using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GrimerNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Grimer";

        public override float commodity => 1f;

        public override PkmnInfo info => GrimerInfo;

        public override int wildLevel => 0;

        public static PkmnInfo GrimerInfo = new PkmnInfo
        {
            Name = "Grimer",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<GrimerPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class GrimerPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Grimer";
    }
}
