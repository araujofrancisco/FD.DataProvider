using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System;

namespace FD.SampleData.Data
{
    /// <summary>
    /// Generic row class for usign with DbContextEntity.
    /// </summary>
    public class Row
    {
        public List<Column> Columns { get; set; } = new List<Column>();       
    }

    /// <summary>
    /// Generic column class for usign with DbContextEntity.
    /// </summary>
    public class Column
    {
        public string Name { get; set; }
        public Type DataType { get; set; }
        public object? Value { get; set; }
    }

    /// <summary>
    /// Generic context entity information. Includes entity name, rows and columns.
    /// </summary>
    public class DbContextEntity
    {
        public string Name { get; set; }
        public IQueryable<object> Entity {get;set;}

        public DbContextEntity(string modelName, IQueryable<object> entity)
        {
            Name = modelName;
            Entity = entity;
        }

        /// <summary>
        /// Returns an enumeration of row for this entity object.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Row> Rows()
        {
            foreach(var item in Entity.ToList())
            {
                Row row = new();
                // item properties are the columns for the row
                foreach(PropertyInfo prop in item.GetType().GetProperties())
                {
                    row.Columns.Add(
                        new()
                        {
                            Name = prop.Name, 
                            DataType = prop.PropertyType,
                            Value = prop.GetValue(item)
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

            return row?.GetType()?.GetProperties(BindingFlags.Public | BindingFlags.Instance)?
                .ToList()?
                .Select(c => new Column { Name = c?.Name, DataType = c?.PropertyType, Value = null })?
                .ToList();
        }
    }
}
