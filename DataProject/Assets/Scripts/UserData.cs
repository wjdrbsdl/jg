using UnityEngine;

//클래스에 대한 직렬화
[System.Serializable]
public class UserData
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    //생성자

    //아이디, 이름, 비번, 이메일을 순서대로 작성해서 생성 가능한 UserData

    //기본 생성자
    public UserData()
    {

    }

    public UserData(string userID, string userName, string userPassword, string userEmail)
    {
        UserID = userID;
        UserName = userName;
        UserPassword = userPassword;
        UserEmail = userEmail;
    }

    public string GetData() => $"{UserID},{UserName},{UserPassword},{UserEmail}";

    public static UserData SetData(string data)
    {
        string[] dataValues = data.Split(','); //, 료 data 문자 분리 

        return new UserData(dataValues[0], dataValues[1], dataValues[2], dataValues[3]);
    }
}
