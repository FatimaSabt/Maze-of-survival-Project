using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioSource _sfxSource;

    [Header("Audio Clips")]
    [SerializeField] public AudioClip _backgroundMusic;
    [SerializeField] public AudioClip _playerFootsteps;
    [SerializeField] public AudioClip _playerJump;
    [SerializeField] public AudioClip _playerLand;
    [SerializeField] public AudioClip _playerRun;
    [SerializeField] public AudioClip _coinCollect;
    [SerializeField] public AudioClip _keyCollect;
    [SerializeField] public AudioClip _doorClosed;
    [SerializeField] public AudioClip _exit;

    [Header("Traps")]
    [SerializeField] public AudioClip _arrowTrap;
    [SerializeField] public AudioClip _steam;
    [SerializeField] public AudioClip _fireTrap;
    [SerializeField] public AudioClip _spikeTrap;

    private bool isMusicOn = true;
    private bool isSoundOn = true;

    void Start()
    {
        isMusicOn = PlayerInventory.isMusicOn;
        isSoundOn = PlayerInventory.isSoundOn;

        if (isMusicOn)
        {
            PlayMusic(_backgroundMusic);
        }
        else
        {
            StopMusic();
        }

        if (!isSoundOn)
        {
            StopSFX();
        }
    }

    public void SetMusicState(bool state)
    {
        isMusicOn = state;

        if (isMusicOn)
        {
            if (!_musicSource.isPlaying)
            {
                PlayMusic(_backgroundMusic);
            }
        }
        else
        {
            StopMusic();
        }
    }

    public void SetSoundState(bool state)
    {
        isSoundOn = state;

        if (!isSoundOn)
        {
            StopSFX();
        }
    }

    public void PlayMusic(AudioClip clip)
    {
        if (clip == null || _musicSource == null)
        {
            return;
        }

        _musicSource.clip = clip;
        _musicSource.loop = true;
        _musicSource.Play();
    }

    public void StopMusic()
    {
        if (_musicSource != null)
        {
            _musicSource.Stop();
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (!isSoundOn)
        {
            return;
        }

        if (clip == null || _sfxSource == null)
        {
            return;
        }

        _sfxSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        if (_sfxSource != null)
        {
            _sfxSource.Stop();
        }
    }
}