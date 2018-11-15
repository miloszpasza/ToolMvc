using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToolMvc.Models
{
    public class PlaceAdressViewModel
    {
        public List<Place> Places;
        public SelectList PlaceAdresses;
        public string PlaceAdress { get; set; }
        public string SearchStringAdr { get; set; }
    }
}