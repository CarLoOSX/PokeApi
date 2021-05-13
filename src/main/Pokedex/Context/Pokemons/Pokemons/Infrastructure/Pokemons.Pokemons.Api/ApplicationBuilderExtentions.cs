using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Pokemons.Pokemons.Api
{
    public static class ApplicationBuilderExtentions
    {
        //the simplest way to store a single long-living object, just for example.
        private static NotifyPokemonOnAddedToFavouriteListener _listener { get; set; }

        public static IApplicationBuilder UseRabbitListeners(this IApplicationBuilder app)
        {
            _listener = app.ApplicationServices.GetService<NotifyPokemonOnAddedToFavouriteListener>();

            var lifetime = app.ApplicationServices.GetService<IApplicationLifetime>();

            lifetime.ApplicationStarted.Register(OnStarted);

            //press Ctrl+C to reproduce if your app runs in Kestrel as a console app
            lifetime.ApplicationStopping.Register(OnStopping);

            return app;
        }

        private static void OnStarted()
        {
            _listener.Register();
        }

        private static void OnStopping()
        {
            _listener.Deregister();    
        }
    }
}