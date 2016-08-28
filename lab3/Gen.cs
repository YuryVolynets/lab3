using System;
using System.IO;

namespace lab3
{
    static class Gen
    {
        public static void Generate(string tocName, string fileName, int n)
        {
            Random r = new Random();

            FileStream tocFs = new FileStream(tocName, FileMode.Create);
            BinaryWriter tocBw = new BinaryWriter(tocFs);
            FileStream fileFs = new FileStream(fileName, FileMode.Create);
            BinaryWriter fileBw = new BinaryWriter(fileFs);

            for (int i = 0; i < n; i++)
            {
                fileBw.Write(new string(new char[] { (char)r.Next(65, 91), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123) }));

                switch (r.Next(3))
                {
                    case 0:
                        tocBw.Write(0);
                        fileBw.Write(r.Next(1990, 2000));
                        fileBw.Write(r.Next(1, 13));
                        fileBw.Write(r.Next(1, 29));
                        fileBw.Write(new string(new char[] { (char)r.Next(65, 91), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123) }));
                        break;
                    case 1:
                        tocBw.Write(1);
                        fileBw.Write(r.Next(1980, 1990));
                        fileBw.Write(r.Next(1, 13));
                        fileBw.Write(r.Next(1, 29));
                        fileBw.Write(new string(new char[] { (char)r.Next(65, 91), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123) }));
                        fileBw.Write(r.Next(1, 6));
                        break;
                    case 2:
                        tocBw.Write(2);
                        fileBw.Write(r.Next(1970, 1980));
                        fileBw.Write(r.Next(1, 13));
                        fileBw.Write(r.Next(1, 29));
                        fileBw.Write(new string(new char[] { (char)r.Next(65, 91), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123) }));
                        fileBw.Write(new string(new char[] { (char)r.Next(65, 91), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123), (char)r.Next(97, 123) }));
                        fileBw.Write(r.Next(20));
                        break;
                }
            }

            tocBw.Close();
            tocFs.Close();
            fileBw.Close();
            fileFs.Close();
        }
    }
}
