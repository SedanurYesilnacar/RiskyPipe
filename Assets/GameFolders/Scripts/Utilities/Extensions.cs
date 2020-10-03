namespace RiskyPipe3D.Extensions
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.LevelDynamics;
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static BasePipe GetPipe(this List<BasePipe> pipes, PipeType pipeType)
        {
            foreach (BasePipe pipe in pipes)
            {
                if (pipe.PipeType.Equals(pipeType))
                {
                    return pipe;
                }
            }
            return pipes[0];
        }

        public static BasePipe GetDirectionPipe(this List<BasePipe> pipes)
        {
            List<BasePipe> diretionPipes = new List<BasePipe>();
            foreach(BasePipe p in pipes)
            {
                if (p.PipeType.Equals(PipeType.VerticalLeft) || p.PipeType.Equals(PipeType.VerticalRight))
                    diretionPipes.Add(p);
            }
            return diretionPipes[new Random().Next(diretionPipes.Count)];
        }

        public static int GetMidPipeIndex(this List<BasePipe> pipes, int currentIndex)
        {
            for(int i = currentIndex; i < pipes.Count; i++)
            {
                if(pipes[i] as MidPipe)
                {
                    return i;
                }
            }
            return -1;

        }
    }
}
