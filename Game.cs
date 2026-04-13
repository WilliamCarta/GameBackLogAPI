namespace GameBackLogApi
{
    public class Game
    {
        public int ID {  get; set; }
        public required string Title { get; set; }
        public required string Genre { get; set; }
        public required string Status { get; set; }
    }
}
