using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace IrfParserNs
{
    public enum Classification
    {
        GreenDot = 0,
        RedDot = 1,
        YellowDot = 2,
        GreenPlus = 3,
        GreenMinus = 4,
        YellowExclamation = 5
    }

    public class PlayerName : IComparable
    { 
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is PlayerName)) return false;
            return string.Equals(Value, ((PlayerName)obj).Value, StringComparison.InvariantCulture);
        }

        public override int GetHashCode()
        {
            return (Value ?? string.Empty).GetHashCode();
        }

        public int CompareTo(object obj)
        {
            if (!(obj is PlayerName)) throw new ArgumentException("The object must be a PlayerName", "obj");
            return (Value ?? string.Empty).CompareTo(((PlayerName)obj).Value);
        }
    }

    public class NoteText 
    {
        public string Value { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is NoteText)) return false;
            return string.Equals(Value, ((NoteText)obj).Value, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return (Value ?? string.Empty).GetHashCode();
        }
    }

    public class IrfNote
    {
        public PlayerName PlayerName { get; set; }

        public NoteText NoteText { get; set; }

        public DateTime? DateTime { get; set; }

        public Classification? Classification { get; set; }

        public void Merge(IrfNote irfNote)
        {
            if(irfNote == null) throw new ArgumentNullException("irfNote");

            if (!PlayerName.Equals(this.PlayerName, irfNote.PlayerName))
                throw new ArgumentException("PlayerName must be identical to merge 2 IrfNote", "irfNote");


            NoteText = NoteText ?? irfNote.NoteText;
            if (NoteText != null && irfNote.NoteText != null)
            {
                if (!NoteText.Value.Contains(irfNote.NoteText.Value))
                    NoteText.Value += Environment.NewLine + irfNote.NoteText.Value;
            }
                
            DateTime = DateTime ?? irfNote.DateTime;
            Classification = Classification ?? irfNote.Classification;
        }

        internal void WriteToStream(StreamWriter stream)
        {
            stream.WriteLine("  <playernote");
            stream.WriteLine("   playername=\"{0}\"", PlayerName.Value);

            if (NoteText != null)
                stream.WriteLine("   notetext=\"{0}\"", NoteText.Value);

            if (DateTime != null)
                stream.WriteLine("   timestamp=\"{0}\"",
                    TimestampHelper.GetTimestamp(DateTime.Value));

            if (Classification != null)
                stream.WriteLine("   classificationindex=\"{0}\"", (int)Classification);

            stream.WriteLine("  >");
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is IrfNote)) return false;

            IrfNote irfNoteObj = (IrfNote)obj;
            return IrfParserNs.PlayerName.Equals(PlayerName, irfNoteObj.PlayerName) &&
                IrfParserNs.NoteText.Equals(NoteText, irfNoteObj.NoteText) &&
                object.Equals(DateTime, irfNoteObj.DateTime) &&
                object.Equals(Classification, irfNoteObj.Classification);
        }

        public override int GetHashCode()
        {
            int pnHash = PlayerName != null ? PlayerName.GetHashCode() : 0;
            int ntHash = NoteText != null ? NoteText.GetHashCode() : 0;
            int dtHash = DateTime != null ? DateTime.GetHashCode() : 0;
            int clHash = Classification != null ? Classification.GetHashCode() : 0;
            return pnHash ^ ntHash ^ dtHash ^ clHash;
        }
    }
}
