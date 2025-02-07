using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class SampleData
{
    public int i;
    public float f;
    public bool b;
    public Vector3 v;
    public string s;
    public int[] iArray;
}

public class JsonSample : MonoBehaviour
{

    private void Start()
    {
        SampleData sampleData = new SampleData();
        sampleData.i = 5;
        sampleData.f = 3f;
        sampleData.b = false;
        sampleData.v = Vector3.zero;
        sampleData.s = "He";
        sampleData.iArray = new int[] { 2, 5, 1 };

        string jsonData = JsonUtility.ToJson(sampleData);
        Debug.Log(jsonData);

        SampleData loadData = JsonUtility.FromJson<SampleData>(jsonData);
        Debug.Log(loadData.s);
    }

}
