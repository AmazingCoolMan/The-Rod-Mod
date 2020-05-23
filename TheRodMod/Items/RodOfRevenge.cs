using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class RodOfRevenge : ModItem
	{
		int originalDamage = 10;
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Get your revenge on enemies by dealing more damage as you take damage.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.magic = true;
            item.damage = originalDamage;   //The damage stat for the Weapon.                      
            item.width = 80;      //The size of the width of the hitbox in pixels.
            item.height = 80;      //The size of the height of the hitbox in pixels.
            item.useTime = 50;     //How fast the Weapon is used.
            item.useAnimation = 50;			//How long the Weapon is used for.
			item.knockBack = 4;
			item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge   
            item.value = Item.buyPrice(0, 0, 5, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 6;   //The color the title of your Weapon when hovering over it ingame
            item.UseSound = SoundID.Item21; //item.UseSound = SoundID.Item1;   //The sound played when using your Weapon
            item.autoReuse = true; //Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
            item.shoot = mod.ProjectileType("RodOfRevengeProjectile");
            item.shootSpeed = 25f;   
			item.mana = 20;
		}
		public override void UpdateInventory(Player player) {
			item.damage = originalDamage + ((player.statLifeMax - player.statLife)/8);
		}
		//Dropped by Skeletron
	}
}