using Unity.VisualScripting;
using UnityEngine;

//클래스 사용법
class Unit
{
    public string unitName;

    public static void UnitAction()
    {
        Debug.Log("유닛 동작");
    }

    public void Cry()
    {
        Debug.Log("유닛 움");
    }
}

public class ClassSample : MonoBehaviour
{
    Unit unit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //클래스변수.필드를 통해 접근
        unit.unitName = "이왕";
        unit.Cry();

        Unit.UnitAction(); //스태틱은 클래스에서 바로 호출. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
