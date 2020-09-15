using System;
using System.Collections.Generic;

namespace RiskyPipe3D
{
    public static class Extensions
    {
        public static BasePipe GetPipe(this List<BasePipe> pipes, PipeType pipeType)
        {
            foreach(BasePipe pipe in pipes)
            {
                
                    return pipe;
                
            }
            return pipes[0];
        }

        public static BasePipe GetRandomPipe(this List<BasePipe> pipes)
        {
            Random rand = new Random();
            BasePipe pipe = pipes[rand.Next(pipes.Count)];
            
            return pipe;
        }
    }
}
