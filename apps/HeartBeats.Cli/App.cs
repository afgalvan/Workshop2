using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.People.Create;
using Application.People.GetAll;
using Domain.People;
using MediatR;
using Microsoft.Extensions.Hosting;

namespace HeartBeats.Cli
{
    public class App : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;
        private readonly IMediator                _mediator;


        public App(IHostApplicationLifetime appLifetime, IMediator mediator)
        {
            _appLifetime = appLifetime;
            _mediator    = mediator;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(() =>
                Task.Run(() => HelloWorld(cancellationToken), cancellationToken));
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task HelloWorld(CancellationToken cancellationToken)
        {
            Person person = RegistrationCli.ReadPersonData();

            CreatePersonCommand createCommand = new(person.Id, person.Name, person.Age, 'm');
            await _mediator.Send(createCommand, cancellationToken);

            (await _mediator.Send(new GetAllPeopleQuery(), cancellationToken)).ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
