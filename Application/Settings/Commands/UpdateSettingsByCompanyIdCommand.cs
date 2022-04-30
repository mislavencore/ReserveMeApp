using Application.Settings.Dto;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Settings.Commands
{
    public class UpdateSettingsByCompanyIdCommand
    {
        public class Request : IRequest<UpdateSettingsDto>
        {
            public UpdateSettingsDto Settings { get; set; }
            public Request(UpdateSettingsDto settings) => Settings = settings;
        }

        public class Handler : IRequestHandler<Request, UpdateSettingsDto>
        {
            private readonly AppDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(AppDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<UpdateSettingsDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var settings = _dbContext.Set<Domain.Entities.Settings>().SingleAsync(x => x.CompanyId == request.Settings.CompanyId).Result;

                settings.SettingName = request.Settings.SettingName;
                settings.ItemName = request.Settings.ItemName;
                settings.ItemPluralName = request.Settings.ItemPluralName;
                settings.PrimaryColor = request.Settings.PrimaryColor;
                settings.IsWaitingListInUse = request.Settings.IsWaitingListInUse;
                settings.PrimeTimeHour = request.Settings.PrimeTimeHour;
                settings.PrimeTimeMinutes = request.Settings.PrimeTimeMinutes;
                settings.LengthOfReservation = request.Settings.LengthOfReservation;

                _dbContext.Update(settings);
                await _dbContext.SaveChangesAsync();

                return request.Settings;
            }
        }
    }
}