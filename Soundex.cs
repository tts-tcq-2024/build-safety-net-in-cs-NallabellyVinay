using System;
using System.Collections.Generic;
using System.Text;

public class Soundex
{
    // Mapping of consonants to Soundex codes
    private static readonly Dictionary<char, char> soundexMap = new Dictionary<char, char>
    {
        { 'B', '1' }, { 'F', '1' }, { 'P', '1' }, { 'V', '1' },
        { 'C', '2' }, { 'G', '2' }, { 'J', '2' }, { 'K', '2' },
        { 'Q', '2' }, { 'S', '2' }, { 'X', '2' }, { 'Z', '2' },
        { 'D', '3' }, { 'T', '3' },
        { 'L', '4' },
        { 'M', '5' }, { 'N', '5' },
        { 'R', '6' }
    };

    // Generates the Soundex code for a given name
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty; // Handle empty or null string
        }

        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0])); // First letter of the name
        char prevCode = GetSoundexCode(name[0]);

        ProcessCharacters(name, soundex, ref prevCode);

        return PadSoundex(soundex).ToString();
    }

    // Processes the characters of the name to generate the Soundex code
    private static void ProcessCharacters(string name, StringBuilder soundex, ref char prevCode)
    {
        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            AppendSoundexCode(name[i], soundex, ref prevCode);
        }
    }

    // Appends the Soundex code for a character if applicable
    private static void AppendSoundexCode(char c, StringBuilder soundex, ref char prevCode)
    {
        char code = GetSoundexCode(c);
        if (IsAppendableCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    // Determines if the Soundex code should be appended
    private static bool IsAppendableCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
    }

    // Pads the Soundex code with zeros to ensure it is four characters long
    private static StringBuilder PadSoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }

        return soundex;
    }

    // Retrieves the Soundex code for a given character
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return soundexMap.ContainsKey(c) ? soundexMap[c] : '0';
    }
}
