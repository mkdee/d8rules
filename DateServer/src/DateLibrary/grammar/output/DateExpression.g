grammar DateExpression;

options
{
	output=AST;			// we want to create ASTs	
	ASTLabelType=CommonTree;
	language=CSharp3;
}

@header
{
	using System;
	using gs.gsjbw.dates.library;
	using gs.gsjbw.dates.library.rules;
	using gs.gsjbw.dates.library.grammar;	
}

@lexer::namespace { gs.gsjbw.dates.library.grammar }
@parser::namespace { gs.gsjbw.dates.library.grammar }

statement returns [IDateRule result = null]
     :	assignment*		
     	rule=expr
     	{$result = $rule.result;}
     ;	
	
assignment
     :	NAME EQUALS rule=expr NEWLINE		
		{AddRule($NAME.Text, rule.result);}
     ;

expr returns [IDateRule result = null]	
	:   (NOT (LPAREN eNot=exprmain RPAREN)?)
		{$result = new DateRuleNot(eNot.result);}
	|	e=exprmain
		{$result = e.result;}
	;

exprmain returns [IDateRule result = null]
@init {$result = null;}
	:	ruleLeft=primary
		{$result = ruleLeft.result;}
		(
			ruleOp=setOperator^ ruleRight=primary
			{$result = GetOperator(ruleOp.result, new IDateRule[]{$result, ruleRight.result});}
		)*
     ;

primary returns [IDateRule result]
	:	rf=function {$result = $rf.result;}
	|	rd=datewild {$result = $rd.result;}
	;

function returns [IDateRule result]
	:   (NAME (LPAREN items=args RPAREN)?)
		{$result = GetRule($NAME.Text, $items.result);}
	;

args returns [List<Object> result]
@init {$result = new List<Object>();}
	:	valueFirst=arg
		{$result.Add($valueFirst.result);}
		(
			COMMA^ value=arg
			{$result.Add($value.result);}
		)*				
	;	

arg returns [Object result = null] 
	:	number=arg_number
		{$result = $number.result;}
	|	rule=expr
		{$result = $rule.result;}
	;

arg_number returns [int result = 0]
	:	
		number=('0' | POS_INT | NEG_INT)
		{$result = int.Parse($number.Text);}	
	;

// DateExpression specifically for dates and wildcarded dates
datewild returns [IDateRule result]
	:       year=(POS_INT | STAR) SLASH month=(POS_INT | STAR) SLASH day=(POS_INT | STAR)
			{$result = new DateRuleWildcard(IntWild.Parse($year.Text),IntWild.Parse($month.Text),IntWild.Parse($day.Text));}
	|		year=(POS_INT | STAR) SLASH month=(POS_INT | STAR) SLASH day='last'
			{$result = new DateRuleWildcard(IntWild.Parse($year.Text),IntWild.Parse($month.Text));}
	;

setOperator returns [String result]
	:       o=(OR | AND | LT | LE)
			{$result = $o.Text;}
	;

OR		:	'|';
AND		:	'&';
LT		:	'<';
LE		:	'<' EQUALS;
EQUALS	:	'=';

MINUS	:	'-';
STAR    :   '*';
SLASH   :   '/';

NOT		:	'!';

NAME	:	'a'..'z' ('a'..'z' | DELIMITER)*;

NEG_INT :	(MINUS POS_INT);
POS_INT	:	'1'..'9' '0'..'9'*;

DELIMITER	: ('.' | '_');

LPAREN	:	'(';
RPAREN	:	')';
COMMA	:	',';

NEWLINE	:	('\r'|'\n')+;	
WS		:  	(' '|'\t')+ {$channel=HIDDEN;};