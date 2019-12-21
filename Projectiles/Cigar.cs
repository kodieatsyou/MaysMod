using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MaysMod.Projectiles
{
	public class Cigar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cigar");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 8;
			projectile.friendly = true;
			projectile.melee = true;
			
		}

		public override void AI()
		{

            for (int i = 0; i < 200; i++)
            {
                NPC target = Main.npc[i];
                //If the npc is hostile
                if (target.CanBeChasedBy())
                {
                    //Get the shoot trajectory from the projectile and target
                    float shootToX = target.position.X + (float)target.width * 0.5f - projectile.Center.X;
                    float shootToY = target.position.Y - projectile.Center.Y;
                    float distance = (float)System.Math.Sqrt((double)(shootToX * shootToX + shootToY * shootToY));

                    //If the distance between the live targeted npc and the projectile is less than 480 pixels
                    if (distance < 480f && !target.friendly && target.active)
                    {
                        //Divide the factor, 3f, which is the desired velocity
                        distance = 3f / distance;

                        //Multiply the distance by a multiplier if you wish the projectile to have go faster
                        shootToX *= distance * 5;
                        shootToY *= distance * 5;

                        //Set the velocities to the shoot values
                        projectile.velocity.X = shootToX;
                        projectile.velocity.Y = shootToY;
                    }
                }
            }

            Lighting.AddLight(projectile.Center, 0.976f, 0.706f, 0.016f);
			Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Smoke, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
            projectile.rotation += 0.4f * (float)projectile.direction;

            projectile.ai[0] += 1f; // Use a timer to wait 15 ticks before applying gravity.
            if (projectile.ai[0] >= 15f)
            {
                projectile.ai[0] = 15f;
                projectile.velocity.Y = projectile.velocity.Y + 0.1f;
            }
            if (projectile.velocity.Y > 16f)
            {
                projectile.velocity.Y = 16f;
            }

        }

        public override void Kill(int timeLeft)
        {
            Dust.NewDust(projectile.position, 20, 20, DustID.Smoke, 0, 0, 150, default(Color), 0.7f);
            Main.PlaySound(SoundID.LiquidsWaterLava, projectile.position);
        }

        // Additional hooks/methods here.
    }
}