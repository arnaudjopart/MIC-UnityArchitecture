namespace _Project.Scripts.Gateways
{
    public interface IPlayerProfileGateway
    {
        void UpdateScore(int _point);
        int GetCurrentScore();
    }
}