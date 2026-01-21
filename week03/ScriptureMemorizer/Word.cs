using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Exceeds core requirements:
        // Preserve trailing punctuation (e.g., "heart;" -> "_____;", "paths." -> "_____.")
        int lastLetterIndex = _text.Length - 1;

        while (lastLetterIndex >= 0 && !char.IsLetterOrDigit(_text[lastLetterIndex]))
        {
            lastLetterIndex--;
        }

        if (lastLetterIndex < 0)
        {
            return new string('_', _text.Length);
        }

        string core = _text.Substring(0, lastLetterIndex + 1);
        string punctuation = _text.Substring(lastLetterIndex + 1);

        return new string('_', core.Length) + punctuation;
    }
}
