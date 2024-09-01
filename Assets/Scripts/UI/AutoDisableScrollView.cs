using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameEngine.UI
{
    public class AutoDisableScroll : AutoDisableScrollViewBase<QuestCellModel>
    {
        [SerializeField] private float cellSize;

        protected override float CellSize => cellSize;
        
        private void Awake()
        {
            Initialize();
            UpdateContent(GetList());
        }

        private List<QuestCellModel> GetList()
        {
            List<QuestCellModel> list = new();
            for (int i = 1; i <= 200; i++)
            {
                list.Add(new() { title = $"TITLE_{i}", desc = $"DESC_{i}" });
            }

            return list;
        }
    }
}