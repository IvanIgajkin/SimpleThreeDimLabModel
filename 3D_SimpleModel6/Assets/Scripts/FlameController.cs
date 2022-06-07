using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameController : MonoBehaviour
{
    private bool[][] _flameActivityGrid;
    
    public float frontLineVelocity = 1.0f;
    [SerializeField] private GameObject flamePrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private bool[][] InitGrid()
    {
        var grid = new List<bool[]>();
        for (int layerNum = 0; layerNum < 50; layerNum++)
        {
            var layer = new List<bool>();
            for (int num = 0; num < 10; num++)
            {
                layer.Add(layerNum == 0 && num is 4 or 5);
            }
            
            grid.Add(layer.ToArray());
        }

        return grid.ToArray();
    }

    private void MoveFlameFrontLine()
    {
        for (int num = 9; num >= 0; num--)
        {
            for (int layerNum = 49; layerNum >= 0; layerNum--)
            {
                if (_flameActivityGrid[layerNum][num])
                {
                    StartFlame(layerNum, num);
                    
                    if (layerNum < 49)
                    {
                        _flameActivityGrid[layerNum++][num] = true;
                    }
                    
                    if (num < 9)
                    {
                        _flameActivityGrid[layerNum][num++] = true;
                    }

                    _flameActivityGrid[layerNum][num] = false;
                }
            }
        }
    }

    private void StartFlame(int layer, int num)
    {
        GameObject flame = Instantiate(flamePrefab);
        var x = -0.5f + num * 0.05f;
        var z = -2.5f + layer * 0.05f;
        var position = new Vector3(x, 1.65f, z);
        flame.transform.Translate(position);
    }
}
