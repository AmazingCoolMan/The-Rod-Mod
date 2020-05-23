using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class RodOfHousing : ModItem
	{
		int theIterator;
		int blockType = 30;
		int wallType = 4;
		int originalUpdateCount  = -80000;
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Back in my day we had to build houses by hand... Not anymore.\nRight click to switch to stone houses, and again to switch back to wood.\nUsable once per day.");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.value = 100000;
			item.rare = 3;
			item.consumable = false;
			item.maxStack = 1;
			item.useStyle = 5;
		}
		public override bool AltFunctionUse(Player player)//You use this to allow the item to be right clicked
		{
			return true;
		}
		public override bool CanUseItem(Player player) {
			//What to do if right click:
			if (player.altFunctionUse == 2) {
				if(theIterator % 2 == 0)
				{
					blockType = 1;
					wallType = 1;
					Main.NewText("Now placing stone houses.");
				}
				if(theIterator % 2 != 0)
				{
					blockType = 30;
					wallType = 4;
					Main.NewText("Now placing wooden houses.");
				}
				theIterator++;
			}
			
			//What to do normally
			else {
				if(Main.GameUpdateCount >= originalUpdateCount + 80000)
				{
					Vector2 topLeftHouse;
					int topLeftHouseX = (int)Main.MouseWorld.X;
					int topLeftHouseY = (int)Main.MouseWorld.Y - 80;
					//Places roof
					for(int i = 0; i < 160; i=i+16)
					{
						WorldGen.PlaceTile((topLeftHouseX + i)/16,topLeftHouseY/16,blockType);
					}
					//Places left wall
					for(int i = 0; i < 80; i=i+16)
					{
						WorldGen.PlaceTile(topLeftHouseX/16,(topLeftHouseY + i)/16,blockType);
					}
					//Places floor
					for(int i = 0; i < 160; i=i+16)
					{
						WorldGen.PlaceTile((topLeftHouseX + i)/16,(topLeftHouseY + 80)/16,blockType);
					}
					//Places the one block above the door
					WorldGen.PlaceTile((topLeftHouseX + 144)/16,(topLeftHouseY + 16)/16,blockType);
					//Places the door
					WorldGen.PlaceTile((topLeftHouseX + 144)/16,(topLeftHouseY + 64)/16,10);
					//Places the walls
					for(int i = 0; i < 128; i=i+16)
					{
						for(int j = 0; j < 64; j=j+16)
						{
							WorldGen.PlaceWall((topLeftHouseX + 16 + i)/16,(topLeftHouseY + 16 + j)/16,wallType);
						}
					}
					//Places torches
					WorldGen.PlaceTile((topLeftHouseX + 16)/16,(topLeftHouseY + 16)/16,4);
					WorldGen.PlaceTile((topLeftHouseX + 128)/16,(topLeftHouseY + 16)/16,4);
					//Places table and chair
					WorldGen.PlaceTile((topLeftHouseX + 48)/16,(topLeftHouseY + 64)/16,14);
					WorldGen.PlaceTile((topLeftHouseX + 80)/16,(topLeftHouseY + 64)/16,15);
					originalUpdateCount = (int)Main.GameUpdateCount;
				}else{
					Main.NewText("Please wait 24 (in game) hours to use this after using it once.");
				}
			}
			return base.CanUseItem(player);
		}
		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 300);
			recipe.AddIngredient(ItemID.StoneBlock, 300);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}