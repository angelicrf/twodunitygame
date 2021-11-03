using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Coins : PowerUpHeart
{
    public Inventory coinsInventory;
    public TextMeshProUGUI coinsText;
    private bool isEntered = false;
    public void FixedUpdate()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainScene")
        {
            if (coinsInventory.itemsList.Count == 0)
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
        if (!isEntered && this.gameObject.name == "CoinsIdle" && other.CompareTag("Player") && !other.isTrigger)
        {
            isEntered = true;

            if (powerUpSignal)
            {
                powerUpSignal.ReadSignals();
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
            isEntered = false;
            coinsInventory.isItem = false;
            powerUpSignal.hasSignal = false;
        }

    }

}