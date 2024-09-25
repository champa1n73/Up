using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIControl : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject soundSettingPanel;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] InputActionAsset actions;

    [Header("Properties")]
    [SerializeField] float delayTimePlayAgain = 1f;
    
    public GameObject GetGameOverPanel()
    {
        return gameOverPanel;
    }

    void Awake()
    {
        gameOverPanel.SetActive(false);
        soundSettingPanel.SetActive(false);
    }

    void Start()
    {
        BoxControl.instance.SetSoundSettingPanel(soundSettingPanel);
        musicSlider.value = AudioManager.instance.GetMusicVolume();
        sfxSlider.value = AudioManager.instance.GetSFXVolume();
    }

    IEnumerator WaitAndLoad(string sceneName, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(sceneName);
    }

    public void PlayAgain()
    {
        StartCoroutine(WaitAndLoad("Play Again Scene", delayTimePlayAgain));
        BoxCollisionManager.towerHeight = 1.64f;
    }

    public void OpenVolumeSetting()
    {
        soundSettingPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseVolumeSetting()
    {
        soundSettingPanel.SetActive(false);
        Time.timeScale = 1;
    }

    public bool SoundSettingIsActive()
    {
        return soundSettingPanel.activeSelf;
    }

    public void MusicVolume()
    {
        AudioManager.instance.SetMusicVolume(musicSlider.value);
    }

    public void SFXVolume()
    {
        AudioManager.instance.SetSFXVolume(sfxSlider.value);
    }
}
