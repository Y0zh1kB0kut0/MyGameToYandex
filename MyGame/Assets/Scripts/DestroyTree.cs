using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class DestroyTree : MonoBehaviour
{
    public TMP_Text text;

    private Image imageHP;

    public bool onTrigger;

    private GameObject tree;
    public GameObject prefabWood;

    private Transform canvas;
    private Transform image;


    private void Update()
    {
        if (onTrigger)
        {
            Damaging();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            text.text = "Нажмите ЛКМ, чтобы начать рубить";
            onTrigger = true;
            tree = other.gameObject;
            canvas = tree.transform.GetChild(1);
            image = canvas.transform.GetChild(0);
            imageHP = image.GetComponent<Image>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Tree")
        {
            text.text = "";
            onTrigger = false;
        }
    }


    public void Damaging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            imageHP.fillAmount -= 0.1f;
        }
        if (imageHP.fillAmount <= 0)
        {
            StartCoroutine("CreateWood");
            text.text = "";
            Destroy(tree);
            onTrigger = false;
        }
    }

    IEnumerator CreateWood() 
    {
        float posX = tree.transform.position.x;
        float posZ = tree.transform.position.z;
        List<GameObject> woods = new List<GameObject>();
        Rigidbody _rb;
        for (int i = 0; i < 3; i++)
        {
            woods.Add(Instantiate(prefabWood, new Vector3(Random.Range(posX - 1f, posX + 1f), .3f, Random.Range(posZ - 1f, posZ + 1f)), Quaternion.identity));
        }
        yield return new WaitForSeconds(.15f);
        foreach (GameObject wood in woods)
        {
            _rb = wood.GetComponent<Rigidbody>();
            _rb.isKinematic = true;
        }

    }
}
