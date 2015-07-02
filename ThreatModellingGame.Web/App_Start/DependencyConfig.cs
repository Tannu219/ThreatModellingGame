using Ninject;
using ThreatModellingGame.Core;
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
            kernel.Bind<IGameRepository>().ToConstant(GameRepository.Instance);
            kernel.Bind<ICardDeck>().To<CardDeck>();
            kernel.Bind<IDealer>().To<Dealer>();
        }
    }
}