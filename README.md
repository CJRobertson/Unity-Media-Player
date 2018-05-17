# Unity-Media-Player
A media player made in Unity3D that uses the Windows Multimedia API.
<br>
# About
This is an extremely basic media player built in Unity3D utilizing the Windows Multimedia API (https://msdn.microsoft.com/en-us/library/windows/desktop/dd743883(v=vs.85).aspx). The media player is currently setup as a music player, but in the future will hopefully support video playback as well. 

# How-To-Use
The music player currently requires a hardcoded path to a specific audio file. For ease of use, there is a public string variable in the 'UI' script named 'Chosen Music File' that can be edited in the inspector. 
<br><br>
- You can find this public variable by clicking on the 'MediaPlayerUI_Canvas' gameobject-->Inspector-->'UI' script. The path you provide should be formatted similiarly to this example: *C:\\\Users\\\JohnSmith\\\Music\\\HelloWorld.mp3*
<br><br>


# Known Issues
- Running the 'stop' MCI command from the Windows Multimedia API exhibits the same behavior as the 'pause' command. Not too sure why. A hack was implemented to get around this, but its not ideal to keep it. 
