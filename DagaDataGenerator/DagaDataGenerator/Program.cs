using DagaDataGenerator.SrcGenerator.Const;
using DagaDataGenerator.SrcGenerator.Enum;
using Microsoft.CodeAnalysis;

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
            //using (EnumSrcGenerator gen = new("CooKing.Enums"))
            //{
            //    if(gen.TryAddEntity("CookType", "요리 과정 종류") && gen["CookType"] is IEnum cookType) 
            //    {
            //        cookType.TryAddEntity(new EnumEntity(name: "Washing", comment: "세척"));
            //        cookType.TryAddEntity(new EnumEntity(name: "Preparing", comment: "손질"));
            //        cookType.TryAddEntity(new EnumEntity(name: "Chopping", value: 10, comment: "큼직하게 자르기"));
            //        cookType.TryAddEntity(new EnumEntity(name: "Slicing", comment: "얇게 썰기"));
            //    }

            //    if (gen.TryAddEntity("CookingUtensilType", "요리 도구 종류") && gen["CookingUtensilType"] is IEnum cookingUtensilType)
            //    {
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Whisk", comment: "거품기"));
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Tongs", comment: "집게"));
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Strainer", comment: "체"));
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Peeler", comment: "껍질 벗기는 칼"));
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Ladle", comment: "국자"));
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Spatula", comment: "주걱"));
            //        cookingUtensilType.TryAddEntity(new EnumEntity(name: "Knife", comment: "식칼"));
            //    }

            //    gen.CreateSource("C:\\Daga\\DagaDataGenerator\\DagaDataGenerator\\data\\Enums", "Enums");
            //}


            using (ConstSrcGenerator gen = new("CooKing.Constants"))
            {
                if (gen.TryAddEntity("Cooking",
                    new ConstantEntity(["WASHING_TIME_LIMIT", "long", "10000", "세척 시간"]),
                    new ConstantEntity(["PREPARING_TIME_LIMIT", "uint", "10000", "손질 시간"]),
                    new ConstantEntity(["CUTTING_TIME_LIMIT", "string", "10000", "자르기 시간"]),
                    "기본 요리 과정"))
                {
                    gen.CreateSource("C:\\Daga\\DagaDataGenerator\\DagaDataGenerator\\data\\Constants", "Constants");
                }

            }


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}