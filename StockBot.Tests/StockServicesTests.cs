using Moq;
using StockBot.Application.Common.DataTransferObjects;
using StockBot.Application.Common.Interfaces;

namespace StockBot.Tests;

public class StockServicesTests
{
    private Mock<IStockServices> _stockServices = null!;
    
    [SetUp]
    public void Setup()
    {
        _stockServices = new Mock<IStockServices>();
    }

    [Test]
    public void GetStockAsync_InputCode_ReturnStock()
    {
        // Arrange
        const string code = "AAPL";

        // Act
        _stockServices.Setup(x => x.GetStockAsync(code)).ReturnsAsync(new BaseResponse<Stock>());
        var actual = _stockServices.Object.GetStockAsync(code).Result;

        // Assert
        Assert.That(actual, Is.Not.Null);
        Assert.That(actual, Is.TypeOf<BaseResponse<Stock>>());
    }
}