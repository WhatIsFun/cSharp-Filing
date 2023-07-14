using System.Diagnostics.Metrics;
using System.IO;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace cSharp_Filing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string exampleFileWithUsing = "Example File with Using.txt";
            //WriteFile(exampleFileWithUsing);
            //Console.WriteLine("Reading from the file");


            // Task 1 
            string fileName = "Task 1.doxc";
            string content = "Task 1 content";
            //Task1(fileName, content);

            // Task 2
            //Task2(exampleFileWithUsing, fileName);

            // Task 3
            //fileStatistics(fileName);

            SearchReplace();

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
        // Task 3: File Statistics
        private static void fileStatistics(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName); // To read from this file
                int lineCount = content.Split('\n').Length; // To count lines in the file
                int wordCount = content.Split(' ','\n').Length; // To count words in the file
                int charCount = content.Length; // To count characters in the file
                Console.WriteLine($"Line Count: {lineCount}"); // To print the statistics 
                Console.WriteLine($"Word Count: {wordCount}");
                Console.WriteLine($"Charactars Count: {charCount}");
            }catch(Exception ex) { Console.WriteLine(ex.Message); }
        }
        // Task 4: Search and Replace.
        // Implement a program in that reads a text file and searches for a specific word or phrase.
        // Prompt the user to enter the file path and the word or phrase to search for.
        // Replace all occurrences of the search term with a user-specified replacement.
        // Save the modified content to a new file.
        private static void SearchReplace()
        {
            Console.WriteLine("Enter the file path:");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter the word to search for:");
            string searchWord = Console.ReadLine();

            if (File.Exists(filePath)) // To check if the file is exists
            {
                
                string content = File.ReadAllText(filePath); //To read the file content

                if (content.Contains(searchWord))   // Check if the search word is found in the content
                {
                    Console.WriteLine("Enter the replacement:"); // To enter the replacement word or phase
                    string replacement = Console.ReadLine();

                    content = content.Replace(searchWord, replacement);

                    string newFilePath = filePath + ".modified";
                    File.WriteAllText(newFilePath, content);  // Save the file

                    Console.WriteLine("The file has been modified and saved as {0}", newFilePath);
                }
                else
                {
                    Console.WriteLine("The word or phrase '{0}' is not found in the file.", searchWord);
                }
            }
            else
            {
                Console.WriteLine("The file '{0}' does not exist.", filePath);
            }
        }
        
    }
}
