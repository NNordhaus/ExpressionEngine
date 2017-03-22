# ExpressionEvaluator
Small tool to evaluate boolean expressions.  Used TDD to hammer it out.

Had a problem which I described in a Stack exchange question here: http://softwareengineering.stackexchange.com/questions/344553/need-to-match-database-tags-using-a-boolean-expression

I decided to make a simple boolean expression tool. So far it only handles && and || operators. I assumed I would need to add  parentheses in the next step, for more complex equations, e.g. "For-Sale && Florida && (Car || Motorcycle || Truck)" but as it turns out, since I evaluate from left to right, the above expression works without the parens.  If you don't believe me, run the tests. I guess that's the beauty of Test Driven Development, the emergent solution got there before I did.  In the future, more complex expressions may require the addition of parens, but for now, it just works.

# How to use:

Instantiate the evaluator, populate the Tags list with a collection of strings, the existence of a string in this list means its usage in an expression will evaluate to true, else, false. Then pass your expression to the Evaluate function.
