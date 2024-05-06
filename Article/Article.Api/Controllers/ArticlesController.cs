using Article.Api.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Article.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ArticlesController : ControllerBase
{
    private readonly IArticleRepo _articleRepository;
    public ArticlesController(IArticleRepo articleRepository)
    {
        _articleRepository = articleRepository;
    }
  [HttpGet]
  public IActionResult Get()
  {
    return Ok(_articleRepository.GetAll());
  }

  [HttpGet("{id}")]
  public IActionResult Get(int id)
  {
    var article = _articleRepository.Get(id);
    if (article is null)
      return NotFound();

    return Ok(article);
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(int id)
  {
    var deletedId = _articleRepository.Delete(id);
    if (deletedId == 0)
      return NotFound();

    return NoContent();
  }
}
