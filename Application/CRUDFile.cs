using DataModel;
using DataModel.DataModel;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;

namespace Application
{
    public class CRUDFile<T> : ICRUD<T> where T: class,IEntity
    {



        public void Create(T item)
        {
            var list = ReadAll();
            if(list.Count() > 0)
            {
                item.id = list.Max(x => x.id) + 1;
            }
            else
            {
                item.id = 0;
            }
            FileContext.sw.WriteLine(JsonConvert.SerializeObject(item));
            FileContext.sw.Close();

            //File.WriteAllLines(FileContext.fileLocation, JsonConvert.SerializeObject(item).ToList());

        }

        public IEnumerable<T> ReadAll()
        {

            var list = new List<T>();
            var lines = File.ReadLines(FileContext.fileLocation).ToList();
            for (var i = 0; i < lines.Count; i++)
            {
                list.Add(JsonConvert.DeserializeObject<T>(lines[i]));
            }
            return list;

        }

        public T ReadById(int id)
        {
            var list = new List<T>();
            var lines = File.ReadLines(FileContext.fileLocation).ToList();
            for (var i = 0; i < lines.Count ; i++)
            {
                list.Add(JsonConvert.DeserializeObject<T>(lines[i]));
            }
            return list.Where(x => x.id == id).Single();
        }


        public void Delete(int id)
        {
            var list = new List<string>();
            var tempFile = Path.GetTempFileName();
            var lines = File.ReadLines(FileContext.fileLocation).ToList();
            for (var i = 0; i < lines.Count; i++)
            {
                var line = JsonConvert.DeserializeObject<T>(lines[i]);
                if (line.id == id)
                {
                    continue;
                }
                list.Add(lines[i]);
            }
            File.WriteAllLines(tempFile, list);
            File.Delete(FileContext.fileLocation);
            File.Move(tempFile, FileContext.fileLocation);
        }

        public void Update( T item)
        {
            var list = new List<string>();
            var tempFile = Path.GetTempFileName();
            var lines = File.ReadLines(FileContext.fileLocation).ToList();
            for (var i = 0; i < lines.Count; i++)
            {
                var line = JsonConvert.DeserializeObject<T>(lines[i]);
                if (line.id == item.id)
                {
                    list.Add(JsonConvert.SerializeObject(item));
                    continue;
                }
                list.Add(lines[i]);
            }
            File.WriteAllLines(tempFile, list);
            File.Delete(FileContext.fileLocation);
            File.Move(tempFile, FileContext.fileLocation);
        }


    }
}
