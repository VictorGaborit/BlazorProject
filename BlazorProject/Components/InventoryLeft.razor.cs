using BlazorProject.Models;
using BlazorProject.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Text.Json;

namespace BlazorProject.Components
{
    public partial class InventoryLeft
    {

        private Item _recipeResult;

        public InventoryLeft()
        {
            Actions = new ObservableCollection<InventoryAction>();
            Actions.CollectionChanged += OnActionsCollectionChanged;
            this.InventoryItems = new List<Item> { null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null, null };
        }

        public ObservableCollection<InventoryAction> Actions { get; set; }

        public Item CurrentDragItem { get; set; }

        public int CurrentStackSize { get; set; }

        [Parameter]
        public List<Item> Items { get; set; }

        public List<Item> InventoryItems { get; set; }

        public Item RecipeResult
        {
            get => this._recipeResult;
            set
            {
                if (this._recipeResult == value)
                {
                    return;
                }

                this._recipeResult = value;
                this.StateHasChanged();
            }
        }

        [Parameter]
        public List<CraftingRecipe> Recipes { get; set; }
        /// <summary>
        /// Gets or sets the java script runtime.
        /// </summary>
        [Inject]
        internal IJSRuntime JavaScriptRuntime { get; set; }

        public void CheckInventory()
        {
            RecipeResult = null;

            // Get the current model
            var currentModel = string.Join("|", this.InventoryItems.Select(s => s != null ? s.Name : string.Empty));

            this.Actions.Add(new InventoryAction { Action = $"Items : {currentModel}" });

            foreach (var craftingRecipe in Recipes)
            {
                // Get the recipe model
                var recipeModel = string.Join("|", craftingRecipe.Have.SelectMany(s => s));

                this.Actions.Add(new InventoryAction { Action = $"Recipe model : {recipeModel}" });

                if (currentModel == recipeModel)
                {
                    RecipeResult = craftingRecipe.Give;
                }
            }
        }

        private void OnActionsCollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            JavaScriptRuntime.InvokeVoidAsync("Crafting.AddActions", e.NewItems);
        }

        public void refresh()
        {
            StateHasChanged();
        }
    }
}
