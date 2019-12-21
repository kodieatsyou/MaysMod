using System;
using System.Drawing;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MaysMod.Items
{
	public class MoneyAndDegree : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("This Money and This Degree"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("The final equation.\nMakes items in shops cheaper.\nYou gain 50 mana.");
		}

		public override void SetDefaults() 
		{
			item.value = 10000;
			item.rare = 2;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.GetItem("Money"));
			recipe.AddIngredient(mod.GetItem("Degree"));
			recipe.AddTile(TileID.TinkerersWorkbench);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

	}
}