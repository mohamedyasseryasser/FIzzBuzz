

using Xunit;
using AkvelonFizzBuzz;


namespace ClassLibrary1
{


    public class FizzBuzzDetectorTests
    {
        private readonly FizzBuzzDetector _detector = new();

        [Fact]
        public void ShouldReplaceEveryThirdWord()
        {
            var result = _detector.getOverlappings(
                "One two three");

            Assert.Equal("One two Fizz", result.Output);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void ShouldReplaceEveryFifthWord()
        {
            var result = _detector.getOverlappings(
                "One two three four five");

            Assert.Equal("One two Fizz four Buzz", result.Output);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void ShouldReplaceEveryFifteenthWordWithFizzBuzz()
        {
            var result = _detector.getOverlappings(
                "One two three four five six seven eight nine ten eleven twelve thirteen fourteen fifteen");

            Assert.Contains("FizzBuzz", result.Output);
            Assert.Equal(7, result.Count);
        }

        [Fact]
        public void ShouldPreservePunctuation()
        {
            var result = _detector.getOverlappings(
                "One, two! three?");

            Assert.Equal("One, two! Fizz?", result.Output);
            Assert.Equal(1, result.Count);
        }

        [Fact]
        public void ShouldHandleNullInput()
        {
            Assert.Throws<ArgumentNullException>(
                () => _detector.getOverlappings(null));
        }

        [Fact]
        public void ShouldHandleNumbersAsWords()
        {
            var result = _detector.getOverlappings(
                "A 12 B 34 C");

            Assert.Equal("A 12 Fizz 34 Buzz", result.Output);
            Assert.Equal(2, result.Count);
        }
    }

}
