using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Settings : MonoBehaviour
{
    [Header("Audio Settings")]
    public static bool isMusicOn = true;
    public static bool isSoundOn = true;

    [Header("Display Settings")]
    public static bool isFullScreen = true;
    public static float sensitivity = 15.0f;

    [Header("Music Buttons")]
    public Button musicOnButton;
    public Button musicOffButton;

    [Header("Sound Buttons")]
    public Button soundOnButton;
    public Button soundOffButton;

    [Header("Fullscreen Buttons")]
    public Button fullScreenOnButton;
    public Button fullScreenOffButton;

    [Header("Sensitivity Input")]
    public TMP_InputField sensitivityInputField;

    private AudioManager audioManager;

    void Start()
    {
        GameObject audioObject = GameObject.FindGameObjectWithTag("Audio");

        if (audioObject != null)
        {
            audioManager = audioObject.GetComponent<AudioManager>();
        }

        musicOnButton.onClick.AddListener(ToggleMusic);
        musicOffButton.onClick.AddListener(ToggleMusic);

        soundOnButton.onClick.AddListener(ToggleSound);
        soundOffButton.onClick.AddListener(ToggleSound);

        fullScreenOnButton.onClick.AddListener(ToggleFullScreen);
        fullScreenOffButton.onClick.AddListener(ToggleFullScreen);

        sensitivityInputField.onValidateInput += ValidateSensitivityInput;
        sensitivityInputField.onEndEdit.AddListener(UpdateSensitivityFromInput);

        sensitivityInputField.text = sensitivity.ToString();

        Screen.fullScreen = isFullScreen;

        if (audioManager != null)
        {
            audioManager.SetMusicState(isMusicOn);
            audioManager.SetSoundState(isSoundOn);
        }

        UpdateSettingsUI();
    }

    private char ValidateSensitivityInput(string text, int charIndex, char addedChar)
    {
        if (char.IsDigit(addedChar))
        {
            return addedChar;
        }

        if (addedChar == '.' && !text.Contains("."))
        {
            return addedChar;
        }

        return '\0';
    }

   private void UpdateSensitivityFromInput(string value)
{
    if (float.TryParse(value, out float newSensitivity))
    {
        sensitivity = newSensitivity;
        PlayerInventory.sensitivity = sensitivity;
        FirstPersonCamera.mouseSensitivity = sensitivity;

        Debug.Log("Sensitivity is now " + sensitivity);
    }
    else
    {
        sensitivityInputField.text = sensitivity.ToString();
    }
}

    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        PlayerInventory.isMusicOn = isMusicOn;

        if (audioManager != null)
        {
            audioManager.SetMusicState(isMusicOn);
        }

        UpdateSettingsUI();
    }

    public void ToggleSound()
    {
        isSoundOn = !isSoundOn;
        PlayerInventory.isSoundOn = isSoundOn;

        if (audioManager != null)
        {
            audioManager.SetSoundState(isSoundOn);
        }

        UpdateSettingsUI();
    }

    public void ToggleFullScreen()
    {
        isFullScreen = !isFullScreen;
        PlayerInventory.isFullScreen = isFullScreen;

        Screen.fullScreen = isFullScreen;

        UpdateSettingsUI();
    }

    private void UpdateSettingsUI()
    {
        musicOnButton.gameObject.SetActive(!isMusicOn);
        musicOffButton.gameObject.SetActive(isMusicOn);

        soundOnButton.gameObject.SetActive(!isSoundOn);
        soundOffButton.gameObject.SetActive(isSoundOn);

        fullScreenOnButton.gameObject.SetActive(!isFullScreen);
        fullScreenOffButton.gameObject.SetActive(isFullScreen);
    }
}