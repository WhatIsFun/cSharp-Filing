namespace cSharp_Filing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exampleFileWithUsing = "Example File with Using.txt";
            WriteFile(exampleFileWithUsing);
        }
        private static void WriteFile(string exampleFile)
        {
            StreamWriter writer = null;
            try
            {
                using (writer = new StreamWriter(exampleFile))
                {
                    writer.WriteLine("TEST with using keyword");
                }
                Console.WriteLine("File writing complete");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}