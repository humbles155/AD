using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AntiDebug.CheckForDebugger
{
    public class CheckForDebugger
    {
        private HashSet<string> BadFile = new HashSet<string>();

        public bool CheckForDebuggers()
        {
            bool found;
            if(Debugger.IsAttached || Debugger.IsLogging())
            {
                found = true;
            } else
            {
                found = false;
            }
            return found;
        }
        
        private bool CheckFiles()
        {
            BadFile.Add("ollydbg");
            BadFile.Add("ida");
            BadFile.Add("ida64");
            BadFile.Add("idag");
            BadFile.Add("idag64");
            BadFile.Add("idau64");
            BadFile.Add("scylla");
            BadFile.Add("scylla_x64");
            BadFile.Add("scylla_x86");
            BadFile.Add("protection_id");
            BadFile.Add("x64dbg");
            BadFile.Add("x32dbg");
            BadFile.Add("windbg");
            BadFile.Add("reshacker");
            BadFile.Add("ImportREC");
            BadFile.Add("IMMUNITYDEBUGGER");
            BadFile.Add("MegaDumper");
            BadFile.Add("idaw");
            BadFile.Add("idaw64");
            BadFile.Add("idaq");
            BadFile.Add("idaq64");
            BadFile.Add("idau");

            BadFile.Add("OLLYDBG");
            BadFile.Add("ida");
            BadFile.Add("disassembly");
            BadFile.Add("scylla");
            BadFile.Add("Debug");
            BadFile.Add("[CPU");
            BadFile.Add("Immunity");
            BadFile.Add("WinDbg");
            BadFile.Add("x32dbg");
            BadFile.Add("x64dbg");
            BadFile.Add("Import reconstructor");
            BadFile.Add("MegaDumper");
            BadFile.Add("MegaDumper 1.0 by CodeCracker / SnD");
            bool found;

            foreach (string files in Directory.GetFiles("*"))
            {
                if(files.Contains(BadFile.ToString()))
                {
                    found = true;
                } else
                {
                    found = false;
                }
                return found;
            }
            return false;
        }

        private bool CheckFolders()
        {
            BadFile.Add("ollydbg");
            BadFile.Add("ida");
            BadFile.Add("ida64");
            BadFile.Add("idag");
            BadFile.Add("idag64");
            BadFile.Add("idau64");
            BadFile.Add("scylla");
            BadFile.Add("scylla_x64");
            BadFile.Add("scylla_x86");
            BadFile.Add("protection_id");
            BadFile.Add("x64dbg");
            BadFile.Add("x32dbg");
            BadFile.Add("windbg");
            BadFile.Add("reshacker");
            BadFile.Add("ImportREC");
            BadFile.Add("IMMUNITYDEBUGGER");
            BadFile.Add("MegaDumper");
            BadFile.Add("idaw");
            BadFile.Add("idaw64");
            BadFile.Add("idaq");
            BadFile.Add("idaq64");
            BadFile.Add("idau");

            BadFile.Add("OLLYDBG");
            BadFile.Add("ida");
            BadFile.Add("disassembly");
            BadFile.Add("scylla");
            BadFile.Add("Debug");
            BadFile.Add("[CPU");
            BadFile.Add("Immunity");
            BadFile.Add("WinDbg");
            BadFile.Add("x32dbg");
            BadFile.Add("x64dbg");
            BadFile.Add("Import reconstructor");
            BadFile.Add("MegaDumper");
            BadFile.Add("MegaDumper 1.0 by CodeCracker / SnD");
            bool found;

            foreach (string files in Directory.GetFiles(Directory.GetDirectories("*.*").ToString()))
            {
                if (files.Contains(BadFile.ToString()))
                {
                    found = true;
                }
                else
                {
                    found = false;
                }
                return found;
            }
            return false;
        }

        public bool CheckForInactiveDebuggers(bool checkforfiles, bool checkfolders)
        {
            MessageBox.Show("Please wait.\nPlease click ok.");
            if(checkforfiles)
            {
                if (CheckFiles())
                {
                    return true;
                }
            }
            if(checkfolders)
            {
                if(CheckFolders())
                {
                    return true;
                }
            }

            return false;
        }

    }
}
