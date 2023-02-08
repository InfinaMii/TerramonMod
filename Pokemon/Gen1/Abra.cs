using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class AbraNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Abra";

        public override float commodity => 1f;

        public override PkmnInfo info => AbraInfo;

        public override int wildLevel => 0;

        public static PkmnInfo AbraInfo = new PkmnInfo
        {
            Name = "Abra",
            type1 = PkmnType.psychic,
            type2 = null,
            captureRate = (float)200 / 255,
            petType = ModContent.ProjectileType<AbraPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class AbraPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Abra";
    }
}
