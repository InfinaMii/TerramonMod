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
		/*internal TestCanvas testCanvas;
		private UserInterface _testUI;
		public override void Load()
		{
			testCanvas = new TestCanvas();
			testCanvas.Activate();
			_testUI = new UserInterface();
			_testUI.SetState(testCanvas);
		}
		public override void UpdateUI(GameTime gameTime)
		{
			_testUI?.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int mouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (mouseTextIndex != -1)
			{
				layers.Insert(mouseTextIndex, new LegacyGameInterfaceLayer(
					"TerramonMod: A Description",
					delegate
					{
						_testUI.Draw(Main.spriteBatch, new GameTime());
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}*/
	}

}
