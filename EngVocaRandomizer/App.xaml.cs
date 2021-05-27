using EngVocaRandomizer.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Excel = Microsoft.Office.Interop.Excel;


namespace EngVocaRandomizer
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            VocaDataList.dataList = ExcelCtrl.ReadExcel();

            //var mainWindow = new MainWindow();
            //Current.ShutdownMode = System.Windows.ShutdownMode.OnMainWindowClose;
            //Current.MainWindow = mainWindow;
            //mainWindow.Show();
        }


    }

}
