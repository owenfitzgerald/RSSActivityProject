# RSSActivityProject
A simple RSS activity project as a prrof of quality submission.
Included is the Visual Studio Project which reads in a txt file dictionary of RSS feeds, keyed by company and valued by url. Then after parsing and storing as a custom class, the program gets each feeds latest post, and creates a new dictionary in the class with is keyed by company and valued by date. Finally the program filters the companies by the inputed date compared to their last post and prints the results.

The project also includes unit tests which test the following
File Does not Exist - Passes
File is Empty - Passes
File Read Succeeds - Passes
Dictionary Creation Succeeds - Passes
