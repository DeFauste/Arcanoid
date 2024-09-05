namespace Assets.LoopGame.Scripts.Cube
{
    internal interface IHealth
    {
        int GetHealth();
        void AddHealth(int value);
        void SubHealth(int value);
    }
}