// Copyright (c) Strange Loop Games. All rights reserved.
// See LICENSE file in the project root for full license information.
// <auto-generated />

namespace Eco.Mods.TechTree
{
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Players;
    using Eco.Gameplay.Skills;
    using Eco.Gameplay.Systems.TextLinks;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Utils;
    using Eco.Core.Controller;

    [Serialized]
    [LocDisplayName("Milk Chocolate")]
    [MaxStackSize(100)]
    [Weight(1)]
    [Ecopedia("Food", "Cooking", createAsSubPage: true)]
    public partial class MilkChocolateItem : FoodItem
    {
        
        public override LocString DisplayDescription { get { return Localizer.DoStr("Who doesn't like chocolate?"); } }
        public override float Calories                  => 850;
        public override Nutrients Nutrition             => new Nutrients() { Carbs = 20, Fat = 16, Protein = 8, Vitamins = 18};
        protected override int BaseShelfLife            => (int)TimeUtil.HoursToSeconds(96);
    }

    [RequiresSkill(typeof(CuttingEdgeCookingSkill), 4)]
    public partial class MilkChocolateRecipe :
        RecipeFamily
    {
        public MilkChocolateRecipe()
        {
            var product = new Recipe(
                "MilkChocolate",
                Localizer.DoStr("Milk Chocolate"),
                new IngredientElement[]
                {
                    new IngredientElement(typeof(FreshMilkItem), 8, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)), 
                    new IngredientElement(typeof(SugarItem), 4, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(HydrocolloidsItem), 1, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),
                    new IngredientElement(typeof(TransglutaminaseItem), 2, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingLavishResourcesTalent)),   
                },
                new CraftingElement<MilkChocolateItem>(2)
                );

            this.Recipes = new List<Recipe> { product };
            this.LaborInCalories = CreateLaborInCaloriesValue(20, typeof(CuttingEdgeCookingSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(MilkChocolateRecipe), 6, typeof(CuttingEdgeCookingSkill), typeof(CuttingEdgeCookingFocusedSpeedTalent), typeof(CuttingEdgeCookingParallelSpeedTalent));
            this.ModsPreInitialize();
            this.Initialize(Localizer.DoStr("Milk Chocolate"), typeof(MilkChocolateRecipe));
            this.ModsPostInitialize();
            CraftingComponent.AddRecipe(typeof(FoodAssemblyLineObject), this);
        }

        /// <summary>Hook for mods to customize RecipeFamily before initialization. You can change recipes, xp, labor, time here.</summary>
        partial void ModsPreInitialize();
        /// <summary>Hook for mods to customize RecipeFamily after initialization, but before registration. You can change skill requirements here.</summary>
        partial void ModsPostInitialize();
    }
}