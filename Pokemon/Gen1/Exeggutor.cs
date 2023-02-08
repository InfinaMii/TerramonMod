using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ExeggutorNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Exeggutor";

        public override float commodity => 1f;

        public override PkmnInfo info => ExeggutorInfo;

        public override int wildLevel => 1;

        public static PkmnInfo ExeggutorInfo = new PkmnInfo
        {
            Name = "Exeggutor",
            type1 = PkmnType.grass,
            type2 = PkmnType.psychic,
            captureRate = (float)45 / 255,
            petType = ModContent.ProjectileType<ExeggutorPet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class ExeggutorPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Exeggutor";
    }
}
