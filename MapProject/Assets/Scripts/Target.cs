using System.Runtime.Serialization;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float lifeTime = 5f;
    private ObjectGenerator generator;
    void Start()
    {
        generator =GameObject.Find("ObjectGenerator").GetComponent<ObjectGenerator>();
        lifeTime = generator.targetLifeTime;
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    private void CountTime()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            generator.ScorePlus(-10);
            Destroy(gameObject);
        }
    }
}
