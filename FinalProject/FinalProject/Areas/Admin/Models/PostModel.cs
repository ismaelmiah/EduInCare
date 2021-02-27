using System;
using System.Collections;
using System.Collections.Generic;
using Autofac;
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
        }

        public IList<PostViewModel> PostList { get; set; }
    }

    public class PostViewModel
    {
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Description { get; set; }
    }
}