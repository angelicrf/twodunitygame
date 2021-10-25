using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coins : PowerUpHeart
{
    public Inventory coinsInventory;
    public TextMeshProUGUI coinsText;
    public bool isCoin = false;
    public void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Main Scene")
        {
            if (!isCoin)
            {
                coinsText.text = "000";
            }
            else
            {
                coinsText.text = "" + coinsInventory.itemsList.Count;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            if (powerUpSignal)
            {
                powerUpSignal.ReadSignals();
                isCoin = true;
            }

            if (powerUpSignal.hasSignal)
            {
                coinsInventory.isItem = true;
                coinsInventory.GetItems();
                StartCoroutine(DoCreateObj());
            }
        }
    }
    IEnumerator DoCreateObj()
    {
        yield return new WaitForSeconds(3f);
        this.gameObject.SetActive(false);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            isCoin = false;
            coinsInventory.isItem = false;
            powerUpSignal.hasSignal = false;
        }

    }

}