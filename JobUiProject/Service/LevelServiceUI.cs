using JobsUI.Dtos;
using Newtonsoft.Json;

namespace JobsUI.Service
{
    public class LevelServiceUI
    {
        private readonly HttpClient _httpClient;
        public LevelServiceUI(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<LevelDtos>> GetAllLevel(CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync("https://localhost:7109/Level/GetAllLevel/", cancellationToken);
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<LevelDtos>>(responce);
            return result;
        }



        public async Task<LevelDtos> GetByIdLevel(int Id, CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync($"https://localhost:7109/Level/GetByIdLevel/{Id}");
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<LevelDtos>(responce);
            return result;
        }



        public async Task<LevelDtos> CreateLevel(LevelDtos Level, CancellationToken cancellationToken = default)
        {
            var request = new StringContent(JsonConvert.SerializeObject(Level), System.Text.UnicodeEncoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("https://localhost:7109/Level/CreateLevel/", request, cancellationToken);
            var result = JsonConvert.DeserializeObject<LevelDtos>(await responce.Content.ReadAsStringAsync(cancellationToken));
            return result;
        }



        public async Task<LevelDtos> UpdateLevel(LevelDtos Level, CancellationToken cancellationToken = default)
        {
            var request = new StringContent(JsonConvert.SerializeObject(Level), System.Text.UnicodeEncoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"https://localhost:7109/Level/UpdateLevel/", request);
            var readresponce = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<LevelDtos>(readresponce);
            return result;
        }

        public async Task<IEnumerable<EmployeeDtos>> GetAllEmployeeByLevelId(int Id, CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync($"https://localhost:7109/Level/GetAllEmployeeByLevelId/{Id}", cancellationToken);
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<EmployeeDtos>>(responce);
            return result;
        }

        public async Task<bool> DeleteLevel(int Id, CancellationToken cancellationToken = default)
        {
            return await _httpClient.DeleteFromJsonAsync<bool>($"https://localhost:7109/Level/DeleteLevel/{Id}");
        }
    }
}
