using System.Collections.Generic;
using FacebookData.Models;
using FacebookData.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacebookData.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly UserRepository _userRepository;
    public UsersController(IConfiguration configuration)
    {
      _userRepository = new UserRepository(configuration);
    }

    // GET: api/<UsersController>
    [HttpGet]
    public IEnumerable<User> Get()
    {
      return _userRepository.FindAll();
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public User Get(int id)
    {
      return _userRepository.FindById(id) ?? new User();
    }

    // POST api/<UsersController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
  }
}
