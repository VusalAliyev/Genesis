using Genesis.Domain.Common;

namespace Genesis.Domain.Entities;

public class CreditDetail : BaseAuditableEntity
{
    public string? LoanPurposes { get; set; }  //Kredi Amaçları
    public string? CreditScore { get; set; } // kredi skoru 
    public float CreditAmount { get; set; } // kredit məbləği 
    public int CreditRate { get; set; } // kredit orani
    public float LoanRate { get; set; } // musterinin muraciet etdiyi kiredit faizi
    public int CreditStatus { get; set; } // credit status
}
