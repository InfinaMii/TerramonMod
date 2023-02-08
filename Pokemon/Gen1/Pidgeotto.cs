using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class PidgeottoNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pidgeotto";

        public override float commodity => 1f;

        public override PkmnInfo info => PidgeottoInfo;

        public override int wildLevel => 1;

        public static PkmnInfo PidgeottoInfo = new PkmnInfo
        {
            Name = "Pidgeotto",
            type1 = PkmnType.normal,
            type2 = PkmnType.flying,
            captureRate = (float)120 / 255,
            petType = ModContent.ProjectileType<PidgeottoPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class PidgeottoPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Pidgeotto";
    }
}
