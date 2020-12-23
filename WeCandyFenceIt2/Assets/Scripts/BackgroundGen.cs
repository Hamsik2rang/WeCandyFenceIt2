using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGen : MonoBehaviour
{
    static float BG_SIZE = 30.0f;

    public GameObject background;
    GameObject player;

    public LinkedList<Vector2> bgList = new LinkedList<Vector2>();

    float bgGenDelay = 0.2f;
    Vector3 playerPos;
    Vector2 playerGrid;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        Instantiate(background, new Vector3(0, 0, 10), Quaternion.identity);
        bgList.AddLast(new Vector2(0, 0));
        StartCoroutine(BgGenCoroutine());
    }

    IEnumerator BgGenCoroutine()
    {
        while (true)
        {
            bool isOnLeft, isOnRight, isOnTop, isOnBottom;
            bool isAlreadyLeft, isAlreadyRight, isAlreadyTop, isAlreadyBottom;
            bool isAlreadyTopLeft, isAlreadyTopRight, isAlreadyBottomLeft, isAlreadyBottomRight;

            isOnLeft = isOnRight = isOnTop = isOnBottom = false;
            isAlreadyLeft = isAlreadyRight = isAlreadyTop = isAlreadyBottom = false;
            isAlreadyTopLeft = isAlreadyTopRight = isAlreadyBottomLeft = isAlreadyBottomRight = false;

            playerPos = player.transform.position;
            float gridX = (int)playerPos.x / ((int)BG_SIZE / 2) - (int)playerPos.x / (int)BG_SIZE;
            float gridY = (int)playerPos.y / ((int)BG_SIZE / 2) - (int)playerPos.y / (int)BG_SIZE;
            playerGrid = new Vector2(gridX, gridY);
            
            if (playerPos.x <= playerGrid.x * BG_SIZE - (BG_SIZE / 6))
                isOnLeft = true;
            if (playerPos.x >= playerGrid.x * BG_SIZE + (BG_SIZE / 6))
                isOnRight = true;
            if (playerPos.y <= playerGrid.y * BG_SIZE - (BG_SIZE / 6))
                isOnBottom = true;
            if (playerPos.y >= playerGrid.y * BG_SIZE + (BG_SIZE / 6))
                isOnTop = true;

            foreach (var bgGrid in bgList)
            {
                if (bgGrid.x == playerGrid.x - 1 && bgGrid.y == playerGrid.y)
                    isAlreadyLeft = true;
                if (bgGrid.x == playerGrid.x + 1 && bgGrid.y == playerGrid.y)
                    isAlreadyRight = true;
                if (bgGrid.x == playerGrid.x && bgGrid.y == playerGrid.y - 1)
                    isAlreadyBottom = true;
                if (bgGrid.x == playerGrid.x && bgGrid.y == playerGrid.y + 1)
                    isAlreadyTop = true;
                if (bgGrid.x == playerGrid.x - 1 && bgGrid.y == playerGrid.y + 1)
                    isAlreadyTopLeft = true;
                if (bgGrid.x == playerGrid.x + 1 && bgGrid.y == playerGrid.y + 1)
                    isAlreadyTopRight = true;
                if (bgGrid.x == playerGrid.x - 1 && bgGrid.y == playerGrid.y - 1)
                    isAlreadyBottomLeft = true;
                if (bgGrid.x == playerGrid.x + 1 && bgGrid.y == playerGrid.y - 1)
                    isAlreadyBottomRight = true;
            }

            if (isOnLeft && !isAlreadyLeft)
            {
                bgList.AddLast(new Vector2(playerGrid.x - 1, playerGrid.y));
                Instantiate(background, new Vector3((playerGrid.x - 1) * BG_SIZE, playerGrid.y * BG_SIZE, 10), Quaternion.identity);
            }
            if(isOnRight && !isAlreadyRight)
            {
                bgList.AddLast(new Vector2(playerGrid.x + 1, playerGrid.y));
                Instantiate(background, new Vector3((playerGrid.x + 1) * BG_SIZE, playerGrid.y * BG_SIZE, 10), Quaternion.identity);
            }
            if(isOnBottom && !isAlreadyBottom)
            {
                bgList.AddLast(new Vector2(playerGrid.x, playerGrid.y - 1));
                Instantiate(background, new Vector3(playerGrid.x * BG_SIZE, (playerGrid.y - 1) * BG_SIZE, 10), Quaternion.identity);
            }
            if(isOnTop && !isAlreadyTop)
            {
                bgList.AddLast(new Vector2(playerGrid.x, playerGrid.y + 1));
                Instantiate(background, new Vector3(playerGrid.x * BG_SIZE, (playerGrid.y + 1) * BG_SIZE, 10), Quaternion.identity);
            }
            if(isOnTop && isOnLeft && !isAlreadyTopLeft)
            {
                bgList.AddLast(new Vector2(playerGrid.x - 1, playerGrid.y + 1));
                Instantiate(background, new Vector3((playerGrid.x - 1) * BG_SIZE, (playerGrid.y + 1) * BG_SIZE, 10), Quaternion.identity);
            }
            if(isOnTop && isOnRight && !isAlreadyTopRight)
            {
                bgList.AddLast(new Vector2(playerGrid.x + 1, playerGrid.y + 1));
                Instantiate(background, new Vector3((playerGrid.x + 1) * BG_SIZE, (playerGrid.y + 1) * BG_SIZE, 10), Quaternion.identity);
            }
            if (isOnBottom && isOnLeft && !isAlreadyBottomLeft)
            {
                bgList.AddLast(new Vector2(playerGrid.x - 1, playerGrid.y - 1));
                Instantiate(background, new Vector3((playerGrid.x - 1) * BG_SIZE, (playerGrid.y - 1) * BG_SIZE, 10), Quaternion.identity);
            }
            if (isOnBottom && isOnRight && !isAlreadyBottomRight)
            {
                bgList.AddLast(new Vector2(playerGrid.x + 1, playerGrid.y - 1));
                Instantiate(background, new Vector3((playerGrid.x + 1) * BG_SIZE, (playerGrid.y - 1) * BG_SIZE, 10), Quaternion.identity);
            }

            yield return new WaitForSeconds(bgGenDelay);
        }
    }
}
