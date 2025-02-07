using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{
    /*
     * ��ǲ �ʵ� �̿��� �Է� �Ϸ�� �ش� ������ ����
     * ������ ���� ��ư ������ playerPrefs�� Name�� Descrip ����
     * �ڷ� ������ �ε� ��ư�� ��Ȱ��
     * ���� ������ ���Ű ����
     */
    public TMP_InputField nameInputField;
    public TMP_InputField descriptionInputField;
    public Button loadButton;

    public TMP_Text nameText;
    public TMP_Text descriptionText;

    private string nameKey = "ItemName";
    private string descriptionKey = "Description";

    private void Start()
    {
        SetLoadBtnState();
    }

    public void OnClickSave()
    {
        if(nameInputField.text != "" && descriptionInputField.text != "")
        {
            //�� �ʵ� ��� ������ ������ ���� ����
            PlayerPrefs.SetString(nameKey, nameInputField.text);
            PlayerPrefs.SetString(descriptionKey, descriptionInputField.text);
        }
        SetLoadBtnState();
    }

    public void OnClickLoad()
    {
        SetItemData();
    }

    public void OnClickDelete()
    {
        ResetData();
        SetItemData();
    }

    private void SetItemData()
    {
        //������ ������ �ҷ��ͼ� ����
        nameText.text = "������ �̸� "+ PlayerPrefs.GetString(nameKey);
        descriptionText.text = "������ ���� "+ PlayerPrefs.GetString(descriptionKey);
    }

    private void SetLoadBtnState()
    {
        bool isHaveData = PlayerPrefs.HasKey(nameKey) && PlayerPrefs.HasKey(descriptionKey);
        loadButton.interactable = isHaveData;
    }

    private void ResetData()
    {
        PlayerPrefs.DeleteKey(nameKey);
        PlayerPrefs.DeleteKey(descriptionKey);
        SetLoadBtnState();
    }

    public void OnValueChange(string _text)
    {
        Debug.Log(_text);
    }
}
