using System.Text.Json;

namespace ControleFluxoCaixa.CQRS.COMANDS
{
    public class JsonFileService
    {
        private readonly string _filePath;

        public JsonFileService(string filePath)
        {
            _filePath = filePath;
        }

        public async Task WriteToFileAsync<T>(T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            await File.WriteAllTextAsync(_filePath, jsonData);
        }

        public async Task<T> ReadFromFileAsync<T>()
        {
            if (!File.Exists(_filePath)) return default(T);

            var jsonData = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<T>(jsonData);
        }
    }

}
