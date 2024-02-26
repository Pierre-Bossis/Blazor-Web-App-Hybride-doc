using Microsoft.AspNetCore.Components.Forms;
using MonAppBlazor.Models;
using System.Text.Json;

namespace MonAppBlazor.Services
{
    public class ProduitsService
    {
        private readonly IHttpClientFactory _factory;

        public ProduitsService(IHttpClientFactory factory)
        {
            _factory = factory;
        }

        public async Task<IEnumerable<ProduitsEntity>> Get()
        {
            using HttpClient client = _factory.CreateClient("Api");

            using HttpResponseMessage response = await client.GetAsync("api/produits");

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<ProduitsEntity>>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<ProduitsEntity> GetById(int id)
        {
            using HttpClient client = _factory.CreateClient("Api");

            using HttpResponseMessage response = await client.GetAsync("api/produits/" + id);

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();
            ProduitsEntity? produit = JsonSerializer.Deserialize<ProduitsEntity>(json, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            if (produit is not null) return produit;

            return null;
        }


        public async Task Create(ProduitsForm produit, IBrowserFile file)
        {
            using var content = new MultipartFormDataContent();

            content.Add(new StreamContent(file.OpenReadStream()), "Icone", file.Name);
            content.Add(new StringContent(produit.Nom), "Nom");
            content.Add(new StringContent(produit.Source), "Source");
            content.Add(new StringContent(produit.Rarete.ToString()), "Rarete");

            using HttpClient client = _factory.CreateClient("Api");

            using HttpResponseMessage response = await client.PostAsync("api/produits/create", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
