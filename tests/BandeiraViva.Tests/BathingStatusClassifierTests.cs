using Xunit;
using BandeiraViva.Api.Services;

namespace BandeiraViva.Tests;

public class BathingStatusClassifierTests
{
    private readonly BathingStatusClassifier _classifier = new();

    [Fact]
    public void Classify_WhenValueIsBelowLimit_ReturnsFavorable()
    {
        var result = _classifier.Classify(50);

        Assert.Equal("Favorável", result.Status);
    }

    [Fact]
    public void Classify_WhenValueExceedsLimit_ReturnsAttention()
    {
        var result = _classifier.Classify(150);

        Assert.Equal("Atenção", result.Status);
    }

    [Fact]
    public void Classify_WhenValueIsNull_ReturnsUndetermined()
    {
        var result = _classifier.Classify(null);

        Assert.Equal("Indeterminada", result.Status);
    }

    [Fact]
    public void Classify_WhenValueIsNegative_ThrowsException()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => _classifier.Classify(-1));
    }
}
