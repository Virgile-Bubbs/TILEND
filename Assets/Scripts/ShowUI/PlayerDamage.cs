using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerDamage : MonoBehaviour
{
    public GameObject player;
    public int damage;
    private float durationMax;
    private float duration;
    // Start is called before the first frame update
    void Start()
    {
        durationMax = 0.5f;
        duration = durationMax;
        GetComponent<TextMeshProUGUI>().text = damage.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(duration < 0)
        {
            Destroy(gameObject);
        }

        Vector3 currentPos = GetComponent<RectTransform>().localPosition;
        currentPos.y++;
        GetComponent<RectTransform>().localPosition = currentPos;

        duration -= Time.deltaTime;
    }
}
