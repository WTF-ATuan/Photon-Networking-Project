using UnityEngine;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    public AudioSource BGM;     
    
    void Update()
    {
        BGM.volume = gameObject.GetComponent<Slider>().value;
    }
}
