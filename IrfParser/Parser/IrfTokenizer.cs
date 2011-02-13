/*
 * IrfTokenizer.cs
 *
 * THIS FILE HAS BEEN GENERATED AUTOMATICALLY. DO NOT EDIT!
 */

using System.IO;

using PerCederberg.Grammatica.Runtime;

namespace IrfParserNs {

    /**
     * <remarks>A character stream tokenizer.</remarks>
     */
    public class IrfTokenizer : Tokenizer {

        /**
         * <summary>Creates a new tokenizer for the specified input
         * stream.</summary>
         *
         * <param name='input'>the input stream to read</param>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        public IrfTokenizer(TextReader input)
            : base(input, false) {

            CreatePatterns();
        }

        /**
         * <summary>Initializes the tokenizer by creating all the token
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            TokenPattern  pattern;

            pattern = new TokenPattern((int) IrfConstants.LT,
                                       "LT",
                                       TokenPattern.PatternType.STRING,
                                       "<");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.GT,
                                       "GT",
                                       TokenPattern.PatternType.STRING,
                                       ">");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.EQUAL,
                                       "EQUAL",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.QUOTE,
                                       "QUOTE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[\"]");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.PLAYER_NOTES,
                                       "PLAYER_NOTES",
                                       TokenPattern.PatternType.STRING,
                                       "playernotes");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.PLAYER_NOTE_SET,
                                       "PLAYER_NOTE_SET",
                                       TokenPattern.PatternType.STRING,
                                       "playernoteset");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.USER_NAME,
                                       "USER_NAME",
                                       TokenPattern.PatternType.REGEXP,
                                       "username=[^\\n]*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.PLAYER_NOTE,
                                       "PLAYER_NOTE",
                                       TokenPattern.PatternType.STRING,
                                       "playernote");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.PLAYER_NAME,
                                       "PLAYER_NAME",
                                       TokenPattern.PatternType.STRING,
                                       "playername");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.NOTE_TEXT,
                                       "NOTE_TEXT",
                                       TokenPattern.PatternType.STRING,
                                       "notetext");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.TIMESTAMP,
                                       "TIMESTAMP",
                                       TokenPattern.PatternType.STRING,
                                       "timestamp");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.CLASSIFICATION,
                                       "CLASSIFICATION",
                                       TokenPattern.PatternType.STRING,
                                       "classificationindex");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.NUMBER,
                                       "NUMBER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[0-9]*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.QUOTED_STRING,
                                       "QUOTED_STRING",
                                       TokenPattern.PatternType.REGEXP,
                                       "(\"([^\"\\\\]|\\\\.)*\")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) IrfConstants.IDENTIFIER,
                                       "IDENTIFIER",
                                       TokenPattern.PatternType.REGEXP,
                                       "[A-Za-z0-9_]*");
            AddPattern(pattern);
        }
    }
}
