using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoraAPF.org.ViewModels.Common
{
    public class GenericListViewModel
    {
        public List<SelectListItem> Countries { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "CA", Text = "Canada" },
            new SelectListItem { Value = "US", Text = "USA"  },
        };


        public List<SelectListItem> Titles { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "Mr", Text = "Mr. " },
            new SelectListItem { Value = "Mrs", Text = "Mrs. "  },
            new SelectListItem { Value = "Ms", Text = "Ms. " },
            new SelectListItem { Value = "Miss", Text = "Miss. " }
        };
    }
}
