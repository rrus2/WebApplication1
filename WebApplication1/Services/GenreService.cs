using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;
        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genre> GetGenre(int id)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.GenreID == id);
            if (genre == null)
                throw new Exception($"Genre with id {id} SHOULD exist");
            return genre;
        }

        public async Task<IEnumerable<Genre>> GetGenres()
        {
            var genres = await _context.Genres.ToListAsync();
            if (genres == null)
                throw new Exception("Error fetching genres");
            return genres;
        }
        
    }
}