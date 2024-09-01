using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

namespace GameEngine.UI
{
    public abstract class RecycleScrollViewBase<T> : MonoBehaviour
    {
        private ScrollRect scrollRect;
        private IList<RecycleScrollCellBase<T>> poolList = new List<RecycleScrollCellBase<T>>();
        private IList<T> dataList;
        private Vector2 prevScrollDirection;

        protected abstract float CellSize { get; }
        protected abstract GameObject CellPrefab { get; }

        protected virtual void Initialize()
        {
            CellPrefab.gameObject.SetActive(false);
            scrollRect = GetComponent<ScrollRect>();
            scrollRect.onValueChanged.AddListener(OnScrollChanged);
        }
        
        private void OnScrollChanged(Vector2 scrollDirection)
        {
            UpdateCells((scrollDirection.y < prevScrollDirection.y) ? 1 : -1);
            prevScrollDirection = scrollDirection;
        }

        private void UpdateCells(int scrollDirection)
        {
            //위로 스크롤 할 때
            if (scrollDirection > 0)
            {
                var firstCell = poolList[0];
                var lastCell = poolList[poolList.Count - 1];

                if (firstCell.Bottom.y > -scrollRect.content.anchoredPosition.y && 
                    lastCell.Index + 1 < dataList.Count)
                {
                    firstCell.Top = lastCell.Bottom;
                    firstCell.Index = lastCell.Index + 1;

                    UpdateCell(firstCell, dataList[lastCell.Index + 1]);

                    poolList.Insert(poolList.Count, firstCell);
                    poolList.RemoveAt(0);
                }
            }
            //아래로 스크롤  할 때
            else if(scrollDirection < 0)
            {
                var firstCell = poolList[0];
                var lastCell = poolList[poolList.Count - 1];
                
                if (lastCell.Top.y < -scrollRect.content.anchoredPosition.y - scrollRect.viewport.rect.height &&
                    firstCell.Index - 1 >= 0)
                {
                    lastCell.Bottom = firstCell.Top;
                    lastCell.Index = firstCell.Index - 1;

                    UpdateCell(lastCell, dataList[firstCell.Index - 1]);
                    
                    poolList.Insert(0, lastCell);
                    poolList.RemoveAt(poolList.Count - 1);
                }
            }
        }

        protected void UpdateContent(IList<T> list)
        {
            dataList = list;
            var scrollRectSizeDelta = scrollRect.GetComponent<RectTransform>().sizeDelta;

            int index = 0;
            for (float i = 0f; i <= scrollRectSizeDelta.y + CellSize; i += CellSize)
            {
                var cell = CreateCell();
                cell.Index = index;
                cell.Top = Vector2.down * index * CellSize;

                UpdateCell(cell, list[index]);
                index += 1;
            }
            
            UpdateContentSize(list.Count);
        }
        
        private void UpdateContentSize(int dataCount)
        {
            float contentHeight = dataCount * CellSize;
            Vector2 sizeDelta = scrollRect.content.sizeDelta;
            sizeDelta.y = contentHeight;
            scrollRect.content.sizeDelta = sizeDelta;
        }
        
        private RecycleScrollCellBase<T> CreateCell()
        {
            GameObject obj = Instantiate(CellPrefab);

            if (obj.TryGetComponent<RecycleScrollCellBase<T>>(out var cell) == false)
            {
                Debug.LogError("Cell Component could not found.");
                return null;
            }

            cell.SetVisible(true);
            cell.MyTransform.SetParent(scrollRect.content.transform, false);
            poolList.Add(cell);

            return cell;
        }
        
        private void UpdateCell(RecycleScrollCellBase<T> cell, T data)
        {
            cell.UpdateContent(data);
        }
    }
}