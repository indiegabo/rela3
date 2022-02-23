using System.Collections;
using System.Collections.Generic;
using IndieGabo.Rela3;
using IndieGabo.Rela3.Items;
using UnityEngine;

public abstract class EntityCore : MonoBehaviour
{

    [Header("Entity Components")]
    [SerializeField] private Board _board;
    [SerializeField] private InputHandler _inputHandler;
    [SerializeField] private ItemFactory _itemFactory;

    public Board board => this._board;
    public InputHandler inputHandler => this._inputHandler;
    public ItemFactory itemFactory => this._itemFactory;

}
