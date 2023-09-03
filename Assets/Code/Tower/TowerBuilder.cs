using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BouncingBall
{
    /// <summary>
    /// Класс с логикой для создания башни
    /// </summary>
    public class TowerBuilder : MonoBehaviour
    {
        [SerializeField] private Base cellsBase;
        [Space]
        [SerializeField] private Cell cell_1m_Prefab;
        [SerializeField] private Cell cell_05m_Prefab;
        [SerializeField] private Cell cell_025m_Prefab;

        [SerializeField] private Base myBase;
        public bool TowerCreated => myBase != null;

        private Cell lastCell = null;

        public void BuildTowerBase()
        {
            GameObject tower = new();
            tower.transform.position = new Vector3(4, 2, 4);
            tower.name = "Tower";

            myBase = Instantiate(cellsBase, tower.transform);
        }

        public void AddCell(TowerCellType newCell)
        {
            Cell cell = new();

            switch (newCell)
            {

                case TowerCellType.One:

                    cell = Instantiate(cell_1m_Prefab);

                break;

                case TowerCellType.ZeroFive:

                    cell = Instantiate(cell_05m_Prefab);

                break;

                case TowerCellType.ZeroTwentyFive:

                    cell = Instantiate(cell_025m_Prefab);

                break;

                default:

                    cell = Instantiate(cell_1m_Prefab);

                break;
            }

            if (lastCell == null)
            {
                Debug.Log("base");

                if (cell == null) Debug.Log("cell null");
                if (myBase == null) Debug.Log("myBase null");

                cell.transform.position = myBase.Attach.position;
                cell.transform.SetParent(myBase.Attach);

                lastCell = cell;
            }
            else
            {
                Debug.Log("to cell");

                cell.transform.position = lastCell.TopAttach.position;

                cell.transform.SetParent(myBase.Attach);

                lastCell = cell;
            }

        }
    }

    public enum TowerCellType
    {
        One,
        ZeroFive,
        ZeroTwentyFive
    }
}