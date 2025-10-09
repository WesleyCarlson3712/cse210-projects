public class Journal
{
    private PromptGenerator _promptGenerator;
    public List<Entry> _entries = new List<Entry>();

    public Journal(PromptGenerator promptGenerator)
    {
        _promptGenerator = promptGenerator;
    }

    public void LoadFile()
    {
        // get filename from user
        Console.Write("Enter the filename to load: ");
        string filename = Console.ReadLine();

        // ensure filename is not empty
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        // load file if it exists
        try
        {
            string[] lines = File.ReadAllLines(filename);
            _entries.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');
                Entry entry = new Entry
                {
                    _date = parts[0],
                    _prompt = parts[1],
                    _response = parts[2]
                };
                _entries.Add(entry);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }     
    }

    public void SaveFile()
    {
        // get filename from user
        Console.Write("Enter the filename to save: ");
        string filename = Console.ReadLine();

        // ensure filename is not empty
        if (string.IsNullOrWhiteSpace(filename))
        {
            Console.WriteLine("Filename cannot be empty.");
            return;
        }

        // save file
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date}|{entry._prompt}|{entry._response}");
            }
        }
    }

    public void DisplayEntries()
    {
        // displays all entries from list of entries
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }
    public void AddEntry()
    {
        // prompts user for response and adds entry to list of entries
        Entry entry = new Entry();

        entry._date = DateTime.Now.ToShortDateString();

        entry._prompt = _promptGenerator.GetPrompt();

        Console.WriteLine(entry._prompt);

        entry._response = Console.ReadLine();
        
        _entries.Add(entry);
    }
}