using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class VenusaurNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Venusaur";

        public override float commodity => 1f;

        public override PkmnInfo info => VenusaurInfo;

        public override int wildLevel => 1;

        public static PkmnInfo VenusaurInfo = new PkmnInfo
        {
            Name = "Venusaur",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<VenusaurPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class VenusaurPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Venusaur";
    }
}
