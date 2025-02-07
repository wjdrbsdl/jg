using UnityEngine;

//Ŭ������ ���� ����ȭ
[System.Serializable]
public class UserData
{
    public string UserID;
    public string UserName;
    public string UserPassword;
    public string UserEmail;

    //������

    //���̵�, �̸�, ���, �̸����� ������� �ۼ��ؼ� ���� ������ UserData

    //�⺻ ������
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
        string[] dataValues = data.Split(','); //, �� data ���� �и� 

        return new UserData(dataValues[0], dataValues[1], dataValues[2], dataValues[3]);
    }
}
