using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MaysMod.Items
{
	public class Degree : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("This Degree"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The other half of the equation.\nReduces mana by 50.");
		}

		public override void SetDefaults() 
		{
			item.value = 10000;
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