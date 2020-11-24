using System.Collections.Generic;

namespace NetCoreNLayerProject.Web.DTOs
{
    public class CategoryWithProductDTO : CategoryDTO
    {
        public IEnumerable<ProductDTO> Products { get; set; }
    }
}
