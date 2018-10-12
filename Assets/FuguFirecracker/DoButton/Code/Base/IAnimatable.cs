namespace FuguFirecracker.UI
{
    public interface IAnimatable
    {
        void OnDown(DoButton doButton);
        void OnUp(DoButton doButton);
        void OnEnter(DoButton doButton);
        void OnExit(DoButton doButton);
    }
}