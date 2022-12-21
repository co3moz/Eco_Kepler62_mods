namespace Eco.Mods.TechTree
{
    using System;
    using System.Collections.Generic;
    using Eco.Core.Items;
    using Eco.Gameplay.Components;
    using Eco.Gameplay.Components.Auth;
    using Eco.Gameplay.Items;
    using Eco.Gameplay.Objects;
    using Eco.Shared.Localization;
    using Eco.Shared.Serialization;
    using Eco.Shared.Items;
    using Eco.Core.Controller;
    using Eco.Gameplay.Systems.NewTooltip;
    using Eco.Gameplay.Systems.Tooltip;

    [Serialized]
    [LocDisplayName("Small Wood Cart Pink")]
    [Weight(5000)]
    [Ecopedia("CavRnMods", "Colored Vehicles", true)]    
    [Tag("ColoredSmallWoodCart")]
    public partial class SmallWoodCartPinkItem : WorldObjectItem<SmallWoodCartPinkObject>
    {
        public override LocString DisplayDescription { get { return Localizer.DoStr("Small pink cart for hauling small loads."); } }
        [Serialized, SyncToView, TooltipChildren, ] public object PersistentData { get; set; }
    }

    public class PaintSmallWoodCartPinkRecipe : RecipeFamily
    {
        public PaintSmallWoodCartPinkRecipe()
        {
            this.Recipes = new List<Recipe>
            {
                new Recipe(
                    "Paint Small Wood Cart Pink",
                    Localizer.DoStr("Paint Small  Cart Pink"),
                    new IngredientElement[]
                    {
                        new IngredientElement(typeof(SmallWoodCartItem), 1, true),
                        new IngredientElement(typeof(BeetItem), 6, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                        new IngredientElement(typeof(LimestoneItem), 4, typeof(CarpentrySkill), typeof(CarpentryLavishResourcesTalent)),
                    },
                    new CraftingElement<SmallWoodCartPinkItem>()
                )
            };
            this.ExperienceOnCraft = 0.05f;
            this.LaborInCalories = CreateLaborInCaloriesValue(125, typeof(BasicEngineeringSkill));
            this.CraftMinutes = CreateCraftTimeValue(typeof(PaintSmallWoodCartPinkRecipe), 2.5f, typeof(BasicEngineeringSkill));

            this.Initialize(Localizer.DoStr("Paint Small Wood Cart Pink"), typeof(PaintSmallWoodCartPinkRecipe));
            CraftingComponent.AddRecipe(typeof(PrimitivePaintingTableObject), this);
        }
    }

    [Serialized]
    [RequireComponent(typeof(StandaloneAuthComponent))]
    [RequireComponent(typeof(PublicStorageComponent))]
    [RequireComponent(typeof(MovableLinkComponent))]
    [RequireComponent(typeof(VehicleComponent))]
    [RequireComponent(typeof(CustomTextComponent))]
    [RequireComponent(typeof(TailingsReportComponent))]
    public partial class SmallWoodCartPinkObject : PhysicsWorldObject, IRepresentsItem
    {
        static SmallWoodCartPinkObject()
        {
            WorldObject.AddOccupancy<SmallWoodCartPinkObject>(new List<BlockOccupancy>(0));
        }

        public override TableTextureMode TableTexture => TableTextureMode.Wood;
        public override LocString DisplayName { get { return Localizer.DoStr("Small Wood Cart Pink"); } }
        public Type RepresentedItemType { get { return typeof(SmallWoodCartPinkItem); } }


        private SmallWoodCartPinkObject() { }

        protected override void Initialize()
        {
            base.Initialize();

            this.GetComponent<CustomTextComponent>().Initialize(200);
            this.GetComponent<PublicStorageComponent>().Initialize(8, 1400000);           
            this.GetComponent<VehicleComponent>().Initialize(10, 1, 1);
            this.GetComponent<VehicleComponent>().HumanPowered(0.5f);           
        }
    }
}