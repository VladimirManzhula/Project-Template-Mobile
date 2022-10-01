namespace Core.Services.Scenes
{
    public readonly struct ScenePlace
    {
        public static readonly ScenePlace Splash = new ScenePlace("Splash");
        public static readonly ScenePlace Game = new ScenePlace("Game");

        public readonly string Value;

        public ScenePlace(string value)
        {
            Value = value;
        }

        public override string ToString() => Value;
    }
}