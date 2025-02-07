using UnityEngine;

public class UserDataSystem : MonoBehaviour
{
    public UserData data01;
    public UserData data02;
    //playerprefs ���
    //1. deleteall
    //2. deletekey
    //3. set - Ű �ߺ��� ���� ����
    //4. get
    //5. has

    private void Start()
    {
        data01 = new UserData();
        data02 = new UserData("IDID", "NAMENAME", "!^$@#$!", "HARIBO@HARIBO");

        string dataValue = data02.GetData();
        Debug.Log(dataValue);

        PlayerPrefs.SetString("Data01", dataValue);

        data01 = UserData.SetData(dataValue);
        Debug.Log(data01.GetData());
    }
}
