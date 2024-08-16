using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesFilmes.Data;
using RazorPagesFilmes.Model;

namespace RazorPagesFilmes.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesFilmes.Data.RazorPagesFilmesContext _context;

        public IndexModel(RazorPagesFilmes.Data.RazorPagesFilmesContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get;set; }
        [BindProperty(SupportsGet = true)]
        public string GenreMovie { get;set; }
        public SelectList Genres { get;set; }

        public async Task OnGetAsync()
        {
            var movies = from m in _context.Movie
                         select m;

            if(!string.IsNullOrWhiteSpace(SearchTerm))
            {
                movies = movies.Where(f => f.Title.Contains(SearchTerm));                
            }

            Movie = await movies.ToListAsync();
        }
    }
}
