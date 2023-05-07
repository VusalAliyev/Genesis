using Genesis.Domain.Common;

namespace Genesis.Domain.Entities;

public class Customer : BaseEntity
{
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public DateTime BrithDate { get; set; }
    public int Age { get; set; }
    public float Salary { get; set; }
    public string HomeOwnership { get; set; } = null!; // ev sahibliyi 
    public float EmploymentTime { get; set; } // is vaxti 
    public CreditDetail? CreditDetail { get; set; }
}
