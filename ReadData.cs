using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Formulaire
{
    public class ReadData
    {
        public string file_name;
        public string jsonStr;
        public List<Class1> client;

        public List<Class1> ReadDataFromJson()
        {
            file_name = @"C:\\Users\\zizir\\source\\repos\\Formulaire\\Formulaire\Data.json";


            using (StreamReader r = new StreamReader(file_name))
            {
                jsonStr = r.ReadToEnd();
                client = JsonConvert.DeserializeObject<List<Class1>>(jsonStr);
            }
            return client;
        }

    }


}

