using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class CrackedRodOfDiscord : ModItem
	{
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Once an extremely powerful magic rod, the energy is now scattered and not focused. Teleports you near the mouse, but not directly to it. \nThe unstable energy even allows you to teleport into blocks.");
		}

		public override void SetDefaults() 
		{
			item.CloneDefaults(2351);
			item.width = 40;
			item.height = 40;
			item.useStyle = 2;
			item.value = 100000;
			item.rare = 2;
			item.consumable = false;
			item.maxStack = 1;
		}
		public override bool UseItem(Player player)
		{
			if(Main.MouseWorld.X > 1000 && Main.MouseWorld.X < ((Main.maxTilesX*16)-1000) && Main.MouseWorld.Y > 1000 && Main.MouseWorld.Y < ((Main.maxTilesY*16)-1000))
			{
				Vector2 targetPosition;
				int num = Main.rand.Next(-100, 100);
				targetPosition.X = Main.MouseWorld.X + num;
				int numTwo = Main.rand.Next(-100, 100);
				targetPosition.Y = Main.MouseWorld.Y + numTwo;
				player.Teleport(targetPosition, 0, 0);
				if(player.FindBuffIndex(88) != -1){
					player.statLife = player.statLife/2;
					if(player.statLife < 10){
						player.Hurt(PlayerDeathReason.ByCustomReason(player.name + "didn't materialize"), 10, 0, false, true, false, 15);
					}
				}
				player.AddBuff(88, 400);
			}else{
				Main.NewText("You are too close to the world border. Try again when you're further away...");
			}
			return true;	
		}
		//Dropped by Wall of Flesh in Expert Mode
	}
}