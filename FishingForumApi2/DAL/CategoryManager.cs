using FishingForumApi2.Models;

using FishingForumApi2.Repository.FishingForum;
using Microsoft.EntityFrameworkCore;

namespace FishingForumApi2.DAL
{
    public class CategoryManager : ICategoryManager
    {
        public List<Models.Category> Categories { get; set; }
        private readonly FishingForumContext _context;

        public CategoryManager(FishingForumContext context)
        {
            _context = context;
        }

        public async Task<List<Models.Category>> GetCategoriesAsync()
        {
            var categories = await _context.Category.ToListAsync();
            var categoriesToReturn = new List<Models.Category>();   
            foreach (var category in categories)
            {
                categoriesToReturn.Add(new Models.Category { Id = category.Id, Name = category.Name});
            }
            return categoriesToReturn;
        }
    }
}
