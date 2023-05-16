namespace DevPace.Core.Entities
{
    public interface IEntityBase<TId>
    {
        TId Id { get; set; }
    }
}
