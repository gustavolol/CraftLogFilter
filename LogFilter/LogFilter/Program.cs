using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawDataFolder=@"D:\RProgramming\FFXIVCrafting\RawData";
            string qualityOutFile = @"D:\RProgramming\FFXIVCrafting\ParsedData\QualityOut.csv";
            var qualityFiles =
                Directory.GetFiles(rawDataFolder).ToList().FindAll(n => n.Contains("Quality") || n.Contains("quality")).ToArray();
            var progressFiles= Directory.GetFiles(rawDataFolder).ToList().FindAll(n => n.Contains("Progress") || n.Contains("progress")).ToArray();
            var qualityEntries = QualityParser.GetEntriesFromFiles(qualityFiles);
            Dictionary<int,QualityEntry> dictionaryQuality=new Dictionary<int, QualityEntry>();
            
            foreach (var qual in qualityEntries)
            {
                QualityEntry targetEntry;
                
                if (dictionaryQuality.TryGetValue(qual.GetHashCode(), out targetEntry))
                {
                    targetEntry.Hits++;
                }
                else
                {
                    dictionaryQuality.Add(qual.GetHashCode(), qual);
                }
            }
            qualityEntries=dictionaryQuality.Values.ToList();
            for (int k = qualityEntries.Count-1; k >= 1; k--)
            {
                var curEntry = qualityEntries[k];
                for (int n = k-1;n >=0; n--)
                {
                    if (curEntry.Equals(qualityEntries[n]))
                    {
                        
                        Console.WriteLine($"\nConflict:\n{curEntry}\n{qualityEntries[n]}");
                        if (curEntry.Hits > qualityEntries[n].Hits)
                        {
                            Console.WriteLine("Removing 2nd entry.");
                            qualityEntries.RemoveAt(n);
                        }
                        else if (curEntry.Hits < qualityEntries[n].Hits)
                        {
                            Console.WriteLine("Removing first entry.");
                            qualityEntries.RemoveAt(k);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Removing both entries.");
                            qualityEntries.RemoveAt(k);
                            qualityEntries.RemoveAt(n);
                            k--;
                        }

                    }
                }
            }
            
            Console.WriteLine($"Total counts including 1 hits {qualityEntries.Count}");
            qualityEntries.RemoveAll(n => n.Hits == 1);
            Console.WriteLine($"Total counts excluding 1 hits {qualityEntries.Count}");
            QualityParser.WriteQualityCsv(qualityEntries,qualityOutFile);
            Console.ReadLine();

        }
    }
}
