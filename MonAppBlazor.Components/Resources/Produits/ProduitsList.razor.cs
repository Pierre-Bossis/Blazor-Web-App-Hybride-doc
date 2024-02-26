using Microsoft.AspNetCore.Components;
using MonAppBlazor.Models;
using MonAppBlazor.Services;

namespace MonAppBlazor.Components.Resources.Produits
{
    public partial class ProduitsList
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Inject]
        public ProduitsService repository { get; set; }

        public IEnumerable<ProduitsEntity> produits { get; set; } = Enumerable.Empty<ProduitsEntity>();

        protected async override Task OnInitializedAsync()
        {
            produits = await repository.Get();
        }

        public void VoirDetails(int produitId)
        {
            NavigationManager.NavigateTo("produits/" + produitId);
        }

        public void GoCreate()
        {
            NavigationManager.NavigateTo("produits/create");
        }
    }
}
