using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

//sliderjoint2D는 GO가 선을 따라 미끄러지게 할 때 사용 ex)미닫이문

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider masterVolSlider;
    [SerializeField] private Slider bgmVolSlider;
    [SerializeField] private Slider sfxVolSlider;

    private void Awake()
    {
        masterVolSlider.onValueChanged.AddListener(SetMaster);
        bgmVolSlider.onValueChanged.AddListener(SetBGM);
        sfxVolSlider.onValueChanged.AddListener(SetSFX);
    }

    private void SetSFX(float volume)
    {
        audioMixer.SetFloat("SFX", MathF.Log10(volume) * 20);
    }

    private void SetBGM(float volume)
    {
        audioMixer.SetFloat("BGM", MathF.Log10(volume) * 20);
    }

    private void SetMaster(float volume)
    {
        //오디오 믹서의 마스터 파라미터 값을 조절? 
        //오디오 믹서에서 export로 스크립트 조절가능케 해놔야함
        audioMixer.SetFloat("Master", MathF.Log10(volume) * 20); 
    }
}
