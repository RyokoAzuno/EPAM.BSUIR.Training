namespace UriToXmlExporter.Interfaces
{
    public interface IValidator<in T>
    {
        bool IsValid(T entity);
    }
}
