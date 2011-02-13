using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using PerCederberg.Grammatica.Runtime;

namespace IrfParserNs
{
    public class IrfObject
    {
        private SortedDictionary<string, IrfUserData> usersData = new SortedDictionary<string, IrfUserData>();

        public IEnumerable<IrfUserData> UsersData { get { return usersData.Values; } }

        public void Add(IrfUserData userData)
        {
            if(userData == null) throw new ArgumentNullException("userData");
            if(string.IsNullOrEmpty(userData.UserName)) throw new ArgumentNullException("userData.UserName");

            usersData.Add(userData.UserName, userData);
        }

        public void WriteToFile(string path)
        {
            using (var stream = new StreamWriter(path, false, Encoding.Unicode))
            {
                stream.WriteLine("<playernotes");
                foreach (var ud in UsersData)
                    ud.WriteToStream(stream);
                stream.WriteLine(">");
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IrfObject)) return false;
            
            IrfObject irfObj = (IrfObject)obj;
            return usersData.SequenceEqual(irfObj.usersData);
        }

        public override int GetHashCode()
        {
            return usersData.Aggregate(0, (currHash, next) => currHash ^ next.GetHashCode());
        }

        public static IrfObject LoadFromFile(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("The input file doesn't exist", path);

            using (StreamReader irfFile = new StreamReader(path))
            {
                IrfFileReader reader = new IrfFileReader();
                Parser parser = new IrfParserNs.IrfParser(irfFile, reader);
                parser.Parse();
                return reader.IrfObject;
            }
        }
    }
}
