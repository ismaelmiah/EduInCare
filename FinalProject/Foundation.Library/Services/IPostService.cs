using System.Collections.Generic;
using Foundation.Library.Entities;

namespace Foundation.Library.Services
{
    public interface IPostService
    {
        void AddPost(Post post);
        IList<Post> GetAllPosts();
        void RemovePost();
    }
}