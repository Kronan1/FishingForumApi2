namespace FishingForumApi2
{
    public interface ICategoryManager
    {
        public Task<List<Models.Category>> GetCategoriesAsync();
    }

}
