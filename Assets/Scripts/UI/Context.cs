using System;
using UnityEngine.Events;

namespace GameEngine.UI
{
    public class Context
    {
        public int Index { get; set; }
        public UnityAction<string> OnClickCell;
    }
}