using TMPro;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //1. ������Ʈ �����ϴ� ���
    //2. ���콺 ��ư�� ������ �� ī�޶��� ��ũ�� �������� ��ü ���� ����
    //3. ��ü�� ���⿡ ���� �߻�

    public GameObject prefab;
    public GameObject target;
    private GameObject scoreText; //���� ǥ�� �ؽ�Ʈ
    public float power = 1000f;
    public int score = 0;
    public int minX = -70;
    public int minZ = 20;
    public int maxX = 70;
    public int maxZ = 60;

    public Material darkSky;
    public Material morningSky;


    private void Start()
    {
        scoreText = GameObject.Find("ScoreText");
        SetScoreText();
        SetSky();
    }

    /// <summary>
    /// ���� ȹ��
    /// </summary>
    /// <param name="_value"></param>
    public void ScorePlus(int _value)
    {
        score += _value;
        SetScoreText();
        SetSky();
    }

    /// <summary>
    /// �� ���� ���
    /// </summary>
    private void SetScoreText()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"���� : {score}";
    }

    private void SetSky()
    {
        if (score >= 30)
        {
            RenderSettings.skybox = darkSky;
            return;
        }
        RenderSettings.skybox = morningSky;
            
    }

    void Update()
    {
        MakeTarget();
        if (Input.GetMouseButtonDown(0))
        {
            GameObject thrownObj = Instantiate(prefab);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Debug.Log(ray.origin.magnitude+"����ũ��");
            //Debug.Log(ray.direction.magnitude + "����ũ��");
            //thrownObj.gameObject.transform.position = Camera.main.transform.position;
            thrownObj.GetComponent<ObjectShooter>().Shoot(ray.direction * power);

        }
    }

    private float curTime = 0;
    public float makePeriod = 3f;
    public float targetLifeTime = 3f;
    private void MakeTarget()
    {
        if(CheckCount() == false)
        {
            return;
        }

        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);
        GameObject madeTarget = Instantiate(target);
        madeTarget.transform.position = new Vector3(randomX, 0, randomZ);
    }

    private bool CheckCount()
    {
        curTime += Time.deltaTime;
        if(makePeriod <= curTime)
        {
            curTime = 0;
            return true;
        }
        return false;
    }
}

