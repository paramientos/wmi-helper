using System;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Threading.Tasks;

namespace MonteSys.Libraries
{
    public class Wmi
    {
        public static T Query<T>(string query) where T : new()
        {
            var wql = new ObjectQuery(query);
            var searcher = new ManagementObjectSearcher(wql);

            var model = new T();
            var properties = model.GetType().GetProperties();

            var values = searcher.Get();

            foreach (var property in properties)
            {
                foreach (var value in values)
                {
                    foreach (var valueProperty in value.Properties)
                    {
                        if (valueProperty.Name == property.Name)
                        {
                            model.GetType().GetProperty(property.Name)?.SetValue(model, valueProperty.Value, null);
                        }
                    }
                }
            }


            return model;
        }

        private static dynamic Query(string query)
        {
            var wql = new ObjectQuery(query);
            var searcher = new ManagementObjectSearcher(wql);
            return searcher.Get();
        }


        public static async Task<T> QueryAsync<T>(string query) where T : new()
        {
            return await Task.Run(() => Query<T>(query));
        }

        public static async Task<dynamic> QueryAsync(string query)
        {
            return await Task.Run(() => Query(query));
        }
    }
}
