namespace Mimisbrunnr.Domain.Events
{
    public enum Accessibility
    {
        OPEN = 0,
        CLOSED = 1, // Schachten en Commilitones; preserve existing stored values.
        HEIMIES = 2
    }
}
