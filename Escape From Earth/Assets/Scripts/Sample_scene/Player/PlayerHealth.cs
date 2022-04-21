using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image bar;
    float fill;
    float maxFill;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        maxFill = player.GetComponent<PlayerBase>().GetMaxHealth();
    }

    // Update is called once per frame
    void Update()
    {
        fill = player.GetComponent<PlayerBase>().GetHealth();
        bar.fillAmount = (fill * 100) / (100 * maxFill);
    }
}
