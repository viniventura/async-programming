using System;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Síncrono
            string UolContentSync = Service.GetPageUol();
            Console.Write($"--- PÁGINA DA UOL----\n{UolContentSync}");

            //Assíncrono - Método 1, 2 threads executando em paralelo
            var taskUol = Service.GetPageUolAsync();
            var taskTerra = Service.GetPageTerraAsync();

            // DO THINGS....

            // AGUARDO AS 2 TASKS FINALIZAREM
            await Task.WhenAll(taskUol, taskTerra);

            //OBTENDO OS RESULTADOS
            string uolContent = await Service.GetPageUolAsync();
            string terraContent = await Service.GetPageTerraAsync();

            Console.Write($"--- PÁGINA DA UOL ----\n{uolContent}\n\n" +
                $"--- PÁGINA DO TERRA ----\n{terraContent}");

            //Assíncrono - Método 2, 2 threads executando em paralelo
            Parallel.Invoke(() => Service.GetPageUol(), () => Service.GetPageUol());
            // nesse momento as 2 funções acima já retornaram (finalizaram)

            Console.ReadKey();
        }
    }
}
