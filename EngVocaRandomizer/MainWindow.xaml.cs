using EngVocaRandomizer.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EngVocaRandomizer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //string str = "";
            //vocaList_lb = Common.VocaDataList.dataList;
            foreach (Common.VocaData voca in Common.VocaDataList.dataList)
            {
                vocaList_lb.Items.Add(voca.index);
                vocaList_eng.Items.Add(voca.vocaEn);
                vocaList_kor.Items.Add(voca.vocaMean);
                //str += voca.vocaEn + "\n";
            }
            vocaList_lb.SelectedItem = vocaList_lb.Items[_selectNum];
            vocaList_eng.SelectedItem = vocaList_eng.Items[_selectNum];
            vocaList_kor.SelectedItem = vocaList_kor.Items[_selectNum];
        }

        private int _selectNum = 0, _lbNum = 0, _engNum = 0, _korNum = 0;

        private void Scr_ValueChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((vocaList_lb.SelectedItem == null) || (vocaList_eng.SelectedItem == null) || (vocaList_kor.SelectedItem == null))
                return;

            if (_lbNum != vocaList_lb.SelectedIndex) _selectNum = _lbNum = vocaList_lb.SelectedIndex;
            if (_engNum != vocaList_eng.SelectedIndex) _selectNum = _engNum = vocaList_eng.SelectedIndex;
            if (_korNum != vocaList_kor.SelectedIndex) _selectNum = _korNum = vocaList_kor.SelectedIndex;

            Console.WriteLine(vocaList_lb.SelectedItem.ToString());
            Console.WriteLine(vocaList_eng.SelectedItem.ToString());
            Console.WriteLine(vocaList_kor.SelectedItem.ToString());

            vocaList_lb.SelectedItem = vocaList_lb.Items[_selectNum];
            vocaList_eng.SelectedItem = vocaList_eng.Items[_selectNum];
            vocaList_kor.SelectedItem = vocaList_kor.Items[_selectNum];
        }

        private void exButton_Click(object sender, RoutedEventArgs e)
        {
            ExcelCtrl.OpenExcel();    
        }
    }
}
