using UnityEngine;

public class NightvisionMask : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask maskOff;
    [SerializeField] private LayerMask maskOn;


    public void Start()
    {
        cam.cullingMask = maskOn;
    }

}
