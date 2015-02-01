using Nancy;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace NancyTransactionTest
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {

        protected override void ConfigureRequestContainer(TinyIoCContainer container, NancyContext context)
        {
            TinyIocConfig.Config(container);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            pipelines.OnError += (ctx, ex) =>
            {
                return null;
            };
        }
    }
}