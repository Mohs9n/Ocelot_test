namespace Article.Api.Repos
{
    public interface IArticleRepo
    {
        List<Models.Article> GetAll();
        Models.Article? Get(int id);
        int Delete(int id);
    }
}
