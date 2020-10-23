using System.Collections.Generic;
using FacebookData.Models;
using FacebookData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FacebookData.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PostsController : ControllerBase
  {
    private readonly PostRepository _postRepository;
    public PostsController(IConfiguration configuration)
    {
      _postRepository = new PostRepository(configuration);
    }
    // GET: api/Posts
    [HttpGet]
    public IEnumerable<Post> Get()
    {
      return _postRepository.FindAll();
    }

    // GET: api/Posts/5
    [HttpGet("{id}", Name = "Get")]
    public Post Get(int id)
    {
      return _postRepository.FindById(id);
    }


  }
}
