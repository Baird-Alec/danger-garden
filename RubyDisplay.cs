using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RubyDisplay : MonoBehaviour {

    private Text text;
    private int total = 100;
    public enum Status {SUCCESS,FAILURE}

    private void Start()
    {
        text = GetComponent<Text>();
        UpdateDisplay();
    }

    public void AddRubyAmount(int amount)
    {
        total += amount;
        UpdateDisplay();
    }

    public Status UseRubyAmount(int spend)
    {
        if(total >= spend)
        {
            total -= spend;
            UpdateDisplay();
            return Status.SUCCESS;
        }

        return Status.FAILURE;
    }

    private void UpdateDisplay()
    {
        text.text = total.ToString();
    }
}
