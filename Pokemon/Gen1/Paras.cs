using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ParasNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Paras";

        public override float commodity => 1f;

        public override PkmnInfo info => ParasInfo;

        public override int wildLevel => 0;

        public static PkmnInfo ParasInfo = new PkmnInfo
        {
            Name = "Paras",
            type1 = PkmnType.bug,
            type2 = PkmnType.grass,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<ParasPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class ParasPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Paras";
    }
}
