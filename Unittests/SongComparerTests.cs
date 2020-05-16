using MusicOrganizer.DataAccess;
using MusicOrganizer.Entities;
using NUnit.Framework;

namespace Unittests
{
    public class SongComparerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void An_empty_song_isnt_like_a_usual_song()
        {
            var emptySong = new Song();
            var comparer = new SongComparer(emptySong);

            var result = comparer.IsLike(new Song() { Title = "TestTitle", Interpret = "Someone" });

            Assert.IsFalse(result);
        }

        [Test]
        public void Searching_for_a_string_like_the_title_matches_if_both_are_the_same()
        {
            var search = new Song() { Title = "TestTitle" };
            var comparer = new SongComparer(search);

            var result = comparer.IsLike(new Song() { Title = "TestTitle"});

            Assert.IsTrue(result);
        }

        [Test]
        public void Searching_for_an_incomplete_Songtitle_matches_the_compete_song()
        {
            var searchFor = new Song() { Title = "stT" };
            var comparer = new SongComparer(searchFor);

            var result = comparer.IsLike(new Song() { Title = "TestTitle" });

            Assert.IsTrue(result);
        }

        [Test]
        public void Searching_for_a_integer_value_matches_on_the_same_value()
        {
            var searchFor = new Song() { Jahr = 1980 };
            var comparer = new SongComparer(searchFor);

            var shouldBeTrue = comparer.IsLike(new Song() {  Jahr = 1980 });
            var shouldBeFalse = comparer.IsLike(new Song() {  Jahr = 1234 });

            Assert.IsTrue(shouldBeTrue);
            Assert.IsFalse(shouldBeFalse);
        }

        [Test]
        public void Searching_for_multiple_conditions_matches_a_valid_song()
        {
            var searchFor = new Song() { Jahr = 1000, Interpret="ABC" };
            var comparer = new SongComparer(searchFor);

            var shouldBeTrue = comparer.IsLike(new Song() { Jahr = 1000, Interpret="XABCDEF" });

            Assert.IsTrue(shouldBeTrue);
        }

        [Test]
        public void Searching_for_a_only_in_part_matching_song_fails()
        {
            var searchFor = new Song() { Jahr = 1000, Interpret = "ABC" };
            var comparer = new SongComparer(searchFor);

            var shouldbeFalse = comparer.IsLike(new Song() { Jahr = 9999, Interpret = "XABCDEF" });

            Assert.IsFalse(shouldbeFalse);
        }
    }
}