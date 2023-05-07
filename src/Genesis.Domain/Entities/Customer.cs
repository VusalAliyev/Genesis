using Genesis.Domain.Common;

namespace Genesis.Domain.Entities;

public class Customer : BaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Age { get; set; }
    public float Salary { get; set; }
    public string HomeOwnership { get; set; } = null!; // ev sahibliyi 
    public float EmploymentTime { get; set; } // is vaxti 
    public CreditDetail? CreditDetail { get; set; }
}
