using DagaDataGenerator.SrcGenerator.Enum;

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
            using (EnumSrcGenerator gen = new())
            {
                if(gen.TryAddEntity("CookType", "요리 과정 종류") &&
                    gen["CookType"] is IEnum cookType) 
                {
                    cookType.TryAddEntity(new EnumEntity(name: "Washing", comment: "세척"));
                    cookType.TryAddEntity(new EnumEntity(name: "Preparing", comment: "손질"));
                    cookType.TryAddEntity(new EnumEntity(name: "Chopping", value: 10, comment: "큼직하게 자르기"));
                    cookType.TryAddEntity(new EnumEntity(name: "Slicing", comment: "얇게 썰기"));
                }
            }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}