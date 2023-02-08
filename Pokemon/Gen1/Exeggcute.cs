using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class ExeggcuteNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Exeggcute";

        public override float commodity => 1f;

        public override PkmnInfo info => ExeggcuteInfo;

        public override int wildLevel => 0;

        public static PkmnInfo ExeggcuteInfo = new PkmnInfo
        {
            Name = "Exeggcute",
            type1 = PkmnType.grass,
            type2 = PkmnType.psychic,
            captureRate = (float)90 / 255,
            petType = ModContent.ProjectileType<ExeggcutePet>(),
            evolveInto = null,//"[PokemonEvoName]NPC",
            evolveAt = 20 //TODO: grab this somehow
        };
    }

    class ExeggcutePet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Exeggcute";
    }
}
