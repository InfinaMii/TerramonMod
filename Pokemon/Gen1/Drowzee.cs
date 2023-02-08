using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DrowzeeNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Drowzee";

        public override float commodity => 1f;

        public override PkmnInfo info => DrowzeeInfo;

        public override int wildLevel => 0;

        public static PkmnInfo DrowzeeInfo = new PkmnInfo
        {
            Name = "Drowzee",
            type1 = PkmnType.psychic,
            type2 = null,
            captureRate = (float)190 / 255,
            petType = ModContent.ProjectileType<DrowzeePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class DrowzeePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Drowzee";
    }
}
