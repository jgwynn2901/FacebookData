namespace FacebookData.Models
{
  public class Post : BaseModel
  {
    public long Id { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public int Timestamp { get; set; }
    public string Text { get; set; }
    public string Uri { get; set; }
  }
}
