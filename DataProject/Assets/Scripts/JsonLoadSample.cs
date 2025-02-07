using System.IO;
using UnityEngine;

[System.Serializable]
public class Item01
{
    public string name;
    public string description;
}

public class JsonLoadSample : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string loadJson = File.ReadAllText(Application.dataPath + "/item01.json");
        var loadItem = JsonUtility.FromJson<Item01>(loadJson);
        Debug.Log(loadItem.name);

        loadItem.name = "�̸� �ٲ�";
        loadItem.description = " ���� �ٲ�";
        File.WriteAllText(Application.dataPath + "/item02.json", JsonUtility.ToJson(loadItem));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
