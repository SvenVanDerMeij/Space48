using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Text : MonoBehaviour
{


    [SerializeField] private TMP_Text introductionField;
    [SerializeField] private TMP_Text messageField;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Introduction());
    }
    public void StartShowMessage(string input)
    {
        StartCoroutine(ShowMessage("hallo"));
        
    }
    IEnumerator Introduction()
    {
        introductionField.enabled = true;
        introductionField.text = "Welcome to Space 4 8. \n Move your ship with the arrows or WASD. \n Shoot with SPACE. \n Gather pickups and cycle with 'Left CTR'.  \n  Use pickups with 'E'.";
        yield return new WaitForSeconds(5f);
        introductionField.enabled = false;
    }
   public IEnumerator ShowMessage(string message)
    {
        Debug.Log(message);
        messageField.enabled = true;
        messageField.text = message;
        yield return new WaitForSeconds(3f);
        messageField.enabled = false;
    }
}
