using Mimisbrunnr.Shared.Identity;

namespace Mimisbrunnr.Shared.Events;

public static class EventRegistrationRoles
{
    public static IReadOnlyList<string> All { get; } =
        [AppRoles.Feut, AppRoles.Heimie, AppRoles.Schacht, AppRoles.Commilitones];
}
