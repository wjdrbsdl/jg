using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

//sliderjoint2D�� GO�� ���� ���� �̲������� �� �� ��� ex)�̴��̹�

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
        //����� �ͼ��� ������ �Ķ���� ���� ����? 
        //����� �ͼ����� export�� ��ũ��Ʈ ���������� �س�����
        audioMixer.SetFloat("Master", MathF.Log10(volume) * 20); 
    }
}
