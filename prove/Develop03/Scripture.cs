public class Scripture
{
    private List<Word> _words = new List<Word>();
    private Refrence _reference;

    public Scripture(string reference, string verse)
    {
        // word parsing
        string[] wordArray = verse.Split(' ');
        foreach (string word in wordArray)
        {
            _words.Add(new Word(word));
        }

        // reference parsing
        string[] refParts = reference.Split(' ');
        string book = refParts[0];
        string[] chapterVerse = refParts[1].Split(':');
        int chapter = int.Parse(chapterVerse[0]);
        string[] verses = chapterVerse[1].Split('-');
        int verseNum = int.Parse(verses[0]);
        int endVerseNum = 0;
        if (verses.Length > 1)
        {
            endVerseNum = int.Parse(verses[1]);
        }
        if (endVerseNum > 0)
        {
            _reference = new Refrence(book, chapter, verseNum, endVerseNum);
        }
        else
        {
            _reference = new Refrence(book, chapter, verseNum);
        }

    }
    // rewrite this method to not hide already hidden words
    public void HideWords()
    {
        for (int i = 0; i < 3; i++)
        {
            Random rand = new Random();
            int index = rand.Next(_words.Count);
            if (!IsCompletlyHidden()) {
                while (_words[index].IsHidden())
                {
                    index = rand.Next(_words.Count);
                }
            }
            _words[index].Hide();
        }
    }
    
    public void DisplayScripture()
    {
        Console.Write($"{_reference.GetReferenceString()} ");
        foreach(Word word in _words)
        {
            Console.Write(word.GetWord() + " ");
        }
        Console.WriteLine();
    }
    public bool IsCompletlyHidden()
    {
        foreach(Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

}