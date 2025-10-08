using System;

public class PromptGenerator
{
    public List<string> _prompts = new List<string>();
    public string GetPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}