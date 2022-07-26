using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace RedRiverTechnical.Pages
{
    public enum Drink
    {
        [Display(Name = "Select...")]
        UNSELECTED,

        [Display(Name = "Lemon tea")]
        LEMON_TEA,

        [Display(Name = "Coffee")]
        COFFEE,

        [Display(Name = "Hot chocolate")]
        HOT_CHOCOLATE
    }

    [BindProperties]
    public class IndexModel : PageModel
    {
        // Constants
        public static readonly Dictionary<Drink, List<String>> recipes = new()
        {
            {
                Drink.LEMON_TEA,
                new List<String>
                {
                    "Boil some water.",
                    "Steep the water in the tea.",
                    "Pour tea in the cup.",
                    "Add lemon."
                }
            },
            {
                Drink.COFFEE,
                new List<String>
                {
                    "Boil some water.",
                    "Brew the coffee grounds.",
                    "Pour coffee in the cup.",
                    "Add sugar and milk."
                }
            },
            {
                Drink.HOT_CHOCOLATE,
                new List<String>
                {
                    "Boil some water.",
                    "Add drinking chocolate powder to the water.",
                    "Pour chocolate in the cup."
                }
            }
        };

        // Properties
        public Drink Drink { get; set; } = Drink.UNSELECTED;
        public List<String> RecipeSteps { get; set; } = new();

        /*
         * On Post
         */
        public async Task<IActionResult> OnPost()
        {
            RecipeSteps = recipes[Drink];

            return Page();
        }
    }
}