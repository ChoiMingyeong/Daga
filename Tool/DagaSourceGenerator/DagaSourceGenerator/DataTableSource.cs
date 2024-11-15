using System.Reflection.Emit;

namespace DagaSourceGenerator
{
    public class DataTableSource : ISourceBase
    {
        public Uid Uid { get; init; }

        public DataTableSource(params string?[] param)
        {
            if (param.Length < 1)
            {
                ArgumentException.ThrowIfNullOrEmpty(nameof(param));
            }

            if (false == uint.TryParse(param[0], out uint uid))
            {
                throw new InvalidDataException(nameof(param));
            }

            Uid = uid;
        }
    }
}
