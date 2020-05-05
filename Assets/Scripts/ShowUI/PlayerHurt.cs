using UnityEngine;
using System.Collections;

public class PlayerHurt : MonoBehaviour
{
    public float time = 0.2f; //Seconds to read the text

    IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}