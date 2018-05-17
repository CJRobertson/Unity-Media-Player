using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private MediaPlayer mp3Player;
    public Button openButton, playButton, stopButton;
    public Toggle repeatToggle;

    [Tooltip("The hardcoded path to the sound file wanting to be played. NOTE: Will only play one song. Multi-song chooser support coming soon.")]
    public string chosenMusicFile = "C:\\Users\\JohnSmith\\Music\\TestAudio.mp3";

    void Start()
    {
        // Calls the respective 'OnClick' method when you click a Button.
        openButton.onClick.AddListener(OpenOnClick);
        playButton.onClick.AddListener(PlayOnClick);
        stopButton.onClick.AddListener(StopOnClick);

        // Calls the required delegate to toggle the repeatToggle on/off.
        repeatToggle.onValueChanged.AddListener(delegate {ToggleValueChanged(repeatToggle);});
    }

    // Repeat Toggle Method
    void ToggleValueChanged(Toggle change)
    {
        Debug.Log("Repeat Toggled:");

        if (mp3Player != null)
        {
            Debug.Log("Repeat Toggled: " + repeatToggle.isOn);
            mp3Player.Repeat = repeatToggle.isOn;
        }
    }

    /* Button Methods */

    void OpenOnClick()
    {
        Debug.Log("Open Button Clicked!");

        if (mp3Player != null)
        {
            mp3Player.Dispose();
        }

        mp3Player = new MediaPlayer(chosenMusicFile);
    }

    void PlayOnClick()
    {
        Debug.Log("Play Button Clicked!");

        if (mp3Player != null)
        {
            mp3Player.Play();
        }
    }

    void StopOnClick()
    {
        Debug.Log("Stop Button Clicked!");

        if (mp3Player != null)
        {
            mp3Player.Stop();

            /* NOTE: The stop functionality for some reason pauses the music rather than stopping and resetting the play time to the beginning. To hack around this, after stopping we'll dispose of the media player 
             * and then immediately recreate it. This hack only works because this example project currently only supports hardcoded paths to one specific song. */
            mp3Player.Dispose();
            mp3Player = new MediaPlayer(chosenMusicFile);
        }
    }

    /* End Button Methods */
}
