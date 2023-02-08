using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace TerramonMod
{
    class TerramonConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [SeparatePage]
        [DefaultValue(false)]
        [Label("Fast Animations")]
        [Tooltip("Whether to use animations for things like Poke Balls")]
        public bool fastAnimations;
        public override void OnChanged()
        {
            TerramonMod.fastAnimations = fastAnimations;
        }
    }
}
