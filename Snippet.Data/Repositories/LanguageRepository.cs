﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Snippet.Data.DbContext;
using Snippet.Data.Entities;
using Snippet.Data.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;
using Snippet.Common.Parameters;

namespace Snippet.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly SnippetDbContext _dbContext;
        public LanguageRepository(SnippetDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LanguageEntity?> GetByNameAsync(string name, CancellationToken ct = default)
        {
            return await _dbContext.Languages.AsNoTracking()
                .FirstOrDefaultAsync(lang => lang.Name == name, ct)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<LanguageEntity>> GetAllAsync(ParamsBase? parameters = default, CancellationToken ct = default)
        {
            var result = _dbContext.Languages
                .Include(x=>x.SnippetPosts)
                .AsNoTracking();

            parameters ??= new ParamsBase();
            
            if (!string.IsNullOrEmpty(parameters.SortBy))
            {
                switch (parameters.SortBy.ToLower())
                {
                    case "popular":
                        result = result.OrderBy(x => x.SnippetPosts.Count);                           
                        break;
                    case "unpopular":
                        result = result.OrderByDescending(x => x.SnippetPosts.Count);
                        break;
                }
            }
            
            result = result.Skip((parameters.Page-1) * parameters.PageSize)
                .Take(parameters.PageSize);

            return await result.ToListAsync(ct).ConfigureAwait(false);
        }

        public async Task<LanguageEntity> CreateAsync(LanguageEntity entity, CancellationToken ct = default)
        {
            var entityEntry = await _dbContext.Languages.AddAsync(entity, ct).ConfigureAwait(false);
            return entityEntry.Entity;
        }

        public async Task<bool> DeleteAsync(long id, CancellationToken ct = default)
        {
            var entity = await GetByIdAsync(id, ct).ConfigureAwait(false);
            if (entity != null)
            {
                var entityEntry = _dbContext.Languages.Remove(entity);
                return entityEntry != null;
            }

            return false;
        }

        public Task<LanguageEntity?> GetByIdAsync(long id, CancellationToken ct = default)
        {
            return _dbContext.Languages
                 .AsNoTracking()
                 .FirstOrDefaultAsync(user => user.Id == id, ct)!;
        }

        public LanguageEntity Update(LanguageEntity entity)
        {
            var entityEntry = _dbContext.Languages.Update(entity);
            return entityEntry.Entity;
        }
    }
}
