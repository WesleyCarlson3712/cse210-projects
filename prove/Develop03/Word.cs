public class Word
{
    private string _word;
    private bool _hidden;

    public Word(string word)
    {
        _word = word;
        _hidden = false;
    }
    public bool IsHidden()
    {
        return _hidden;
    }
    public void Hide()
    {
        _hidden = true;
    }
    public string GetWord()
    {
        if(_hidden)
        {
            return new string('_', _word.Length);
        }
        return _word;
    }
}