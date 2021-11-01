using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class DialogStoryManager : MonoBehaviour
{
    private DialogTextItems dialogTextItems;
    private DialogBtnItems dialogBtnItems;
    [SerializeField] private GameObject dialogTxtPrefab;
    [SerializeField] private GameObject dialogBtnPrefab;
    public GameObject dialogPanel;
    public Story story;
    public GameObject textSlider;
    public GameObject btnSlider;
    [SerializeField] private TextAsset textAsset;


    void Start()
    {
        story = new Story(textAsset.text);
        dialogPanel.SetActive(true);
        dialogTxtPrefab.SetActive(true);
        dialogBtnPrefab.SetActive(true);
        RefreshValues();

    }
    void Update()
    {
        //if (Input.GetButtonDown("DialogCheck"))
        //{
        //}
    }
    void RefreshValues()
    {
        //ClearUI();

        //dialogTxtPrefab.transform.SetParent(textSlider.transform);
        //dialogBtnPrefab.transform.SetParent(btnSlider.transform);
        GetNextStoryBlock();
        //GetBtnAllChoices();
    }
    public void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshValues();
    }
    void ClearUI()
    {
        int childCount = this.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        }
    }
    public void GetBtnAllChoices()
    {
        foreach (Choice choice in story.currentChoices)
        {

            DialogBtnItems dglBtnItm = Instantiate(dialogBtnPrefab, btnSlider.transform).GetComponent<DialogBtnItems>();
            Button newChoiceBtn = dglBtnItm.GetComponent<Button>();
            newChoiceBtn.transform.SetParent(btnSlider.transform);


            Text choiceText = newChoiceBtn.GetComponentInChildren<Text>();
            choiceText.text = choice.text;
            newChoiceBtn.onClick.AddListener(delegate
            {
                OnClickChoiceButton(choice);
            });

        }
    }
    public void GetNextStoryBlock()
    {
        do
        {

            //dialogTxtPrefab.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = story.Continue();
            DialogTextItems txtItem = Instantiate(dialogTxtPrefab, textSlider.transform).GetComponent<DialogTextItems>();
            txtItem.SetDialogText(story.Continue(), 1);
        } while (story.canContinue);
    }
}
