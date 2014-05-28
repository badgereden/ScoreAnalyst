
namespace ScoreAnalyst
{
    public static class Global
    {
        public static XDefault Default { get; set; }
        public static int GradeId { get;set;}
        public static string ConfigFile { get; private set; }
        public static string ConnectionString { get; set; }
        public static string ExcelConnectionStringFormat { get; set; }
        public static XGrade CurrentGrade { get; set; }
        public static XProduct Product { get; set; }
        static Global()
        {
            //默认值
            ConfigFile = "config\\new-config.xml";
        }

    }
}
