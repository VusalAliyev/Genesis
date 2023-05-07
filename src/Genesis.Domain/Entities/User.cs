using Genesis.Domain.Common;

namespace Genesis.Domain.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string FinCode { get; set; } = null!;
    }

}
