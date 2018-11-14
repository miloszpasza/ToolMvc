using System.ComponentModel.DataAnnotations;

namespace ToolMvc.Models
{
    public class Tool
    {
        public int ID { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Description { get; set; }
    }
}