using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace  Battleship
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private int[,] grid = new int[,]
        {
            { 1,1,0,0,1 },
            { 0,0,0,0,0 },
            { 0,0,1,0,1 },
            { 1,0,1,0,0 },
            { 1,0,1,0,0 }
        };

        private bool[,] hits;

        //Total number of rows and colums
        private int nRows;
        private int nCols;

        // Current colum/row we are on
        private int row;
        private int col;
        private int score;
        private int time;

        [SerializeField] Transform gridRoot;

        //Template used to populate the grid
        [SerializeField] GameObject cellPrefab;
        [SerializeField] GameObject winLabel;
        [SerializeField] TextMeshProUGUI timeLabel;
        [SerializeField] TextMeshProUGUI scoreLabel;

        //Initialize the variables and builts out the grid
        private void Awake()
        {
            nRows = grid.GetLength(0);
            nCols = grid.GetLength(1);

            hits = new bool[nRows, nCols];

            for(int i = 0; i < nRows * nCols; i++)
            {
                Instantiate(cellPrefab, gridRoot);
            }

            SelectCurrentCell();
            InvokeRepeating("IncrementTime", 1f, 1f);
        }


        //Selects cells and navigate the gameboard
        Transform GetCurrentCell()
        {
            int index = (row * nCols) + col;
            
            return gridRoot.GetChild(index);
        }
        // Below functions, selects and unselects a cell
        void SelectCurrentCell()
        {
            Transform cell = GetCurrentCell();

            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(true);
        }

        void UnselectObjectCell()
        {
            Transform cell = GetCurrentCell();

            Transform cursor = cell.Find("Cursor");
            cursor.gameObject.SetActive(false);
        }

        public void MoveHorizontal(int amt)
        {
            UnselectObjectCell();

            col += amt;

            col = Mathf.Clamp(col, 0, nCols - 1);

            SelectCurrentCell();

        }


        public void MoveVertical(int amt)
        {
            UnselectObjectCell();

            row += amt;

            row = Mathf.Clamp(row, 0, nRows - 1);

            SelectCurrentCell();

        }

        //Functions gets the current cell, look for correct image and turn it on
        void ShowHit()
        {
            Transform cell = GetCurrentCell();

            Transform hit = cell.Find("Hit");
            hit.gameObject.SetActive(true);
        }

        void ShowMiss()
        {
            Transform cell = GetCurrentCell();

            Transform miss = cell.Find("Miss");
            miss.gameObject.SetActive(true);
        }


        void IncrementScore()
        {
            score++;
            scoreLabel.text = string.Format("Score: {0}", score);
        }

        //Fire button: looks if the cell already been fired, if not, it sets the bool in the hits 2D array to true,
        //checks if cell is a ship or open water in the frid 2D array, if its a ship then fuction will hit and increment score
        public void Fire()
        {
            if (hits[row, col]) return;
            hits[row, col] = true;

            if  (grid[row, col] == 1)
            {
                ShowHit();
                IncrementScore();
            }

            else
            {
                ShowMiss();
            }
        }

        void IncrementTime()
        {
            time++;

            timeLabel.text = string.Format("{0}:{1}", time / 60, (time % 60).ToString("00"));
        }

        void TryEndGame()
        {
           for (int row= 0; row < nRows; row++)
            {
                for (int col = 0; col < nCols; col++)
                {
                    if (grid[row, col] == 0) continue;

                    if (hits[row, col] == false) return;
                }
           }

            winLabel.SetActive(false);

            CancelInvoke("IncrementTime");

        }

      

    }
}
