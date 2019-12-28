
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace MaysMod.Projectiles
{
	public class GolfBall : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Golf Ball");
		}

		public override void SetDefaults()
		{
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.aiStyle = 14;
			aiType = ProjectileID.Glowstick;
		}

		public override void AI()
		{
			projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
			if (projectile.ai[0] >= 10f)
			{
				projectile.Kill();
			}
		}

		public override void Kill(int timeLeft)
		{
			Dust.NewDust(projectile.position, 20, 20, DustID.Dirt, 0, 0, 150, default(Color), 0.7f);
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if(projectile.velocity.Y != 0)
			{
				Dust.NewDust(projectile.position, 25, 25, DustID.Dirt, 0, 0, 150, default(Color), 0.7f);
			}
			return base.OnTileCollide(oldVelocity);
		}
	}
}