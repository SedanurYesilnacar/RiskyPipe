using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace RiskyPipe3D
{
    enum Direction
    {
        Left,
        Right
    };
    public class LevelFactory
    {
        private List<GameObject> _pipeObjects;
        private List<GameObject> _trapObjects;

        public List<Pipe> Pipes { get; private set; }
        public List<Trap> Traps { get; private set; }

        public LevelFactory()
        {
            Pipes = new List<Pipe>();
            Traps = new List<Trap>();
            _pipeObjects = Resources.LoadAll<GameObject>("Pipes").ToList();
            _trapObjects = Resources.LoadAll<GameObject>("Traps").ToList();
            foreach (GameObject obj in _pipeObjects)
            {
                Pipes.Add(obj.GetComponent<Pipe>());
            }
            foreach (GameObject obj in _trapObjects)
            {
                Traps.Add(obj.GetComponent<Trap>());
            }
        }

       

        public Level GetNewLevel(int length)
        {

            List<Pipe> pipes = new List<Pipe>();
            List<Trap> traps = new List<Trap>();
            byte hasMadeLeftCount = 0;
            byte hasMadeRightCount = 0;
            byte maxReturnCount = 1;
            byte loopCount = 0;


            //Başlangıçta random sayı kadar boru ekleniyor.
            #region Start Pipes           
            byte randomPipeCount = (byte)Random.Range(5, 8);
            for (byte i = 0; i < randomPipeCount; i++)
            {
                GameObject gameObject = MonoBehaviour.Instantiate(Pipes.GetPipe(PipeType.NormalPipe).gameObject);
                pipes.Add(gameObject.GetComponent<Pipe>());
            }
            #endregion

            //Level oluşumundaki logic işlemlerini içeren döngü
            #region Level Loop
            while (pipes.Count < length)
            {
                //Üst üste sağa veya sola dönebileceği sayıyı 10 adımda bir 2'ye çıkartıyoruz ki biraz daha dağınık görünüm elde edelim.
                #region Set return count limit
                loopCount++;

                if (loopCount % 10 == 0)
                    maxReturnCount = 2;
                else
                    maxReturnCount = 1;
                #endregion

                //Bu region içinde boru yönünün sağa mı yoksa sola mı gideceğini karar veren logic var.
                #region Direction Choosing
                Direction direction = GetRandomDirection();
                if (direction == Direction.Left)
                {
                    if(hasMadeLeftCount < maxReturnCount)
                    {
                        pipes.Add(Pipes.GetPipe(PipeType.MidLeftPipe));
                        hasMadeLeftCount++;
                        hasMadeRightCount = 0;
                    }
                    else
                    {
                        pipes.Add(Pipes.GetPipe(PipeType.MidRightPipe));
                        hasMadeRightCount++;
                        hasMadeLeftCount = 0;
                    }
                   
                }
                else
                {
                    if (hasMadeRightCount < maxReturnCount)
                    {
                        pipes.Add(Pipes.GetPipe(PipeType.MidRightPipe));
                        hasMadeRightCount++;
                        hasMadeLeftCount = 0;
                    }
                    else
                    {
                        pipes.Add(Pipes.GetPipe(PipeType.MidLeftPipe));
                        hasMadeLeftCount++;
                        hasMadeRightCount = 0;
                    }
                }
                GameObject returnPipe = MonoBehaviour.Instantiate(pipes.Last().gameObject);
                pipes[pipes.Count - 1] = returnPipe.GetComponent<Pipe>();
                #endregion


                //Sağ veya sol yönelime karar verilen boruların devamında gelecek düz boruların eklendiği region.
                #region Continious Pipes
                randomPipeCount = (byte)Random.Range(6, 11);
                byte trapStartIndex = (byte)Random.Range(2, randomPipeCount - 1);
                for (byte i = 0; i < randomPipeCount; i++)
                {
                    GameObject gameObject = MonoBehaviour.Instantiate(Pipes.GetPipe(PipeType.NormalPipe).gameObject);
                    pipes.Add(gameObject.GetComponent<Pipe>());
                    if(trapStartIndex == i)
                    {
                        GameObject trapObj = MonoBehaviour.Instantiate(Traps.GetRandomTrap().gameObject, gameObject.transform);
                        traps.Add(trapObj.GetComponent<Trap>());
                    }
                    
                }
                #endregion
            }
            #endregion

            //for (int i = 0; i < pipes.Count; i++)
            //{
            //    GameObject gameObject = MonoBehaviour.Instantiate(pipes[i].gameObject);
            //    pipes[i] = gameObject.GetComponent<Pipe>();
            //}
            List<LevelObject> levelObjects = new List<LevelObject>();
            foreach(Pipe pipe in pipes)
            {
                levelObjects.Add(pipe);
            }
            foreach (Trap trap in traps)
            {
                levelObjects.Add(trap);
            }
            return new Level(levelObjects);
        }
        private Direction GetRandomDirection()
        {
            return Random.Range(0, 2) == 0 ? Direction.Left : Direction.Right;
        }

        

    }

}

