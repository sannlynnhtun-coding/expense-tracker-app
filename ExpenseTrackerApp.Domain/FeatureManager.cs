using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApp.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseTrackerApp.Domain
{
    public static class FeatureManager
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ExpenseService>();
        }
    }
}
