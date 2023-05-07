namespace Genesis.Application.Features.Queries.User.GetUser
{
    public class GetUserQueryResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public int Age { get; set; }
        public string FinCode { get; set; } = null!;
    }
}
