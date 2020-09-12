using System;
using System.Collections.Generic;
using System.Text;

namespace DjRequestLive.Data.ViewModels
{
    public class Select2ResultsViewModel
    {
        public IEnumerable<Select2ItemViewModel> Results { get; set; }
        public Select2PaginationViewModel Pagination { get; set; }
    }
}
