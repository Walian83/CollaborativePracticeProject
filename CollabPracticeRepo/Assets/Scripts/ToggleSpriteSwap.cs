using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ToggleSpriteSwap : MonoBehaviour
{
    public Toggle targetToggle;
    public Image imageOff;
    public Image imageOn;
    // Start is called before the first frame update
    void Start()
    {
        targetToggle.toggleTransition = Toggle.ToggleTransition.None;
        targetToggle.onValueChanged.AddListener(OnTargetToggleValueChanged);
    }

    void OnTargetToggleValueChanged(bool newValue)
    {
        if (newValue == false)
        {
            imageOff.enabled = true;
            imageOn.enabled = false;
        }
        else if (newValue == true)
        {
            imageOff.enabled = false;
            imageOn.enabled = true;
        }
    }
}
