using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordChecker
{
    class CmdWorker
    {

        public static string[] getCMDParametrs()
        {
            string[] Params = {};

            if (Environment.GetCommandLineArgs().Length != 3)
            {
                Console.WriteLine("Wrong Parametrs!");
                return Params;
            }

            Params = Environment.GetCommandLineArgs();
            return Params;

        }

    }
}
