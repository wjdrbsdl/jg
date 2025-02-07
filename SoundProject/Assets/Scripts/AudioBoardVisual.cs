using UnityEngine;
using UnityEngine.Audio;

//����� ������� ȭ�鿡 ǥ���ϴ� ����
//AudioUI �� ����
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
            audioSource = new GameObject("������ҽ�").AddComponent<AudioSource>();
        }

        audioSource.clip = audioClip;
        Debug.Log(audioMixer.outputAudioMixerGroup); //null��

        //����� �ͼ� �� ��Ī �׷� Master�� �̸��� ã�´�?
        audioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
        audioSource.Play();
    }

    private void Update()
    {
        float[] data = audioSource.GetSpectrumData(samples,0,FFTWindow.Rectangular);

        //���� ���� ��ŭ ���� �۾� ����
        for (int i = 0; i < boards.Length; i++)
        {
            var size = boards[i].GetComponent<RectTransform>().rect.size;
            //���� ������ ������ �ִ� ������

            size.y = minBoardValue + (data[i] * (maxBoardValue - minBoardValue)*3f);

            boards[i].GetComponent<RectTransform>().sizeDelta = size;
        }
    }
}
