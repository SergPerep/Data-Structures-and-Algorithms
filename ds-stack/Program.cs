using ds_stack.Services;

var input = "[]()({[][][})";

var balancedBracketValidator = new BalancedBracketValidator();

balancedBracketValidator.Validate(input);