using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TakeWood : MonoBehaviour
{
    public TMP_Text text;
    public TMP_Text countWoodText;

    private int countWood;

    private bool onCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wood")
        {
            text.text = "Нажмите К, чтобы подобрать дерево";
            onCollision = true;
        } 
    }

    private void OnTriggerExit(Collider other)
    {
        text.text = "";
        onCollision = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Wood")
        {
            Take(other);
        }
    }

    void Take(Collider other)
    {
        if (Input.GetKey(KeyCode.R))
        {
            countWood++;
            countWoodText.text = "Дерева: " + Convert.ToString(countWood);
            text.text = "";
            Destroy(other.gameObject);
        }
    }
}
