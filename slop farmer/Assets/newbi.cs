using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class newbi : MonoBehaviour
{
    public class d
    {
        public int q { get; set; }
        public GameObject p { get; set; }
        public int iq { get; set; }
        public int kg { get; set; }
        public int id { get; set; }
        public bool boo { get; set; }
        public string su { get; set; }
    }
        public Text work;
    public GameObject buttonTemplate,buttons;
    public List<GameObject> list = new List<GameObject>();

    public Dictionary<int, d> dict = new Dictionary<int, d>();
    public System.Random r = new System.Random();
    public Color mycolor = new Color(0.9f, 0.55f, 0.55f), white = new Color(1.0f, 1.0f, 1.0f), orange = new Color(1.0f, 1.0f, 1.0f);
    public List<int> s;
    public int x = 0, r1 = 0, r2 = 0, ro = 0, ra = 0;
    public Dictionary<int, d> pigs = new Dictionary<int, d>();
    public double xp, r3;

    void Start()
    {
        
        s.Add(-1);
        s.Add(-1);
        for (int i = 0; i < 6; i++)
        {
            pigs.Add(pigs.Count, new d { iq = 100, kg = 100, id = 100 });
            yes();
        }
      
    }
    public void yes()
    {

        buttons = Instantiate(buttonTemplate) as GameObject;
        dict.Add(x, new d { q = 0, p = buttons, boo = false });
        dict[x].p.SetActive(true);
        dict[x].p.transform.SetParent(buttonTemplate.transform.parent, false);
        string pigstats = $@"
button: {x}
pig : {pigs[x ].su}
iq : {pigs[x ].iq}
kg : {pigs[x ].kg}
id : {pigs[x ].id}";
        dict[x].p.GetComponentInChildren<Text>().text = pigstats;


        debug();
        x++;
    }
    void debug()
    {
        int i = x;
        {


            dict[i].p.GetComponent<Button>().onClick.AddListener(delegate {

                dict[i].boo = !dict[i].boo;//switch colour        
                if (dict[i].boo == true)
                {
                    dict[i].p.GetComponent<Image>().color = mycolor;// turn new button pink
                    if (s[1] != i && s[0] != i)
                    {
                        if (s[1] != -1 && s[0] != -1)
                        {
                            dict[s[1]].p.GetComponent<Image>().color = white;
                            dict[s[1]].boo = false;

                        }
                        if (s[0] != -1)
                        {
                            s[1] = s[0];
                        }//stage 1=stage 0
                        s[0] = i;// stage 0 =i

                        Debug.Log($"s0={s[0]}       s1={s[1]}          bool={dict[i].boo}");
                    }
                }
                if (dict[i].boo == false)
                {
                    if (s[1] == i)
                    {
                        s[1] = -1;
                    }
                    if (s[0] == i)
                    {
                        s[0] = -1;
                    }
                    dict[i].p.GetComponent<Image>().color = white;
                    Debug.Log($"s0={s[0]}       s1={s[1]}          bool={dict[i].boo}");

                }
            });
        }
    }
    public void pigbreed()
    {

        if (s[0] != -1 && s[1] != -1 && s[0] != s[1])
        {

            r1 = (pigs[s[0] ].iq + pigs[s[1] ].iq) / 2;
            piglog();
            int iq = (int)r3;
            r1 = (pigs[s[0] ].kg + pigs[s[1] ].kg) / 2;
            piglog();
            int kg = (int)r3;
            r1 = (pigs[s[0] ].id + pigs[s[1]].id) / 2;
            piglog();
            int id = (int)r3;

            string fish = "s";// $"{pigs[s[0]+1].su}{pigs[s[1] + 1].su}";//"{0}{1}",pigs[s[0]+1],pigs[s[1] + 1];
            pigs.Add(pigs.Count , new d { iq = iq, kg = kg, id = id, su = "" + fish });


            dict[s[1]].p.GetComponent<Image>().color = white;
            dict[s[1]].boo = false;
            dict[s[0]].p.GetComponent<Image>().color = white;
            dict[s[0]].boo = false;
            s[0] = -1;
            s[1] = -1;
            yes();
        }
    }
    public void piglog()
    {
        // double l = r.NextDouble() * (1 - 0);
        xp = -3 * Math.Log(r.NextDouble() * (1 - 0), 2);
        if (r.Next(0, 2) == 0)
        {
            xp = -xp;
        }
        r3 = (xp / 100) * r1 + r1;
        Debug.Log(xp);
    }

}
