using NUnit.Framework;
using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


[Serializable]

public class Item
{
    public string name; //json 키와 같게
    public int count;//json 키와 같게
}

[Serializable]
public class Inventory
{
    public List<Item> itemList;//json 키와 같게
    //public Item[] inventory; //유니티에선 리스트와 배열이 같다?
}

public class JsonArraySample : MonoBehaviour
{
    //배열/List 형태 저장 json 파일 사용 예제
    //Resoucres에서 파싱 
    private void Start()
    {
        TextAsset textAsset = Resources.Load<TextAsset>("inventory"); //    
        Inventory inventory = JsonUtility.FromJson<Inventory>(textAsset.text);
        
        //리스트는 포이치를 많이 쓴다?
        foreach(Item item in inventory.itemList)
        {
            Debug.Log(item.name);
        }
        string toJson = JsonUtility.ToJson(inventory);
        Debug.Log("인벤토리 리스트 투 제이슨" + toJson);
        File.WriteAllText(Application.dataPath + "/itemList.json", toJson);
    }
}

