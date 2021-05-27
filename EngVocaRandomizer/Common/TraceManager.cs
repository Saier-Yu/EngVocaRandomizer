using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngVocaRandomizer.Common
{
    /// <summary>
    /// 로그관리 클래스
    /// </summary>
    public class TraceManager
    {
        public TraceManager()
        {
            saveFolder = System.Environment.GetCommandLineArgs()[0];
        }

        static string saveFolder = System.IO.Directory.GetCurrentDirectory();
        /// <summary>
        /// LOG를 저장할 기본 위치 (기본값 : 프로그램 시작위치)
        /// </summary>
        public static string StartupFolder
        {
            get { return saveFolder; }
            set { saveFolder = value; }
        }

        static int traceMaxDay = 30;
        /// <summary>
        /// 최대보관일
        /// </summary>
        public static int TraceMaxDay
        {
            get { return TraceManager.traceMaxDay; }
            set
            {
                TraceManager.traceMaxDay = value;
                if (traceMaxDay <= 0) traceMaxDay = 1;
            }
        }

        static string logFolerName = "Trace";
        /// <summary>
        /// 저장할 폴더명 (기본 : Trace )
        /// </summary>
        public static string LogFolerName
        {
            get { return logFolerName; }
            set { logFolerName = value; }
        }

        static string logHeadName = "log";
        /// <summary>
        /// 저장할 폴더명 (기본 : Trace )
        /// </summary>
        public static string LogHeadName
        {
            get { return logHeadName; }
            set { logHeadName = value; }
        }

        static bool _showDateTime = true;
        /// <summary>
        /// 저장할 폴더명 (기본 : Trace )
        /// </summary>
        public static bool ShowDateTime
        {
            get { return _showDateTime; }
            set { _showDateTime = value; }
        }
        
        public static void AddLog(string log)
        {
            System.Diagnostics.Debug.WriteLine(log);
            Console.WriteLine(log);
            try
            {
                string folder = System.IO.Path.Combine(saveFolder, logFolerName);

                if (System.IO.Directory.Exists(folder) == false) System.IO.Directory.CreateDirectory(folder);
                string fileName = folder + string.Format("\\{0}_", "log") + DateTime.Now.ToString("yyyyMMdd") + ".log";

                if (_showDateTime == true)
                {
                    DateTime dtm = DateTime.Now;
                    string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                        dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                    log = formatDateTime + log;
                }

                System.IO.StreamWriter sw = System.IO.File.AppendText(fileName);
                sw.WriteLine(log);
                sw.Close();

                //CheckRemoveFiles(folder);
            }
            catch (Exception ee)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("### {0}\r\n{1} ###", ee.StackTrace, ee.Message));
            }
        }

        /// <summary>
        /// 프로그램 실행시 중요정보 저장
        /// </summary>
        public static void AddLine(string log)
        {
            System.Diagnostics.Debug.WriteLine(log);
            try
            {
                string folder = System.IO.Path.Combine(saveFolder, logFolerName);

                if (System.IO.Directory.Exists(folder) == false) System.IO.Directory.CreateDirectory(folder);

                string fileName = folder + "\\" + logHeadName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                if (_showDateTime == true)
                {
                    DateTime dtm = DateTime.Now;
                    string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                        dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                    log = formatDateTime + log;
                }

                System.IO.StreamWriter sw = System.IO.File.AppendText(fileName);
                sw.WriteLine(log);
                sw.Close();

               // CheckRemoveFiles(folder);
            }
            catch (Exception ex)
            {
                AddLog(string.Format("로그 추가 실패 : {0}", ex.Message));
            }
        }

        /// <summary>
        /// 프로그램 실행시 중요정보 저장
        /// </summary>
        public static void AddLine(string log , string TitleName)
        {
            Console.WriteLine(log); 
            try
            {
                string folder = System.IO.Path.Combine(saveFolder, logFolerName);

                if (System.IO.Directory.Exists(folder) == false) System.IO.Directory.CreateDirectory(folder);

                string fileName = folder + "\\" + TitleName + "_" + DateTime.Now.ToString("yyyyMMdd") + ".log";

                if (_showDateTime == true)
                {
                    DateTime dtm = DateTime.Now;
                    string formatDateTime = string.Format("{0:0000}/{1:00}/{2:00} {3:00}:{4:00}:{5:00} [{6:000}] ",
                        dtm.Year, dtm.Month, dtm.Day, dtm.Hour, dtm.Minute, dtm.Second, dtm.Millisecond);
                    log = formatDateTime + log;
                }

                System.IO.StreamWriter sw = System.IO.File.AppendText(fileName);
                sw.WriteLine(log);
                sw.Close();

                // CheckRemoveFiles(folder);
            }
            catch (Exception ex)
            {
                AddLog(string.Format("로그 추가 실패 : {0}", ex.Message));
            }
        }

        /// <summary>
        /// 일자가 지난 파일들을 삭제한다.
        /// </summary>
        /// <param name="folder"></param>
        static void CheckRemoveFiles(string folder)
        {
            int maxHour = TraceMaxDay * 24; //

            string[] files = System.IO.Directory.GetFiles(folder);
            for (int i = 0; i < files.Length; i++)
            {
                DateTime tm = System.IO.File.GetLastAccessTime(files[i]);
                TimeSpan span = DateTime.Now - tm;
                if (span.TotalHours >= maxHour)
                {
                    System.IO.File.Delete(files[i]);
                }
            }
        }

        public static void ClearRemoveFiles()
        {
            try
            {
                int maxHour = TraceMaxDay * 24; //

                string folder = System.IO.Path.Combine(saveFolder, logFolerName);
                if (System.IO.Directory.Exists(folder) == false) return;

                string[] files = System.IO.Directory.GetFiles(folder);
                for (int i = 0; i < files.Length; i++)
                {
                    DateTime tm = System.IO.File.GetLastAccessTime(files[i]);
                    TimeSpan span = DateTime.Now - tm;
                    if (span.TotalHours >= maxHour)
                    {
                        System.IO.File.Delete(files[i]);
                    }
                }
            }
            catch (Exception ee)
            {
                Console.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
                System.Diagnostics.Debug.WriteLine(string.Format("{0}\r\n{1}", ee.StackTrace, ee.Message));
            }
        }
    }
}