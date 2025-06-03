using HygeeaMind.Models; // Asigură-te că modelele sunt accesibile
using System.Collections.Generic; // Pentru IEnumerable

namespace HygeeaMind.ViewModels
{
    public class HomeViewModel
    {
        // Proprietăți pentru listele de date pe care le vom afișa pe pagina Home
        public required IEnumerable<Article> Articles { get; set; }
        public required IEnumerable<Specialist> Specialists { get; set; }

        // Proprietate pentru a reține stringul de căutare
        // Utilizată pentru a pre-popula câmpul de căutare după o căutare
        public required string SearchString { get; set; }
    }
}