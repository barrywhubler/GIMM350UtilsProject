using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class avgCharPWord : MonoBehaviour
{

    public Button bButton;
    //public Text inText;
    //public Text outText;
    public Text inTText;
    public Text outTText;

    // Start is called before the first frame update
    void Start()
    {
        Button button = bButton.GetComponent<Button>();
        button.onClick.AddListener(TaskOnClick);
    }

    void TextSplitter()
    {
        string sentence = inTText.text;
        int charCount = sentence.Length;
        string[] wWords = sentence.Split(' ');
        int wordCount = wWords.Length;

        int charPWord = (charCount - wordCount + 1) / wordCount;
        outTText.text = charPWord.ToString();
    }
    
   void TaskOnClick(){

        TextSplitter();
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
