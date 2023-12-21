using WebApplication2.Models;

namespace WebApplication2.Data
{
    public class BancoSeed
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<WebApplication2Context>();
                context.Database.EnsureCreated();
                if (!context.Jogador.Any())
                {
                    context.Jogador.AddRange(new List<Jogador>()
                    {
                        new Jogador()
                        {
                           Nome = "Gabigol",
                           Posicao = "Atacante",
                           Time = "Flamengo",
                           numero = 10

                        }

                    }) ;

                }
                context.SaveChanges();
            }
        }
    }
}
