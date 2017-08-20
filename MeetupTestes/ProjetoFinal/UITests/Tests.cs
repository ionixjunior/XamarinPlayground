using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Core.UITests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            //app.Repl();
            app.Screenshot("Lista dos clientes");

			app.Tap("Cadastrar");
            app.Screenshot("Formulário do cliente");

			app.EnterText("etNome", "Joao Gilberto");
			app.EnterText("etEndereco", "Rua Canario, 11");
			app.EnterText("etEmail", "joaogilberto@gmail.com");
			app.EnterText("etTelefone", "011 99887766");
			app.DismissKeyboard();
            app.Screenshot("Formulário preenchido");

            app.Tap("btSalvar");
            app.Screenshot("Cliente cadastrado");
        }
    }
}
