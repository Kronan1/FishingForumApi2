using FishingForumApi2.DAL;
using FishingForumApi2.Models;
using FishingForumApi2.Repository.FishingForum;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FishingForumApi2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager; 
        }

        [HttpGet]
        public async Task<IEnumerable<Models.Category>> GetCategoriesAsync()
        {

            return await _categoryManager.GetCategoriesAsync();

        }
    }
}
