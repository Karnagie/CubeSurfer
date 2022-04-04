using UnityEngine;

namespace WayEssence
{
    public interface IWay
    {
        Vector3[] Positions { get; }

        void Next();
    }
}