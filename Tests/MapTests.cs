using ResultModelsDotNet.ApiResponseModels;
using ResultModelsDotNet.ResultModels;


namespace Tests;

public class MapTests
{
    [Fact]
    public void StatusCodeMustMatch()
    {
        // Arrange
        var result = Result<int>.Fail(Error.NOT_FOUND_ERROR);

        // Act
        var apiResponse = (ApiResponse<int>)result;

        // Assert
        Assert.NotNull(apiResponse);
        Assert.Equal(apiResponse.Status.Text, Error.NOT_FOUND_ERROR.Code);
    }
}