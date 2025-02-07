using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ObjectShooter : MonoBehaviour
{
    //�߻� ���
    //�浹 �� ������Ʈ ���� ���� 
    GameObject objectGenerator;

    void Start()
    {
        //������ �ش� �̸��� ���� ���� ������Ʈ ã��. 
        objectGenerator = GameObject.Find("ObjectGenerator");
        //objectGenerator = GameObject.FindWithTag("Generator"); // �±� Ž��
        //ObjectGenerator obg = GameObject.FindAnyObjectByType<ObjectGenerator>();
    }

    /// <summary>
    /// ��ü�� �߻��ϴ� ����� ���� �Լ�
    /// </summary>
    /// <param name="_direction">�̰� ��������</param>
    public void Shoot(Vector3 _direction)
    {
        GetComponent<Rigidbody>().AddForce(_direction);
    }

    

    private void OnCollisionEnter(Collision collision)
    {
        //������ٵ� Ű�׸�ƽ�� Ʈ����ϸ� �����ȴ�
        Debug.Log("�浹�� ��"+collision.gameObject.tag);
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponentInChildren<ParticleSystem>().Play();

        if(collision.gameObject.tag == "terrain")
        {
            Destroy(gameObject, 1.0f);
        }
        else //������ ���
        {
            objectGenerator.GetComponent<ObjectGenerator>().ScorePlus(10);
            Destroy(collision.gameObject);
        }
    }
}
