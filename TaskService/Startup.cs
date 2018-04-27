using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using System.Web.Cors;

namespace TaskService
{
    public partial class Startup
    {
        // The OWIN middleware will invoke this method when the app starts
        public void Configuration(IAppBuilder app)
        {
            ConfigureCors(app);

            //app.UserCors();
            ConfigureAuth(app);
        }

        private void ConfigureCors(IAppBuilder app)
        {
            var politica = new CorsPolicy();

            politica.AllowAnyHeader = true;
            politica.AllowAnyMethod = true;
            politica.AllowAnyOrigin = true;

            //politica.Origins.Add("http://localhost:40874");
            //politica.Origins.Add("http://localhost:40880");

            politica.Methods.Add("GET");
            politica.Methods.Add("POST");

            var corsOptions = new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(politica)
                }
            };

            app.UseCors(corsOptions);
        }

    }
}
