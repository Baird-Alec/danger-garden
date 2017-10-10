using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    private RubyDisplay rubyDisplay;
    public int rubyCost = 50;

    private void Start()
    {
        rubyDisplay = GameObject.FindObjectOfType<RubyDisplay>();
    }
    public void AddRubyAmount (int amount)
    {
        rubyDisplay.AddRubyAmount(amount);
    }
}
