using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLayers : MonoBehaviour
{
    [SerializeField] LayerMask solidObjectsLayer;
    [SerializeField] LayerMask interactablesLayer;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] LayerMask pressurePadLayer;
    [SerializeField] LayerMask portalLayer;

    [SerializeField] LayerMask boundaryLayer;

    // Instance of gamelayers so any script can access it. (Singleton pattern)
    public static GameLayers i { get; set; }

    private void Awake()
    {
        i = this;
    }

    public LayerMask SolidLayer
    {
        get => solidObjectsLayer;
    }

    public LayerMask InteractablesLayer
    {
        get => interactablesLayer;
    }

    public LayerMask PlayerLayer
    {
        get => playerLayer;
    }

    public LayerMask PressurePadLayer
    {
        get => pressurePadLayer;
    }

    public LayerMask PortalLayer
    {
        get => portalLayer;
    }

    public LayerMask BoundaryLayer
    {
        get => boundaryLayer;
    }

    public LayerMask TriggerableLayers
    {
        get => pressurePadLayer | portalLayer;
    }
}
