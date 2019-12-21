using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MaysMod.Items
{
	public class ForgieClub : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("The Forgie"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Out for a rip eh?\nShoots golf balls and has a chance to release homing cigars.");
		}

		public override void SetDefaults() 
		{
			item.damage = 65;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 4;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = false;
			item.shoot = mod.ProjectileType("Cigar");
			item.shootSpeed = 10f;
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
			Random rnd = new Random();
			int cigarChance = rnd.Next(0, 100);
			if(cigarChance <= 25)
			{
				type = mod.ProjectileType("Cigar");
			} else
			{
				type = mod.ProjectileType("GolfBall");
			}
			return true;
		}

	}
}