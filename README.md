# RSSActivityProject
A simple RSS activity project as a proof of quality submission.
Included is the Visual Studio Project which reads in a txt file dictionary of RSS feeds, keyed by company and valued by url. Then after parsing and storing as a custom class, the program gets each feeds latest post, and creates a new dictionary in the class with is keyed by company and valued by date. Finally the program filters the companies by the inputed date compared to their last post and prints the results.

The project also includes unit tests which test the following
- File Does not Exist - Passes
- File is Empty - Passes
- File Read Succeeds - Passes
- Dictionary Creation Succeeds - Passes
- getFeed - Passes
- Overall Success - Passses [NEEDS TO HAVE EXPECTED VALUE UPDATED IF A NEW POST OUTDATES THE CURRENT ONES]

The dependency packages are not included in repo due to file number and the fact that they are all included in .NET framework by default.
Dependencies are:
- MSTest.TestAdapter
- MSTest.TesFramework
- System.ServiceModel.Primitives
