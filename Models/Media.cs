namespace FacebookData.Models
{
  public class Media :BaseModel
  {
    public long Id { get; set; }
    public long PostId { get; set; }
    public string Uri { get; set; }
    public string Thumbnail { get; set; }
    public byte[] Data { get; set; }
  }
}
