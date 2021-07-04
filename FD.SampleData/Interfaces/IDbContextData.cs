using FD.SampleData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FD.SampleData.Interfaces
{
    public interface IDbContextData
    {
        /// <summary>
        /// Allows to get query all the entities in the dbcontext.
        /// </summary>
        /// <returns></returns>
        IEnumerable<DbContextEntity> GetAllEntityQueries();

        /// <summary>
        /// Allows to seed database during OnModelCreating. If overriding OnModelCreating call base method at the end
        /// of the implementation, since is required the entity be already defined.
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>
        Task Seed(ModelBuilder builder);

        /// <summary>
        /// Allows to seed database using a context that only accepts seed size.
        /// </summary>
        /// <param name="seedSize"></param>
        /// <returns></returns>
        Task Seed(int? seedSize);

        /// <summary>
        /// Allows to seed database using a service scope.
        /// </summary>
        /// <param name="serviceScope"></param>
        /// <param name="SeedSize"></param>
        /// <returns></returns>
        Task Seed(IServiceScope serviceScope, int? seedSize);
    }
}
