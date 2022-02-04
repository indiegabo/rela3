using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private ItemType _type;

    private Tile _currentTile;
    private ITransition _transition;

    public ItemType type => this._type;

    private void Awake()
    {
        this._transition = this.GetComponent<ITransition>();
    }

    private void Start()
    {
    }
}
