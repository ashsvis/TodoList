using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using TodoList.Models;

namespace TodoList.Services
{
    class FileIOService
    {
        private readonly string PATH;

        public FileIOService(string path)
        {
            PATH = path;
        }

        public BindingList<TodoModel> LoadData()
        {
            bool fileExists = File.Exists(PATH);
            if (!fileExists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<TodoModel>();
            }
            using (StreamReader reader = File.OpenText(PATH))
            {
                string input = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<BindingList<TodoModel>>(input);
            }
        }

        public void SaveData(object todoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(todoDataList);
                writer.Write(output);
            }
        }
    }
}
