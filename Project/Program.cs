namespace Project
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Game game = new Game(new Player("Munir"),
                new Player("Borka"),
                new Player("Andrey"),
                new Player("Viktor"),
                new Player("Tolya"),
                new Player("Kolya"),
                new Player("Masha"),
                new Player("Katya"),
                new Player("Alisa"));
            game.start();
        }
    }
}