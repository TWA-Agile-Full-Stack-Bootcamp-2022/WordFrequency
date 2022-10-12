namespace WordFrequency
{
    public class FrequencyWord
    {
        private string word;
        private int count;

        public FrequencyWord(string word, int count)
        {
            this.word = word;
            this.count = count;
        }

        public string Word
        {
            get { return this.word; }
        }

        public int WordCount
        {
            get { return this.count; }
        }
    }
}
