using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToolMvc.Models
{
    public class ToolTypeViewModel
    {
        public List<Tool> Tools;
        public SelectList Types;
        public string ToolType { get; set; }
        public string SearchString { get; set; }
    }
}