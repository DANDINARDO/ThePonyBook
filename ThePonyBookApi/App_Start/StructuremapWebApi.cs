// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StructuremapWebApi.cs" company="Web Advanced">
// Copyright 2012 Web Advanced (www.webadvanced.com)
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0

// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;
using ThePonyBookApi.DependencyResolution;
using ThePonyBookLibraries.Repositories.EF;
using ThePonyBookLibraries.Services;
using ThePonyBookLibraries.Services.Interfaces;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ThePonyBookApi.App_Start.StructuremapWebApi), "Start")]

namespace ThePonyBookApi.App_Start {
    public static class StructuremapWebApi {
        public static void Start() {
			var container = StructuremapMvc.StructureMapDependencyScope.Container;
            container.Configure(x => x.For<IUserService>().Use<UserService>());
            container.Configure(x => x.For<IContactService>().Use<ContactService>());
            container.Configure(x => x.For<IDbContext>().Use<ThePonyBookModel>());
            container.Configure(x => x.For<IContactPhoneService>().Use<ContactPhoneService>());
            container.Configure(x => x.For<IContactAddressService>().Use<ContactAddressService>());
            container.Configure(x => x.For<ICountryService>().Use<CountryService>());
            GlobalConfiguration.Configuration.DependencyResolver = new StructureMapWebApiDependencyResolver(container);
        }
    }
}