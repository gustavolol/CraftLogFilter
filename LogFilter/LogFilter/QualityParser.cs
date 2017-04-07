using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace LogFilter
{
    public static class QualityParser
    {
        public static List<QualityEntry> GetEntriesFromFiles(string[] fileList)
        {
            List<QualityEntry> retList=new List<QualityEntry>();
            foreach (var file in fileList)
            {
                using (TextReader treader = File.OpenText(file))
                {
                    var csv=new CsvReader(treader);
                    while (csv.Read())
                    {
                        var qualityEntry = new QualityEntry
                        {
                            CharLevel = csv.GetField<int>(0),
                            ItemLevel = csv.GetField<int>(1),
                            ItemName = csv.GetField<string>(2),
                            SkillName = csv.GetField<string>(3),
                            Coefficient = csv.GetField<double>(4),
                            BaseControl = csv.GetField<int>(5),
                            CurrentControl = (int) csv.GetField<double>(6),
                            Condition = csv.GetField<int>(7),
                            IqStacks = csv.GetField<int>(8),
                            GreatStrides = csv.GetField<bool>(9),
                            Ingenuity1 = csv.GetField<bool>(10),
                            Ingenuity2 = csv.GetField<bool>(11),
                            Innovation = csv.GetField<bool>(12),
                            Increase = csv.GetField<int>(13),
                            IncreaseB = csv.GetField<int>(14),
                            SimIncrease = csv.GetField<int>(15),
                            Error = csv.GetField<int>(16),
                            CurQuality = csv.GetField<int>(17),
                            MaxQuality = csv.GetField<int>(18),
                            Hits = 1
                        };
                        retList.Add(qualityEntry);
                    }
                }

            }


            return retList;
        }

        public static void WriteQualityCsv(List<QualityEntry> qualityOut,string fileOut )
        {

            using (TextWriter textWriter = new StreamWriter(fileOut))
            {
                var csv=new CsvWriter(textWriter);
                
                foreach (var qual in qualityOut)
                {
                    
                    csv.WriteField(qual.CharLevel);
                    csv.WriteField(qual.ItemLevel);
                    csv.WriteField(qual.ItemName);
                    csv.WriteField(qual.SkillName);
                    csv.WriteField(qual.Coefficient);
                    csv.WriteField(qual.BaseControl);
                    csv.WriteField(qual.CurrentControl);
                    csv.WriteField(qual.Condition);
                    csv.WriteField(qual.IqStacks);
                    csv.WriteField(qual.GreatStrides);
                    csv.WriteField(qual.Ingenuity1);
                    csv.WriteField(qual.Ingenuity2);
                    csv.WriteField(qual.Innovation);
                    csv.WriteField(qual.Increase);
                    csv.WriteField(qual.IncreaseB);
                    csv.WriteField(qual.SimIncrease);
                    csv.WriteField(qual.Error);
                    csv.WriteField(qual.CurQuality);
                    csv.WriteField(qual.MaxQuality);
                    csv.WriteField(qual.Hits);
                    csv.NextRecord();
                }
                
            }
            

        }
    }
}
