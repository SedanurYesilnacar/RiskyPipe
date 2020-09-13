using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace RiskyPipe3D
{
    public class LevelFactory
    {
        private List<GameObject> _pipeObjects;

        public List<Pipe> Pipes { get; private set; }

        public LevelFactory()
        {
            Pipes = new List<Pipe>();
            _pipeObjects = Resources.LoadAll<GameObject>("Pipes").ToList();
            foreach(GameObject obj in _pipeObjects)
            {
                Pipes.Add(obj.GetComponent<Pipe>());
            }
        }

        public Level GetNewLevel(int length)
        {
            int c = 0;
            List<Pipe> pipes = new List<Pipe>();
            Pipe pipe = Pipes.GetPipe(PipeType.NormalPipe);
            pipes.Add(pipe);
            Pipe divisionPipe = Pipes.GetPipe(PipeType.MidRightPipe);
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
                pipes[i] = gameObject.GetComponent<Pipe>();
            }

            return new Level(pipes);
        }

    }

}

