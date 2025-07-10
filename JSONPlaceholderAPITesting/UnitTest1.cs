using RestSharp;
using System.Text.Json.Nodes;
using System.Text.Json;

namespace JSONPlaceholderAPITesting
{
    public class PostsTests
    {
        [Fact]
        public async void PostsList_WhenPostsListIsReturned_PostsListIsJsonArray()
        {
            //Arrange
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("posts", Method.Get);

            //Act
            var response = await client.ExecuteAsync(request);
            var data = JsonSerializer.Deserialize<JsonNode>(response.Content);
     
            //Assert
            Assert.IsType<JsonArray>(data);
        }

        [Fact]
        public async void PostsList_WhenPostsListIsReturned_PostsListIsNotNull()
        {
            //Arrange
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("posts", Method.Get);

            //Act
            var response = await client.ExecuteAsync(request);
            var data = JsonSerializer.Deserialize<JsonNode>(response.Content);

            //Assert
            Assert.NotNull(data);
        }

        [Fact]
        public async void PostsList_WhenPostsListIsReturned_PostsListContainsExpectedObjects()
        {
            //Arrange
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("posts", Method.Get);

            //Act
            var response = await client.ExecuteAsync(request);
            var data = JsonSerializer.Deserialize<JsonNode>(response.Content!)!.AsArray();


            //Assert
            Assert.Equal(100, data.Count);
        }
    }
    public class SinglePostTest
    {
        /*public class PostObj
        {
           public int userId { get; set; }
           public int id { get; set; }
           public string title { get; set; }
           public string body { get; set; }
        };*/

        public record PostObj(int userId, int id, string title, string body);

        [Fact]
        public async void SinglePost_WhenPostIsReturned_ContainsCorrectProperties()
        {
            var client = new RestClient("https://jsonplaceholder.typicode.com");
            var request = new RestRequest("posts/1", Method.Get);
            var response = await client.ExecuteAsync(request);

            var data = JsonSerializer.Deserialize<PostObj>(response.Content!);
            /*var expected = new PostObj
            {
              userId = 1,
              id = 2,
              title = "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
              body = "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            };*/
            var expected = new PostObj
            (
              1,
              1,
              "sunt aut facere repellat provident occaecati excepturi optio reprehenderit",
              "quia et suscipit\nsuscipit recusandae consequuntur expedita et cum\nreprehenderit molestiae ut ut quas totam\nnostrum rerum est autem sunt rem eveniet architecto"
            );

            /*Assert.Equal(expected.userId, data.userId);
            Assert.Equal(expected.id, data.id);
            Assert.Equal(expected.title, data.title);
            Assert.Equal(expected.body, data.body);*/
            Assert.Equal(expected, data);
        }
    }
}