using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using SimpleJSON;
using System;
using Photon.Pun;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    [SerializeField] private GameObject barbarian, elf, dwarf, wizard;
    private GameObject hero;
    public Text character;

    [SerializeField] private int _width, _height;
    [SerializeField] private GameObject
        square
        /* room_17
        barbarian */
        ;

    /*
    [SerializeField] private Tile
        _tilePrefab,
        _trapPrefab,
        _room1_prefab,
        _room2_prefab,
        _room3_prefab,
        _room4_prefab,
        _room5_prefab,
        _room6_prefab,
        _room7_prefab,
        _room8_prefab,
        _room9_prefab,
        _room10_prefab,
        _room11_prefab,
        _room12_prefab,
        _room13_prefab,
        _room14_prefab,
        _room15_prefab,
        _room16_prefab,
        _room17_prefab,
        _room18_prefab,
        _room19_prefab,
        _room20_prefab,
        _room21_prefab,
        _room22_prefab
        ; */

    [SerializeField] private Transform _cam;

    /* private JSONNode _traps; */

    void Start()
    {
        InitGrid();
    }

    void InitGrid()
    {
        StartCoroutine(GetTraps("http://localhost/zeroquest/traps.php", CreateGrid));
    }

    void CreateGrid()
    {
        switch(StateNameController.characterName)
        {
            case "dwarf":
                hero = dwarf;
                break;
            case "elf":
                hero = elf;
                break;
            case "wizard":
                hero = wizard;
                break;
            case "barbarian":
                hero = barbarian;
                break;
            default:
                break;
        }

        GameObject myHero = PhotonNetwork.Instantiate(hero.name, new Vector3(0, (float)0.5, 0), Quaternion.identity);
        myHero.name = hero.name;

        for (int x = 0; x < _width; x++)
        {
            for (int z = 0; z < _height; z++)
            {
                /* Set a random rotate value / Create various textures */
                int randRotate = UnityEngine.Random.Range(0, 2);
                randRotate = randRotate.Equals(0) ? randRotate : 90;

                /* Set a random offset value / Create various textures */
                float randOffsetX = UnityEngine.Random.Range(0, 2);
                float randOffsetY = UnityEngine.Random.Range(0, 2);

                float randY = UnityEngine.Random.Range(0, 2).Equals(1) ? -randOffsetX / 2 : randOffsetX / 2;
                float randX = UnityEngine.Random.Range(0, 2).Equals(1) ? -randOffsetY / 2 : randOffsetY / 2;

                string xPos = x.ToString().Length == 1 ? $"0{x}" : $"{x}";
                string zPos = z.ToString().Length == 1 ? $"0{z}" : $"{z}";

                GameObject cube = Instantiate(square, new Vector3(x, 0, z), Quaternion.identity);
                cube.name = $"Cube [{xPos} - {zPos}]";
                cube.transform.Rotate(0, randRotate, 0);

                cube.GetComponent<MeshRenderer>().materials[0].SetTextureOffset("_MainTex", new Vector2(randX, randY));

                /* Tile prefabType;

                if (
                    x.Equals(0) ||
                    y.Equals(0) ||
                    x.Equals(_width - 1) ||
                    y.Equals(_height - 1) ||
                    x >= 12 && x <= 13 && y >= 0 && y <= 6 ||
                    x >= 12 && x <= 13 && y <= _height - 1 && y >= 12 ||
                    x >= 0 && x <= 9 && y == 9 ||
                    x <= _width - 1 && x >= 16 && y == 9 ||
                    y >= 6 && y <= 12 && x == 9 ||
                    y >= 6 && y <= 12 && x == 16 ||
                    x >= 9 && x <= 16 && y == 6 ||
                    x >= 9 && x <= 16 && y == 12
                )
                {
                    prefabType = _trapPrefab;
                } else
                {
                    if (x > 0 && x <= 4 && y < _height && y >= _height - 4)
                    {
                        prefabType = _room1_prefab;
                    } else if (x > 4 && x <= 8 && y < _height && y >= _height - 4)
                    {
                        prefabType = _room2_prefab;
                    } else if (x > 8 && x <= 11 && y < _height && y >= _height - 6)
                    {
                        prefabType = _room3_prefab;
                    } else if (x > 0 && x <= 4 && y <= _height - 4 && y >= _height - 9)
                    {
                        prefabType = _room4_prefab;
                    } else if (x > 4 && x <= 8 && y <= _height - 4 && y >= _height - 9)
                    {
                        prefabType = _room5_prefab;
                    } else if (x > 13 && x <= 16 && y < _height && y >= _height - 6)
                    {
                        prefabType = _room6_prefab;
                    } else if (x > 16 && x <= 20 && y < _height && y >= _height - 5)
                    {
                        prefabType = _room7_prefab;
                    } else if (x > 20 && x < _width && y < _height && y >= _height - 5) 
                    {
                        prefabType = _room8_prefab;
                    } else if (x > 16 && x <= 20 && y < _height - 5 && y >= _height - 9)
                    {
                        prefabType = _room9_prefab;
                    } else if (x > 20 && x < _width && y < _height - 5 && y >= _height - 9)
                    {
                        prefabType = _room10_prefab;
                    } else if (x > 0 && x <= 4 && y <= 8 && y > 4)
                    {
                        prefabType = _room11_prefab;
                    } else if (x > 4 && x <= 6 && y <= 8 && y > 5) 
                    {
                        prefabType = _room12_prefab;
                    } else if (x > 6 && x <= 8 && y <= 8 && y > 5)
                    {
                        prefabType = _room13_prefab;
                    } else if (x > 0 && x <= 4 && y > 0 && y <= 4)
                    {
                        prefabType = _room14_prefab;
                    } else if (x > 4 && x <= 8 && y > 0 && y <= 5)
                    {
                        prefabType = _room15_prefab;
                    } else if (x > 8 && x <= 11 && y > 0 && y <= 5)
                    {
                        prefabType = _room16_prefab;
                    } else if (x > 13 && x <= 17 && y > 0 && y <= 5)
                    {
                        prefabType = _room17_prefab;
                    } else if (x > 17 && x <= 20 && y > 0 && y <= 4)
                    {
                        prefabType = _room18_prefab;
                    } else if (x > 20 && x < _width && y > 0 && y <= 4)
                    {
                        prefabType = _room19_prefab;
                    } else if (x > 16 && x <=  20 && y > 4 && y <= 8)
                    {
                        prefabType = _room20_prefab;
                    } else if (x > 20 && x < _width && y > 4 && y <= 8)
                    {
                        prefabType = _room21_prefab;
                    } else if (x > 9 && x <= 15 && y < 13 && y > 6)
                    {
                        prefabType = _room22_prefab;
                    }
                    else
                    {
                        prefabType = _tilePrefab;
                    }
                }

                createTitle(prefabType, x, y);

                /* foreach (JSONClass _trap in _traps.AsArray)
                {
                    if (x.Equals(_trap["posX"].AsInt) && y.Equals(_trap["posY"].AsInt))
                    {
                        spawnedTile.IsATrap(true);
                    }
                } */

            }
        }
    }

    IEnumerator GetTraps(string uri, Action doLast)
    {
        using UnityWebRequest webRequest = UnityWebRequest.Get(uri);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log("Error: " + webRequest.error);
        }
        else
        {
            JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(webRequest.downloadHandler.data));
            /* _traps = jsonData; */
        }

        doLast();
    }

}
