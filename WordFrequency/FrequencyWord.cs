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

        public string Word => this.word;

        public int WordCount => this.count;

        public override string ToString()
        {
            return $"{word} {count}";
        }
    }
}
