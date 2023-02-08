using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class GyaradosNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gyarados";

        public override float commodity => 1f;

        public override PkmnInfo info => GyaradosInfo;

        public override int wildLevel => 1;

        public static PkmnInfo GyaradosInfo = new PkmnInfo
        {
            Name = "Gyarados",
            type1 = PkmnType.water,
            type2 = PkmnType.flying,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<GyaradosPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class GyaradosPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Gyarados";
    }
}
