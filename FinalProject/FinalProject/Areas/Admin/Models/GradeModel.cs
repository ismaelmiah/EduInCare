using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using FinalProject.Web.Areas.Admin.Models.ModelBuilder;

namespace FinalProject.Web.Areas.Admin.Models
{
    public class GradeModel
    {
        internal GradeModelBuilder ModelBuilder;
        public GradeModel()
        {
            ModelBuilder = new GradeModelBuilder();
            Rules = BuildRules();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Rules> Rules { get; set; }

        private List<Rules> BuildRules()
        {
            return new List<Rules>
            {
                new Rules{Name = "A+", Point = 5.00, Minimum = 80, Maximum = 100},
                new Rules{Name = "A", Point = 4.00, Minimum = 70, Maximum = 79},
                new Rules{Name = "A-", Point = 3.50, Minimum = 60, Maximum = 69},
                new Rules{Name = "B", Point = 3.00, Minimum = 50, Maximum = 59},
                new Rules{Name = "C", Point = 2.00, Minimum = 40, Maximum = 49},
                new Rules{Name = "D", Point = 1.00, Minimum = 33, Maximum = 39},
                new Rules{Name = "F", Point = 0.00, Minimum = 00, Maximum = 32},
            };
        }
    }

    public class Rules
    {
        public string Name { get; set; }
        public double Point { get; set; }
        public int Minimum { get; set; }
        public int Maximum { get; set; }
    }
}