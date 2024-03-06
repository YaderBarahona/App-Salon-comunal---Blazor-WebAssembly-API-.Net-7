using System.Text.Json;

namespace WebAssembly.Utilidades
{
    public class ConfigService
    {
        private readonly string _configFilePath = "config.json";

        public async Task<ConfigModel> GetConfigAsync()
        {
            using (FileStream fs = File.OpenRead(_configFilePath))
            {
                return await JsonSerializer.DeserializeAsync<ConfigModel>(fs);
            }
        }
    }
}
