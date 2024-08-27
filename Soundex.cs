using System;
using System.Collections.Generic;
using System.Text;
 
public class Soundex
{
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
 
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
 
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);
 
        ProcessCharacters(name, soundex, ref prevCode);
 
        return PadSoundex(soundex).ToString();
    }
 
    private static void ProcessCharacters(string name, StringBuilder soundex, ref char prevCode)
    {
        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            AppendSoundexCode(name[i], soundex, ref prevCode);
        }
    }
 
    private static void AppendSoundexCode(char c, StringBuilder soundex, ref char prevCode)
    {
        char code = GetSoundexCode(c);
        if (IsAppendableCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }
 
    private static bool IsAppendableCode(char code, char prevCode)
    {
        return code != '0' && code != prevCode;
    }
 
    private static StringBuilder PadSoundex(StringBuilder soundex)
    {
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
 
        return soundex;
    }
 
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        return soundexMap.ContainsKey(c) ? soundexMap[c] : '0';
    }
}
