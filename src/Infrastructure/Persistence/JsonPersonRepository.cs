using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Domain.People;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace Infrastructure.Persistence
{
    public class JsonPersonRepository : IPersonRepository
    {
        private readonly string _fileName;

        public JsonPersonRepository(IConfiguration configuration)
        {
            _fileName = configuration["File"];
        }

        public async Task<Person> Save(Person entity, CancellationToken cancellation)
        {
            await UpdateFileWith(p => p.Add(entity), cancellation);
            return entity;
        }

        public async Task<IEnumerable<Person>> GetAll(CancellationToken cancellation)
        {
            if (!File.Exists(_fileName)) return new List<Person>();

            using StreamReader jsonFileReader = File.OpenText(_fileName);
            string             content        = await jsonFileReader.ReadToEndAsync();
            return string.IsNullOrEmpty(content)
                ? new List<Person>()
                : JsonConvert.DeserializeObject<List<Person>>(content);
        }

        public async Task<Person> GetById(string id, CancellationToken cancellation)
        {
            return (await GetAll(cancellation)).FirstOrDefault(p => p.Id == id);
        }

        public async Task RemoveById(string id, CancellationToken cancellation)
        {
            await UpdateFileWith(people =>
                    people.Remove(people.FirstOrDefault(p => p.Id == id)), cancellation
            );
        }

        public Task UpdateById(string id, Person newData, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }

        private async Task OverrideFileWith(IEnumerable<Person> people,
            CancellationToken cancellation)
        {
            string serializedObject = JsonConvert.SerializeObject(people);
            await File.WriteAllTextAsync(_fileName, serializedObject, cancellation);
        }

        private async Task UpdateFileWith(Action<List<Person>> action,
            CancellationToken cancellation)
        {
            List<Person> people = (await GetAll(cancellation)).ToList();
            action(people);
            await OverrideFileWith(people, cancellation);
        }
    }
}
