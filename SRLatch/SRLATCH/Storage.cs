using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using STLATCh;
namespace SRLATCH
{
    public class Storage
    {
        static string STORAGE = "MyStore.txt";
        static string TruthTableFile = "TT.txt";
        public static bool SaveData(int val)
        {
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.Write( val);
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }
        public static bool SaveTT(String str,int flg)
        {
            var md=FileMode.Append;
            if (flg == 0)
                md = FileMode.Create;
            
            var fs = new FileStream(TruthTableFile,md);
            var sw = new StreamWriter(fs);
            sw.Write(str);
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }


        public static int ReadData()
        {
            if (!File.Exists(STORAGE))
            {
                return 0;
            }
            var data = File.ReadAllText(STORAGE);
            var inValue = int.Parse(data);
                return inValue;
        }


      
        public static bool SaveTruthTableData(int val1, int val2,  int result)
        {
            var fs = new FileStream(STORAGE, FileMode.Create);
            var sw = new StreamWriter(fs);
            sw.WriteLine($"{val1}, {val2}, {result}");
            sw.Flush();
            sw.Close();
            fs.Close();
            return true;
        }

        public static bool SaveTruthTableData(TruthTable tt )
        {
            
            return SaveTruthTableData(
                                        tt.S ? 1 : 0,
                                        tt.R ? 1 : 0, 
                                        tt.Q_prev ? 1 : 0
                                        );
        }
        public static TruthTable ReadTruthTable()
        {
            var inputRow = new TruthTable();
            if (!File.Exists(STORAGE))
            {
                return inputRow;
            }
            var data = File.ReadAllText(STORAGE);
            var dataElements = data.Split(','); // 0,1,0,1  will be split into arrays
            if (dataElements[0] != "S") { 
                inputRow.S = Utility.ConvertToBoolean(dataElements[0]);
                inputRow.R = Utility.ConvertToBoolean(dataElements[1]);
                inputRow.Q_prev = Utility.ConvertToBoolean(dataElements[2]);
        
            }
            return inputRow;
        }

        public static List<TruthTable> ReadTruthTableData(string dataPath)
        {
            var inputList = new List<TruthTable>();
            var fs = new FileStream(dataPath, FileMode.Open);
            var sr = new StreamReader(fs);

            while (sr.Peek() > -1) // peek and read till End of File
            {
                var inputRow = new TruthTable();

                var data = sr.ReadLine();
                var dataElements = data.Split(','); // 0,1,0,1  will be split into arrays
                if (dataElements[0] != "S")
                {
                    inputRow.S = Utility.ConvertToBoolean(dataElements[0]);
                    inputRow.R = Utility.ConvertToBoolean(dataElements[1]);
                    inputRow.Q_prev = Utility.ConvertToBoolean(dataElements[2]);
                    inputList.Add(inputRow);
                }
            }

            sr.Close();
            fs.Close();

            return inputList;
        }

    }
}
