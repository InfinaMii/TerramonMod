using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.UI;
using TerramonMod.UI;
using Microsoft.Xna.Framework;
using Terraria;

namespace TerramonMod
{
    class TerramonSystem : ModSystem
    {
		internal TestCanvas terramonCanvas;
		internal UserInterface terramonUI;

        private GameTime _lastUpdateUiGameTime;

        public override void Load()
        {
            if (!Main.dedServ)
            {
                terramonUI = new UserInterface();

                terramonCanvas = new TestCanvas();
                terramonCanvas.Activate(); // Activate calls Initialize() on the UIState if not initialized and calls OnActivate, then calls Activate on every child element.
            }
        }

        public override void Unload()
        {
            terramonCanvas = null;
        }


        public override void UpdateUI(GameTime gameTime)
        {
            //update canvas and all of its elements
            _lastUpdateUiGameTime = gameTime;
            if (terramonUI?.CurrentState != null)
            {
                terramonUI.Update(gameTime);
            }
        }
        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            //add custom layer to ui and make it draw itself
            int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
            if (mouseTextIndex != -1)
            {
                layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
                    "TerramonMod: Terramon UI",
                    delegate
                    {
                        if (_lastUpdateUiGameTime != null && terramonUI?.CurrentState != null)
                        {
                            terramonUI.Draw(Main.spriteBatch, _lastUpdateUiGameTime);
                        }
                        return true;
                    },
                    InterfaceScaleType.UI));
            }
        }
        internal void ShowStarterUI()
        {
            terramonUI?.SetState(terramonCanvas);
        }

        internal void HideStarterUI()
        {
            terramonUI?.SetState(null);
        }
    }

}
