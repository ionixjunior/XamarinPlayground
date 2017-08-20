using System;
using Autofac;
using Core.Interfaces;
using Core.Models;
using Core.Services;
using Core.UnitTests.Impl;
using Core.ViewModels;
using NUnit.Framework;

namespace Core.UnitTests
{
    public abstract class BaseTest
    {
        protected IContainer Container { get; private set; }

		[SetUp]
		public void BeforeBaseEachTest()
		{
            Container = BuildDependencies().Build();
            PrepareDatabase();
		}

		private ContainerBuilder BuildDependencies()
		{
			var container = new ContainerBuilder();

			container.RegisterType<SQLiteImpl>().As<ISQLite>().SingleInstance();
			container.RegisterType<ClienteViewModel>();
			container.RegisterType<ClienteDetalheViewModel>();
			container.RegisterType<ClienteService>().SingleInstance();

			return container;
		}

		private void PrepareDatabase()
		{
			ISQLite db = null;

			using (var scope = Container.BeginLifetimeScope())
				db = scope.Resolve<ISQLite>();

			if (db == null)
				return;

            db.GetConnection().CreateTable<ClienteModel>();
            db.GetConnection().DeleteAll<ClienteModel>();
		}
    }
}
