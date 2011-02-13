/*
 * IrfParser.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace IrfParserNs {

    /**
     * <remarks>A token stream parser.</remarks>
     */
    public class IrfParser : RecursiveDescentParser {

        /**
         * <summary>An enumeration with the generated production node
         * identity constants.</summary>
         */
        private enum SynteticPatterns {
        }

        /**
         * <summary>Creates a new parser with a default analyzer.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public IrfParser(TextReader input)
            : base(input) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new parser.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <param name='analyzer'>the analyzer to parse with</param>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        public IrfParser(TextReader input, IrfAnalyzer analyzer)
            : base(input, analyzer) {

            CreatePatterns();
        }

        /**
         * <summary>Creates a new tokenizer for this parser. Can be overridden
         * by a subclass to provide a custom implementation.</summary>
         *
         * <param name='input'>the input stream to read from</param>
         *
         * <returns>the tokenizer created</returns>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        protected override Tokenizer NewTokenizer(TextReader input) {
            return new IrfTokenizer(input);
        }

        /**
         * <summary>Initializes the parser by creating all the production
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the parser
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            ProductionPattern             pattern;
            ProductionPatternAlternative  alt;

            pattern = new ProductionPattern((int) IrfConstants.IRF_DOCUMENT,
                                            "IrfDocument");
            alt = new ProductionPatternAlternative();
            alt.AddProduction((int) IrfConstants.ROOT_NODE, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.ROOT_NODE,
                                            "RootNode");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.LT, 1, 1);
            alt.AddToken((int) IrfConstants.PLAYER_NOTES, 1, 1);
            alt.AddProduction((int) IrfConstants.USER_NODE, 0, 1);
            alt.AddToken((int) IrfConstants.GT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.USER_NODE,
                                            "UserNode");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.LT, 1, 1);
            alt.AddToken((int) IrfConstants.PLAYER_NOTE_SET, 1, 1);
            alt.AddToken((int) IrfConstants.USER_NAME, 1, 1);
            alt.AddProduction((int) IrfConstants.PLAYER_NOTE_NODE, 1, -1);
            alt.AddToken((int) IrfConstants.GT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.PLAYER_NOTE_NODE,
                                            "PlayerNoteNode");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.LT, 1, 1);
            alt.AddToken((int) IrfConstants.PLAYER_NOTE, 1, 1);
            alt.AddProduction((int) IrfConstants.PLAYER_NAME_ATTRIBUTE, 1, 1);
            alt.AddProduction((int) IrfConstants.NOTE_TEXT_ATTRIBUTE, 0, 1);
            alt.AddProduction((int) IrfConstants.TIMESTAMP_ATTRIBUTE, 0, 1);
            alt.AddProduction((int) IrfConstants.CLASSIFICATION_ATTRIBUTE, 0, 1);
            alt.AddToken((int) IrfConstants.GT, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.PLAYER_NAME_ATTRIBUTE,
                                            "PlayerNameAttribute");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.PLAYER_NAME, 1, 1);
            alt.AddToken((int) IrfConstants.EQUAL, 1, 1);
            alt.AddToken((int) IrfConstants.QUOTED_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.NOTE_TEXT_ATTRIBUTE,
                                            "NoteTextAttribute");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.NOTE_TEXT, 1, 1);
            alt.AddToken((int) IrfConstants.EQUAL, 1, 1);
            alt.AddToken((int) IrfConstants.QUOTED_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.TIMESTAMP_ATTRIBUTE,
                                            "TimestampAttribute");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.TIMESTAMP, 1, 1);
            alt.AddToken((int) IrfConstants.EQUAL, 1, 1);
            alt.AddToken((int) IrfConstants.QUOTED_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);

            pattern = new ProductionPattern((int) IrfConstants.CLASSIFICATION_ATTRIBUTE,
                                            "ClassificationAttribute");
            alt = new ProductionPatternAlternative();
            alt.AddToken((int) IrfConstants.CLASSIFICATION, 1, 1);
            alt.AddToken((int) IrfConstants.EQUAL, 1, 1);
            alt.AddToken((int) IrfConstants.QUOTED_STRING, 1, 1);
            pattern.AddAlternative(alt);
            AddPattern(pattern);
        }
    }
}
