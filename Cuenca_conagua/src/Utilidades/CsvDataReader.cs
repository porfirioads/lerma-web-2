using System;
using System.Collections.Generic;
using System.IO;
using LumenWorks.Framework.IO.Csv;

namespace Cuenca_conagua.src.Utilidades
{
    public class CsvDataReader
    {
        public static List<Dictionary<string, string>> ReadCsv(string filename)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            using (CsvReader csv = new CsvReader(new StreamReader(filename), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                Logger.AddToLog("Csv filename: " + filename, true);
                Logger.AddToLog("Csv fields: " + fieldCount, true);
                Logger.AddToLog("Csv headers: " + string.Join(", ", headers), true);

                while (csv.ReadNextRecord())
                {
                    string[] record = new string[fieldCount];
                    csv.CopyCurrentRecordTo(record);
                    Logger.AddToLog("Csv row: " + string.Join(", ", record), true);

                    data.Add(new Dictionary<string, string>());

                    for (int i = 0; i < fieldCount; i++)
                        data[data.Count - 1].Add(headers[i], record[i]);
                }
            }

            return data;
        }
    }
}