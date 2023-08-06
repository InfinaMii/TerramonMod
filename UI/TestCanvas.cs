using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Reflection;
using TerramonMod.Pokemon;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ModLoader;
using Terraria.UI;

namespace TerramonMod.UI
{
    class TestCanvas : UIState
    {
        public string GetRandomPoke()
        {
            string targetNamespace = "TerramonMod.Pokemon.Gen1";
            Assembly assembly = Assembly.GetExecutingAssembly(); // or any other assembly where your classes reside

            Type[] types = assembly.GetTypes();
            string poke = null;

            do {
                var random = types[Main.rand.Next(0, types.Length - 1)];
                if (random.Namespace == targetNamespace && random.BaseType == typeof(BasePkmn))
                {
                    var randomPoke = (BasePkmn)Activator.CreateInstance(random);
                    if (randomPoke.wildLevel == 0)
                    poke = random.Name;
                }
            } 
            while (poke == null);

            poke = poke.Replace("NPC", null);
            poke = poke.Replace("Pet", null);

            return poke;
        }

        public override void OnInitialize()
        {
            //(test) add panel to ui
            UIPanel panel = new UIPanel();
            panel.Width.Set(0, 0.3f);
            panel.Height.Set(0, 0.3f);
            //panel.Left.Set(0, 0.5f - (panel.Width.Percent / 2));
            //panel.Top.Set(0, 0.45f - (panel.Width.Percent / 2));
            panel.HAlign = 0.5f;
            panel.VAlign = 0.45f;
            Append(panel);

            UIText text = new UIText("Choose your Starter Pokemon", 1.5f);
            text.HAlign = 0.5f;
            text.Top.Set(0, 0.05f);
            panel.Append(text);

            UIText nameText = new UIText("", 1.25f);
            nameText.HAlign = 0.5f;
            nameText.Top.Set(0, 0.85f);
            panel.Append(nameText);

            StarterPkmn starter1 = null;
            StarterPkmn starter2 = null;
            StarterPkmn starter3 = null;

            if (TerramonMod.randomStarters)
            {
                starter1 = new StarterPkmn(GetRandomPoke(), null, nameText);
                starter2 = new StarterPkmn(GetRandomPoke(), null, nameText);
                starter3 = new StarterPkmn(GetRandomPoke(), null, nameText);
            }
            else
            {
                starter1 = new StarterPkmn("Charmander", "Lizard", nameText);
                starter2 = new StarterPkmn("Squirtle", "Tiny Turtle", nameText);
                starter3 = new StarterPkmn("Bulbasaur", "Seed", nameText);
            }

            starter1.Width.Set(0, 0.2f);
            starter1.Height.Set(0, 0.2f);
            starter1.HAlign = 0.15f;
            starter1.VAlign = 0.5f;
            panel.Append(starter1);

            starter2.Width.Set(0, 0.2f);
            starter2.Height.Set(0, 0.2f);
            starter2.HAlign = 0.5f;
            starter2.VAlign = 0.5f;
            panel.Append(starter2);

            starter3.Width.Set(0, 0.2f);
            starter3.Height.Set(0, 0.2f);
            starter3.HAlign = 0.85f;
            starter3.VAlign = 0.5f;
            panel.Append(starter3);

        }
    }
}