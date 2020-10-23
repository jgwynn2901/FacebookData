using FacebookData.Models;
using GraphQL.Types;

namespace FacebookData.GraphQL.Types
{
  public sealed class PostType : ObjectGraphType<Post>
  {
    public PostType()
    {
      Field(t => t.Id).Description("Post's Id (Primary Key)");
      Field(t => t.Text).Description("Text of Post");
      Field(t => t.Timestamp).Description("Unix Timestamp => to be converted");
    }
  }
}
