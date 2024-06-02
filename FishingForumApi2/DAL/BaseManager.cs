using FishingForumApi2.Repository.FishingForum;

namespace FishingForumApi2.DAL
{
    public class BaseManager
    {
        protected readonly FishingForumContext _context;
        public BaseManager(FishingForumContext context)
        {
            
        }
    }
}
