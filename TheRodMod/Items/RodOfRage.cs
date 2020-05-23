using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace TheRodMod.Items
{
	public class RodOfRage : ModItem
	{
		int theIterator;
		int blockType = 30;
		int wallType = 4;
		int originalUpdateCount  = -80000;
		public override void SetStaticDefaults() 
		{
			Tooltip.SetDefault("Don't ragequit if this doesn't shoot where you planned it to.");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults() 
		{
			item.magic = true;
            item.damage = 200;   //The damage stat for the Weapon.                      
            item.width = 80;      //The size of the width of the hitbox in pixels.
            item.height = 80;      //The size of the height of the hitbox in pixels.
            item.useTime = 50;     //How fast the Weapon is used.
            item.useAnimation = 50;			//How long the Weapon is used for.
			item.knockBack = 5;
			item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;     //Setting to True allows the weapon sprite to stop doing damage, so only the projectile does the damge   
            item.value = Item.buyPrice(0, 0, 5, 0); // How much the item is worth, in copper coins, when you sell it to a merchant. It costs 1/5th of this to buy it back from them. An easy way to remember the value is platinum, gold, silver, copper or PPGGSSCC (so this item price is 10gold)
            item.rare = 6;   //The color the title of your Weapon when hovering over it ingame
            item.UseSound = SoundID.Item21; //item.UseSound = SoundID.Item1;   //The sound played when using your Weapon
            item.autoReuse = true; //Weather your Weapon will be used again after use while holding down, if false you will need to click again after use to use it again.
            item.shoot = mod.ProjectileType("RodOfRageProjectile");
            item.shootSpeed = 20f;   
			item.mana = 20;
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
          {
              float numberProjectiles = 1; // This defines how many projectiles to shot
              float rotation = MathHelper.ToRadians(Main.rand.Next(-90,90));
              position += Vector2.Normalize(new Vector2(speedX, speedY)) * 5f; //this defines the distance of the projectiles form the player when the projectile spawns
              for (int i = 0; i < numberProjectiles; i++)
              {
                  Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles ))) * .4f; // This defines the projectile roatation and speed. .4f == projectile speed
                  Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
              }
              return false;
          }  
		  //Dropped by Wall of Flesh
	}
}