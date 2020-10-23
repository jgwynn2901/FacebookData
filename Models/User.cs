namespace FacebookData.Models
{
  public class User : BaseModel
  {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}
