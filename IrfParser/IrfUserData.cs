using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IrfParserNs
{
    public class IrfUserData
    {
        public string UserName { get; internal set; }

        private SortedDictionary<PlayerName, IrfNote> notes = new SortedDictionary<PlayerName, IrfNote>();

        public IEnumerable<IrfNote> Notes { get { return notes.Values; } }

        public void Add(IrfNote note)
        {
            if (note == null) throw new ArgumentNullException("note");
            if (note.PlayerName == null) throw new ArgumentNullException("note.PlayerName");

            notes.Add(note.PlayerName, note);
        }

        public void Merge(IrfUserData userData)
        {
            foreach (var note in userData.notes)
            {
                if (!notes.ContainsKey(note.Key))
                    notes.Add(note.Key, note.Value);
                else
                    notes[note.Key].Merge(note.Value);
            }
        }

        internal void WriteToStream(StreamWriter stream)
        {
            stream.WriteLine(" <playernoteset ");
            stream.WriteLine("  username={0}", UserName);
            foreach (var note in Notes)
                note.WriteToStream(stream);
            stream.WriteLine(" >");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IrfUserData)) return false;

            IrfUserData iudObj = (IrfUserData)obj;

            if (!string.Equals(UserName, iudObj.UserName)) return false;

            return notes.SequenceEqual(iudObj.notes);
        }

        public override int GetHashCode()
        {
            int userHash = (UserName ?? string.Empty).GetHashCode();
            return notes.Aggregate(userHash, (currHash, next) => currHash ^ next.GetHashCode());
        }
    }
}
