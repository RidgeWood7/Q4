using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Wind : MonoBehaviour
{
    //private ParticleSystem _particles;
    private BoxCollider _col;

    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _redirectSpeed;

    [SerializeField] private bool _isOn;

    private List<PlayerMovement> _objects = new();

    public GameObject Barrier;

    public void Awake()
    {
        //_particles = GetComponent<ParticleSystem>();
        _col = GetComponent<BoxCollider>();

        //ParticleSystem.ShapeModule shape = _particles.shape;

        //shape.shapeType = ParticleSystemShapeType.SingleSidedEdge;
        //shape.scale = new(_col.size.x / 2, _col.size.y / 2, _col.size.z / 2);
        //shape.position = _col.center + new Vector3(0, _col.size.y / -2);

        //if (!_isOn)
        //    _particles.Stop();
        //else
        //    _particles.Play();
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
        foreach (var obj in _objects)
        {
            if (obj.currentMask is LeafMask leafMask)
            {
                Barrier.GetComponent<BoxCollider>().enabled = false;
            }
            else
            {
                Barrier.GetComponent<BoxCollider>().enabled = true;
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
