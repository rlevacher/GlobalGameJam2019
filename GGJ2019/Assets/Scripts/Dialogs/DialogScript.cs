using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogScript : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public GameObject continueButton;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Type());
    }

    IEnumerator Type()
    {
        continueButton.SetActive(false);


        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    public void NexSentence()
    {
        if (index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (textDisplay.text ==sentences[index])
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);
        }
    }
}
