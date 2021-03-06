﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordChecker
{
    public class Worker
    {
        public static void Start()
        {
            string regularExp = @"[^\w\s\-]"; // all letters and "-"

            string fullText = FileWorker.ReadFromFile();

            if (fullText.Length == 0) Console.WriteLine("Error!"); 

            //delete punctuation marks
            string fullClearText = Regex.Replace(fullText, regularExp, "");

            // text to words list
            List<string> fullWordList = fullClearText.Split(' ').ToList();

            // to lower
            fullWordList = fullWordList.ConvertAll(w => w.ToLower());

            // alphabet sort
            fullWordList.Sort();

            FileWorker.WriteToFile(ListWorker.VocabularToPresentation(ListWorker.FinalDictionary(ListWorker.PrepareDictionary(fullWordList))));

        }
    }
}
