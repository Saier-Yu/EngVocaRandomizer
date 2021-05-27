using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngVocaRandomizer.Common
{
    class VocaData
    {
        // 인덱스 번호
        private int _index = 0; 
        public string index { get { return _index.ToString("D4"); } set { Int32.TryParse(value, out _index); } }
        // 영어 단어
        private string _vocaEn = "";
        public string vocaEn { get { return _vocaEn; } set { _vocaEn = value; } }
        // 영어 단어 뜻
        private string _vocaMean = "";
        public string vocaMean { get { return _vocaMean; } set { _vocaMean = value; } }
        // 분류
        private string _category = "";
        public string category { get { return _category; } set { _category = value; } }
    }

    static class VocaDataList
    {
        // 인덱스 번호
        private static List<VocaData> _dataList = new List<VocaData>();
        public static List<VocaData> dataList { get { return _dataList; } set { _dataList = value; } }
    }
}
