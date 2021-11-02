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
    private DialogTextItems dialogTextItems;
    private DialogBtnItems dialogBtnItems;
    [SerializeField] private GameObject dialogTxtPrefab;
    [SerializeField] private GameObject dialogBtnPrefab;
    public GameObject dialogPanel;
    public Story story;
    public GameObject textSlider;
    public GameObject btnSlider;
    [SerializeField] private TextAsset textAsset;
    private List<DialogBtnItems> instanceBtns = new List<DialogBtnItems>();
    private List<DialogTextItems> instanceItems = new List<DialogTextItems>();
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
        //ResetList();
        Debug.Log("btn clicked..");
        RefreshValue();
    }

    void ResetList()
    {
        instanceBtns.Clear();
    }
    void ClearUI()
    {
        int childCount = btnSlider.transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Destroy(btnSlider.transform.GetChild(i).gameObject);
        }
    }
    public void TestClick()
    {
        Debug.Log("clickedd..");
    }
    public void GetBtnAllChoices()
    {
        if (story.currentChoices.Count > 0)
        {
            //ClearUI();
            foreach (Choice choice in story.currentChoices)
            {
                DialogBtnItems dglBtnItm = Instantiate(dialogBtnPrefab, btnSlider.transform, false).GetComponent<DialogBtnItems>();
                dglBtnItm.SetBtnOptions(choice.text, choice.index);
                Button newChoiceBtn = dglBtnItm.GetComponentInChildren<Button>();
                newChoiceBtn.onClick.AddListener(() => OnClickChoiceButton(choice));
                //newChoiceBtn.onClick.Invoke();
                /*  .AddListener(delegate
                 {
                     Debug.Log("btn clickedd...");
                     OnClickChoiceButton(choice);
                 }); */
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
        do
        {
            DialogTextItems txtItem = Instantiate(dialogTxtPrefab, textSlider.transform).GetComponent<DialogTextItems>();
            instanceItems.Add(txtItem);
            txtItem.SetDialogText(story.Continue(), 1);

        } while (story.canContinue);

    }
    private void ElementsOfItemsInstances()
    {
        float changeX = 411f;
        float changeY = 275f;

        for (int i = 0; i < instanceItems.Count; i++)
        {
            if (i > 0 && i == 1)
            {
                instanceItems[i].transform.position = new Vector3(changeX, changeY, 0f);
                Debug.Log("itemOne");
            }
            else if (i > 0 && i > 1)
            {
                instanceItems[i].transform.position = new Vector3(changeX, changeY += -30f, 0f);
            }
        }
    }
    private void ElementsOfChoicInstances()
    {
        float changeX = 417f;
        float changeY = 85f;

        for (int i = 0; i < instanceBtns.Count; i++)
        {
            if (i > 0 && i == 1)
            {
                instanceBtns[i].transform.position = new Vector3(changeX, changeY, 0f);
            }
            else if (i > 0 && i > 1)
            {
                instanceBtns[i].transform.position = new Vector3(changeX, changeY += -30f, 0f);
            }
        }
    }
}
