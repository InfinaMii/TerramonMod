using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GloomNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gloom";

        public override float commodity => 1f;

        public override PkmnInfo info => GloomInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GloomInfo = new PkmnInfo
        {
            Name = "Gloom",
            type1 = PkmnType.grass,
            type2 = PkmnType.poison,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<GloomPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class GloomPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gloom";
    }
}
