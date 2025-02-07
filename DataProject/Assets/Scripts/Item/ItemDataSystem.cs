using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemDataSystem : MonoBehaviour
{
    /*
     * 인풋 필드 이용해 입력 완료시 해당 데이터 저장
     * 데이터 저장 버튼 누르면 playerPrefs로 Name과 Descrip 저장
     * 자료 없으면 로드 버튼은 비활성
     * 삭제 누르면 모든키 삭제
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
            //두 필드 모두 내용이 있을때 저장 진행
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
        //아이템 데이터 불러와서 쓰기
        nameText.text = "아이템 이름 "+ PlayerPrefs.GetString(nameKey);
        descriptionText.text = "아이템 설명 "+ PlayerPrefs.GetString(descriptionKey);
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
