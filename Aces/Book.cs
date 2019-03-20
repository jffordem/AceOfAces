using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Aces
{
    public class Book
    {
        IDictionary<string, IDictionary<int, string>> values;

        public static Book loadGermans() { return load("germans"); }
        public static Book loadAllies() { return load("allies");  }
        private static Book load(String name)
        {
            // name should be "germans" or "allies"
            IDictionary<string, IDictionary<int, string>> values = new Dictionary<string, IDictionary<int, string>>();

            bool header = true;
            string resourceName = string.Format("Aces.Resources.{0}.csv", name);
            // Stream stream = global::Aces.Properties.Resources.ResourceManager.GetStream(resourceName);
            Stream stream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
            using (var reader = new StreamReader(stream))
            {
                for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
                {
                    String[] fields = line.Split(',');
                    if (header)
                    {
                        header = false;
                    }
                    else
                    {
                        values[fields[0]] = new Dictionary<int, string>();
                        for (int i = 1; i <= 223; i++)
                        {
                            values[fields[0]][i] = fields[i];
                        }
                    }
                }
            }
            return new Book(values);
        }

        private Book(IDictionary<string, IDictionary<int, string>> values)
        {
            this.values = values;
        }
        public string Lookup(String maneuver, int page)
        {
            return values[maneuver][page];
        }
        public int LookupInt(String row, int page)
        {
            return Int32.Parse(Lookup(row, page));
        }
        public bool LookupBool(String row, int page)
        {
            return bool.Parse(Lookup(row, page));
        }
        public int LookupPage(String maneuver, int page)
        {
            return LookupInt(maneuver, page);
        }
    }
}
