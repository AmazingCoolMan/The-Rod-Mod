using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class RodOfFilling : ModItem
	{
		int size = 1;
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Use to fill holes as deep as you want. Or build vertically. I don't make the rules!\nCreates dirt up to your mouse pointer, filling all blocks below it. Right click to change setting.");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.value = 50000;
			item.rare = 3;
			item.consumable = false;
			item.maxStack = 1;
			item.useStyle = 5;
			item.useTime = 25;    
            item.useAnimation = 25;	
		}
		public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
		{
			return true;
		}
		public override bool CanUseItem(Player player) {
			if (player.altFunctionUse == 2)
			{
				size++;
				if(size == 6)
				{
					size = 1;
					Main.NewText("Now filling a hole " + size + " tile wide.");
				}else{
					Main.NewText("Now filling holes " + size + " tiles wide.");
				}
			}else{
				int amountDown = 0;
				if(size == 1)
				{
					while(!Main.tile[(int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown)].active())
					{
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						amountDown++;
					}
				}
				if(size == 2)
				{
					while(!Main.tile[(int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown)].active())
					{
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-1), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						amountDown++;
					}
				}
				if(size == 3)
				{
					while(!Main.tile[(int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown)].active())
					{
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-1), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-2), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						amountDown++;
					}
				}
				if(size == 4)
				{
					while(!Main.tile[(int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown)].active())
					{
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-1), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-2), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-3), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						amountDown++;
					}
				}
				if(size == 5)
				{
					while(!Main.tile[(int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown)].active())
					{
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16, (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-1), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-2), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-3), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						WorldGen.PlaceTile((int)Main.MouseWorld.X/16 + (size-4), (int)(Main.MouseWorld.Y/16) + (amountDown),0);
						amountDown++;
					}
				}
			}
			return base.CanUseItem(player);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 999);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}