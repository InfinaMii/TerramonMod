using Microsoft.Xna.Framework;
using System.Diagnostics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using TerramonMod;
using TerramonMod.Items;
using TerramonMod.Pokemon;

namespace TerramonMod.Commands
{
    internal class Nickname : ModCommand
    {
        public override CommandType Type => CommandType.Chat;

        public override string Command => "nickname";

        public override string Description => "Give a nickname to the currently summoned Pokemon.";

        public override string Usage => "/nickname";

        public override void Action(CommandCaller caller, string input, string[] args)
        {
            bool setName = true;
            if (args.Length == 0)
                setName = false;

            var pokemon = Main.player[Main.myPlayer].GetModPlayer<TerramonPlayer>().pokeInUse;

            if (pokemon != null)
            {
                var nickname = string.Join(" ", args);
                if (!setName || nickname == pokemon.data.GetInfo().Name)
                {
                    pokemon.data.Nickname = null;
                    Main.NewText($"Your {pokemon.data.GetName()}'s name has been reset.", Color.Yellow);
                }
                else
                {
                    Main.NewText($"Your Pokemon {pokemon.data.GetName()} has been given the name {nickname}.", Color.Yellow);
                    pokemon.data.Nickname = nickname;
                }
                pokemon.UpdateName();
            }
            else
                Main.NewText("No Pokemon is summoned!", Color.Red);

        }
    }
}