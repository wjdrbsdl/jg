using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    //발사 기능
    //충돌 시 오브젝트 고정 역할 
    GameObject objectGenerator;

    void Start()
    {
        //씬에서 해당 이름을 가진 게임 오브젝트 찾음. 
        objectGenerator = GameObject.Find("ObjectGenerator");
        //objectGenerator = GameObject.FindWithTag("Generator"); // 태그 탐색
        //ObjectGenerator obg = GameObject.FindAnyObjectByType<ObjectGenerator>();
    }

    /// <summary>
    /// 물체를 발사하는 기능을 가진 함수
    /// </summary>
    /// <param name="_direction">이건 뭘까요오오</param>
    public void Shoot(Vector3 _direction)
    {
        GetComponent<Rigidbody>().AddForce(_direction);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        //리지드바디 키네마틱을 트루로하면 고정된다
        Debug.Log("충돌된 것"+collision.gameObject.tag);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if(collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
        }
        else //과녁인 경우
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10);
            Destroy(collision.gameObject);
        }
    }
}
