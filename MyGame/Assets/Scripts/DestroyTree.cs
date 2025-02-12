using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyTree : MonoBehaviour
{
    public TMP_Text text;

    //private void OnCollisionStay(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Tree")
    //    {
    //        text.text = "Нажмите ЛКМ, чтобы начать рубить";
    //    }
    //}

    //private void OnCollisionExit(Collision collision)
    //{
    //    if (collision.gameObject.tag == "Tree")
    //    {
    //        text.text = "";
    //    }
    //}

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
}
