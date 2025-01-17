using DagaDataGenerator.SrcGenerator.Const;
using DagaDataGenerator.SrcGenerator.Enum;

namespace DagaDataGenerator
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            using (EnumSrcGenerator gen = new("Daga.Enums"))
            {
                IEnum accountTypeEnum = new(
                    name: "AccountType", 
                    summary: "계정 타입 분류", 
                    typeName: "byte",
                    new EnumEntity(name: "SuperAdmin", comment: "최상위 관리자 (모든 권한 보유)"),
                    new EnumEntity(name: "Admin", comment: "일반 관리자 (특정 권한 관리)"),
                    new EnumEntity(name: "User", comment: "일반 사용자"),
                    new EnumEntity(name: "Guest", comment: "비회원 또는 방문자")
                    );
                gen.TryAddEntity(accountTypeEnum);

                if (gen.TryAddEntity("CouplingType", "취향 필터링 분류", "byte",
                    new EnumEntity("None"), new EnumEntity("All")) && gen["CouplingType"] is IEnum couplingType)
                {
                    couplingType.TryAddEntity(new EnumEntity(name: "BL"));
                    couplingType.TryAddEntity(new EnumEntity(name: "GL"));
                }

                gen.CreateSource("C:\\Daga\\DagaDataGenerator\\DagaDataGenerator\\data\\Enums", "Enums");
            }

            using (ConstSrcGenerator gen = new("Daga.Constants"))
            {
                if (gen.TryAddEntity(name: "Constants", summary: "공통 constant",
                    new ConstantEntity(["RESET_TIME", "byte", "0", "리셋 시간(UTC 0시)"])))
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