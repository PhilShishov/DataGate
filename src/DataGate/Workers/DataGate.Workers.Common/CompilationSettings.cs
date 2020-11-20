//namespace DataGate.Workers.Common
//{
//    public static class CompilationSettings
//    {
//        public const string RunTimeConfigJsonFileName = ".runtimeconfig.json";

//        public const string CSharpOutputFileExtension = ".dll";

//        public const string ExeFileExtension = ".exe";

//        public const string JavaOutputFileExtension = ".jar";

//        public const string SetCompilerPathCommand = " & set PATH=%PATH%;";

//        public static string SetCPlusPlusCompilerPathCommand => GetCompilerPathCommand(CppCompilerPath);

//        public static string SetJavaCompilerPathCommand => GetCompilerPathCommand(JavaCompilerPath);

//        public static string GetCompilerPathCommand(string compilerPath)
//        {
//            if (!string.IsNullOrEmpty(compilerPath))
//            {
//                return $"{SetCompilerPathCommand}{compilerPath};";
//            }
//            return "";
//        }
//    }
//}
