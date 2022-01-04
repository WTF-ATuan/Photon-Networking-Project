using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    AudioSource BGM;

    private void Start()
    {
        BGM = GameObject.Find("DontDestory").GetComponent<AudioSource>();
    }
    void Update()
    {
        BGM.volume = gameObject.GetComponent<Slider>().value;
    }
}
