using Assets.LoopGame.Scripts.Baff;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Factory
{
    public class FactoryBaff
    {
        private GameObject[] _baffs;
        private GameProperty _gameProperty;
        public int GetCountBaff() => _baffs.Length;
        public FactoryBaff(GameProperty gameProperty)
        {
            _gameProperty = gameProperty;
        }

        public void LoadPref()
        {
            _baffs = Resources.LoadAll<GameObject>("Prefabs/Baff/");
        }

        public GameObject CreateRandomBaff(Vector2 position)
        {
            int random = Random.Range(0, _baffs.Length);
            var baff = GameObject.Instantiate(_baffs[random]);
            baff.GetComponent<BaseBaff>().Construct(_gameProperty);
            baff.transform.position = position;
            return baff;
        }
    }
}
