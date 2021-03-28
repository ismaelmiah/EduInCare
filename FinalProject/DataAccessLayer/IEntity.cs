namespace DataAccessLayer.Library
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
