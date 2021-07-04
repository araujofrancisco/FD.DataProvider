using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System;

namespace FD.SampleData.Data
{
    public class Row
    {
        public List<Column> Columns { get; set; } = new List<Column>();

        public void Add(Column column) =>
            Columns.Add(column);
    }

    public class Column
    {
        public string Name { get; set; }
        public Type DataType { get; set; }
        public object? Value { get; set; }
    }

    public class DbContextEntity
    {
        public string Name { get; set; }
        public IQueryable<object> Entity {get;set;}

        public DbContextEntity(string modelName, IQueryable<object> entity)
        {
            Name = modelName;
            Entity = entity;
        }

        //public Type? GetEntityType()
        //{
        //    //MethodInfo method = typeof(DbContext).GetMethods().Where(m => m.Name == nameof(DbContext.Set)).First();
        //    //MethodInfo genericMethod = method.MakeGenericMethod(entityType);

        //    //var dbSet = genericMethod.Invoke(context, null);
        //    //var entity = (IQueryable<object>)dbSet;
        //    //string modelName = entity.GetType().GetProperties()
        //    //    .Where(p => p.Name == "EntityType")?
        //    //    .First()?.ReflectedType?.GenericTypeArguments[0]?.Name;

        //    //return new DbContextEntity(modelName, entity);
        //    return Entity.GetType().GetProperties().Where(p => p.Name == "EntityType")?.First()?.ReflectedType;

        //}

        public IEnumerable<Row> Rows()
        {
            foreach(var item in Entity.ToList())
            {
                Row row = new();
                // item properties are the columns for the row
                foreach(PropertyInfo prop in item.GetType().GetProperties())
                {
                    row.Add(
                        new()
                        {
                            Name = prop.Name, //prop.GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Instance).First().Name,
                            DataType = prop.PropertyType,
                            Value = prop.GetValue(item) //prop.GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Instance).First().GetValue(prop)
                        });
                }
                yield return row;
            }
        }


        /// <summary>
        /// Returns an enumaration for the columns names and types, value property will be null.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Column> Columns()
        {
            var row = Entity?.FirstOrDefault();
            //return row?.GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Instance)?.ToList();
            return row?.GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Instance)?
                .ToList()?
                .Select(c => new Column { Name = c?.Name, DataType = c?.PropertyType, Value = null })?
                .ToList();
        }
    }
}
