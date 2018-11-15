using System.ComponentModel.DataAnnotations;

namespace ToolMvc.Models
{
    public class Place
    {
        public int ID { get; set; }
        [Required]
        public string PlaceAdress { get; set; }
        [Required]
        public string PlaceDescription { get; set; }
    }
}