using UnityEngine.UI;
using UnityEngine;

namespace GameEngine.UI
{
    public class QuestCellModel
    {
        public string title;
        public string desc;
    }

    public class RecycleScrollCell : RecycleScrollCellBase<QuestCellModel>
    {
        [SerializeField] private Text title;
        [SerializeField] private Text desc;

        public override void UpdateContent(QuestCellModel item)
        {
            title.text = item.title;
            desc.text = item.desc;
        }
    }
}