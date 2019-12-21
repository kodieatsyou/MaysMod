using Terraria.ID;
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
			projectile.arrow = true;
			projectile.width = 24;
			projectile.height = 24;
			projectile.aiStyle = 8;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.ignoreWater = true;
			aiType = ProjectileID.Fireball;
		}

		// Additional hooks/methods here.
	}
}