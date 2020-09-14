using StardewModdingAPI;

namespace BuildOnAnyTile
{
    class Config
    {
        public SButton debugKey { get; set; }

        public Config()
        {
            debugKey = SButton.J;
        }
    }
}
