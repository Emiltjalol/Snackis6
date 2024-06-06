using Microsoft.AspNetCore.Mvc.RazorPages;
using Snackis6.Models;

namespace Snackis6.Pages.Messages.Admin.AdminCategory
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IList<Category> Category { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //Category = await _httpClient.GetFromJsonAsync<List<Category>>("https://localhost:7079/api/categories");
            Category = await _httpClient.GetFromJsonAsync<List<Category>>("https://emilsnackisapi.azurewebsites.net/api/categories");
        }
    }
}
