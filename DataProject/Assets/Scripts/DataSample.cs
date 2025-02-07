using UnityEngine;

public class DataSample : MonoBehaviour
{
    //1. 유니티 데이터의 저장
    //게임의 서비스 제공에서 가장 핵심 되는 부분

    public UserData userData;

    private void Start()
    {
        //PlayerPrefs.SetString("ID", userData.UserID);
        //PlayerPrefs.SetString("UserName", userData.UserName);
        //PlayerPrefs.SetString("PassWord", userData.UserPassword);
        //PlayerPrefs.SetString("E-mail", userData.UserEmail);

        //Debug.Log("데이터가 저장되었다.");

        Debug.Log(PlayerPrefs.GetString("ID"));
        PlayerPrefs.GetString("UserName");
        PlayerPrefs.GetString("PassWord");
        PlayerPrefs.GetString("E-mail");


    }   
}       
        
