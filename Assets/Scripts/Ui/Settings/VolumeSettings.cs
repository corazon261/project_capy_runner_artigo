using Manager;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    
    //public float volumeMasterMusic;

    private void Start()
    {
        GetMasterVolume();        
    }

    public void SetMasterVolume()
    {
        float volume = volumeSlider.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        GameManager.Instance.volumeMaster = volume;
    }    

    public void GetMasterVolume()
    {
        volumeSlider.value = GameManager.Instance.volumeMaster;
        float volume = volumeSlider.value;
        audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
    }
}