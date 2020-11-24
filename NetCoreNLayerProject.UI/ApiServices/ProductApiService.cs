using NetCoreNLayerProject.API.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.UI.ApiServices
{
    public class ProductApiService
    {
        private readonly HttpClient _httpClient;

        public ProductApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<ProductDTO> productDTOs;
            var response = await _httpClient.GetAsync("Products");

            if (response.IsSuccessStatusCode)
                productDTOs = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(await response.Content.ReadAsStringAsync());

            else 
                productDTOs = null;

            return productDTOs;
        }

        public async Task<ProductDTO> AddAsync(ProductDTO productDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Products", stringContent);

            if (response.IsSuccessStatusCode)
                return productDTO = JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());

            else
                return productDTO = null; 
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Products/{id}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());

            else
                return null;
        }

        public async Task<bool> UpdateAsync(ProductDTO productDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(productDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("Products", stringContent);

            if (response.IsSuccessStatusCode)
                return true;

            else
                return false;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"Products/{id}");
            if (response.IsSuccessStatusCode)
                return true;

            else
            return false;
        }

        public async Task<ProductDTO> GetWithCategoryByIdAsync(int productId)
        {
            ProductDTO productDTO;
            var response = await _httpClient.GetAsync($"Products/{productId}/category");

            if (response.IsSuccessStatusCode)
                productDTO = JsonConvert.DeserializeObject<ProductDTO>(await response.Content.ReadAsStringAsync());

            else
                productDTO = null;

            return productDTO;
        }
    }
}
