using Genesis.Domain.Common;

namespace Genesis.Domain.Entities;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
