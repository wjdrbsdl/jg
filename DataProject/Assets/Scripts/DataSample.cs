using UnityEngine;

public class DataSample : MonoBehaviour
{
    //1. ����Ƽ �������� ����
    //������ ���� �������� ���� �ٽ� �Ǵ� �κ�

    public UserData userData;

    private void Start()
    {
        //PlayerPrefs.SetString("ID", userData.UserID);
        //PlayerPrefs.SetString("UserName", userData.UserName);
        //PlayerPrefs.SetString("PassWord", userData.UserPassword);
        //PlayerPrefs.SetString("E-mail", userData.UserEmail);

        //Debug.Log("�����Ͱ� ����Ǿ���.");

        Debug.Log(PlayerPrefs.GetString("ID"));
        PlayerPrefs.GetString("UserName");
        PlayerPrefs.GetString("PassWord");
        PlayerPrefs.GetString("E-mail");


    }   
}       
        
