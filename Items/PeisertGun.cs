using System;
using System.Diagnostics;
using System.Drawing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MaysMod.Items
{
	public class PeisertGun : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Peisert"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("'Realistic Spray Pattern'\nCant crit while moving but has 100% crit chance when standing still.\nShoots a high velocity bullet.");
		}

		public override void SetDefaults() 
		{
			item.damage = 715;
			item.ranged = true;
			item.width = 103;
			item.height = 30;
			item.useTime = 45;
			item.useAnimation = 45;
			item.useStyle = 5;
			item.knockBack = 6;
			item.value = 320000;
			item.rare = 3;
			item.noMelee = true;
			item.crit = 0;
			item.UseSound = mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/AWP").WithVolume(3.5f);
			item.autoReuse = false;
			item.shoot = ProjectileID.BulletHighVelocity;
			item.shootSpeed = 15f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Debug.WriteLine(player.direction);
			Vector2 perturbedSpeed;
			if(player.direction < 0)
			{
				perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(45));
			} else
			{
				perturbedSpeed = new Vector2(speedX, speedY).RotatedBy(MathHelper.ToRadians(-45));
			}
			
			speedX += perturbedSpeed.X;
			speedY += perturbedSpeed.Y;
			Debug.WriteLine(this.item.crit);
			if (player.velocity.X == 0)
			{
				this.item.crit = 100;
			} else if(player.velocity.X != 0)
			{
				this.item.crit = -100;
			}
			return true;
		}
		


	}
}