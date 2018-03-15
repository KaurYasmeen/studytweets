using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudyTweets.Startup))]
namespace StudyTweets
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
