using Unity.VisualScripting;
using UnityEngine;

//Ŭ���� ����
class Unit
{
    public string unitName;

    public static void UnitAction()
    {
        Debug.Log("���� ����");
    }

    public void Cry()
    {
        Debug.Log("���� ��");
    }
}

public class ClassSample : MonoBehaviour
{
    Unit unit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Ŭ��������.�ʵ带 ���� ����
        unit.unitName = "�̿�";
        unit.Cry();

        Unit.UnitAction(); //����ƽ�� Ŭ�������� �ٷ� ȣ��. 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
