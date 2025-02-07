using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class AudioSourceSample : MonoBehaviour
{
    public AudioSource audioSourceBGM;

    private AudioSource ownAudioSource;//�ش� ������Ʈ�� ������ GetComponet�� ������ �� ����. 
    //ownAudiosource = getcomponent<audiosource>();
    public AudioSource audioSourceSFX;

    public AudioClip bgm; 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSourceSFX = GameObject.Find("SFX").GetComponent<AudioSource>(); //���ε�� ã�� ���

        audioSourceBGM.clip = bgm;

        audioSourceSFX.clip = Resources.Load<AudioClip>("Explosion");
        
    }

    public void OnClickPlay()
    {
        audioSourceBGM.Play();
    }

    public void OnclickPause()
    {
        audioSourceBGM.mute = !audioSourceBGM.mute;
    }

    IEnumerator GetAudioClip()
    {
        UnityWebRequest webRequest = UnityWebRequestMultimedia.GetAudioClip("file:///" +Application.dataPath + "/Audio/Explosion.wav", AudioType.WAV);
        yield return webRequest.SendWebRequest();
        
        var newClip = DownloadHandlerAudioClip.GetContent(webRequest);

        audioSourceBGM.clip = newClip;
        audioSourceBGM.Play();

    }
}
