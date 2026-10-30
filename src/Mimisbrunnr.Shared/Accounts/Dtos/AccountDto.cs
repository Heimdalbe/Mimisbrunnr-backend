namespace Mimisbrunnr.Shared.Accounts.Dtos;

public static class AccountDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
    
    public class Detailed
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public required string Email { get; set; }
    }
}
