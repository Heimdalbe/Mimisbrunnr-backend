namespace Mimmisbrunnr.Shared.Identity;

/// <summary>
/// Provides a centralized definition of application roles as static properties.
/// This class is used to define role names that are utilized across the application
/// for authentication and authorization purposes.
/// </summary>
public static class AppRoles
{
    public const string Feut = "Feut";
    public const string Schacht = "Schacht";
    public const string Commilitones = "Commilitones";
    public const string Hmdl = "Hmdl"; // Praeses, ICT
    public const string EventEditor = "EventEditor";
    public const string MediaEditor = "MediaEditor";
    public const string SponsorEditor = "SponsorEditor";
    
}