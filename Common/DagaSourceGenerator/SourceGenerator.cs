namespace DagaSourceGenerator
{
    public class SourceGenerator
    {
        private Dictionary<Namespace, string> _sheets = [];


        private SourceGeneratorOption? _option;
        public SourceGeneratorOption Option
        {
            get
            {
                _option ??= new();
                return _option;
            }

            init
            {
                _option = value;
            }
        }
    }

    public class SourceGeneratorOption
    {
        /// <summary>
        /// 동일한 네임스페이스 코드 소스 병합 여부
        /// </summary>
        public bool CombineCode { get; init; } = false;
    }
}
