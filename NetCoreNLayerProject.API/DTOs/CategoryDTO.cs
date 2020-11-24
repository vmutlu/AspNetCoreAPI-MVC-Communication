using System.ComponentModel.DataAnnotations;

namespace NetCoreNLayerProject.API.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
