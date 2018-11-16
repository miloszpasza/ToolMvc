using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToolMvc.Models
{
    public class Place
    {
        public Place()
        {
            this.Tool = new HashSet<Tool>();
        }
        public int PlaceID { get; set; }
        [Required]
        public string PlaceAdress { get; set; }
        [Required]
        public string PlaceDescription { get; set; }
        
        public virtual ICollection<Tool> Tool { get; set; }

    }
}