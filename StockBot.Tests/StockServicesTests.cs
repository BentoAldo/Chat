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
    public void GetStockAsync_InputCode_ReturnsStock()
    {
        // Arrange
        const string code = "aapl.us";

        // Act
        _stockServices.Setup(x => x.GetStockAsync(code)).ReturnsAsync(new BaseResponse<Stock>
        {
            Success = true,
            Data = new Stock
            {
                Symbol= code.ToUpper(),
                Date = DateOnly.FromDateTime(DateTime.Now),
                Time = new TimeOnly(20,18,29),
                Open = "150.64",
                High = "155.23",
                Low = "150.64",
                Close = "153.62",
                Volume = 42469455
            }
        });

        var actual = _stockServices.Object.GetStockAsync(code).Result;

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.TypeOf<BaseResponse<Stock>>());
            Assert.That(actual.Success, Is.True);
            Assert.That(actual.Data, Is.Not.Null);
            Assert.That(actual.ProblemDetails, Is.Null);
        });
    }
}