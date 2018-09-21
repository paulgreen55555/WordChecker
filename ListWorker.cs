using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordChecker
{
    class ListWorker
    {

        public static Dictionary<string, int> PrepareDictionary(List<string> list)
        {
            Dictionary<string,int> tempDictionary = new Dictionary<string, int>();

            foreach (string item in list)
            {
                if (item.Length > 0)
                {
                    if (!tempDictionary.ContainsKey(item))
                    {
                        tempDictionary.Add(item, 1);
                    }
                    else
                    {
                        tempDictionary[item] = tempDictionary[item] + 1;
                    }
                }
            }

            return tempDictionary;
        }


        public static VocabularModel FinalDictionary(Dictionary<string,int> prDictionary)
        {
            char tempFirstLetter = ' ';
             VocabularModel vocabular = new VocabularModel();

            foreach (KeyValuePair<string, int> item in prDictionary)
            {
                if (item.Key[0] != tempFirstLetter)
                {
                    vocabular.Vocabular.Add(new VocabularItemModel() { FirstLetter = item.Key[0], Words = new List<KeyValuePair<string, int>>() { item } });
                    tempFirstLetter = item.Key[0];
                }
                else
                {
                    var element = vocabular.Vocabular.FirstOrDefault(e => e.FirstLetter == item.Key[0]);
                    if (element != null)
                    {
                        element.Words.Add(item);
                    }
                }
            }

            return vocabular;
        }


        public static List<string> VocabularToPresentation(VocabularModel model)
        {
            List<string> result = new List<string>();

            foreach (var el in model.Vocabular)
            {
                result.Add(string.Format("{0}", el.FirstLetter.ToString()));

                foreach (var word in el.Words)
                {
                    result.Add(string.Format("{0} --- {1}", word.Key, word.Value) );
                }
            }

            return result;
        }
    }
}
