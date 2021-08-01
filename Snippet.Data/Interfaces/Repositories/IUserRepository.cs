﻿using Snippet.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Snippet.Data.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<UserEntity?> GetByIdAsync(ulong id, CancellationToken ct = default);
        Task<UserEntity> CreateAsync(UserEntity entity, CancellationToken ct = default);
        Task<UserEntity> UpdateAsync(UserEntity entity, CancellationToken ct = default);
        Task<bool> DeleteAsync(ulong id, CancellationToken ct = default);
    }
}
