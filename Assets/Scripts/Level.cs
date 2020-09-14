using System.Collections.Generic;

namespace RiskyPipe3D
{
    public class Level
    {
        public List<LevelObject> LevelObjects { get; private set; }

        public Level(List<LevelObject> levelObjects)
        {
            LevelObjects = levelObjects;
        }

        public void LoadLevel()
        {
            if (LevelObjects.Count < 2) return;
            LevelObjects[0].SetObject();
            for(int i = 1; i< LevelObjects.Count; i++)
            {
                LevelObjects[i].SetObject(LevelObjects[i - 1]);
            }
        }

        public void EndLevel()
        {
            foreach(LevelObject p in LevelObjects)
            {
                p.Deactive();
            }
        }

        public void StartLevel()
        {
            foreach(LevelObject p in LevelObjects)
            {
                p.Active();
            }
        }
    }
}

