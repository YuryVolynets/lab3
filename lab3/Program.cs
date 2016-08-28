using System;
using System.IO;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            const string tocName = "toc.data", fileName = "file.data";

            Console.Write("n: ");
            int n = int.Parse(Console.ReadLine());

            Gen.Generate(tocName, fileName, n);

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
        }
    }
}
