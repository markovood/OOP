using System;
using System.IO;
using System.Text;

namespace TextEditor
{
    public class TextEditor
    {
        static void Main()
        {
            Console.WriteLine("Paste the path to the text to be edited here:");
            string readPath = Console.ReadLine();

            string writePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string writePathWithFileName = writePath + "\\editedText.txt";
            using (StreamReader sr = new StreamReader(readPath))
            {
                using (StreamWriter sw = new StreamWriter(writePathWithFileName, false, Encoding.UTF8))
                {
                    string currentLine = sr.ReadLine();
                    while (currentLine != null)
                    {
                        if (currentLine.StartsWith("-"))
                        {
                            currentLine = sr.ReadLine();
                            continue;
                        }

                        sw.WriteLine(currentLine);
                        currentLine = sr.ReadLine();
                    }
                }
            }

            Console.WriteLine("Well Done!");
            Console.WriteLine("The edited text is saved as editedText.txt, and it's location is on your Desktop");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
