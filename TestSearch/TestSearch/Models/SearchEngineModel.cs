using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestSearch.Models
{
    /// <summary>
    /// Properties for Search engine management
    /// </summary>
    public class SearchEngineModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Engine Name is required")]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [DisplayName("Engine Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "API url is required")]
        [StringLength(1000, ErrorMessage = "Url cannot be longer than 1000 characters.")]
        [DisplayName("Engine API Url")]
        public string Url { get; set; }
    }
}