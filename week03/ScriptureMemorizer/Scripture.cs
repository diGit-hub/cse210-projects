using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] stringsList = text.Split(" ");

        foreach (string word in stringsList)
        {
            Word wordObj = new Word(word);
            _words.Add(wordObj);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int visibleCount = 0;
        foreach (var word in _words)
        {
            if (!word.IsHidden()) visibleCount++;
        }

        int target = numberToHide > visibleCount ? visibleCount : numberToHide;

        if (target == 0) return;

        var random = new Random();

        while (target > 0)
        {
            int index = random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                target--;
            }
        }
    }

    public string GetDisplayText()
    {
        string scriptureText = _reference.GetDisplayText();
        foreach (Word word in _words)
        {
            scriptureText += " " + word.GetDisplayText();
        }

        return scriptureText;
    }

    public bool IsCompletelyHidden()
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