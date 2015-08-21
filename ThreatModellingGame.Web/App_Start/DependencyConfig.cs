using Ninject;
using ThreatModellingGame.Core.Factories;
using ThreatModellingGame.Core.Repositories;
using ThreatModellingGame.Core.Web;

namespace ThreatModellingGame.Web
{
    public static class DependencyConfig
    {
        public static void Setup(IKernel kernel)
        {
            kernel.Bind<ICookieManager>().To<CookieManager>();
            kernel.Bind<ICardRepository>().To<CardRepository>();
            kernel.Bind<IGameRepository>().To<InMemoryGameRepository>();
            kernel.Bind<ICardDeckFactory>().To<CardDeckFactory>();
            kernel.Bind<IGameFactory>().To<GameFactory>();
        }
    }
}