using System;
using System.Collections.Generic;
using Autofac;
using Foundation.Library.Entities;
using Foundation.Library.Services;

namespace FinalProject.Web.Areas.Admin.Models
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
            var posts = _service.GetAllPosts();
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