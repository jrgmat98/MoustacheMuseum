using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown resolutionsDropdown;

    public Dropdown quality;

    public Slider master;
    public Slider music;
    public Slider effects;

    public Toggle fullSecreen;

    int[] resolutionHeigh = new int[5];
    int[] resolutionWidth= new int[5];


    private void Start()
    {
        
        resolutionWidth[0] = 640;
        resolutionWidth[1] = 1280;
        resolutionWidth[2] = 1920;
        resolutionWidth[3] = 2048;
        resolutionWidth[4] = 3840;

        resolutionHeigh[0] =480;
        resolutionHeigh[1] =720;
        resolutionHeigh[2] =1080;
        resolutionHeigh[3] =1080;
        resolutionHeigh[4] =2160;
        resolutionsDropdown.options.Add(new Dropdown.OptionData(resolutionWidth[0]+"x"+ resolutionHeigh[0]));
        resolutionsDropdown.options.Add(new Dropdown.OptionData(resolutionWidth[1] + "x" + resolutionHeigh[1]));
        resolutionsDropdown.options.Add(new Dropdown.OptionData(resolutionWidth[2] + "x" + resolutionHeigh[2]));
        resolutionsDropdown.options.Add(new Dropdown.OptionData(resolutionWidth[3] + "x" + resolutionHeigh[3]));
        resolutionsDropdown.options.Add(new Dropdown.OptionData(resolutionWidth[4] + "x" + resolutionHeigh[4]));





        fullSecreen.GetComponent<Toggle>().isOn = Screen.fullScreen;

        quality.GetComponent<Dropdown>().value = QualitySettings.GetQualityLevel();
       
        audioMixer.GetFloat("VolumeMaster", out float x );
        
        master.GetComponent<Slider>().value = x;


        audioMixer.GetFloat("VolumeMusica", out  x);

        music.GetComponent<Slider>().value = x;

        audioMixer.GetFloat("VolumeEfectos", out  x);

        effects.GetComponent<Slider>().value = x;
    }

    public void SetVolumeMaster(float volume)
    {
        audioMixer.SetFloat("VolumeMaster", volume);
    }
     

    public void SetVolumeMusica(float volume)
    {
        audioMixer.SetFloat("VolumeMusica", volume);
    }

    public void SetVolumeEfectos(float volume)
    {
        audioMixer.SetFloat("VolumeEfectos", volume);
    }

    public void setQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }

    public void FullScreen(bool fullScreen)
    {
        Screen.fullScreen = fullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        
        Screen.SetResolution(resolutionWidth[resolutionIndex], resolutionHeigh[resolutionIndex], Screen.fullScreen);
     
    }

  
}
