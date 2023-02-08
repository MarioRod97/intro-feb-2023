namespace Demo1.UnitTests
{
    public class SongTest
    {
        [Fact]
        public void CreateSong()
        {
            var song = new Song("Snowblind", "Black Sabbath");

            Assert.Equal("Snowblind", song.Title);
            Assert.Equal("Black Sabbath", song.Artist);
        }
    }
}
