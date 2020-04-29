# wmi-helper
Wmi Helper for C#

WMI (Windows Management Instrumentation) information can be hande by C# easly.But maybe you want to use strong typed object in your project.So wmi-helperd does automatic mapping to model clases so you can easily work with WMI classes without having to worry about writing complex queries and handling WMI connections

## Usage

     public class OperatingSystemInfoModel
        {
            public string Caption { get; set; }
    		public string BuildNumber { get; set; }
    		public string OSArchitecture { get; set; }
    		public string Version { get; set; }
            public string WindowsDirectory { get; set; }
        }
        
      public async Task<OperatingSystemInfoModel> GetOperationSystem()
       {
          return await Wmi.QueryAsync<OperatingSystemInfoModel>("SELECT * FROM Win32_OperatingSystem");
       }

## Avilable methods :

     Task<T> QueryAsync<T>(string query)
     Task<dynamic> QueryAsync(string query)

