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
        public async void 
    }
}