using Bunit;
using MyBlazorApp.Components.Pages;

namespace MyBlazorApp.Test
{
    public class CounterPageTests : TestContext
    {

        [Fact]
        public void Header_DefaultState_ExpectedTitle()
        {
            //Arrange
            var renderComponent = RenderComponent<Counter>();
            var element = renderComponent.Find("h1");

            //Assert
            element.MarkupMatches("<h1>Counter</h1>");
        }

        [Fact]
        public void CurrentLabel_DefaultState_ExpectedValue()
        {
            //Arrange
            var renderComponent = RenderComponent<Counter>();
            var element = renderComponent.Find("p");

            //Assert
            element.MarkupMatches("<p role=\"status\">Current count: 0</p>");
        }

        [Fact]
        public void CounterShouldIncrementWhenClicked()
        {
            //Arrange
            var renderComponent = RenderComponent<Counter>();
            var element = renderComponent.Find("button");
            var elPar = renderComponent.Find("p");


            //Act
            element.Click();

            //Assert
            var elParText = elPar.TextContent;

            elPar.MarkupMatches("<p role=\"status\">Current count: 1</p>");

            Assert.Equal("Current count: 1", elParText);

        }

        [Fact]
        public void CurrentLabel_CountIsSet_ExpectedValue()
        {
            //Arrange
            var renderComponent = RenderComponent<Counter>();

            renderComponent.SetParametersAndRender(_ =>
            {
                _.Add<int>(_ => _.CurrentCount, 5);
            });

            //Assert

            renderComponent.Find("p")
                .MarkupMatches("<p role=\"status\">Current count: 5</p>");
        }

        [Fact]
        public void CurrentLabel_CountIsSet_WhenClick_ExpectedValue()
        {
            //Arrange
            var renderComponent = RenderComponent<Counter>();

            renderComponent.SetParametersAndRender(_ =>
            {
                _.Add<int>(_ => _.CurrentCount, 5);
            });

            //Act
            renderComponent.Find("button").Click();


            //Assert

            renderComponent.Find("p")
                .MarkupMatches("<p role=\"status\">Current count: 6</p>");
        }
    }
}
