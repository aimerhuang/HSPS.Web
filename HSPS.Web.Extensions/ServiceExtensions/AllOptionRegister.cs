using HSPS.Web.Common;
using HSPS.Web.Common.Option.Core;
using Microsoft.Extensions.DependencyInjection;

namespace HSPS.Web.Extensions.ServiceExtensions;

public static class AllOptionRegister
{
    public static void AddAllOptionRegister(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        foreach (var optionType in App.EffectiveTypes.Where(s =>
                     !s.IsInterface && typeof(IConfigurableOptions).IsAssignableFrom(s)))
        {
            services.AddConfigurableOptions(optionType);
        }
    }
}
