using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace EngVocaRandomizer.Common
{
    static class ExcelCtrl
    {
        static string _fname = "voca.xlsx";
        static Excel.Application xlApp = null;
        static Excel.Workbook xlWb = null;
        static Excel.Worksheet xlWs = null;
        //Excel.Range range = null;

        private static bool SettingExcel()
        {
            string path = System.IO.Path.Combine(Environment.CurrentDirectory, _fname);
            try
            {
                xlApp = new Excel.Application();
                xlWb = xlApp.Workbooks.Open(path, 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWs = xlWb.Worksheets.get_Item(1) as Excel.Worksheet;
            }
            catch(Exception ee)
            {
                TraceManager.AddLog(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
            }
            return xlApp != null;
        }

        public static void OpenExcel()
        {
            try
            {
                xlApp.Visible = true;
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee);
            }
        }

        public static List<VocaData> ReadExcel()
        {
            int rCnt = 1, cCnt = 1;

            List<VocaData> result = new List<VocaData>();
            VocaData data = new VocaData();
            
            SettingExcel();
            
            while (true)
            {
                string str = Convert.ToString((/*range*/xlWs.Cells[cCnt][rCnt] as Excel.Range).Value2);
                if (str == null)
                    break;
                switch (cCnt)
                {
                    case 1: // 엑셀 1열은 카테고리
                        data.category = str;
                        cCnt++;
                        break;
                    case 2: // 엑셀 2열은 인덱스
                        data.index = str;
                        cCnt++;
                        break;
                    case 3: // 엑셀 3열은 영어 단어
                        data.vocaEn = str;
                        cCnt++;
                        break;
                    case 4: // 엑셀 3열은 영어 단어 뜻
                        data.vocaMean = str;
                        result.Add(data);
                        data = null;
                        GC.Collect();
                        data = new VocaData();
                        cCnt = 1;
                        rCnt++;
                        break;
                }
            }


            //for (rCnt = 1; rCnt <= range.Rows.Count; rCnt++) 
            //{
            //    Common.VocaData data = new Common.VocaData();
            //    for (cCnt = 1; cCnt <= range.Columns.Count; cCnt++)
            //    {
            //        var str = (range.Cells[cCnt][rCnt] as Excel.Range).Value2;
            //        switch (cCnt)
            //        {
            //            case 1: // 엑셀 1열은 카테고리
            //                data.category = Convert.ToString(str);
            //                break;
            //            case 2: // 엑셀 2열은 인덱스
            //                data.index = Convert.ToString(str);
            //                break;
            //            case 3: // 엑셀 3열은 영어 단어
            //                data.vocaEn = Convert.ToString(str);
            //                break;
            //            case 4: // 엑셀 3열은 영어 단어 뜻
            //                data.vocaMean = Convert.ToString(str);
            //                break;
            //        }
            //    }
            //    result.Add(data);
            //}
            return result;
        }
    }
}
