using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DestroyTree : MonoBehaviour
{
    public TMP_Text text;
    public Image imageHP;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            text.text = "Нажмите ЛКМ, чтобы начать рубить";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            text.text = "";
        }
    }

    private void OnTriggerStay(Collider other)
    {
        Damaging();
    }

    public void Damaging()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Debug.Log("Я здесь");
            imageHP.fillAmount -= 0.1f;
        }
    }
}
