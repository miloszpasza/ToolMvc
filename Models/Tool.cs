using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToolMvc.Models
{
    public class Tool
    {
        public int ToolID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
        public int PlaceID { get; set; }
        public virtual Place Place { get; set; }
    }
}