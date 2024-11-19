using BookStore.Data;
using BookStore.Models;
using BookStore.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BookStore.Services
{
    public class GenreService
    {
        private readonly BookstoreContext _context;

        public GenreService(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<List<Genre>> FindAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

       public async Task InsertAsync(Genre genre)
        {
            _context.Add(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<Genre> FindByIdAsync(int id)
        {
            return await _context.Genres.FindAsync(id);
        }

        public async Task  RemoveAsync(int id)
        {
            try
            {
                var obj = await _context.Genres.FindAsync(id);
                _context.Genres.Remove(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }

        // POST: Genres/Edit/x
        public async Task UpdateAsync(Genre genre)
        {
            // Confere se tem alguém com esse Id
            bool hasAny = await _context.Genres.AnyAsync(x => x.Id == genre.Id);
            // Se não tiver, lança exceção de NotFound.
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            // Tenta atualizar
            try
            {
                _context.Update(genre);
                await _context.SaveChangesAsync();
            }
            // Se não der, captura a exceção lançada
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
    }
}
