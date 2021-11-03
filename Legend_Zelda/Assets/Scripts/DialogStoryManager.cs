using System;
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
    [SerializeField] private GameObject dialogTxtPrefab;
    [SerializeField] private GameObject dialogBtnPrefab;
    [SerializeField] private TextAsset textAsset;
    public GameObject dialogPanel;
    public Story story;
    public GameObject textSlider;
    public GameObject btnSlider;


    void Start()
    {
        story = new Story(textAsset.text);
        dialogPanel.SetActive(true);
        dialogTxtPrefab.SetActive(true);
        dialogBtnPrefab.SetActive(true);
        RefreshValue();

    }
    void RefreshValue()
    {
        GetNextStoryBlock();
        GetBtnAllChoices();
    }
    public void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        RefreshValue();
    }

    void ClearUI(GameObject thisContent)
    {
        int childCount = thisContent.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Destroy(thisContent.transform.GetChild(i).gameObject);
        }
    }
    public void GetBtnAllChoices()
    {
        if (story.currentChoices.Count > 0)
        {
            ClearUI(btnSlider);
            foreach (Choice choice in story.currentChoices)
            {
                DialogBtnItems dglBtnItm = Instantiate(dialogBtnPrefab, btnSlider.transform, false).GetComponent<DialogBtnItems>();
                dglBtnItm.SetBtnOptions(choice.text, choice.index);
                Button newChoiceBtn = dglBtnItm.GetComponentInChildren<Button>();
                newChoiceBtn.onClick.AddListener(() => OnClickChoiceButton(choice));
            }
        }
        else
        {
            dialogPanel.SetActive(false);
            Debug.Log("error to read data from file ");
        }


    }
    public void GetNextStoryBlock()
    {
        ClearUI(textSlider);
        do
        {
            DialogTextItems txtItem = Instantiate(dialogTxtPrefab, textSlider.transform).GetComponent<DialogTextItems>();
            txtItem.SetDialogText(story.Continue(), 1);

        } while (story.canContinue);

    }

}
