using FD.SampleData.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FD.SampleData.Extensions
{
    public static class DbContextExtensions
    {
        /// <summary>
        /// Extension to allow seed from OnModelCreation using model builder.
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static Task Seed(this ModelBuilder modelBuilder, Func<ModelBuilder, Task> func)
        {
            return func(modelBuilder);
        }

        /// <summary>
        /// Returns entity name and object reference from dbcontext.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static DbContextEntity GetEntityQuery(this DbContext context, Type entityType)
        {
            MethodInfo method = typeof(DbContext).GetMethods().Where(m => m.Name == nameof(DbContext.Set)).First();
            MethodInfo genericMethod = method.MakeGenericMethod(entityType);

            var dbSet = genericMethod.Invoke(context, null);
            var entity = (IQueryable<object>)dbSet;
            string modelName = entity.GetType().GetProperties()
                .Where(p => p.Name == "EntityType")?
                .First()?.ReflectedType?.GenericTypeArguments[0]?.Name;

            return new DbContextEntity(modelName, entity);
        }

        /// <summary>
        /// Returns an IEnumerable with all the names and entities references in the dbcontext.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static IEnumerable<DbContextEntity> GetDbContextEntityQueries(this DbContext context)
        {
            foreach (var entityType in context.Model.GetEntityTypes())
                yield return context.GetEntityQuery(entityType.ClrType);
        }
    }
}
