# 08th To 10th DayOfXamarin
In this project I have learn learned and implemented how to make the code more clean by using the MVVM Architecture.

## MVVM Architecture
The Model-View-ViewModel (MVVM) pattern helps to cleanly separate the business and presentation logic of an application from its user interface (UI). Maintaining a clean separation between application logic and the UI helps to address numerous development issues and can make an application easier to test, maintain, and evolve. It can also greatly improve code re-use opportunities and allows developers and UI designers to more easily collaborate when developing their respective parts of an app.
There are three core components in the MVVM pattern: the model, the view, and the view model. Each serves a distinct purpose.

<p align="center">
<img src="https://github.com/shankarmadeshvaran/Xamarin_MVVM/blob/master/ScreenShots/mvvm.png" width="70%" height="70%"/> 
</p>

## Work Done on this Project
- Implemented the MVVM architectural pattern, we start by using the INotifyPropertyChanged interface in a way that helps us clean some of the code. 
- This interface removes the necessity to get and set values to and from the XAML pages into C# objects. Instead, Data Binding does the work.
- We have to created an appropriate view model, one ICommand property for each of the buttons and toolbar items that require them. 
- Added one Command for each of these events to the corresponding view model and bind that command to the appropriate element.
- We have implemented ObservableCollection<T> class ,which implies changes to the collection are observed. hence, if by using this we have binded our view, the view can react to those changes.

## ScreenShots 

<p align="center">
<img src="https://github.com/shankarmadeshvaran/10DaysOfXamarin/blob/master/Day8To10OfXamarin/ScreenShots/Screen1.png" width="20%" height="25%"/>
<img src="https://github.com/shankarmadeshvaran/10DaysOfXamarin/blob/master/Day8To10OfXamarin/ScreenShots/Screen2.png" width="20%" height="25%"/>
<img src="https://github.com/shankarmadeshvaran/10DaysOfXamarin/blob/master/Day8To10OfXamarin/ScreenShots/Screen3.png" width="20%" height="25%"/>
</p>

<p align="center">
<img src="https://github.com/shankarmadeshvaran/10DaysOfXamarin/blob/master/Day8To10OfXamarin/ScreenShots/Screen4.png" width="20%" height="25%"/>
<img src="https://github.com/shankarmadeshvaran/10DaysOfXamarin/blob/master/Day8To10OfXamarin/ScreenShots/Screen5.png" width="20%" height="25%"/>
<img src="https://github.com/shankarmadeshvaran/10DaysOfXamarin/blob/master/Day8To10OfXamarin/ScreenShots/Screen6.png" width="20%" height="25%"/>
</p>

## Issues
If you came to know any issues in the sample project that I have shared, fell free to create an issue or contact me via 
[Twitter](https://twitter.com/Shankar__am). I'll responds to the queries as soon as I came across. 

## More Updates
I'll constanly implement lot more features whenever something popup in my mind.Follow me on [Twitter](https://twitter.com/Shankar__am) or [LinkedIn](https://www.linkedin.com/in/shankar-mathesh) to get the latest update about features, code and more. Consider star the repo if you like it. 

## References
- [Day 08 Of Xamarin Development](https://10daysofxamarin.blog/2019/03/07/day-8/)
- [Day 09 Of Xamarin Development](https://10daysofxamarin.blog/2019/03/07/day-9/)
- [Day 09 Of Xamarin Development](https://10daysofxamarin.blog/2019/03/07/day-10/)
