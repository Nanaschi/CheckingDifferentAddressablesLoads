using System;

namespace Scripts.Gameplay.Tiles
{
    [Serializable]
    public class TileItem
    {
        public int Id;
        public string Title;
        public TextureItem PreviewTexture;
        public TextureItem TGHTexture;
        public TextureItem InteractiveMap;
        public ModelItem ModelItem;

    }
}
