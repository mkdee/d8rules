# d8rules
D8rules (pronounced DateRules) is a library and DSL for defining, working with and generating
sets of infinite dates.   Perfect for schedules, public holidays etc.

Schedules and public holidays involve recuring dates.   D8Rules is a DSL to allow individual
schedules or infinite date sets to be quickly defined.

For example, all Thursdays could be defined as "Thu" and the 15th of the month as "\*/\*/15".   This
then allows the sets to be easily combined: "Thu & \*/\*/15" yields an infinite set of Thursdays that
also fall on the 15th of the month.


Programing:
While the base of the DSL exists, at it's core is a pluggable framework that allows custom functions to
be defined.   This could be extended to support dates relative to lunar cycles. 
