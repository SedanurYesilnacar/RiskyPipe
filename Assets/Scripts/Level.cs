using System.Collections.Generic;

namespace RiskyPipe3D
{
    public class Level
    {
        public List<Pipe> Pipes { get; private set; }

        public Level(List<Pipe> pipes)
        {
            Pipes = pipes;
        }

        public void LoadLevel()
        {
            if (Pipes.Count < 2) return;
            Pipes[0].SetObject();
            for(int i = 1; i< Pipes.Count; i++)
            {
                Pipes[i].SetObject(Pipes[i - 1]);
            }
        }

        public void EndLevel()
        {
            foreach(Pipe p in Pipes)
            {
                p.Deactive();
            }
        }

        public void StartLevel()
        {
            foreach(Pipe p in Pipes)
            {
                p.Active();
            }
        }
    }
}

