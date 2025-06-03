using HygeeaMind.Models; 
using System.Collections.Generic; 

namespace HygeeaMind.ViewModels
{
    public class HomeViewModel
    {
        // Proprietati pentru listele de date  pe pagina Home
        public required IEnumerable<Article> Articles { get; set; }
        public required IEnumerable<Specialist> Specialists { get; set; }

        // Proprietate pentru a retine stringul de cautare
        public required string SearchString { get; set; }
    }
}