using System.Collections.Generic;

namespace WordChecker
{
    public class VocabularItemModel
    {
        public char FirstLetter { get; set; }

        public List<KeyValuePair<string, int>> Words { get; set; }

        public VocabularItemModel()
        {
            Words = new List<KeyValuePair<string, int>>();
        }

    }
}
