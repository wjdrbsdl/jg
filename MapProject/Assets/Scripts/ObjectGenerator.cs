using TMPro;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    //1. 오브젝트 생성하는 기능
    //2. 마우스 버튼을 눌렀을 때 카메라의 스크린 지점으로 물체 방향 설정
    //3. 물체를 방향에 맞춰 발사

    public GameObject prefab;
    public GameObject target;
    private GameObject scoreText; //점수 표시 텍스트
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
    /// 점수 획득
    /// </summary>
    /// <param name="_value"></param>
    public void ScorePlus(int _value)
    {
        score += _value;
        SetScoreText();
        SetSky();
    }

    /// <summary>
    /// 현 점수 출력
    /// </summary>
    private void SetScoreText()
    {
        scoreText.GetComponent<TextMeshProUGUI>().text = $"점수 : {score}";
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
            //Debug.Log(ray.origin.magnitude+"원본크기");
            //Debug.Log(ray.direction.magnitude + "방향크기");
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

