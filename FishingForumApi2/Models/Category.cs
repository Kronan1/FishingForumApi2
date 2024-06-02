
namespace FishingForumApi2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static explicit operator Category(Repository.FishingForum.Category v)
        {
            throw new NotImplementedException();
        }
    }
}
