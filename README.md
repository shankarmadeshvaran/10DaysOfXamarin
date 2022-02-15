# 10DayOfXamarin
10DaysOfXamarin is a repository where I keep the projects done by learning from [10daysofxamarin](https://10daysofxamarin.blog)

## Introduction to Xamarin Forms

Xamarin is an application development platform that lets you build applications for many platforms with a single shared code base.

Xamarin.Forms exposes a complete cross-platform UI toolkit for .NET developers. Build fully native Android, iOS, and Universal Windows Platform apps using C# in Visual Studio.

## Challenge

I will create modified and improvised projects on top of the [10DaysOfXamarin projects](https://10daysofxamarin.blog). 

You can follow [#10DaysOfXamarin](https://twitter.com/hashtag/10DaysOfXamarin) on twitter for latest updates!

## All Challenges From Day-0 to Day-10

**Day 0**
- Get your computer ready for [Xamarin development](https://10daysofxamarin.blog/2019/03/07/day-0/)

**Day 01**
- Create an app that requests the user’s name through an Entry and, on the click of a button, displays -on a label- a greeting to that user. 
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day01OfXamarin)

**Day 02**
- Create an interface that allows users to enter a title and the content for a new experience. This interface should also display a button for the user to save the experience (the actual functionality won’t yet be implemented) and another button to cancel the creation of the new experience.
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day02OfXamarin)

**Day 03**
- Add the [SQLite-net-PCL NuGet package](https://github.com/praeclarum/sqlite-net) to all projects and make sure that each platform creates the database file in a specific path. Each platform then should pass the platform-specific file path to the shared .NET Standard library project, for its usage with shared code.
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day03OfXamarin)

**Day 04**
- Create a class that represents the table that holds the experiences, along with some attributes that help model this table when it is created. 
- These attributes include those limiting how long a title can be and setting the primary key.After this, you have to create an instance of this class and insert it into the table.
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day04OfXamarin)

**Day 05** 
- Create a new ExpriencesPage page that contains a ListView. Make this new page the MainPage from the App’s constructor. Make sure you fully implement navigation to the page where users can insert new experiences. The navigation must happen at the click of an “add” or “new” button, I recommend you use a ToolbarItem type of button, but a standard button could do. 
- Create a new connection to the same SQLite database that we used yesterday, this time to read the Experience table. Once the items in the table exist on a local variable, use that variable to populate a ListView that you also need to define.
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day05OfXamarin)

**Day 06**
- Accessing the GPS requires the user to grant the permissions. Asking for permissions can be particularly tricky on Android, so you use a [handy plugin](https://github.com/jamesmontemagno/PermissionsPlugin) that makes things easier.
- Once you are confident that the user granted the required permissions, you can request the current location and store the latitude and longitude in a couple of variables. That couple of variables are used tomorrow to get the nearby venues.
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day06OfXamarin)

**Day 07**
- Our goal today is to use the public Foursquare API to find venues that exist close to the coordinates that we have retrieved. You need to familiarize yourself with the Foursquare search API, create an account so you can create an app that has access to that API, and use the API to search for nearby venues.
- Users will be able to select the venue from a list, which has to be assigned to the Experience and saved along with the title and experience into the SQLite table.
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day07OfXamarin)

**Day 08,Day 09 and Day 10**
- To implement the MVVM architectural pattern, we start by using the INotifyPropertyChanged interface in a way that helps us clean some of the code. 
- [**Completed Project and Source Code**](https://github.com/shankarmadeshvaran/10DaysOfXamarin/tree/master/Day8To10OfXamarin)

## Issues
If you came to know any issues in the sample project that I have shared fell free to crate an issue or contact me via 
[Twitter](https://twitter.com/Shankar__am). I'll responds to the queries as I came across. 

## More Updates
I'll constanly implement lot more features whenever something popup in my mind.Follow me on [Twitter](https://twitter.com/devinmaking) or [LinkedIn](https://www.linkedin.com/in/shankar-mathesh) to get the latest update about features, code and more. Consider star the repo if you like it. 

## References
- [Introduction to Xamarin Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/)
- [10 Days Of Xamarin Development](https://10daysofxamarin.blog/)
