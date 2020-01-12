namespace OPMS.Data.Interfaces
{
    public interface ISlug
    {
        bool SlugExists(string slug);
        bool SlugExists(int? id, string slug);
    }
}
