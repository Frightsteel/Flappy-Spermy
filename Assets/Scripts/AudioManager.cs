using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip mainTheme;
    public AudioClip[] gameOverSounds;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void GameOverSoundPlay()
    {
        audioSource.Stop();
        audioSource.PlayOneShot(gameOverSounds[Random.Range(0,2)]);
    }

    public void MainThemePlay()
    {
        audioSource.PlayOneShot(mainTheme);
    }

    public void MainThemePause()
    {
        audioSource.Pause();
    }

    public void MainThemeUnPause()
    {
        audioSource.UnPause();

    }
}
