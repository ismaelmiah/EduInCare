using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Foundation.Entities;
using Foundation.Services;

namespace FinalProject.Areas.Admin.Models
{
    public class PostModel
    {
        private readonly IPostService _service;

        public PostModel(IPostService service)
        {
            _service = service;
        }

        public PostModel()
        {
            _service = Startup.AutofacContainer.Resolve<IPostService>();

            GetAllPosts();
        }

        public IList<PostViewModel> PostList { get; set; }

        public void SavePost(Post post)
        {
            _service.AddPost(post);
        }

        private void GetAllPosts()
        {
            var posts = _service.Posts();
            PostList = new List<PostViewModel>();
            foreach (var post in posts)
            {
                PostList.Add(new PostViewModel()
                {
                    Title = post.Title,
                    Description = post.Description,
                    IsActive = post.IsActive
                });
            }
        }

    }

    public class PostViewModel
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Post ConvertToEntity()
        {
            return new Post
            {
                Title = Title,
                Description = Description,
                IsActive = IsActive
            };
        }

        public void SavePost()
        {
            var model = ConvertToEntity();
            new PostModel().SavePost(model);
        }
    }
}