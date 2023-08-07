using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.GameContent.ItemDropRules;
using TerramonMod.Items.Consumable;

namespace TerramonMod.Items
{
    class NPCLoot : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, Terraria.ModLoader.NPCLoot npcLoot)
        {
            if (!npc.boss)
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RareCandy>(), 32));
            else
            {
                int amount = 0;
                switch (npc.type)
                {
                    case NPCID.KingSlime:
                    case NPCID.Deerclops:
                    case NPCID.QueenBee:
                    case NPCID.Spazmatism:
                    case NPCID.Retinazer:
                        amount = 3;
                        break;

                    case NPCID.EyeofCthulhu:
                    case NPCID.SkeletronHead:
                    case NPCID.BrainofCthulhu:
                        amount = 5;
                        break;

                    case NPCID.WallofFlesh:
                    case NPCID.QueenSlimeBoss:
                    case NPCID.SkeletronPrime:
                        amount = 7;
                        break;

                    case NPCID.Plantera:
                    case NPCID.Golem:
                    case NPCID.DukeFishron:
                        amount = 9;
                        break;

                    case NPCID.HallowBoss:
                    case NPCID.CultistBoss:
                    case NPCID.MoonLordHead:
                        amount = 11;
                        break;
                }

                if (Main.expertMode)
                    amount = (int)(amount * 1.5);
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RareCandy>(), minimumDropped: amount, maximumDropped: amount));
            }
        }

        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type == NPCID.Mechanic)
                foreach (var item in items)
                    if (item.IsAir)
                    {
                        item.SetDefaults(ModContent.ItemType<LinkCable>());
                        break;
                    }


        }
    }
}