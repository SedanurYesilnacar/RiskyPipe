namespace RiskyPipe3D.Extensions
{
    using RiskyPipe3D.Enums;
    using RiskyPipe3D.LevelDynamics;
    using System;
    using System.Collections.Generic;

    public static class Extensions
    {
        public static Pipe GetPipe(this List<Pipe> pipes, PipeType pipeType)
        {
            foreach (Pipe pipe in pipes)
            {
                if (pipe.PipeType.Equals(pipeType))
                {
                    return pipe;
                }
            }
            return pipes[0];
        }

        public static Pipe GetDirectionPipe(this List<Pipe> pipes)
        {
            List<Pipe> diretionPipes = new List<Pipe>();
            foreach(Pipe p in pipes)
            {
                if (p.PipeType.Equals(PipeType.VerticalLeft) || p.PipeType.Equals(PipeType.VerticalRight))
                    diretionPipes.Add(p);
            }
            return diretionPipes[new Random().Next(diretionPipes.Count)];
        }
    }
}
