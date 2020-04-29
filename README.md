# wmi-helper
Wmi Helper for C#

WMI (Windows Management Instrumentation) information can be hande by C# easily.But maybe you want to use strong typed object in your project.So wmi-helperd does automatic mapping to model clases so you can easily work with WMI classes without having to worry about writing complex queries and handling WMI connections

## Usage

     public class ComputerSystemInfoModel
     {
            public string Caption{ get; set; }
            public string WorkGroup { get; set; }
            public string Manufacturer{ get; set; }
            public string Model { get; set; }
            public string Name { get; set; }
            public string PrimaryOwnerName{ get; set; }
     }
        
     public async Task<ComputerSystemInfoModel> GetComputerSystem()
     {
         return await WmiConnectionHelper.QueryFirstOrDefaultAsync<ComputerSystemInfoModel>(
             "SELECT * FROM Win32_ComputerSystem");
     }

## Avilable methods :

     Task<T> QueryAsync<T>(string query)
     Task<dynamic> QueryAsync(string query)

