using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class Item
{
    public string name; //json Ű�� ����
    public int count;//json Ű�� ����
}

[Serializable]
public class Inventory
{
    public List<Item> itemList;//json Ű�� ����
    //public Item[] inventory; //����Ƽ���� ����Ʈ�� �迭�� ����?
}

public class JsonArraySample : MonoBehaviour
{
    //�迭/List ���� ���� json ���� ��� ����
    //Resoucres���� �Ľ� 
    private void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("inventory"); //    
        Inventory inventory = JsonUtility.FromJson<Inventory>(textAsset.text);
        
        //����Ʈ�� ����ġ�� ���� ����?
        foreach(Item item in inventory.itemList)
        {
            Debug.Log(item.name);
        }
        string toJson = JsonUtility.ToJson(inventory);
        Debug.Log("�κ��丮 ����Ʈ �� ���̽�" + toJson);
        File.WriteAllText(Application.dataPath + "/itemList.json", toJson);
    }
}

