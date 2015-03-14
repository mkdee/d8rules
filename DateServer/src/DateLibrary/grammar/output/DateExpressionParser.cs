// $ANTLR 3.1.2 C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g 2010-09-24 12:27:19

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 219
// Unreachable code detected.
#pragma warning disable 162


	using System;
	using drules.dates.library;
	using drules.dates.library.rules;
	using drules.dates.library.grammar;	


using System.Collections.Generic;
using Antlr.Runtime;
using Stack = System.Collections.Generic.Stack<object>;
using List = System.Collections.IList;
using ArrayList = System.Collections.Generic.List<object>;


using Antlr.Runtime.Tree;
using RewriteRuleITokenStream = Antlr.Runtime.Tree.RewriteRuleTokenStream;

namespace  drules.dates.library.grammar 
{
public partial class DateExpressionParser : Parser
{
	internal static readonly string[] tokenNames = new string[] {
		"<invalid>", "<EOR>", "<DOWN>", "<UP>", "AND", "COMMA", "DELIMITER", "EQUALS", "LE", "LPAREN", "LT", "MINUS", "NAME", "NEG_INT", "NEWLINE", "NOT", "OR", "POS_INT", "RPAREN", "SLASH", "STAR", "WS", "'0'", "'last'"
	};
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

	public DateExpressionParser( ITokenStream input )
		: this( input, new RecognizerSharedState() )
	{
	}
	public DateExpressionParser( ITokenStream input, RecognizerSharedState state )
		: base( input, state )
	{
		InitializeTreeAdaptor();
		if ( TreeAdaptor == null )
			TreeAdaptor = new CommonTreeAdaptor();
	}
		
	// Implement this function in your helper file to use a custom tree adaptor
	partial void InitializeTreeAdaptor();
	ITreeAdaptor adaptor;

	public ITreeAdaptor TreeAdaptor
	{
		get
		{
			return adaptor;
		}
		set
		{
			this.adaptor = value;
		}
	}

	public override string[] TokenNames { get { return DateExpressionParser.tokenNames; } }
	public override string GrammarFileName { get { return "C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g"; } }


