﻿using Mapster;
using OpenDinner.Application.Menus.Commands.CreateMenu;
using OpenDinner.Contracts.Menus;
using OpenDinner.Domain.MenuAggregate;
using MenuSection = OpenDinner.Domain.MenuAggregate.Entities.MenuSection;
using MenuItem = OpenDinner.Domain.MenuAggregate.Entities.MenuItem;

namespace OpenDinner.Api.Common.Mapping
{
    public class MenuMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
                .Map(dest => dest.HostId, src => src.HostId)
                .Map(dest => dest, src => src.Request);

            config.NewConfig<Menu, MenuResponse>()
               .Map(dest => dest.Id, src => src.Id.Value)
               .Map(dest => dest.HostId, src => src.HostId.Value)
               .Map(dest => dest.DinnerIds, src => src.DinnerIds.Select( dinnerId => dinnerId.Value))
               .Map(dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select( menuReviewId => menuReviewId.Value));

            config.NewConfig<MenuSection, MenuSectionResponse>()
              .Map(dest => dest.Id, src => src.Id.Value);
            
            config.NewConfig<MenuItem, MenuItemResponse>()
              .Map(dest => dest.Id, src => src.Id.Value);
        }
    }
}
