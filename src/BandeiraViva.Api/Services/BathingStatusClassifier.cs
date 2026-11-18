using BandeiraViva.Api.Interfaces;

namespace BandeiraViva.Api.Services;

public class BathingStatusClassifier : IBathingStatusClassifier
{
    // Limite de referência simplificado para demonstração acadêmica.
    // Não substitui a classificação oficial da CETESB.
    private const double ReferenceLimit = 100;

    public (string Status, string Explanation) Classify(double? enterococciPer100Ml)
    {
        if (enterococciPer100Ml is null)
            return ("Indeterminada", "Não há medição de enterococos disponível.");

        if (enterococciPer100Ml < 0)
            throw new ArgumentOutOfRangeException(nameof(enterococciPer100Ml),
                "A concentração não pode ser negativa.");

        if (enterococciPer100Ml > ReferenceLimit)
            return ("Atenção", $"A medição ({enterococciPer100Ml:N1} UFC/100mL) ultrapassa o limite de referência adotado pelo protótipo.");

        return ("Favorável", $"A medição ({enterococciPer100Ml:N1} UFC/100mL) está dentro do limite de referência adotado pelo protótipo.");
    }
}
