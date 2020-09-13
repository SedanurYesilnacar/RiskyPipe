using System;
using System.Collections.Generic;

namespace RiskyPipe3D
{
    public static class Extensions
    {
        public static Pipe GetPipe(this List<Pipe> pipes, PipeType pipeType)
        {
            foreach(Pipe pipe in pipes)
            {
                if(pipe.Type.Equals(pipeType))
                {
                    return pipe;
                }
            }
            return pipes[0];
        }

        public static Pipe GetRandomPipe(this List<Pipe> pipes)
        {
            Random rand = new Random();
            Pipe pipe = pipes[rand.Next(pipes.Count)];
            while (!pipe.IsMid)
            {
                pipe = pipes[rand.Next(pipes.Count)];
            }
            return pipe;
        }
    }
}
