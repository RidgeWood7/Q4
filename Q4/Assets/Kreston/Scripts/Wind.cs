using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Wind : MonoBehaviour
{
    private bool leafMaskOn;
    private BoxCollider _col;

    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _redirectSpeed;
    [SerializeField] private bool _isOn;

    private List<PlayerMovement> _objects = new();

    public void Start()
    {
        _col = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        if (!_isOn)
            return;

        foreach (var obj in _objects)
        {
            if (obj.currentMask is not LeafMask leafMask)
            {
            obj.controller.Move(_direction * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
        _objects.Add(playerMovement);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.TryGetComponent(out PlayerMovement playerMovement))
        {
        _objects.Remove(playerMovement);
        }
    }

    [ContextMenu("Toggle On")]
    public void ToggleOn()
    {
        _isOn = !_isOn;

        //if (!_isOn)
        //    _particles.Stop();
        //else
        //    _particles.Play();
    }

    [ContextMenu("Toggle Off")]
    public void ToggleOff()
    {
        _isOn = !_isOn;

        //if (!_isOn)
        //    _particles.Stop();
        //else
        //    _particles.Play();
    }
}
