using ResultModelsDotNet.ApiResponseModels;
using ResultModelsDotNet.ResultModels;
using System.Text.Json;

namespace Tests
{
    public class ConvertTest
    {
        [Fact]
        public void Test1()
        {
            var result = Result.Success<TestResult>(new TestResult("Test", true));
            ApiResponse<TestResult> apiResponse = result;
            var json = JsonSerializer.Serialize(result);
        }
    }
    public record TestResult(string Name, bool Success);
}
