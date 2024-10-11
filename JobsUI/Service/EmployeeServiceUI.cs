
using JobsUI.Dtos;
using Newtonsoft.Json;
using System.Text;

namespace JobsUI.Service
{
    public class EmployeeServiceUI
    {
        private readonly HttpClient _httpClient;
        public EmployeeServiceUI(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public async Task<IEnumerable<EmployeeDtos>> GetAllEmployee(CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync("https://localhost:7109/Employee/GetAllEmployee/", cancellationToken);
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<IEnumerable<EmployeeDtos>>(responce);
            return result;
        }



        public async Task<EmployeeDtos> GetByIdEmployee(int Id, CancellationToken cancellationToken = default)
        {
            var request = await _httpClient.GetAsync($"https://localhost:7109/Employee/GetByIdEmployee/{Id}");
            var responce = await request.Content.ReadAsStringAsync(cancellationToken);
            var result = System.Text.Json.JsonSerializer.Deserialize<EmployeeDtos>(responce);
            return result;
        }



        public async Task<EmployeeDtos> CreateEmployee(EmployeeDtos employee, CancellationToken cancellationToken = default)
        {
            var request = new StringContent(JsonConvert.SerializeObject(employee), System.Text.UnicodeEncoding.UTF8, "application/json");
            var responce = await _httpClient.PostAsync("https://localhost:7109/Employee/CreateEmployee/", request, cancellationToken);
            var result = JsonConvert.DeserializeObject<EmployeeDtos>(await responce.Content.ReadAsStringAsync(cancellationToken));
            return result;
        }



        public async Task<EmployeeDtos> UpdateEmployee(EmployeeDtos employee, CancellationToken cancellationToken = default)
        {
            var request = new StringContent(JsonConvert.SerializeObject(employee), System.Text.UnicodeEncoding.UTF8, "application/json");
            var responce = await _httpClient.PutAsync($"https://localhost:7109/Employee/UpdateEmployee/", request);
            var readresponce = await responce.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EmployeeDtos>(readresponce);
            return result;
        }



        public async Task<bool> DeleteEmployee(int Id, CancellationToken cancellationToken = default)
        {
            return await _httpClient.DeleteFromJsonAsync<bool>($"https://localhost:7109/Employee/DeleteEmployee/{Id}");
        }
    }
}
