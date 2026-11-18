namespace BandeiraViva.Api.Interfaces;

public interface IBathingStatusClassifier
{
    (string Status, string Explanation) Classify(double? enterococciPer100Ml);
}
