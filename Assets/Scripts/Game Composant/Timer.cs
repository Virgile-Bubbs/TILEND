using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float duration;
    public float durationMax;
    public bool end;

    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        durationMax = 5.0f;
        duration = durationMax;
        end = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(duration <= 0)
        {
            end = true;
            text.text = duration.ToString("0");

        }
        else
        {
            duration -= Time.deltaTime;
            GetComponent<UnityEngine.UI.Image>().fillAmount = duration / durationMax;
            text.text = duration.ToString("0.00");
        }

    }
}
