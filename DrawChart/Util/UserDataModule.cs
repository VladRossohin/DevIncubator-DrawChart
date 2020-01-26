using ChartDraw.BLL.Interfaces;
using ChartDraw.BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DrawChart.Util
{
    public class UserDataModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserDataService>().To<UserDataService>();
        }
    }
}