using System.Collections;
using System.Collections.Generic;
using Foundation.Entities;

namespace Foundation.Services
{
    public interface IPostService
    {
        void AddPost(Post post);
        IList<Post> GetAllPosts();
        void RemovePost();
    }
}