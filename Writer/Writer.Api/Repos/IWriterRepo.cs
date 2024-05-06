namespace Writer.Api.Repos
{
    public interface IWriterRepo 
    {
        List<Models.Writer> GetAll();
        Models.Writer? Get(int id);
        Models.Writer Insert(Models.Writer writer);
    }
}
