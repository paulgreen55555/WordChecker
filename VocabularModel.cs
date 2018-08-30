using System.Collections.Generic;

namespace WordChecker
{
    public class VocabularModel
    {
        public List<VocabularItemModel> Vocabular { get; set; }

        public VocabularModel()
        {
            Vocabular = new List<VocabularItemModel>();
        }
    }
}
