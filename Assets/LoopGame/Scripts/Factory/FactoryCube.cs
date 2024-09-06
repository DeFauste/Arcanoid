using Assets.LoopGame.Scripts.Cube;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Factory
{
    public enum TypeCube
    {
        Ordinary,
        DensityLite,
        DensityMiddle,
        DensityHard
    }
    public class FactoryCube
    {
        private Dictionary<string, GameObject> _cubs = new Dictionary<string, GameObject>();
        private GameProperty _gameProperty;
        public int GetCountCube() => _cubs.Count;
        public FactoryCube(GameProperty gameProperty)
        {
            _gameProperty = gameProperty; 
        }

        public void LoadPref()
        {
            var prefs = Resources.LoadAll<GameObject>("Prefabs/Cubs/");
            foreach (var pref in prefs)
            {
                _cubs.Add(pref.name, pref);
                Debug.Log(pref.name);
            }
        }
    
        public GameObject GetCube(TypeCube type)
        {
            GameObject cube = null;
            if(type == TypeCube.Ordinary)
            {
                cube = CreateOrdinary();
            } else if(type == TypeCube.DensityLite)
            {
                cube = CreateDensityLite();
            }
            else if (type == TypeCube.DensityMiddle)
            {
                cube = CreateDensityMiddle();
            }
            else if (type == TypeCube.DensityHard)
            {
                cube = CreateDensityHard();
            }

            return cube;
        }

        private GameObject CreateOrdinary()
        {
            var pref = _cubs["Ordinary"];
            var obj = GameObject.Instantiate(pref);
            var cube = obj.GetComponent<BaseCube>();
            cube.Construct(_gameProperty);
            return obj;
        }

        private GameObject CreateDensityLite()
        {
            var pref = _cubs["DensityLite"];
            var obj = GameObject.Instantiate(pref);
            var cube = obj.GetComponent<BaseCube>();
            cube.Construct(_gameProperty);
            return obj;
        }

        private GameObject CreateDensityMiddle()
        {
            var pref = _cubs["DensityMiddle"];
            var obj = GameObject.Instantiate(pref);
            var cube = obj.GetComponent<BaseCube>();
            cube.Construct(_gameProperty);
            return obj;
        }
        private GameObject CreateDensityHard()
        {
            var pref = _cubs["DensityHard"];
            var obj = GameObject.Instantiate(pref);
            var cube = obj.GetComponent<BaseCube>();
            cube.Construct(_gameProperty);
            return obj;
        }
    }
}
