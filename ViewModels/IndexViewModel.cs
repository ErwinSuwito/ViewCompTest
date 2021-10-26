using System.Collections.Generic;
using ViewComponentSample.Models;

namespace ViewCompFinal.ViewModels
{
    public class IndexViewModel
    {
        public List<TodoItem> TodoItems { get; set; }
        public string PageLayout { get; set; }
    }
}
