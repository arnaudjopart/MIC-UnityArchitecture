using Controllers;
using Entities;
using Gateways;
using UnityEngine;
using UseCases;
using Zenject;

public class SceneInstaller : MonoInstaller
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private PointController m_pointPrefab;

    public override void InstallBindings()
    {
        var profile = new PlayerProfile("John Doe");
        var playerProfileGateway = new PlayerProfileGateway(profile);
        var playerProfileUserCase = new UserProfileUseCase(playerProfileGateway);
        var controller = m_player.AddComponent<PlayerMovementController>();
        var scoreController = new PlayerScoreController(playerProfileUserCase);
        controller.Impulse = 1;
        controller.Initialize(playerProfileUserCase);
        
        Container.Bind<IPlayerShipController>().FromInstance(controller);
        Container.Bind<IUserProfileUseCase>().FromInstance(playerProfileUserCase);
        Container.Bind<IScoreController>().FromInstance(scoreController);
        Container.BindFactory<IUserProfileUseCase,PointController,PointController.Factory>().FromComponentInNewPrefab(m_pointPrefab);
    }
}
