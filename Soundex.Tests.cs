using Xunit;

public class SoundexTests
{
    [Fact]
    public void HandlesEmptyString()
    {
        Assert.Equal(string.Empty, Soundex.GenerateSoundex(""));
    }

    [Fact]
    public void HandlesSingleCharacter()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("A"));
        Assert.Equal("Z000", Soundex.GenerateSoundex("Z"));
    }

    [Fact]
    public void HandlesLowercaseInput()
    {
        Assert.Equal("A000", Soundex.GenerateSoundex("a"));
        Assert.Equal("A350", Soundex.GenerateSoundex("aiden"));
    }

    [Fact]
    public void HandlesUppercaseInput()
    {
        Assert.Equal("A350", Soundex.GenerateSoundex("AIDEN"));
    }

    [Fact]
    public void HandlesMixedCaseInput()
    {
        Assert.Equal("A350", Soundex.GenerateSoundex("AiDeN"));
    }


    [Fact]
    public void HandlesVowelsAndIgnoredCharacters()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert"));
        Assert.Equal("A536", Soundex.GenerateSoundex("Andrews"));
    }


    [Fact]
    public void HandlesNamesWithApostrophes()
    {
        Assert.Equal("O256", Soundex.GenerateSoundex("O'Connor"));
    }

    [Fact]
    public void HandlesHyphenatedNames()
    {
        Assert.Equal("S532", Soundex.GenerateSoundex("Smith-Jones"));
    }

    [Fact]
    public void HandlesNamesWithSpaces()
    {
        Assert.Equal("S532", Soundex.GenerateSoundex("Smith Jones"));
    }

    [Fact]
    public void HandlesNonAlphabeticCharacters()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert123"));
    }

    [Fact]
    public void HandlesSpecialCharacters()
    {
        Assert.Equal("R163", Soundex.GenerateSoundex("Rupert!@#"));
    }

    [Fact]
    public void HandlesConsonantsFollowedByHOrW()
    {
        Assert.Equal("A261", Soundex.GenerateSoundex("Ashcraft"));
    }

    [Fact]
    public void HandlesNamesWithVowelsInBetweenConsonants()
    {
        Assert.Equal("M630", Soundex.GenerateSoundex("Martha"));
    }

    [Fact]
    public void HandlesNamesWithConsonantsPrecededByVowels()
    {
        Assert.Equal("M200", Soundex.GenerateSoundex("McGee"));
    }

    [Fact]
    public void HandlesNamesStartingWithConsonantsIgnored()
    {
        Assert.Equal("C365", Soundex.GenerateSoundex("Catherine"));
    }

    [Fact]
    public void HandlesMultipleSameConsonants()
    {
        Assert.Equal("H500", Soundex.GenerateSoundex("Hamm"));
    }

    [Fact]
    public void HandlesDifferentConsonantsInDifferentPositions()
    {
        Assert.Equal("G626", Soundex.GenerateSoundex("Gregory"));
    }

    [Fact]
    public void HandlesNamesEndingWithIgnoredLetters()
    {
        Assert.Equal("A536", Soundex.GenerateSoundex("Andrews"));
    }
}
