using System;
using System.Collections.Generic;
using System.Text;

public class Soundex
{
    // Mapping of letters to their respective Soundex codes
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
        // Check for null or empty input
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }

        // Initialize a StringBuilder to construct the Soundex code
        StringBuilder soundex = new StringBuilder();

        // Append the first letter of the name (converted to uppercase) to the Soundex code
        soundex.Append(char.ToUpper(name[0]));

        // Get the Soundex code for the first character
        char prevCode = GetSoundexCode(name[0]);

        // Process the remaining characters in the name
        ProcessCharacters(name, soundex, ref prevCode);

        // Pad the Soundex code with zeros if it is less than 4 characters long
        return PadSoundex(soundex).ToString();
    }

    // Processes characters in the name to generate the Soundex code
    private static void ProcessCharacters(string name, StringBuilder soundex, ref char prevCode)
    {
        // Loop through the name starting from the second character
        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            // Append the Soundex code for the current character if applicable
            AppendSoundexCode(name[i], soundex, ref prevCode);
        }
    }

    // Appends the Soundex code for a character to the result if it meets the conditions
    private static void AppendSoundexCode(char c, StringBuilder soundex, ref char prevCode)
    {
        // Get the Soundex code for the current character
        char code = GetSoundexCode(c);

        // Append the code to the Soundex result if it is valid and different from the previous code
        if (IsAppendableCode(code, prevCode))
        {
            soundex.Append(code);
            prevCode = code;
        }
    }

    // Determines if a Soundex code should be appended to the result
    private static bool IsAppendableCode(char code, char prevCode)
    {
        // Return true if the code is not '0' and different from the previous code
        return code != '0' && code != prevCode;
    }

    // Pads the Soundex result with zeros if it is less than 4 characters long
    private static StringBuilder PadSoundex(StringBuilder soundex)
    {
        // Append zeros until the Soundex result is 4 characters long
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }

        // Return the padded Soundex result
        return soundex;
    }

    // Retrieves the Soundex code for a given character
    private static char GetSoundexCode(char c)
    {
        // Convert the character to uppercase
        c = char.ToUpper(c);

        // Return the corresponding Soundex code or '0' if the character is not in the map
        return soundexMap.ContainsKey(c) ? soundexMap[c] : '0';
    }
}
