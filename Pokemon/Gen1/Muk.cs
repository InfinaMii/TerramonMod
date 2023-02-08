using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class MukNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Muk";

        public override float commodity => 1f;

        public override PkmnInfo info => MukInfo;

        public override int wildLevel => 1;

        public static PkmnInfo MukInfo = new PkmnInfo
        {
            Name = "Muk",
            type1 = PkmnType.poison,
            type2 = null,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<MukPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class MukPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Muk";
    }
}
