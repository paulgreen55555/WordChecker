using System;
using System.Collections.Generic;
using System.IO;

namespace WordChecker
{
    public class FileWorker
    {
        static bool Error = false;
        static string inputPath = "";
        static string outputPath = "";

        static string[] cmdParams = CmdWorker.getCMDParametrs();

        static void getFilesPaths()
        {
            if (cmdParams.Length == 0)
            {
                Error = true;
            }
            else
            {
                inputPath = cmdParams[1];
                outputPath = cmdParams[2];
            }  
        }

        private static bool checkInputFile()
        {
            getFilesPaths();

            if (Error)
            {
                return false;
            }

            if (!File.Exists(inputPath))
            {
                Console.WriteLine("Input file " + inputPath + " not Exist!");
                Error = true;
                return false;
            } 

            return true;
        }

        public static string ReadFromFile()
        {
            string fullText = "";

            if (checkInputFile())
            {
                using (StreamReader sr = new StreamReader(inputPath))
                {
                    try
                    {
                        fullText = sr.ReadToEnd();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something wrong with File: " + ex);
                    }
                }
            }

            return fullText;
        }

        public static void WriteToFile(List<string> list)
        {
            if (!Error && outputPath.Length > 0 )
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    try
                    {
                        foreach (var el in list)
                        {
                            writer.Write(el + "\r\n");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Something wrong with File: " + ex);
                    }
                    
                }
                if (File.Exists(outputPath)) Console.WriteLine("Success! Result in file " + outputPath);
            } 
        }
    }
}
