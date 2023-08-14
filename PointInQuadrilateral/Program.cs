using PointInQuadrilateral;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            try
            {
                UI.UIFlow();
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("\nOops, something went wrong :( Let's see what...");
                Console.WriteLine($"\n{ex.Message}");
                UI.PressAnyKey();
            }

        }
    }
}