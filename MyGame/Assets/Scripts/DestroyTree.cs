using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;

public class DestroyTree : MonoBehaviour
{
    [SerializeField] private TMP_Text text;

    private bool onTrigger;

    private GameObject tree;
    [SerializeField] private GameObject prefabWood;

    private Transform canvas;
    private Transform image;

    [SerializeField] private int HPTree;
    [SerializeField] private int countWood;

    private List<GameObject> woods = new List<GameObject>();
    private Rigidbody _rb;


    private void Update()
    {
        if (onTrigger)
        {
            if (text.text == "")
            {
                text.text = "Нажмите ЛКМ, чтобы начать рубить";
            }
            Damaging();
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "Нажмите ЛКМ, чтобы начать рубить";
            onTrigger = true;
            tree = gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            text.text = "";
            onTrigger = false;
        }
    }


    public void Damaging()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HPTree -= 10;
        }
        if (HPTree <= 0)
        {
            StartCoroutine("CreateWood");
            text.text = "";
            onTrigger = false;
        }
    }

    IEnumerator CreateWood()
    {  
        float posX = tree.transform.position.x;
        float posZ = tree.transform.position.z;
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
        Destroy(tree);
    }
}