	#region Rules
	public class statement_return : ParserRuleReturnScope
	{
		public IDateRule result = null;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "statement"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:21:0: statement returns [IDateRule result = null] : ( assignment )* rule= expr ;
	private DateExpressionParser.statement_return statement(  )
	{
		DateExpressionParser.statement_return retval = new DateExpressionParser.statement_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		DateExpressionParser.expr_return rule = default(DateExpressionParser.expr_return);
		DateExpressionParser.assignment_return assignment1 = default(DateExpressionParser.assignment_return);


		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:22:8: ( ( assignment )* rule= expr )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:22:8: ( assignment )* rule= expr
			{
			root_0 = (CommonTree)adaptor.Nil();

			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:22:8: ( assignment )*
			for ( ; ; )
			{
				int alt1=2;
				int LA1_0 = input.LA(1);

				if ( (LA1_0==NAME) )
				{
					int LA1_2 = input.LA(2);

					if ( (LA1_2==EQUALS) )
					{
						alt1=1;
					}


				}


				switch ( alt1 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:22:0: assignment
					{
					PushFollow(Follow._assignment_in_statement68);
					assignment1=assignment();

					state._fsp--;

					adaptor.AddChild(root_0, assignment1.Tree);

					}
					break;

				default:
					goto loop1;
				}
			}

			loop1:
				;


			PushFollow(Follow._expr_in_statement81);
			rule=expr();

			state._fsp--;

			adaptor.AddChild(root_0, rule.Tree);
			retval.result = (rule!=null?rule.result:default(IDateRule));

			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "statement"

	public class assignment_return : ParserRuleReturnScope
	{
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "assignment"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:27:0: assignment : NAME EQUALS rule= expr NEWLINE ;
	private DateExpressionParser.assignment_return assignment(  )
	{
		DateExpressionParser.assignment_return retval = new DateExpressionParser.assignment_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken NAME2=null;
		IToken EQUALS3=null;
		IToken NEWLINE4=null;
		DateExpressionParser.expr_return rule = default(DateExpressionParser.expr_return);

		CommonTree NAME2_tree=null;
		CommonTree EQUALS3_tree=null;
		CommonTree NEWLINE4_tree=null;

		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:28:8: ( NAME EQUALS rule= expr NEWLINE )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:28:8: NAME EQUALS rule= expr NEWLINE
			{
			root_0 = (CommonTree)adaptor.Nil();

			NAME2=(IToken)Match(input,NAME,Follow._NAME_in_assignment110); 
			NAME2_tree = (CommonTree)adaptor.Create(NAME2);
			adaptor.AddChild(root_0, NAME2_tree);

			EQUALS3=(IToken)Match(input,EQUALS,Follow._EQUALS_in_assignment112); 
			EQUALS3_tree = (CommonTree)adaptor.Create(EQUALS3);
			adaptor.AddChild(root_0, EQUALS3_tree);

			PushFollow(Follow._expr_in_assignment116);
			rule=expr();

			state._fsp--;

			adaptor.AddChild(root_0, rule.Tree);
			NEWLINE4=(IToken)Match(input,NEWLINE,Follow._NEWLINE_in_assignment118); 
			NEWLINE4_tree = (CommonTree)adaptor.Create(NEWLINE4);
			adaptor.AddChild(root_0, NEWLINE4_tree);

			AddRule(NAME2.Text, rule.result);

			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "assignment"

	public class expr_return : ParserRuleReturnScope
	{
		public IDateRule result = null;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "expr"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:32:0: expr returns [IDateRule result = null] : ( ( NOT ( LPAREN eNot= exprmain RPAREN )? ) |e= exprmain );
	private DateExpressionParser.expr_return expr(  )
	{
		DateExpressionParser.expr_return retval = new DateExpressionParser.expr_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken NOT5=null;
		IToken LPAREN6=null;
		IToken RPAREN7=null;
		DateExpressionParser.exprmain_return eNot = default(DateExpressionParser.exprmain_return);
		DateExpressionParser.exprmain_return e = default(DateExpressionParser.exprmain_return);

		CommonTree NOT5_tree=null;
		CommonTree LPAREN6_tree=null;
		CommonTree RPAREN7_tree=null;

		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:33:6: ( ( NOT ( LPAREN eNot= exprmain RPAREN )? ) |e= exprmain )
			int alt3=2;
			int LA3_0 = input.LA(1);

			if ( (LA3_0==NOT) )
			{
				alt3=1;
			}
			else if ( (LA3_0==NAME||LA3_0==POS_INT||LA3_0==STAR) )
			{
				alt3=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 3, 0, input);

				throw nvae;
			}
			switch ( alt3 )
			{
			case 1:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:33:6: ( NOT ( LPAREN eNot= exprmain RPAREN )? )
				{
				root_0 = (CommonTree)adaptor.Nil();

				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:33:6: ( NOT ( LPAREN eNot= exprmain RPAREN )? )
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:33:7: NOT ( LPAREN eNot= exprmain RPAREN )?
				{
				NOT5=(IToken)Match(input,NOT,Follow._NOT_in_expr147); 
				NOT5_tree = (CommonTree)adaptor.Create(NOT5);
				adaptor.AddChild(root_0, NOT5_tree);

				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:33:11: ( LPAREN eNot= exprmain RPAREN )?
				int alt2=2;
				int LA2_0 = input.LA(1);

				if ( (LA2_0==LPAREN) )
				{
					alt2=1;
				}
				switch ( alt2 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:33:12: LPAREN eNot= exprmain RPAREN
					{
					LPAREN6=(IToken)Match(input,LPAREN,Follow._LPAREN_in_expr150); 
					LPAREN6_tree = (CommonTree)adaptor.Create(LPAREN6);
					adaptor.AddChild(root_0, LPAREN6_tree);

					PushFollow(Follow._exprmain_in_expr154);
					eNot=exprmain();

					state._fsp--;

					adaptor.AddChild(root_0, eNot.Tree);
					RPAREN7=(IToken)Match(input,RPAREN,Follow._RPAREN_in_expr156); 
					RPAREN7_tree = (CommonTree)adaptor.Create(RPAREN7);
					adaptor.AddChild(root_0, RPAREN7_tree);


					}
					break;

				}


				}

				retval.result = new DateRuleNot(eNot.result);

				}
				break;
			case 2:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:35:4: e= exprmain
				{
				root_0 = (CommonTree)adaptor.Nil();

				PushFollow(Follow._exprmain_in_expr170);
				e=exprmain();

				state._fsp--;

				adaptor.AddChild(root_0, e.Tree);
				retval.result = e.result;

				}
				break;

			}
			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "expr"

	public class exprmain_return : ParserRuleReturnScope
	{
		public IDateRule result = null;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "exprmain"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:39:0: exprmain returns [IDateRule result = null] : ruleLeft= primary (ruleOp= setOperator ruleRight= primary )* ;
	private DateExpressionParser.exprmain_return exprmain(  )
	{
		DateExpressionParser.exprmain_return retval = new DateExpressionParser.exprmain_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		DateExpressionParser.primary_return ruleLeft = default(DateExpressionParser.primary_return);
		DateExpressionParser.setOperator_return ruleOp = default(DateExpressionParser.setOperator_return);
		DateExpressionParser.primary_return ruleRight = default(DateExpressionParser.primary_return);


		retval.result = null;
		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:41:4: (ruleLeft= primary (ruleOp= setOperator ruleRight= primary )* )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:41:4: ruleLeft= primary (ruleOp= setOperator ruleRight= primary )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			PushFollow(Follow._primary_in_exprmain196);
			ruleLeft=primary();

			state._fsp--;

			adaptor.AddChild(root_0, ruleLeft.Tree);
			retval.result = ruleLeft.result;
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:43:3: (ruleOp= setOperator ruleRight= primary )*
			for ( ; ; )
			{
				int alt4=2;
				int LA4_0 = input.LA(1);

				if ( (LA4_0==AND||LA4_0==LE||LA4_0==LT||LA4_0==OR) )
				{
					alt4=1;
				}


				switch ( alt4 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:44:4: ruleOp= setOperator ruleRight= primary
					{
					PushFollow(Follow._setOperator_in_exprmain211);
					ruleOp=setOperator();

					state._fsp--;

					root_0 = (CommonTree)adaptor.BecomeRoot(ruleOp.Tree, root_0);
					PushFollow(Follow._primary_in_exprmain216);
					ruleRight=primary();

					state._fsp--;

					adaptor.AddChild(root_0, ruleRight.Tree);
					retval.result = GetOperator(ruleOp.result, new IDateRule[]{retval.result, ruleRight.result});

					}
					break;

				default:
					goto loop4;
				}
			}

			loop4:
				;



			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "exprmain"

	public class primary_return : ParserRuleReturnScope
	{
		public IDateRule result;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "primary"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:49:0: primary returns [IDateRule result] : (rf= function |rd= datewild );
	private DateExpressionParser.primary_return primary(  )
	{
		DateExpressionParser.primary_return retval = new DateExpressionParser.primary_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		DateExpressionParser.function_return rf = default(DateExpressionParser.function_return);
		DateExpressionParser.datewild_return rd = default(DateExpressionParser.datewild_return);


		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:50:4: (rf= function |rd= datewild )
			int alt5=2;
			int LA5_0 = input.LA(1);

			if ( (LA5_0==NAME) )
			{
				alt5=1;
			}
			else if ( (LA5_0==POS_INT||LA5_0==STAR) )
			{
				alt5=2;
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 5, 0, input);

				throw nvae;
			}
			switch ( alt5 )
			{
			case 1:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:50:4: rf= function
				{
				root_0 = (CommonTree)adaptor.Nil();

				PushFollow(Follow._function_in_primary247);
				rf=function();

				state._fsp--;

				adaptor.AddChild(root_0, rf.Tree);
				retval.result = (rf!=null?rf.result:default(IDateRule));

				}
				break;
			case 2:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:51:4: rd= datewild
				{
				root_0 = (CommonTree)adaptor.Nil();

				PushFollow(Follow._datewild_in_primary256);
				rd=datewild();

				state._fsp--;

				adaptor.AddChild(root_0, rd.Tree);
				retval.result = (rd!=null?rd.result:default(IDateRule));

				}
				break;

			}
			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "primary"

	public class function_return : ParserRuleReturnScope
	{
		public IDateRule result;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "function"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:54:0: function returns [IDateRule result] : ( NAME ( LPAREN items= args RPAREN )? ) ;
	private DateExpressionParser.function_return function(  )
	{
		DateExpressionParser.function_return retval = new DateExpressionParser.function_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken NAME8=null;
		IToken LPAREN9=null;
		IToken RPAREN10=null;
		DateExpressionParser.args_return items = default(DateExpressionParser.args_return);

		CommonTree NAME8_tree=null;
		CommonTree LPAREN9_tree=null;
		CommonTree RPAREN10_tree=null;

		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:55:6: ( ( NAME ( LPAREN items= args RPAREN )? ) )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:55:6: ( NAME ( LPAREN items= args RPAREN )? )
			{
			root_0 = (CommonTree)adaptor.Nil();

			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:55:6: ( NAME ( LPAREN items= args RPAREN )? )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:55:7: NAME ( LPAREN items= args RPAREN )?
			{
			NAME8=(IToken)Match(input,NAME,Follow._NAME_in_function276); 
			NAME8_tree = (CommonTree)adaptor.Create(NAME8);
			adaptor.AddChild(root_0, NAME8_tree);

			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:55:12: ( LPAREN items= args RPAREN )?
			int alt6=2;
			int LA6_0 = input.LA(1);

			if ( (LA6_0==LPAREN) )
			{
				alt6=1;
			}
			switch ( alt6 )
			{
			case 1:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:55:13: LPAREN items= args RPAREN
				{
				LPAREN9=(IToken)Match(input,LPAREN,Follow._LPAREN_in_function279); 
				LPAREN9_tree = (CommonTree)adaptor.Create(LPAREN9);
				adaptor.AddChild(root_0, LPAREN9_tree);

				PushFollow(Follow._args_in_function283);
				items=args();

				state._fsp--;

				adaptor.AddChild(root_0, items.Tree);
				RPAREN10=(IToken)Match(input,RPAREN,Follow._RPAREN_in_function285); 
				RPAREN10_tree = (CommonTree)adaptor.Create(RPAREN10);
				adaptor.AddChild(root_0, RPAREN10_tree);


				}
				break;

			}


			}

			retval.result = GetRule(NAME8.Text, (items!=null?items.result:default(List<Object>)));

			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "function"

	public class args_return : ParserRuleReturnScope
	{
		public List<Object> result;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "args"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:59:0: args returns [List<Object> result] : valueFirst= arg ( COMMA value= arg )* ;
	private DateExpressionParser.args_return args(  )
	{
		DateExpressionParser.args_return retval = new DateExpressionParser.args_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken COMMA11=null;
		DateExpressionParser.arg_return valueFirst = default(DateExpressionParser.arg_return);
		DateExpressionParser.arg_return value = default(DateExpressionParser.arg_return);

		CommonTree COMMA11_tree=null;

		retval.result = new List<Object>();
		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:61:4: (valueFirst= arg ( COMMA value= arg )* )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:61:4: valueFirst= arg ( COMMA value= arg )*
			{
			root_0 = (CommonTree)adaptor.Nil();

			PushFollow(Follow._arg_in_args314);
			valueFirst=arg();

			state._fsp--;

			adaptor.AddChild(root_0, valueFirst.Tree);
			retval.result.Add((valueFirst!=null?valueFirst.result:default(Object)));
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:63:3: ( COMMA value= arg )*
			for ( ; ; )
			{
				int alt7=2;
				int LA7_0 = input.LA(1);

				if ( (LA7_0==COMMA) )
				{
					alt7=1;
				}


				switch ( alt7 )
				{
				case 1:
					// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:64:4: COMMA value= arg
					{
					COMMA11=(IToken)Match(input,COMMA,Follow._COMMA_in_args327); 
					COMMA11_tree = (CommonTree)adaptor.Create(COMMA11);
					root_0 = (CommonTree)adaptor.BecomeRoot(COMMA11_tree, root_0);

					PushFollow(Follow._arg_in_args332);
					value=arg();

					state._fsp--;

					adaptor.AddChild(root_0, value.Tree);
					retval.result.Add((value!=null?value.result:default(Object)));

					}
					break;

				default:
					goto loop7;
				}
			}

			loop7:
				;



			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "args"

	public class arg_return : ParserRuleReturnScope
	{
		public Object result = null;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "arg"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:69:0: arg returns [Object result = null] : (number= arg_number |rule= expr );
	private DateExpressionParser.arg_return arg(  )
	{
		DateExpressionParser.arg_return retval = new DateExpressionParser.arg_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		DateExpressionParser.arg_number_return number = default(DateExpressionParser.arg_number_return);
		DateExpressionParser.expr_return rule = default(DateExpressionParser.expr_return);


		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:70:4: (number= arg_number |rule= expr )
			int alt8=2;
			switch ( input.LA(1) )
			{
			case POS_INT:
				{
				int LA8_1 = input.LA(2);

				if ( (LA8_1==SLASH) )
				{
					alt8=2;
				}
				else if ( (LA8_1==COMMA||LA8_1==RPAREN) )
				{
					alt8=1;
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 8, 1, input);

					throw nvae;
				}
				}
				break;
			case NAME:
			case NOT:
			case STAR:
				{
				alt8=2;
				}
				break;
			case NEG_INT:
			case 22:
				{
				alt8=1;
				}
				break;
			default:
				{
					NoViableAltException nvae = new NoViableAltException("", 8, 0, input);

					throw nvae;
				}
			}

			switch ( alt8 )
			{
			case 1:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:70:4: number= arg_number
				{
				root_0 = (CommonTree)adaptor.Nil();

				PushFollow(Follow._arg_number_in_arg365);
				number=arg_number();

				state._fsp--;

				adaptor.AddChild(root_0, number.Tree);
				retval.result = (number!=null?number.result:default(int));

				}
				break;
			case 2:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:72:4: rule= expr
				{
				root_0 = (CommonTree)adaptor.Nil();

				PushFollow(Follow._expr_in_arg376);
				rule=expr();

				state._fsp--;

				adaptor.AddChild(root_0, rule.Tree);
				retval.result = (rule!=null?rule.result:default(IDateRule));

				}
				break;

			}
			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "arg"

	public class arg_number_return : ParserRuleReturnScope
	{
		public int result = 0;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "arg_number"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:76:0: arg_number returns [int result = 0] : number= ( '0' | POS_INT | NEG_INT ) ;
	private DateExpressionParser.arg_number_return arg_number(  )
	{
		DateExpressionParser.arg_number_return retval = new DateExpressionParser.arg_number_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken number=null;

		CommonTree number_tree=null;

		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:78:3: (number= ( '0' | POS_INT | NEG_INT ) )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:78:3: number= ( '0' | POS_INT | NEG_INT )
			{
			root_0 = (CommonTree)adaptor.Nil();

			number=(IToken)input.LT(1);
			if ( input.LA(1)==NEG_INT||input.LA(1)==POS_INT||input.LA(1)==22 )
			{
				input.Consume();
				adaptor.AddChild(root_0, (CommonTree)adaptor.Create(number));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				throw mse;
			}

			retval.result = int.Parse(number.Text);

			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "arg_number"

	public class datewild_return : ParserRuleReturnScope
	{
		public IDateRule result;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "datewild"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:83:0: datewild returns [IDateRule result] : (year= ( POS_INT | STAR ) SLASH month= ( POS_INT | STAR ) SLASH day= ( POS_INT | STAR ) |year= ( POS_INT | STAR ) SLASH month= ( POS_INT | STAR ) SLASH day= 'last' );
	private DateExpressionParser.datewild_return datewild(  )
	{
		DateExpressionParser.datewild_return retval = new DateExpressionParser.datewild_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken year=null;
		IToken month=null;
		IToken day=null;
		IToken SLASH12=null;
		IToken SLASH13=null;
		IToken SLASH14=null;
		IToken SLASH15=null;

		CommonTree year_tree=null;
		CommonTree month_tree=null;
		CommonTree day_tree=null;
		CommonTree SLASH12_tree=null;
		CommonTree SLASH13_tree=null;
		CommonTree SLASH14_tree=null;
		CommonTree SLASH15_tree=null;

		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:84:10: (year= ( POS_INT | STAR ) SLASH month= ( POS_INT | STAR ) SLASH day= ( POS_INT | STAR ) |year= ( POS_INT | STAR ) SLASH month= ( POS_INT | STAR ) SLASH day= 'last' )
			int alt9=2;
			int LA9_0 = input.LA(1);

			if ( (LA9_0==POS_INT||LA9_0==STAR) )
			{
				int LA9_1 = input.LA(2);

				if ( (LA9_1==SLASH) )
				{
					int LA9_2 = input.LA(3);

					if ( (LA9_2==POS_INT||LA9_2==STAR) )
					{
						int LA9_3 = input.LA(4);

						if ( (LA9_3==SLASH) )
						{
							int LA9_4 = input.LA(5);

							if ( (LA9_4==POS_INT||LA9_4==STAR) )
							{
								alt9=1;
							}
							else if ( (LA9_4==23) )
							{
								alt9=2;
							}
							else
							{
								NoViableAltException nvae = new NoViableAltException("", 9, 4, input);

								throw nvae;
							}
						}
						else
						{
							NoViableAltException nvae = new NoViableAltException("", 9, 3, input);

							throw nvae;
						}
					}
					else
					{
						NoViableAltException nvae = new NoViableAltException("", 9, 2, input);

						throw nvae;
					}
				}
				else
				{
					NoViableAltException nvae = new NoViableAltException("", 9, 1, input);

					throw nvae;
				}
			}
			else
			{
				NoViableAltException nvae = new NoViableAltException("", 9, 0, input);

				throw nvae;
			}
			switch ( alt9 )
			{
			case 1:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:84:10: year= ( POS_INT | STAR ) SLASH month= ( POS_INT | STAR ) SLASH day= ( POS_INT | STAR )
				{
				root_0 = (CommonTree)adaptor.Nil();

				year=(IToken)input.LT(1);
				if ( input.LA(1)==POS_INT||input.LA(1)==STAR )
				{
					input.Consume();
					adaptor.AddChild(root_0, (CommonTree)adaptor.Create(year));
					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					throw mse;
				}

				SLASH12=(IToken)Match(input,SLASH,Follow._SLASH_in_datewild447); 
				SLASH12_tree = (CommonTree)adaptor.Create(SLASH12);
				adaptor.AddChild(root_0, SLASH12_tree);

				month=(IToken)input.LT(1);
				if ( input.LA(1)==POS_INT||input.LA(1)==STAR )
				{
					input.Consume();
					adaptor.AddChild(root_0, (CommonTree)adaptor.Create(month));
					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					throw mse;
				}

				SLASH13=(IToken)Match(input,SLASH,Follow._SLASH_in_datewild459); 
				SLASH13_tree = (CommonTree)adaptor.Create(SLASH13);
				adaptor.AddChild(root_0, SLASH13_tree);

				day=(IToken)input.LT(1);
				if ( input.LA(1)==POS_INT||input.LA(1)==STAR )
				{
					input.Consume();
					adaptor.AddChild(root_0, (CommonTree)adaptor.Create(day));
					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					throw mse;
				}

				retval.result = new DateRuleWildcard(IntWild.Parse(year.Text),IntWild.Parse(month.Text),IntWild.Parse(day.Text));

				}
				break;
			case 2:
				// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:86:5: year= ( POS_INT | STAR ) SLASH month= ( POS_INT | STAR ) SLASH day= 'last'
				{
				root_0 = (CommonTree)adaptor.Nil();

				year=(IToken)input.LT(1);
				if ( input.LA(1)==POS_INT||input.LA(1)==STAR )
				{
					input.Consume();
					adaptor.AddChild(root_0, (CommonTree)adaptor.Create(year));
					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					throw mse;
				}

				SLASH14=(IToken)Match(input,SLASH,Follow._SLASH_in_datewild490); 
				SLASH14_tree = (CommonTree)adaptor.Create(SLASH14);
				adaptor.AddChild(root_0, SLASH14_tree);

				month=(IToken)input.LT(1);
				if ( input.LA(1)==POS_INT||input.LA(1)==STAR )
				{
					input.Consume();
					adaptor.AddChild(root_0, (CommonTree)adaptor.Create(month));
					state.errorRecovery=false;
				}
				else
				{
					MismatchedSetException mse = new MismatchedSetException(null,input);
					throw mse;
				}

				SLASH15=(IToken)Match(input,SLASH,Follow._SLASH_in_datewild502); 
				SLASH15_tree = (CommonTree)adaptor.Create(SLASH15);
				adaptor.AddChild(root_0, SLASH15_tree);

				day=(IToken)Match(input,23,Follow._23_in_datewild506); 
				day_tree = (CommonTree)adaptor.Create(day);
				adaptor.AddChild(root_0, day_tree);

				retval.result = new DateRuleWildcard(IntWild.Parse(year.Text),IntWild.Parse(month.Text));

				}
				break;

			}
			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "datewild"

	public class setOperator_return : ParserRuleReturnScope
	{
		public String result;
		internal CommonTree tree;
		public override object Tree { get { return tree; } }
	}

	// $ANTLR start "setOperator"
	// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:90:0: setOperator returns [String result] : o= ( OR | AND | LT | LE ) ;
	private DateExpressionParser.setOperator_return setOperator(  )
	{
		DateExpressionParser.setOperator_return retval = new DateExpressionParser.setOperator_return();
		retval.start = input.LT(1);

		CommonTree root_0 = null;

		IToken o=null;

		CommonTree o_tree=null;

		try
		{
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:91:10: (o= ( OR | AND | LT | LE ) )
			// C:\\Workspace\\Development\\Subversion\\Dates\\DateServer\\src\\DateLibrary\\grammar\\output\\DateExpression.g:91:10: o= ( OR | AND | LT | LE )
			{
			root_0 = (CommonTree)adaptor.Nil();

			o=(IToken)input.LT(1);
			if ( input.LA(1)==AND||input.LA(1)==LE||input.LA(1)==LT||input.LA(1)==OR )
			{
				input.Consume();
				adaptor.AddChild(root_0, (CommonTree)adaptor.Create(o));
				state.errorRecovery=false;
			}
			else
			{
				MismatchedSetException mse = new MismatchedSetException(null,input);
				throw mse;
			}

			retval.result = o.Text;

			}

			retval.stop = input.LT(-1);

			retval.tree = (CommonTree)adaptor.RulePostProcessing(root_0);
			adaptor.SetTokenBoundaries(retval.tree, retval.start, retval.stop);

		}
		catch ( RecognitionException re )
		{
			ReportError(re);
			Recover(input,re);
		retval.tree = (CommonTree)adaptor.ErrorNode(input, retval.start, input.LT(-1), re);

		}
		finally
		{
		}
		return retval;
	}
	// $ANTLR end "setOperator"
	#endregion Rules


	#region Follow sets
	static class Follow
	{
		public static readonly BitSet _assignment_in_statement68 = new BitSet(new ulong[]{0x129000UL});
		public static readonly BitSet _expr_in_statement81 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NAME_in_assignment110 = new BitSet(new ulong[]{0x80UL});
		public static readonly BitSet _EQUALS_in_assignment112 = new BitSet(new ulong[]{0x129000UL});
		public static readonly BitSet _expr_in_assignment116 = new BitSet(new ulong[]{0x4000UL});
		public static readonly BitSet _NEWLINE_in_assignment118 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NOT_in_expr147 = new BitSet(new ulong[]{0x202UL});
		public static readonly BitSet _LPAREN_in_expr150 = new BitSet(new ulong[]{0x129000UL});
		public static readonly BitSet _exprmain_in_expr154 = new BitSet(new ulong[]{0x40000UL});
		public static readonly BitSet _RPAREN_in_expr156 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _exprmain_in_expr170 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _primary_in_exprmain196 = new BitSet(new ulong[]{0x10512UL});
		public static readonly BitSet _setOperator_in_exprmain211 = new BitSet(new ulong[]{0x129000UL});
		public static readonly BitSet _primary_in_exprmain216 = new BitSet(new ulong[]{0x10512UL});
		public static readonly BitSet _function_in_primary247 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _datewild_in_primary256 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _NAME_in_function276 = new BitSet(new ulong[]{0x202UL});
		public static readonly BitSet _LPAREN_in_function279 = new BitSet(new ulong[]{0x52B000UL});
		public static readonly BitSet _args_in_function283 = new BitSet(new ulong[]{0x40000UL});
		public static readonly BitSet _RPAREN_in_function285 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _arg_in_args314 = new BitSet(new ulong[]{0x22UL});
		public static readonly BitSet _COMMA_in_args327 = new BitSet(new ulong[]{0x52B000UL});
		public static readonly BitSet _arg_in_args332 = new BitSet(new ulong[]{0x22UL});
		public static readonly BitSet _arg_number_in_arg365 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _expr_in_arg376 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_arg_number400 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_datewild439 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _SLASH_in_datewild447 = new BitSet(new ulong[]{0x120000UL});
		public static readonly BitSet _set_in_datewild451 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _SLASH_in_datewild459 = new BitSet(new ulong[]{0x120000UL});
		public static readonly BitSet _set_in_datewild463 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_datewild482 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _SLASH_in_datewild490 = new BitSet(new ulong[]{0x120000UL});
		public static readonly BitSet _set_in_datewild494 = new BitSet(new ulong[]{0x80000UL});
		public static readonly BitSet _SLASH_in_datewild502 = new BitSet(new ulong[]{0x800000UL});
		public static readonly BitSet _23_in_datewild506 = new BitSet(new ulong[]{0x2UL});
		public static readonly BitSet _set_in_setOperator534 = new BitSet(new ulong[]{0x2UL});

	}
	#endregion Follow sets
}

} // namespace  drules.dates.library.grammar 
