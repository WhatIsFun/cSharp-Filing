using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace cSharp_Filing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string exampleFileWithUsing = "Example File with Using.txt";
            //WriteFile(exampleFileWithUsing);
            //Console.WriteLine("Reading from the file");


            // Task 1 
            string fileName = "Task 1.doxc";
            string content = "Task 1 content";
            //Task1(fileName, content);

            // Task 2
            Task2(exampleFileWithUsing, fileName);
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

        // Task 1:Write a program:
        // That writes the content to a file.
        // That can read contents of a file.
        // If the file exist, it appends/adds the text to the file.
        private static void Task1(string fileName, string content)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine(content);
            }
            //Console.WriteLine("The file is Created");

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine($"Reading from the {fileName}");
                    Console.WriteLine(line);
                }
            }
            if (File.Exists(fileName))
            {
                Console.WriteLine("File is Created");
            }
            else
            {
                Console.WriteLine("File is already exist");
            }
        }

        //Task 2: Copy contents from file to another.
        private static void Task2(string exampleFileWithUsing, string fileName)
        {
            // examFileWithUsing is the source file that will take the content and destinated to fileName.
            try
            {
                if (!File.Exists(exampleFileWithUsing))
                {
                    throw new FileNotFoundException("The source file not found please use another file");
                }
                if (!File.Exists(fileName))
                {
                    throw new IOException("The destination file is already exists");
                }
                // To copy the content from source file to destination file.
                File.Copy(exampleFileWithUsing, fileName);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }finally { Console.WriteLine("Exit"); }
            
        }
    }
}
