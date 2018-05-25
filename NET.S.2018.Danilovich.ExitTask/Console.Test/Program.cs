using Crossword.Logic;

namespace Console.Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            Table table = new Table();
            table.FillBoard();
            table.GenerateVerticalWords();
            table.GenerateHorizontalWords();
            table.ShowBoard();
        }
    }
}