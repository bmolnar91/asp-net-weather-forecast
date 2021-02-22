using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeatherApp.WebSite.Controllers;
using WeatherApp.WebSite.Models;
using WeatherApp.WebSite.Services;

namespace WeatherApp.WebSite
{
    [TestFixture]
    public class AutocompleteTests
    {
        private AutocompleteController _autocompleteController;
        private IAutocompleteService _autocompleteService;

        [SetUp]
        public void Setup()
        {
            _autocompleteService = Substitute.For<IAutocompleteService>();
            _autocompleteController = new AutocompleteController(_autocompleteService);
        }

        [Test]
        public async Task GetSuggestionsAsync_OneSuggestion_ReturnsOneLocation()
        {
            var input = "budap";

            var suggestionList = (ISet<Location>)new HashSet<Location>();

            suggestionList.Add(new Location()
            {
                Id =          default,
                City =        "Budapest",
                State =       default,
                Country =     "Hungary",
                CountryCode = "HU"
            });

            _autocompleteService.GetSuggestionsAsync(input).Returns(suggestionList);

            var result = await _autocompleteController.GetSuggestionsAsync(input);

            Assert.AreEqual(result, suggestionList);
        }

        [Test]
        public async Task GetSuggestionsAsync_MultipleSuggestions_ReturnsMultipleLocations()
        {
            var input = "zuri";

            var suggestionList = (ISet<Location>)new HashSet<Location>();

            suggestionList.Add(new Location()
            {
                Id =          default,
                City =        "Zurich",
                State =       default,
                Country =     "Switzerland",
                CountryCode = "CH"
            });

            suggestionList.Add(new Location()
            {
                Id =          default,
                City =        "Zurite",
                State =       default,
                Country =     "Peru",
                CountryCode = "PE"
            });

            _autocompleteService.GetSuggestionsAsync(input).Returns(suggestionList);

            var result = await _autocompleteController.GetSuggestionsAsync(input);

            Assert.AreEqual(result, suggestionList);
        }

        [Test]
        public async Task GetSuggestionsAsync_ZeroSuggestion_ReturnsEmpty()
        {
            var input = "this location does not exist";

            var suggestionList = (ISet<Location>)new HashSet<Location>();

            _autocompleteService.GetSuggestionsAsync(input).Returns(suggestionList);

            var result = await _autocompleteController.GetSuggestionsAsync(input);

            Assert.AreEqual(result, suggestionList);
        }
    }
}
