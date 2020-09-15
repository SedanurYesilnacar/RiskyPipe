using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace RiskyPipe3D
{
    public class LevelFactory
    {
        private List<GameObject> _pipeObjects;

        public List<BasePipe> Pipes { get; private set; }

        public LevelFactory()
        {
            Pipes = new List<BasePipe>();
            _pipeObjects = Resources.LoadAll<GameObject>("Pipes").ToList();
            foreach(GameObject obj in _pipeObjects)
            {
                Pipes.Add(obj.GetComponent<BasePipe>());
            }
        }

        public Level GetNewLevel(int length)
        {
            int c = 0;
            List<BasePipe> pipes = new List<BasePipe>();
            BasePipe pipe = Pipes.GetPipe(PipeType.NormalPipe);
            pipes.Add(pipe);
            BasePipe divisionPipe = Pipes.GetPipe(PipeType.MidRightPipe);
            pipes.Add(divisionPipe);
            for(int i = 0; i < 5; i++)
            {
                pipes.Add(Pipes.GetPipe(PipeType.NormalRightPipe));
            }

            pipes.Add(Pipes.GetPipe(PipeType.MidNormalPipe));

            for(int i = 0; i< 5; i++)
            {
                pipes.Add(Pipes.GetPipe(PipeType.NormalPipe));
            }

            for(int i = 0; i< pipes.Count; i++)
            {
                GameObject gameObject = MonoBehaviour.Instantiate(pipes[i].gameObject);
                pipes[i] = gameObject.GetComponent<BasePipe>();
            }

            return new Level(pipes);
        }

    }

}

