using DagaDataGenerator.DataSets;

namespace DagaDataGenerator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Dictionary<uint, DataSet> test = [];

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}

namespace DagaDataGenerator.DataSets
{
    public class DataManager
    {
        private string _dataSrcRootPath = string.Empty;

        private Dictionary<Type, Dictionary<uint, DataSet>> _data = [];
        
        public DataManager()
        {

        }

        public bool Load(Type dataSetType)
        {
            if (dataSetType.BaseType != typeof(DataSet))
            {
                return false;
            }

            string dataSetName = dataSetType.Name;
            var srcPath = Path.Combine(_dataSrcRootPath, dataSetName);
            if (false == File.Exists(srcPath))
            {
                return false;
            }


            return true;
        }

        public bool Save()
        {
            return true;
        }
    }

    public class DataSet
    {
        public uint Idx { get; set; }
    }
}

namespace DagaDataGenerator.DataSets
{
    public class ItemData : DataSet
    {
        public string ItemName { get; set; }
    }

    public class LocalizationData : DataSet
    {
        public string Korean { get; set; }

        public string English { get; set; }

        public string Japanese { get; set; }
    }
}