using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tabs : MonoBehaviour
{
    public GameObject tab0, tab1, tab2, tab3, tab4, tab5, tab6, button0, button1, button2, button3, button4, button5, button6;
    public List<GameObject> tablist = new List<GameObject>();
    public List<GameObject> buttonlist = new List<GameObject>();
    public int p;

    public void Start()
    {
        tablist.Add(tab0);
        tablist.Add(tab1);
        tablist.Add(tab2);
        tablist.Add(tab3);
        tablist.Add(tab4);
        tablist.Add(tab5);
        
        buttonlist.Add(button0);
        buttonlist.Add(button1);
        buttonlist.Add(button2);
        buttonlist.Add(button3);
        buttonlist.Add(button4);
        buttonlist.Add(button5);

        for (int i =0; i<tablist.Count;i++)
        {
            ontabclick();
            p++;
        }


    }
    void ontabclick()
    {
        int q = p;
        buttonlist[q].GetComponent<Button>().onClick.AddListener(delegate
        {
           // Debug.Log(q);
            for (int i = 0; i < tablist.Count; i++)
            {
                if (i != q)
                {
                    tablist[i].SetActive(false);
                }
                else
                {
                    tablist[i].SetActive(true);
                }
            }
        });
    }
}
