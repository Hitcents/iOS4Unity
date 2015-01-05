// ***********************************************************************
// Copyright (c) 2007 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System.Collections.Generic;
using System.IO;
using System.Text;
#if true || true

#endif

namespace NUnitLite.Runner
{
    /// <summary>
    /// The CommandLineOptions class parses and holds the values of
    /// any options entered at the command line.
    /// </summary>
    public class CommandLineOptions
    {
        private string optionChars;
        private static string NL = NUnit.Env.NewLine;

        private bool wait = false;
        private bool noheader = false;
        private bool help = false;
        private bool full = false;
        private bool explore = false;

        private string exploreFile;
        private string resultFile;
        private string outFile;

        private bool error = false;

        private StringList tests = new StringList();
        private StringList invalidOptions = new StringList();
        private StringList parameters = new StringList();

        #region Properties

        /// <summary>
        /// Gets a value indicating whether the 'wait' option was used.
        /// </summary>
        public bool Wait
        {
            get { return wait; }
        }

        /// <summary>
        /// Gets a value indicating whether the 'nologo' option was used.
        /// </summary>
        public bool NoHeader
        {
            get { return noheader; }
        }

        /// <summary>
        /// Gets a value indicating whether the 'help' option was used.
        /// </summary>
        public bool ShowHelp
        {
            get { return help; }
        }

        /// <summary>
        /// Gets a list of all tests specified on the command line
        /// </summary>
        public string[] Tests
        {
            get { return (string[])tests.ToArray(); }
        }

        /// <summary>
        /// Gets a value indicating whether a full report should be displayed
        /// </summary>
        public bool Full
        {
            get { return full; }
        }

        /// <summary>
        /// Gets a value indicating whether tests should be listed
        /// rather than run.
        /// </summary>
        public bool Explore
        {
            get { return explore; }
        }

        /// <summary>
        /// Gets the name of the file to be used for listing tests
        /// </summary>
        public string ExploreFile
        {
            get { return ExpandToFullPath(exploreFile); }
        }

        /// <summary>
        /// Gets the name of the file to be used for test results
        /// </summary>
        public string ResultFile
        {
            get { return ExpandToFullPath(resultFile); }
        }

        /// <summary>
        /// Gets the full path of the file to be used for output
        /// </summary>
        public string OutFile
        {
            get 
            {
                return ExpandToFullPath(outFile);
            }
        }

        private string ExpandToFullPath(string path)
        {
            if (path == null) return null;

#if NETCF
            return Path.Combine(NUnit.Env.DocumentFolder, path);
#else
            return Path.GetFullPath(path); 
#endif
        }

        /// <summary>
        /// Gets the test count
        /// </summary>
        public int TestCount
        {
            get { return tests.Count; }
        }

        #endregion

        /// <summary>
        /// Construct a CommandLineOptions object using default option chars
        /// </summary>
        public CommandLineOptions()
        {
            this.optionChars = System.IO.Path.DirectorySeparatorChar == '/' ? "-" : "/-";
        }

        /// <summary>
        /// Construct a CommandLineOptions object using specified option chars
        /// </summary>
        /// <param name="optionChars"></param>
        public CommandLineOptions(string optionChars)
        {
            this.optionChars = optionChars;
        }

        /// <summary>
        /// Parse command arguments and initialize option settings accordingly
        /// </summary>
        /// <param name="args">The argument list</param>
        public void Parse(params string[] args)
        {
            foreach( string arg in args )
            {
                if (optionChars.IndexOf(arg[0]) >= 0 )
                    ProcessOption(arg);
                else
                    ProcessParameter(arg);
            }
        }

        /// <summary>
        ///  Gets the parameters provided on the commandline
        /// </summary>
        public string[] Parameters
        {
            get { return (string[])parameters.ToArray(); }
        }

