using System.Collections.Generic;
using UnityEngine;

namespace GameEngine.UI
{
    public class RecycleScrollView : RecycleScrollViewBase<QuestCellModel>
    {
        [SerializeField] private float cellSize;
        [SerializeField] private GameObject cellPrefab;

        protected override float CellSize => cellSize;

        protected override GameObject CellPrefab => cellPrefab;

        private void Start()
        {
            Initialize();
            Context.OnClickCell += OnClickClaimButton;
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

        private void OnClickClaimButton(string msg)
        {
            Debug.Log($"[RecycleScrollView] : {msg}");
        }
    }
}