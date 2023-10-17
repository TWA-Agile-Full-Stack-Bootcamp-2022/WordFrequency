namespace WordFrequency
{
    public class WordFrequency
    {
        private string word;
        private int count;

        public WordFrequency(string word, int count)
        {
            this.word = word;
            this.count = count;
        }

        public string Word
        {
            get { return word; }
        }

        public int Count
        {
            get { return count; }
        }
    }
}
