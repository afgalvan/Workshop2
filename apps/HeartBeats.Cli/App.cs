using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.People.Create;
using Application.People.Find;
using Application.People.GetAll;
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
            PersonData person = RegistrationCli.ReadPersonData();

            CreatePersonCommand createCommand = new(person.Id, person.Name, person.Age, person.Genre);
            await _mediator.Send(createCommand, cancellationToken);

            Console.WriteLine("\nFind by id: ");
            var response =
                await _mediator.Send(new FindPersonQuery(person.Id), cancellationToken);
            Console.WriteLine(response);

            Console.WriteLine("\nAll people registered: ");
            (await _mediator.Send(new GetAllPeopleQuery(), cancellationToken))
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
