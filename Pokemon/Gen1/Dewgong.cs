using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Terraria;
using Terraria.ModLoader;
using static TerramonMod.TerramonMod;

namespace TerramonMod.Pokemon.Gen1
{
    class DewgongNPC : BasePkmn
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dewgong";

        public override float commodity => 1f;

        public override PkmnInfo info => DewgongInfo;

        public override int wildLevel => 1;

        public static PkmnInfo DewgongInfo = new PkmnInfo
        {
            Name = "Dewgong",
            type1 = PkmnType.water,
            type2 = PkmnType.ice,
            captureRate = (float)75 / 255,
            petType = ModContent.ProjectileType<DewgongPet>(),
            evolveInto = "DewgongNPC",
            evolveAt = -1
        };
    }

    class DewgongPet : BasePkmnPet
    {
        public override string Texture => "TerramonMod/Pokemon/Gen1/Dewgong";
	    public override bool doesFly => false;
    }
}
