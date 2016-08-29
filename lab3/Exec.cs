using System;
using System.IO;

namespace lab3
{
    static class Exec
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

        public static void Print(string tocName, string fileName, int n)
        {
            FileStream tocFs = new FileStream(tocName, FileMode.Open);
            BinaryReader tocBr = new BinaryReader(tocFs);
            FileStream fileFs = new FileStream(fileName, FileMode.Open);
            BinaryReader fileBr = new BinaryReader(fileFs);

            for (int i = 0; i < n; i++)
            {
                switch (tocBr.ReadInt32())
                {
                    case 0:
                        Enrollee e = new Enrollee(fileBr.ReadString(), new DateTime(fileBr.ReadInt32(), fileBr.ReadInt32(), fileBr.ReadInt32()), fileBr.ReadString());
                        e.Print();
                        break;
                    case 1:
                        Student s = new Student(fileBr.ReadString(), new DateTime(fileBr.ReadInt32(), fileBr.ReadInt32(), fileBr.ReadInt32()), fileBr.ReadString(), fileBr.ReadInt32());
                        s.Print();
                        break;
                    case 2:
                        Teacher t = new Teacher(fileBr.ReadString(), new DateTime(fileBr.ReadInt32(), fileBr.ReadInt32(), fileBr.ReadInt32()), fileBr.ReadString(), fileBr.ReadString(), fileBr.ReadInt32());
                        t.Print();
                        break;
                }
            }

            tocBr.Close();
            tocFs.Close();
            fileBr.Close();
            fileFs.Close();
        }

        public static void Search(string tocName, string fileName, int n, int ageMin, int ageMax)
        {
            FileStream tocFs = new FileStream(tocName, FileMode.Open);
            BinaryReader tocBr = new BinaryReader(tocFs);
            FileStream fileFs = new FileStream(fileName, FileMode.Open);
            BinaryReader fileBr = new BinaryReader(fileFs);

            for (int i = 0; i < n; i++)
            {
                switch (tocBr.ReadInt32())
                {
                    case 0:
                        Enrollee e = new Enrollee(fileBr.ReadString(), new DateTime(fileBr.ReadInt32(), fileBr.ReadInt32(), fileBr.ReadInt32()), fileBr.ReadString());
                        if ((e.Age() >= ageMin) && (e.Age() <= ageMax))
                        {
                            e.Print();
                        }
                        break;
                    case 1:
                        Student s = new Student(fileBr.ReadString(), new DateTime(fileBr.ReadInt32(), fileBr.ReadInt32(), fileBr.ReadInt32()), fileBr.ReadString(), fileBr.ReadInt32());
                        if ((s.Age() >= ageMin) && (s.Age() <= ageMax))
                        {
                            s.Print();
                        }
                        break;
                    case 2:
                        Teacher t = new Teacher(fileBr.ReadString(), new DateTime(fileBr.ReadInt32(), fileBr.ReadInt32(), fileBr.ReadInt32()), fileBr.ReadString(), fileBr.ReadString(), fileBr.ReadInt32());
                        if ((t.Age() >= ageMin) && (t.Age() <= ageMax))
                        {
                            t.Print();
                        }
                        break;
                }
            }

            tocBr.Close();
            tocFs.Close();
            fileBr.Close();
            fileFs.Close();
        }
    }
}
