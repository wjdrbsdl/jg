using UnityEngine;
using UnityEngine.Audio;

//보드로 오디오를 화면에 표현하는 도구
//AudioUI 에 연결
public class AudioBoardVisual : MonoBehaviour
{
    public float minBoardValue = 50.0f;
    public float maxBoardValue = 500.0f;

    public int samples = 2;

    public AudioClip audioClip;
    public AudioSource audioSource;
    public AudioMixer audioMixer;
    public AudioMixerGroup group;
    public Board[] boards;

    private void Start()
    {
        boards = GetComponentsInChildren<Board>();
  
        if (audioSource == null)
        {
            audioSource = new GameObject("오디오소스").AddComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
        Debug.Log(audioMixer.outputAudioMixerGroup); //null임

        //오디오 믹서 의 매칭 그룹 Master란 이름을 찾는다?
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        audioSource.Play();
    }

    private void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples,0,FFTWindow.Rectangular);

        //보드 갯수 만큼 각각 작업 진행
        for (int i = 0; i < boards.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;
            //보드 각각이 가지고 있는 사이즈

            size.y = minBoardValue + (data[i] * (maxBoardValue - minBoardValue)*3f);

            boards[i].GetComponent<RectTransform>().sizeDelta = size;
        }
    }
}
