using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleModeStateCheckTiles : SimpleModeState
{
    public SimpleModeStateCheckTiles(SimpleMode simpleMode) : base(simpleMode)
    {
    }

    public override void Tick()
    {
        base.Tick();
    }

    public override void FixedTick()
    {
        base.FixedTick();
    }

    public override void OnEnter()
    {
        base.OnEnter();

        Debug.Log("Verificando matches...");

        for (int x = 0; x < _simpleMode.core.board.xSize; x++)
        {
            for (int y = 0; y < _simpleMode.core.board.ySize; y++)
            {
                //Check adjascent tiles to detect a match
                var tile = _simpleMode.core.board.GetTile(new Vector2(x, y));
                var tile2 = _simpleMode.core.board.GetTile(new Vector2(x - 1, y));
                var tile3 = _simpleMode.core.board.GetTile(new Vector2(x - 2, y));
                if ((tile != null && tile2 != null && tile3 != null) && (tile.item.type == tile2.item.type && tile2.item.type == tile3.item.type))
                {
                    tile.item.transform.position = new Vector3(999f, 999f, -5f);
                    tile2.item.transform.position = new Vector3(999f, 999f, -5f);
                    tile3.item.transform.position = new Vector3(999f, 999f, -5f);
                }
            }
        }

        _simpleMode.stateMachine.SetActiveState(_simpleMode.simpleModeStateInputCheck);
    }

    public override void OnExit()
    {
        base.OnExit();
    }
}
