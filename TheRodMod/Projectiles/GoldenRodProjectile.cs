using System; 
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace TheRodMod.Projectiles //where it's stored, replace Mod with the name of your mod. This file is stored in the folder \Mod Sources\(mod name, folder can't have spaces)\Projectiles.
{
    public class GoldenRodProjectile : ModProjectile //the class of the projectile
    {
        public override void SetDefaults()
        {
            projectile.width = 32;
            projectile.height = 32;
            projectile.aiStyle = 0; 
            projectile.friendly  = true; 
            projectile.ranged = true; 
            projectile.timeLeft = 600;
			aiType = ProjectileID.Bullet; 
			projectile.penetrate = -1;
			
        }
        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }
		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //When you hit an NPC
        {
			if(target.life <= 25)
			{
				target.life = 0;
				Vector2 npcPos = target.Center;
				Main.tile[(int)npcPos.X/16, (int)npcPos.Y/16].type = TileID.Gold;
				Main.tile[(int)npcPos.X/16, (int)npcPos.Y/16].active(true);
			}
        }
    }
}
