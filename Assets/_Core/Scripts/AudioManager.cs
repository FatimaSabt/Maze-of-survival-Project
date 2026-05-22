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
    [SerializeField] public AudioClip _arrowTrap;

    private void Start()
    {
        _musicSource.clip = _backgroundMusic;
        _musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        _sfxSource.PlayOneShot(clip);
    }

}
