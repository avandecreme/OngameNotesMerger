using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using PerCederberg.Grammatica.Runtime;

namespace IrfParserNs
{
    public class IrfFileReader : IrfAnalyzer
    {
        private IrfObject irfObject;
        public IrfObject IrfObject { get { return irfObject; } }

        public override Node ExitRootNode(Production node)
        {
            var values = GetChildValues(node);

            if (values.Count != 0)
            {
                irfObject = new IrfObject();
                for (int i = 0; i < values.Count; i++)
                    irfObject.Add((IrfUserData)values[i]);
            }

            return node;
        }

        public override Node ExitUserNode(Production node)
        {
            var values = GetChildValues(node);

            if (values.Count != 0)
            {
                IrfUserData userData = new IrfUserData();
                userData.UserName = (string)values[0];

                for (int i = 1; i < values.Count; i++)
                    userData.Add((IrfNote)values[i]);

                node.AddValue(userData);
            }

            return node;
        }

        public override Node ExitUserName(Token node)
        {
            node.AddValue(node.GetImage().Substring(9).Trim());
            return node;
        }

        public override Node ExitPlayerNoteNode(Production node)
        {
            var values = GetChildValues(node);

            if (values.Count != 0)
            {
                IrfNote note = new IrfNote();
                note.PlayerName = (PlayerName)values[0];

                for (int i = 1; i < values.Count; i++)
                {
                    object value = values[i];
                    if (value is NoteText)
                        note.NoteText = (NoteText)value;
                    else if (value is DateTime)
                        note.DateTime = (DateTime)value;
                    else if (value is Classification)
                        note.Classification = (Classification)value;
                }
                node.AddValue(note);
            }

            return node;
        }

        public override Node ExitPlayerNameAttribute(Production node)
        {
            var values = GetChildValues(node);
            if(values.Count != 0)
                node.AddValue(new PlayerName() { Value = (string)values[0] });
            return node;
        }

        public override Node ExitNoteTextAttribute(Production node)
        {
            var values = GetChildValues(node);
            if (values.Count != 0)
                node.AddValue(new NoteText() { Value = (string)values[0] });
            return node;
        }

        public override Node ExitTimestampAttribute(Production node)
        {
            var values = GetChildValues(node);
            if (values.Count != 0)
            {
                long seconds = long.Parse((string)values[0]);
                node.AddValue(TimestampHelper.GetDateTime(seconds));
            }
            return node;
        }

        public override Node ExitClassificationAttribute(Production node)
        {
            var values = GetChildValues(node);
            if (values.Count != 0)
            {
                Classification value = (Classification)int.Parse((string)values[0]);
                node.AddValue(value);
            }
            return node;
        }

        public override Node ExitQuotedString(Token node)
        {
            string quotedString = node.GetImage();
            // Remove first and last char which are both a quote.
            string content = quotedString.Substring(1, quotedString.Length - 2);
            node.AddValue(content);
            return node;
        }
    }
}