        private void ProcessOption(string opt)
        {
            int pos = opt.IndexOfAny( new char[] { ':', '=' } );
            string val = string.Empty;

            if (pos >= 0)
            {
                val = opt.Substring(pos + 1);
                opt = opt.Substring(0, pos);
            }

            switch (opt.Substring(1))
            {
                case "wait":
                    wait = true;
                    break;
                case "noheader":
                case "noh":
                    noheader = true;
                    break;
                case "help":
                case "h":
                    help = true;
                    break;
                case "test":
                    tests.Add(val);
                    break;
                case "full":
                    full = true;
                    break;
                case "explore":
                    explore = true;
                    exploreFile = val;
                    break;
                case "result":
                    resultFile = val;
                    break;
                case "out":
                    outFile = val;
                    break;
                default:
                    error = true;
                    invalidOptions.Add(opt);
                    break;
            }
        }

        private void ProcessParameter(string param)
        {
            parameters.Add(param);
        }

        /// <summary>
        /// Gets a value indicating whether there was an error in parsing the options.
        /// </summary>
        /// <value><c>true</c> if error; otherwise, <c>false</c>.</value>
        public bool Error
        {
            get { return error; }
        }

        /// <summary>
        /// Gets the error message.
        /// </summary>
        /// <value>The error message.</value>
        public string ErrorMessage
        {
            get 
            {
                StringBuilder sb = new StringBuilder();
                foreach (string opt in invalidOptions)
                    sb.Append( "Invalid option: " + opt + NL );
                return sb.ToString();
            }
        }

        /// <summary>
        /// Gets the help text.
        /// </summary>
        /// <value>The help text.</value>
        public string HelpText
        {
            get
            {
                StringBuilder sb = new StringBuilder();

#if PocketPC || WindowsCE || NETCF || true
                string name = "NUnitLite";
#else
                string name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
#endif

                sb.Append(NL + name + " [assemblies] [options]" + NL + NL);
                sb.Append("Runs a set of NUnitLite tests from the console." + NL + NL);
                sb.Append("You may specify one or more test assemblies by name, without a path or" + NL);
                sb.Append("extension. They must be in the same in the same directory as the exe" + NL);
                sb.Append("or on the probing path. If no assemblies are provided, tests in the" + NL);
                sb.Append("executing assembly itself are run." + NL + NL);
                sb.Append("Options:" + NL);
                sb.Append("  -test:testname  Provides the name of a test to run. This option may be" + NL);
                sb.Append("                  repeated. If no test names are given, all tests are run." + NL + NL);
                sb.Append("  -out:PATH       Path to a file to which output is redirected. If this option" + NL);
                sb.Append("                  is not used, output is to the Console, which means it is lost" + NL);
                sb.Append("                  on devices without a Console." + NL + NL);
                sb.Append("  -full           Prints full report of all test results." + NL + NL);
                sb.Append("  -result:PATH    Path to a file to which the xml test result is written." + NL + NL);
                sb.Append("  -explore[:PATH] If provided, this option indicates that the tests in the" + NL);
                sb.Append("                  should be listed rather than executed. If a path is given" + NL);
                sb.Append("                  it represents the file to which the listing is directed." + NL);
                sb.Append("                  If no path is given, the listing displays on the Console." + NL + NL);
                sb.Append("  -help,-h        Displays this help" + NL + NL);
                sb.Append("  -noheader,-noh  Suppresses display of the initial message" + NL + NL);
                sb.Append("  -wait           Waits for a key press before exiting" + NL + NL);

                sb.Append("Notes:" + NL);
                sb.Append(" * Any relative path is based on the current directory or on the Documents" + NL);
                sb.Append("   folder if running on a device under the compact framework." + NL + NL);
                if (System.IO.Path.DirectorySeparatorChar != '/')
                    sb.Append(" * On Windows, options may be prefixed by a '/' character if desired" + NL + NL);
                sb.Append(" * Options that take values may use an equal sign or a colon" + NL);
                sb.Append("   to separate the option from its value." + NL + NL);

                return sb.ToString();
            }
        }

#if true || true
        class StringList : List<string> { }
#else
        class StringList : ArrayList 
        {
            public new string[] ToArray()
            {
                return (string[])ToArray(typeof(string));
            }
        }
#endif
    }
}
