using System.Collections.Generic;

namespace NetCoreNLayerProject.API.DTOs
{
    public class CategoryWithProductDTO : CategoryDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
