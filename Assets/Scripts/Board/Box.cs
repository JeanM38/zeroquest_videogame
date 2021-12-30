using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Box : MonoBehaviour
{
    [SerializeField] private GameObject _highlight;
/*    private GameObject hero;
    public static bool isMoving = false;
    PhotonView view;*/

/*    private void Start()
    {
        hero = GameObject.Find($"/{StateNameController.characterName}");
        view = hero.GetComponent<PhotonView>();
    }*/

    void OnMouseEnter()
    {
        _highlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _highlight.SetActive(false);
    }

/*    void OnMouseDown()
    {
        if (view.IsMine && !isMoving && hero.transform.position != new Vector3(this.transform.position.x, 0.5f, this.transform.position.z))
        {
            isMoving = true;
        } else
        {
            isMoving = false;
        }
    }

    void Update()
    {
        if (isMoving)
        {
            hero.transform.position = Vector3.MoveTowards(hero.transform.position, new Vector3(this.transform.position.x, 0.5f, this.transform.position.z), 0.5f);
        }
    }*/
}
