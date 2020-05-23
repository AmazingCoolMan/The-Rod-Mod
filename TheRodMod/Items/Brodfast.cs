using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class Brodfast : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("A balanced breakfast... if you don't think about what's in it.");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(1787);
			item.width = 40;
			item.height = 40;
			item.useStyle = 2;
			item.value = 10000;
			item.rare = 2;
			item.consumable = true;
			item.maxStack = 5;
		}
		//1 in 500 drop from all mobs.
	}
}