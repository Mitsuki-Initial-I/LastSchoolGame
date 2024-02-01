using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainScenes
{
    public class Gimmick_MoveObject : BaseGimmick
    {
        int moveDir = -1;
        float vecLength = 0.5f;
        Vector2 rayPosition;
        RaycastHit2D hit;
        public LayerMask layerMask;
        LayerMask defaultlayer;
        enum Move_dir
        {
            right,
            left,
            up,
            down
        }

        private void Start()
        {
            defaultlayer = gameObject.layer;
        }
        public override void UseGimmick()
        {
            switch (moveDir)
            {
                case (int)Move_dir.left:
                    rayPosition = (Vector2)transform.position + new Vector2(0.5f, 0.0f);
                    Debug.DrawRay(rayPosition, Vector2.right * vecLength, Color.red,2f);
                    hit = Physics2D.Raycast(rayPosition, Vector2.right, vecLength, layerMask);
                    if (hit)
                    {
                        Debug.Log(hit.collider.tag);
                        if((hit.collider.tag != "wall"&& hit.collider.tag != "moveObj"))
                        {
                            transform.position = (Vector2)transform.position + Vector2.right;
                        }
                    }
                    else
                    {
                        transform.position = (Vector2)transform.position + Vector2.right;
                    }
                    break;                
                case (int)Move_dir.right:
                    rayPosition = (Vector2)transform.position + new Vector2(-0.5f, 0.0f);
                    Debug.DrawRay(rayPosition, Vector2.left * vecLength, Color.red, 2f);
                    hit = Physics2D.Raycast(rayPosition, Vector2.left, vecLength, layerMask);
                    if (hit)
                    {
                        if (hit.collider.tag != "wall" && hit.collider.gameObject.layer != 6)
                        {
                            transform.position = (Vector2)transform.position + Vector2.left;
                        }
                    }
                    else
                    {
                        transform.position = (Vector2)transform.position + Vector2.left;
                    }
                    break;                
                case (int)Move_dir.up:
                    rayPosition = (Vector2)transform.position + new Vector2(0.0f, -0.5f);
                    Debug.DrawRay(rayPosition, Vector2.down * vecLength, Color.red, 2f);
                    hit = Physics2D.Raycast(rayPosition, Vector2.down, vecLength, layerMask);
                    if (hit)
                    {
                        if (hit.collider.tag != "wall" && hit.collider.gameObject.layer != 6)
                        {
                            transform.position = (Vector2)transform.position + Vector2.down;
                        }
                    }
                    else
                    {
                        transform.position = (Vector2)transform.position + Vector2.down;
                    }
                    break;                
                case (int)Move_dir.down:
                    rayPosition = (Vector2)transform.position + new Vector2(0.0f, 0.5f);
                    Debug.DrawRay(rayPosition, Vector2.up * vecLength, Color.red, 2f);
                    hit = Physics2D.Raycast(rayPosition, Vector2.up, vecLength, layerMask);
                    if (hit)
                    {
                        if (hit.collider.tag != "wall" && hit.collider.gameObject.layer != 6)
                        {
                            transform.position = (Vector2)transform.position + Vector2.up;
                        }
                    }
                    else
                    {
                        transform.position = (Vector2)transform.position + Vector2.up;
                    }
                    break;
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.gameObject.CompareTag("Player"))
                {
                    gameObject.layer = defaultlayer;
                }
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                gameObject.layer = 0;
                Vector2 playerPos = collision.transform.position;
                if (playerPos.x+0.05<transform.position.x-transform.localScale.x/2 && playerPos.y-1< transform.position.y + transform.localScale.y / 2&& playerPos.y+0.2 > transform.position.y - transform.localScale.y / 2)
                {
                    moveDir = (int)Move_dir.left;
                }
                else if (playerPos.x - 0.05 > transform.position.x + transform.localScale.x / 2 && playerPos.y - 1 < transform.position.y + transform.localScale.y / 2 && playerPos.y + 0.2 > transform.position.y - transform.localScale.y / 2)
                {
                    moveDir = (int)Move_dir.right;
                }
                else if(playerPos.x + 0.05 > transform.position.x - transform.localScale.x / 2 && playerPos.x - 0.05 < transform.position.x + transform.localScale.x / 2 && playerPos.y - 1 > transform.position.y + transform.localScale.y / 2)
                {
                    moveDir = (int)Move_dir.up;
                }
                else
                {
                    moveDir = (int)Move_dir.down;
                }
            }
        }
    }
}
