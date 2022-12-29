using LittleBlocks.AspNetCore;
using LittleBlocks.Logging.SeriLog.Loggly;
using LittleBlocks.Logging.SeriLog.Seq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace LittleBlocks.Template.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostAsWeb.Run<Startup>(
                s =>
                {
                    return s.Environment.IsDevelopment()
                        ? s.ConfigureLogger<Startup>(c => c.UseSeq(s.Configuration.GetSection("Logging:Seq")))
                        : s.ConfigureLogger<Startup>(c => c.UseLoggly(s.Configuration.GetSection("Logging:Loggly")));
                }, args);
        }
    }
}