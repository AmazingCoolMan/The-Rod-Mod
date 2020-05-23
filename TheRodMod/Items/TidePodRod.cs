using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class TidePodRod : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Clears your debuffs. Keep out of reach of children ages 1-100.");
		}

		public override void SetDefaults() 
		{
			item.width = 40;
			item.height = 40;
			item.value = 30000;
			item.rare = 3;
			item.consumable = false;
			item.maxStack = 1;
			item.useStyle = 5;
		}
		public override bool CanUseItem(Player player) {
			for(int i = 0; i < 200; i++)
			{
				if(player.FindBuffIndex(i) != -1)
				{
					if(Main.debuff[i] == true)
					{
						if(i != 21)
						{
							player.ClearBuff(i);
						}
					}
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