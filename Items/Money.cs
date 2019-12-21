using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MaysMod.Items
{
	public class Money : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("This Money"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Just one half of the equation.\nMakes items in shops more expensive.");
		}

		public override void SetDefaults() 
		{
			item.width = 30;
			item.height = 27;
			item.rare = 2;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}