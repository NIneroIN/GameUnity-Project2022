using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image bar;
    public float fill;
    public float maxFill;

    // Start is called before the first frame update
    void Start()
    {
        maxFill = transform.GetComponentInParent<Enemy>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        fill = transform.GetComponentInParent<Enemy>().GetHealth();
        bar.fillAmount = (fill * 100) / (100 * maxFill);
    }
}
