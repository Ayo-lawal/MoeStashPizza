using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoeStashPizza.Models;
using MoeStashPizza.Services;

namespace RazorPagesPizza.RazorPages
{
    public class PizzaModel : PageModel
    {
        public List<Pizza> pizzas = new();
        [BindProperty]
        public Pizza NewPizza { get; set; } = new();

        public void OnGet()
        {
            pizzas = PizzaService.GetAll();
        }

        public string GlutenFreeText(Pizza pizza)
        {
            return pizza.IsGlutenFree? "Gluten Free": "Not Gluten Free";
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            PizzaService.Add(NewPizza);
            return RedirectToAction("Get");
        }
        
        public IActionResult OnPostDelete(int id)
        {
            PizzaService.Delete(id);
            return RedirectToAction("Get");
        }
    }

}