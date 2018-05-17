using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using UnityEngine;

public class MediaPlayer :  IDisposable
{
    public bool Repeat { get; set; }

    // The most important DLL ever since this is what will allow us to send commands to play, stop, etc.
    [DllImport("winmm.dll")]
    private static extern long mciSendString(string strCommand,
        StringBuilder strReturn, int iRetrunLength, IntPtr hwndCallback);

    void Start()
    {
        Repeat = false;
    }

    /* Media Player Functions. */

    public MediaPlayer(string fileName)
    {
        const string FORMAT = @"open ""{0}"" type mpegvideo alias MediaFile";
        string command = String.Format(FORMAT, fileName);
        mciSendString(command, null, 0, IntPtr.Zero);
    }

    public void Play()
    {
        string command = "play MediaFile";
        if (Repeat) command += " REPEAT";
        mciSendString(command, null, 0, IntPtr.Zero);
    }

    // TO-DO: Figure out why the below 'NOTE' happens. Has something to do with the winmm.dll.
    // NOTE: The stop command exhibits the same behavior as the Pause command. Not quite sure why.
    public void Stop()
    {
        string command = "stop MediaFile";
        mciSendString(command, null, 0, IntPtr.Zero);
    }

    // Exists after implementing the IDispose interface.
    // Closes the opened media file.
    public void Dispose()
    {
        string command = "close MediaFile";
        mciSendString(command, null, 0, IntPtr.Zero);
    }

    /* End Media Player Functions */
}