using System.Collections.Generic;
using Foundation.Library.Entities;
using Foundation.Library.UnitOfWorks;

namespace Foundation.Library.Services
{
    public class PostService : IPostService
    {
        private readonly IWebsiteUnitOfWork _websiteUnit;

        public PostService(IWebsiteUnitOfWork website)
        {
            _websiteUnit = website;
        }

        public void AddPost(Post post)
        {
            _websiteUnit.Post.Add(post);
            _websiteUnit.Save();
        }

        public IList<Post> GetAllPosts()
        {
            return _websiteUnit.Post.GetAll();
        }

        public void RemovePost()
        {
            throw new System.NotImplementedException();
        }
    }
}