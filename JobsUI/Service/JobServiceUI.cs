using JobsUI.Dtos;
using Newtonsoft.Json;

namespace JobsUI.Service
{
    public class JobServiceUI
    {
        private readonly HttpClient _httpClient;
        public JobServiceUI(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<JobsDtos>> GetAllJob(CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync("https://localhost:7109/Job/GetAllJob/", cancellationToken);
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<JobsDtos>>(responce);
            return result;
        }



        public async Task<JobsDtos> GetByIdJob(int Id, CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync($"https://localhost:7109/Job/GetByIdJob/{Id}");
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<JobsDtos>(responce);
            return result;
        }



        public async Task<JobsDtos> CreateJob(JobsDtos Job, CancellationToken cancellationToken = default)
        {
            var request = new StringContent(JsonConvert.SerializeObject(Job), System.Text.UnicodeEncoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("https://localhost:7109/Job/CreateJob/", request, cancellationToken);
            var result = JsonConvert.DeserializeObject<JobsDtos>(await responce.Content.ReadAsStringAsync(cancellationToken));
            return result;
        }



        public async Task<JobsDtos> UpdateJob(JobsDtos Job, CancellationToken cancellationToken = default)
        {
            var request = new StringContent(JsonConvert.SerializeObject(Job), System.Text.UnicodeEncoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"https://localhost:7109/Job/UpdateJob/", request);
            var readresponce = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<JobsDtos>(readresponce);
            return result;
        }

        public async Task<IEnumerable<EmployeeDtos>> GetAllEmployeeByCompanyId(int Id, CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync($"https://localhost:7109/Job/GetAllEmployeeByCompanyId/{Id}", cancellationToken);
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<EmployeeDtos>>(responce);
            return result;
        }

        public async Task<bool> DeleteJob(int Id, CancellationToken cancellationToken = default)
        {
            return await _httpClient.DeleteFromJsonAsync<bool>($"https://localhost:7109/Job/DeleteJob/{Id}");
        }
    }
}
