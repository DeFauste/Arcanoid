using Assets.LoopGame.Scripts.Factory;
using UnityEngine;

namespace Assets.LoopGame.Scripts.Level
{
    public class PrintMap
    {
        int width = 9;
        int height = 10;
        private FactoryCube _factoryCube;
        private System.Random _random = new(100);
        public PrintMap(FactoryCube factoryCube)
        {
            _factoryCube = factoryCube;
        }

        public void PrintNextLevel(Transform startPoint, int lvl)
        {
            float xStep = 0;
            float yStep = 0;
            if(lvl >  _factoryCube.GetCountCube())
            {
                lvl = _factoryCube.GetCountCube();
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    var typeCube = _random.Next()%lvl;
                    var cube = _factoryCube.GetCube((TypeCube)typeCube);
                    if (cube != null)
                    {
                        if(xStep == 0 && yStep == 0)
                        {
                            var bounds = cube.gameObject.GetComponent<BoxCollider2D>().size;
                            xStep = bounds.x;
                            yStep = bounds.y/2;
                        }
                        cube.transform.position = new Vector3(startPoint.position.x + xStep * j, startPoint.position.y - yStep * i, 0);
                    }
                }
            }
        }
    }
}
