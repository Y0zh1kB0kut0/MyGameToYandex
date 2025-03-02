using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageTree : MonoBehaviour
{
    public TMP_Text text;

    private bool onTrigger;

    private GameObject tree;
    public GameObject prefabWood;

    private Transform canvas;
    private Transform image;

    private int HPTree;
    private int countWood;


    private void Update()
    {
        if (onTrigger)
        {
            Damaging();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "SmallTree" || other.gameObject.tag == "MediumTree" || other.gameObject.tag == "BigTree")
        {
            text.text = "Нажмите ЛКМ, чтобы начать рубить";
            onTrigger = true;
            tree = other.gameObject;
        }
        switch (other.gameObject.tag) 
        {
            case "SmallTree":
                HPTree = 30;
                countWood = 1;
                break;
            case "MediumTree":
                HPTree = 50;
                countWood = 2;
                break;
            case "BigTree":
                HPTree = 100;
                countWood = 5;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "SmallTree" || other.gameObject.tag == "MediumTree" || other.gameObject.tag == "BigTree")
        {
            text.text = "";
            onTrigger = false;
            HPTree = 0;
        }
    }


    public void Damaging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HPTree -= 10;
            Debug.Log(HPTree);
        }
        if (HPTree <= 0)
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
        for (int i = 0; i < countWood; i++)
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
