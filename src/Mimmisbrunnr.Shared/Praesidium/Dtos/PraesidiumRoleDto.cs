namespace Mimmisbrunnr.Shared.Praesidium.Dtos;

public static class PraesidiumRoleDto
{
    public class Simple
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required int Order { get; set; }
    }

    public class Detailed : Simple
    {
        public string Email { get; set; }
    }
}