using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonlist : MonoBehaviour
{
    [SerializeField]
    private Text mytext;
    public void Settext(string textString)
    {
        mytext.text = textString;
        
    }

}
