using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Cadastro
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            var doc = new Document(PageSize.A6);
            PdfWriter.GetInstance(doc, new FileStream(@"C:\teste\arquivoCadastro.pdf", FileMode.Create));

            doc.Open();

            doc.Add(new Paragraph("Testando"));
            doc.Close();

        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }

}
