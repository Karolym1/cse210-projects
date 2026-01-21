using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        foreach (string part in parts)
        {
            _words.Add(new Word(part));
        }
    }

    public string GetDisplayText()
    {
        string referenceText = _reference.GetDisplayText();
        string wordsText = string.Join(" ", _words.ConvertAll(w => w.GetDisplayText()));
        return $"{referenceText} - {wordsText}";
    }

    public void HideRandomWords(int numberToHide)
    {
        // Collect indexes of words that are not hidden yet
        List<int> visibleIndexes = new List<int>();
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                visibleIndexes.Add(i);
            }
        }

        // Hide up to numberToHide words (or whatever is left visible)
        int toHide = Math.Min(numberToHide, visibleIndexes.Count);

        for (int i = 0; i < toHide; i++)
        {
            int pickIndex = _random.Next(visibleIndexes.Count);
            int wordIndex = visibleIndexes[pickIndex];

            _words[wordIndex].Hide();

            // Remove so we don't hide the same word twice this round
            visibleIndexes.RemoveAt(pickIndex);
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word w in _words)
        {
            if (!w.IsHidden())
            {
                return false;
            }
        }
        return true;
    }
}

