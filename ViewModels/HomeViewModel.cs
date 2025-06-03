using HygeeaMind.Models; // Asigură-te că modelele sunt accesibile
using System.Collections.Generic; // Pentru IEnumerable

namespace HygeeaMind.ViewModels
{
    public class HomeViewModel
    {
        // Proprietăți pentru listele de date  pe pagina Home
        public required IEnumerable<Article> Articles { get; set; }
        public required IEnumerable<Specialist> Specialists { get; set; }

        // Proprietate pentru a reține stringul de căutare
        public required string SearchString { get; set; }
    }
}