using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityCore : MonoBehaviour
{
    [Header("Entity Components")]
    [SerializeField] private Board _board;
    [SerializeField] private ItemProvider _itemProvider;

    public Board board => this._board;
    public ItemProvider itemProvider => this._itemProvider;

}
