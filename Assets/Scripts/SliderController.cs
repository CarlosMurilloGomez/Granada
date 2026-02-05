using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Image sliderFill;
    public Sprite[] sliderColores;
    public float max;
    private Slider sd;
    public TextMeshProUGUI valorText;

    void Start()
    {
        sd = GetComponent<Slider>();
        sd.maxValue = max;

    }

    // Update is called once per frame
    void Update()
    {
        valorText.text = sd.value.ToString();
        if (sd.value / max < 0.25)
        {
            sliderFill.sprite = sliderColores[0];
        }
        else if ((sd.value / max > 0.25) && (sd.value / max < 0.5))
        {
            sliderFill.sprite = sliderColores[1];
        }
        else if ((sd.value / max > 0.5) && (sd.value / max < 0.75))
        {
            sliderFill.sprite = sliderColores[2];
        }
        else if ((sd.value / max > 0.75) && (sd.value / max < 1))
        {
            sliderFill.sprite = sliderColores[3];
        }
    }
}
