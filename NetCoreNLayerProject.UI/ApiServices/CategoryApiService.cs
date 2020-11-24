using NetCoreNLayerProject.API.DTOs;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreNLayerProject.UI.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            IEnumerable<CategoryDTO> categoryDTOs;
            var response = await _httpClient.GetAsync("Categories");

            if (response.IsSuccessStatusCode)
            {
                categoryDTOs = JsonConvert.DeserializeObject<IEnumerable<CategoryDTO>>(await response.Content.ReadAsStringAsync());
            }

            else
                categoryDTOs = null;

            return categoryDTOs;
        }

        public async Task<CategoryDTO> AddAsync(CategoryDTO categoryDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Categories", stringContent);

            if (response.IsSuccessStatusCode)
            {
                categoryDTO = JsonConvert.DeserializeObject<CategoryDTO>(await response.Content.ReadAsStringAsync());
            }

            else
                return null;

            return categoryDTO;
        }

        public async Task<CategoryDTO> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Categories/{id}");

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<CategoryDTO>(await response.Content.ReadAsStringAsync());

            else
                return null;
        }

        public async Task<bool> Update(CategoryDTO categoryDTO)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDTO), Encoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("Categories", stringContent);

            if (response.IsSuccessStatusCode)
                return true;

            else
                return false;
        }

        public async Task<bool> Remove(int id)
        {
            var response = await _httpClient.DeleteAsync($"Categories/{id}");

            if (response.IsSuccessStatusCode)
                return true;

            else
                return false;
        }
    }
}
