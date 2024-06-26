using Writer.Api.Models;
using Writer.Api.Models;

namespace Writer.Api.Repos
{
    public class WriterRepo : List<Models.Writer>, IWriterRepo
    {
        private readonly static List<Models.Writer> _writers = Populate();

        private static List<Models.Writer> Populate()
        {
            return new List<Models.Writer>
            {
                new Models.Writer
                {
                    Id = 1,
                    Name = "Leanne Graham"
                },
                new Models.Writer
                {
                    Id = 2,
                    Name = "Ervin Howell"
                },
                new Models.Writer
                {
                    Id = 3,
                    Name = "Glenna Reichert"
                }
            };
        }

        public List<Models.Writer> GetAll()
        {
            return _writers;
        }

        public Models.Writer Insert(Models.Writer writer)
        {
            var maxId = _writers.Max(x => x.Id);

            writer.Id = ++maxId;
            _writers.Add(writer);

            return writer;
        }

        public Models.Writer? Get(int id)
        {
            return _writers.FirstOrDefault(x => x.Id == id);
        }
    }
}
