using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MyMod.Items.Weapons
{
    public class StarstormStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Display name of the item
            DisplayName.SetDefault("Starstorm Staff");
            // Tooltip
            Tooltip.SetDefault("Fires a barrage of falling stars that explode and create smaller stars");
        }

        public override void SetDefaults()
        {
            // Basic item properties
            item.damage = 250; // The damage your item deals
            item.magic = true; // Whether your item is part of the magic class
            item.mana = 15; // How much mana your weapon uses
            item.width = 40; // The item texture's width
            item.height = 40; // The item texture's height
            item.useTime = 10; // The time span of using the weapon. Remember in terraria, 60 frames is a second.
            item.useAnimation = 10; // The time span of the using animation of the weapon, suggest setting it the same as useTime.
            item.useStyle = ItemUseStyleID.HoldingOut; // The way your weapon will be used, 5 is for guns and other ranged weapons
            item.noMelee = true; // Whether the weapon itself does damage
            item.knockBack = 4; // The force of knockback of the weapon. Maximum is 20
            item.value = Item.buyPrice(platinum: 1); // The value of the weapon in copper coins
            item.rare = ItemRarityID.Red; // The rarity of the weapon, from -1 to 13
            item.UseSound = SoundID.Item9; // The sound when the weapon is being used
            item.autoReuse = true; // Whether the weapon can be used more than once automatically by holding the use button

            // Weapon's shoot properties
            item.shoot = ModContent.ProjectileType<FallingStar>(); // The projectile type of the shoot when this weapon is used.
            item.shootSpeed = 16f; // The speed of the projectile when this weapon is used
        }

        public override bool ConsumeAmmo(Player player)
        {
            // 20% chance to not consume ammo
            return Main.rand.NextFloat() >= .2f;
        }

        public override void AddRecipes()
        {
            // How to craft this item
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LunarBar, 20); // An ingredient in the recipe, this can be either an ItemID, an ItemType<ModItem>(), or an instance of an Item.
            recipe.AddIngredient(ItemID.FallenStar, 15); 
            recipe.AddIngredient(ItemID.FragmentStardust, 10); 
            recipe.AddIngredient(ModContent.ItemType<StarWrath>(), 5); 
            recipe.AddTile(TileID.LunarCraftingStation); // The tile you craft this item at
            recipe.SetResult(this); // The result of this recipe
            recipe.AddRecipe(); // This adds the recipe to the game
        }
    }
}
