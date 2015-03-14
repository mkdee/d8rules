// $ANTLR 3.1.2 C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g 2010-09-24 12:27:20

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;

namespace  drules.dates.library.grammar 
{
public partial class DateExpressionLexer : Lexer
{
	public const int EOF=-1;
	public const int T__22=22;
	public const int T__23=23;
	public const int AND=4;
	public const int COMMA=5;
	public const int DELIMITER=6;
	public const int EQUALS=7;
	public const int LE=8;
	public const int LPAREN=9;
	public const int LT=10;
	public const int MINUS=11;
	public const int NAME=12;
	public const int NEG_INT=13;
	public const int NEWLINE=14;
	public const int NOT=15;
	public const int OR=16;
	public const int POS_INT=17;
	public const int RPAREN=18;
	public const int SLASH=19;
	public const int STAR=20;
	public const int WS=21;

    // delegates
    // delegators

	public DateExpressionLexer() {}
	public DateExpressionLexer( ICharStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public DateExpressionLexer( ICharStream input, RecognizerSharedState state )
		: base( input, state )
	{

	}
	public override string GrammarFileName { get { return "C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g"; } }

	// $ANTLR start "T__22"
	private void mT__22()
	{
		try
		{
			int _type = T__22;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:9:9: ( '0' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:9:9: '0'
			{
			Match('0'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "T__22"

	// $ANTLR start "T__23"
	private void mT__23()
	{
		try
		{
			int _type = T__23;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:10:9: ( 'last' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:10:9: 'last'
			{
			Match("last"); 


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "T__23"

	// $ANTLR start "OR"
	private void mOR()
	{
		try
		{
			int _type = OR;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:95:7: ( '|' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:95:7: '|'
			{
			Match('|'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "OR"

	// $ANTLR start "AND"
	private void mAND()
	{
		try
		{
			int _type = AND;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:96:8: ( '&' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:96:8: '&'
			{
			Match('&'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "AND"

	// $ANTLR start "LT"
	private void mLT()
	{
		try
		{
			int _type = LT;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:97:7: ( '<' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:97:7: '<'
			{
			Match('<'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "LT"

	// $ANTLR start "LE"
	private void mLE()
	{
		try
		{
			int _type = LE;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:98:7: ( '<' EQUALS )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:98:7: '<' EQUALS
			{
			Match('<'); 
			mEQUALS(); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "LE"

	// $ANTLR start "EQUALS"
	private void mEQUALS()
	{
		try
		{
			int _type = EQUALS;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:99:10: ( '=' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:99:10: '='
			{
			Match('='); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "EQUALS"

	// $ANTLR start "MINUS"
	private void mMINUS()
	{
		try
		{
			int _type = MINUS;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:101:9: ( '-' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:101:9: '-'
			{
			Match('-'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "MINUS"

	// $ANTLR start "STAR"
	private void mSTAR()
	{
		try
		{
			int _type = STAR;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:102:13: ( '*' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:102:13: '*'
			{
			Match('*'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "STAR"

	// $ANTLR start "SLASH"
	private void mSLASH()
	{
		try
		{
			int _type = SLASH;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:103:13: ( '/' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:103:13: '/'
			{
			Match('/'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "SLASH"

	// $ANTLR start "NOT"
	private void mNOT()
	{
		try
		{
			int _type = NOT;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:105:8: ( '!' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:105:8: '!'
			{
			Match('!'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "NOT"

	// $ANTLR start "NAME"
	private void mNAME()
	{
		try
		{
			int _type = NAME;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:107:8: ( 'a' .. 'z' ( 'a' .. 'z' | DELIMITER )* )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:107:8: 'a' .. 'z' ( 'a' .. 'z' | DELIMITER )*
			{
			MatchRange('a','z'); 
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:107:17: ( 'a' .. 'z' | DELIMITER )*
			for ( ; ; )
			{
				int alt1=2;
				int LA1_0 = input.LA(1);

				if ( (LA1_0=='.'||LA1_0=='_'||(LA1_0>='a' && LA1_0<='z')) )
				{
					alt1=1;
				}


				switch ( alt1 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:
					{
					input.Consume();


					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;



			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "NAME"

	// $ANTLR start "NEG_INT"
	private void mNEG_INT()
	{
		try
		{
			int _type = NEG_INT;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:109:11: ( ( MINUS POS_INT ) )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:109:11: ( MINUS POS_INT )
			{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:109:11: ( MINUS POS_INT )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:109:12: MINUS POS_INT
			{
			mMINUS(); 
			mPOS_INT(); 

			}


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "NEG_INT"

	// $ANTLR start "POS_INT"
	private void mPOS_INT()
	{
		try
		{
			int _type = POS_INT;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:110:11: ( '1' .. '9' ( '0' .. '9' )* )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:110:11: '1' .. '9' ( '0' .. '9' )*
			{
			MatchRange('1','9'); 
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:110:20: ( '0' .. '9' )*
			for ( ; ; )
			{
				int alt2=2;
				int LA2_0 = input.LA(1);

				if ( ((LA2_0>='0' && LA2_0<='9')) )
				{
					alt2=1;
				}


				switch ( alt2 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:
					{
					input.Consume();


					}
					break;

				default:
					goto loop2;
				}
			}

			loop2:
				;



			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "POS_INT"

	// $ANTLR start "DELIMITER"
	private void mDELIMITER()
	{
		try
		{
			int _type = DELIMITER;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:112:13: ( ( '.' | '_' ) )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:
			{
			if ( input.LA(1)=='.'||input.LA(1)=='_' )
			{
				input.Consume();

			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				Recover(mse);
				throw mse;}


			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "DELIMITER"

	// $ANTLR start "LPAREN"
	private void mLPAREN()
	{
		try
		{
			int _type = LPAREN;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:114:10: ( '(' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:114:10: '('
			{
			Match('('); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "LPAREN"

	// $ANTLR start "RPAREN"
	private void mRPAREN()
	{
		try
		{
			int _type = RPAREN;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:115:10: ( ')' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:115:10: ')'
			{
			Match(')'); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "RPAREN"

	// $ANTLR start "COMMA"
	private void mCOMMA()
	{
		try
		{
			int _type = COMMA;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:116:9: ( ',' )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:116:9: ','
			{
			Match(','); 

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "COMMA"

	// $ANTLR start "NEWLINE"
	private void mNEWLINE()
	{
		try
		{
			int _type = NEWLINE;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:118:11: ( ( '\\r' | '\\n' )+ )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:118:11: ( '\\r' | '\\n' )+
			{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:118:11: ( '\\r' | '\\n' )+
			int cnt3=0;
			for ( ; ; )
			{
				int alt3=2;
				int LA3_0 = input.LA(1);

				if ( (LA3_0=='\n'||LA3_0=='\r') )
				{
					alt3=1;
				}


				switch ( alt3 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:
					{
					input.Consume();


					}
					break;

				default:
					if ( cnt3 >= 1 )
						goto loop3;

					EarlyExitException eee3 = new EarlyExitException( 3, input );
					throw eee3;
				}
				cnt3++;
			}
			loop3:
				;



			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "NEWLINE"

	// $ANTLR start "WS"
	private void mWS()
	{
		try
		{
			int _type = WS;
			int _channel = DefaultTokenChannel;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:119:9: ( ( ' ' | '\\t' )+ )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:119:9: ( ' ' | '\\t' )+
			{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:119:9: ( ' ' | '\\t' )+
			int cnt4=0;
			for ( ; ; )
			{
				int alt4=2;
				int LA4_0 = input.LA(1);

				if ( (LA4_0=='\t'||LA4_0==' ') )
				{
					alt4=1;
				}


				switch ( alt4 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:
					{
					input.Consume();


					}
					break;

				default:
					if ( cnt4 >= 1 )
						goto loop4;

					EarlyExitException eee4 = new EarlyExitException( 4, input );
					throw eee4;
				}
				cnt4++;
			}
			loop4:
				;


			_channel=HIDDEN;

			}

			state.type = _type;
			state.channel = _channel;
		}
		finally
		{
		}
	}
	// $ANTLR end "WS"

	public override void mTokens()
	{
		// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:10: ( T__22 | T__23 | OR | AND | LT | LE | EQUALS | MINUS | STAR | SLASH | NOT | NAME | NEG_INT | POS_INT | DELIMITER | LPAREN | RPAREN | COMMA | NEWLINE | WS )
		int alt5=20;
		alt5 = dfa5.Predict(input);
		switch ( alt5 )
		{
		case 1:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:10: T__22
			{
			mT__22(); 

			}
			break;
		case 2:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:16: T__23
			{
			mT__23(); 

			}
			break;
		case 3:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:22: OR
			{
			mOR(); 

			}
			break;
		case 4:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:25: AND
			{
			mAND(); 

			}
			break;
		case 5:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:29: LT
			{
			mLT(); 

			}
			break;
		case 6:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:32: LE
			{
			mLE(); 

			}
			break;
		case 7:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:35: EQUALS
			{
			mEQUALS(); 

			}
			break;
		case 8:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:42: MINUS
			{
			mMINUS(); 

			}
			break;
		case 9:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:48: STAR
			{
			mSTAR(); 

			}
			break;
		case 10:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:53: SLASH
			{
			mSLASH(); 

			}
			break;
		case 11:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:59: NOT
			{
			mNOT(); 

			}
			break;
		case 12:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:63: NAME
			{
			mNAME(); 

			}
			break;
		case 13:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:68: NEG_INT
			{
			mNEG_INT(); 

			}
			break;
		case 14:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:76: POS_INT
			{
			mPOS_INT(); 

			}
			break;
		case 15:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:84: DELIMITER
			{
			mDELIMITER(); 

			}
			break;
		case 16:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:94: LPAREN
			{
			mLPAREN(); 

			}
			break;
		case 17:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:101: RPAREN
			{
			mRPAREN(); 

			}
			break;
		case 18:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:108: COMMA
			{
			mCOMMA(); 

			}
			break;
		case 19:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:114: NEWLINE
			{
			mNEWLINE(); 

			}
			break;
		case 20:
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:1:122: WS
			{
			mWS(); 

			}
			break;

		}

	}


	#region DFA
	DFA5 dfa5;

	protected override void InitDFAs()
	{
		base.InitDFAs();
		dfa5 = new DFA5( this );
	}

	class DFA5 : DFA
	{

		const string DFA5_eotS =
			"\x2\xFFFF\x1\xB\x2\xFFFF\x1\x14\x1\xFFFF\x1\x16\xB\xFFFF\x1\xB\x4\xFFFF"+
			"\x1\xB\x1\x1A\x1\xFFFF";
		const string DFA5_eofS =
			"\x1B\xFFFF";
		const string DFA5_minS =
			"\x1\x9\x1\xFFFF\x1\x61\x2\xFFFF\x1\x3D\x1\xFFFF\x1\x31\xB\xFFFF\x1\x73"+
			"\x4\xFFFF\x1\x74\x1\x2E\x1\xFFFF";
		const string DFA5_maxS =
			"\x1\x7C\x1\xFFFF\x1\x61\x2\xFFFF\x1\x3D\x1\xFFFF\x1\x39\xB\xFFFF\x1\x73"+
			"\x4\xFFFF\x1\x74\x1\x7A\x1\xFFFF";
		const string DFA5_acceptS =
			"\x1\xFFFF\x1\x1\x1\xFFFF\x1\x3\x1\x4\x1\xFFFF\x1\x7\x1\xFFFF\x1\x9\x1"+
			"\xA\x1\xB\x1\xC\x1\xE\x1\xF\x1\x10\x1\x11\x1\x12\x1\x13\x1\x14\x1\xFFFF"+
			"\x1\x5\x1\x6\x1\x8\x1\xD\x2\xFFFF\x1\x2";
		const string DFA5_specialS =
			"\x1B\xFFFF}>";
		static readonly string[] DFA5_transitionS =
			{
				"\x1\x12\x1\x11\x2\xFFFF\x1\x11\x12\xFFFF\x1\x12\x1\xA\x4\xFFFF\x1\x4"+
				"\x1\xFFFF\x1\xE\x1\xF\x1\x8\x1\xFFFF\x1\x10\x1\x7\x1\xD\x1\x9\x1\x1"+
				"\x9\xC\x2\xFFFF\x1\x5\x1\x6\x21\xFFFF\x1\xD\x1\xFFFF\xB\xB\x1\x2\xE"+
				"\xB\x1\xFFFF\x1\x3",
				"",
				"\x1\x13",
				"",
				"",
				"\x1\x15",
				"",
				"\x9\x17",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"",
				"\x1\x18",
				"",
				"",
				"",
				"",
				"\x1\x19",
				"\x1\xB\x30\xFFFF\x1\xB\x1\xFFFF\x1A\xB",
				""
			};

		static readonly short[] DFA5_eot = DFA.UnpackEncodedString(DFA5_eotS);
		static readonly short[] DFA5_eof = DFA.UnpackEncodedString(DFA5_eofS);
		static readonly char[] DFA5_min = DFA.UnpackEncodedStringToUnsignedChars(DFA5_minS);
		static readonly char[] DFA5_max = DFA.UnpackEncodedStringToUnsignedChars(DFA5_maxS);
		static readonly short[] DFA5_accept = DFA.UnpackEncodedString(DFA5_acceptS);
		static readonly short[] DFA5_special = DFA.UnpackEncodedString(DFA5_specialS);
		static readonly short[][] DFA5_transition;

		static DFA5()
		{
			int numStates = DFA5_transitionS.Length;
			DFA5_transition = new short[numStates][];
			for ( int i=0; i < numStates; i++ )
			{
				DFA5_transition[i] = DFA.UnpackEncodedString(DFA5_transitionS[i]);
			}
		}

		public DFA5( BaseRecognizer recognizer )
		{
			this.recognizer = recognizer;
			this.decisionNumber = 5;
			this.eot = DFA5_eot;
			this.eof = DFA5_eof;
			this.min = DFA5_min;
			this.max = DFA5_max;
			this.accept = DFA5_accept;
			this.special = DFA5_special;
			this.transition = DFA5_transition;
		}
		public override string GetDescription()
		{
			return "1:0: Tokens : ( T__22 | T__23 | OR | AND | LT | LE | EQUALS | MINUS | STAR | SLASH | NOT | NAME | NEG_INT | POS_INT | DELIMITER | LPAREN | RPAREN | COMMA | NEWLINE | WS );";
		}
	}

 
	#endregion

}

} // namespace  drules.dates.library.grammar 
