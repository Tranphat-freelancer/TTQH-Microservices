﻿using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Tasky.Administration;

[DependsOn(
    typeof(AdministrationApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class AdministrationHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AdministrationApplicationContractsModule).Assembly,
            AdministrationRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AdministrationHttpApiClientModule>();
        });

    }
}
