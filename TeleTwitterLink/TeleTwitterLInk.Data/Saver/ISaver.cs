namespace TeleTwitterLInk.Data.Saver
{
    public interface ISaver
    {
        void SaveChanges();

        void SaveChangesAsync();
    }
}