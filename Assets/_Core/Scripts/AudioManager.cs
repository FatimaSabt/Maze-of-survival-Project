using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField]  AudioSource _musicSource;
    [SerializeField]  AudioSource _sfxSource;

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
    [Header("Arrow Trap")]
    [SerializeField] public AudioClip _arrowTrap;

    [Header("Fire Jet Trap")]
    [SerializeField] public AudioClip _steam;
    [SerializeField] public AudioClip _fireTrap;

    [Header("Spike Trap")]
    [SerializeField] public AudioClip _spikeTrap;
    
    private void Start()
    {
        _musicSource.clip = _backgroundMusic;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

    public void StopSFX()
    {
        _sfxSource.Stop();
    }

}
