﻿using System;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class ExamModel
    {
        internal ExamModelBuilder ModelBuilder;
        public ExamModel()
        {
            ModelBuilder = new ExamModelBuilder();
        }

        public Guid Id { get; set; }
    }
}