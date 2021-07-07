namespace RecipeFinder.Domain.SeedWork
{
    public interface ISoftDelete
    {
        const int RECORD_STATUS_ACTIVE = 1;

        const int RECORD_STATUS_DELETED = 0;

        int RecordStatus { get; set; }
    }
}
