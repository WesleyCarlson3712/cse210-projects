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
    // public void HideWords()
    // {
    //     int wordsToHide = Math.Min(3, _visibleWords.Count);
    //     for (int i = 0; i < wordsToHide; i++)
    //     {
    //         Random rand = new Random();
    //         int index = rand.Next(_visibleWords.Count);
    //         _words[index].Hide();
    //         _visibleWords.RemoveAt(index);
    //     }
    // }
    // the above function doesnt work. i need to hide 3 random words from _words list each time its called without hiding the same word twice

  public void HideWords()
    {
        int visibleWordCount = 0;
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                visibleWordCount++;
            }
        }
        int wordsToHide = Math.Min(3, visibleWordCount);
        Random rand = new Random();
        for (int i = 0; i < wordsToHide; i++)
        {
            int index;
            do
            {
                index = rand.Next(_words.Count);
            } while (_words[index].IsHidden());
            _words[index].Hide();
        }
    }
    public void DisplayScripture()
    {
        Console.Write($"{_reference.GetReferenceString()} ");
        foreach (Word word in _words)
        {
            Console.Write(word.GetWord() + " ");
        }
        Console.WriteLine();
    }
    public bool IsCompletlyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }
        return true;
    }

}