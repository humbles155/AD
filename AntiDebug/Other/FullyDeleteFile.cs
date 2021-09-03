using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AntiDebug.Other
{
    class Other
    {
        public void OverwriteFileAndDelete(string path, string textooverwritewith, bool delete)
        {
            if(!File.Exists(path))
            {
                Debug.WriteLine($"[AntiDebug] Oops! {path} doesn't exist!");
                return;
            }
            var bytes = Encoding.UTF8.GetBytes(textooverwritewith);
            using (var f = File.Open(path, FileMode.Create))
            {
                Debug.WriteLine("[AntiDebug] Writing text to file");
                f.Write(bytes, 0, bytes.Length);
                Debug.WriteLine("[AntiDebug] Text written to file");
            }
            if (delete)
            {
                try
                {
                    Debug.WriteLine("[AntiDebug] Deleting file");
                    File.Delete(path);
                } catch(Exception ex)
                {
                    Debug.WriteLine($"[AntiDebug] We couldn't delete {path} | Default error message: {ex}");
                }
            }
        }

        public string WebRequestWithAntiSnifer(WebRequest url)
        {
            Debug.WriteLine("[AntiDebug] Making request");
            WebRequest wr = WebRequest.Create(url.ToString()); 
            wr.Proxy = null; 
            string html = new System.IO.StreamReader(wr.GetResponse().GetResponseStream()).ReadToEnd();
            Debug.WriteLine("[AntiDebug] Returning request");
            return html;
        }

        public string WebRequestWithAntiSniferStringVersion(string url)
        {
            Debug.WriteLine("[AntiDebug] Making request");
            WebRequest wr = WebRequest.Create(url);
            wr.Proxy = null;
            string html = new System.IO.StreamReader(wr.GetResponse().GetResponseStream()).ReadToEnd();
            Debug.WriteLine("[AntiDebug] Returning request");
            return html;
        }

        public string FileToByteArray(string filepath)
        {
            Debug.WriteLine("[AntiDebug] Reading bytes");
            byte[] filebytes = File.ReadAllBytes(filepath);
            Debug.WriteLine("[AntiDebug] Returning bytes");
            return filebytes.ToString();
        }
    }
}
