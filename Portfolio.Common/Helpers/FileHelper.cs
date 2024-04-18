using Microsoft.AspNetCore.Http;
using Portfolio.Common.Enums;

namespace Portfolio.Common.Helpers
{
    public static class FileHelper
    {
        private static readonly string[] ImageExtensions = { ".jpg", ".png", ".jpeg", ".svg" };
        private static readonly string[] VideoExtensions = { ".mp4", ".mkv" };

        #region Folders 

        public const string Review = "Review";
        public const string Product = "Product";
        public const string Category = "Category";
        public const string Partner = "Partner";
        public const string Home = "Home";
        public const string FeatureDetails = "FeatureDetails";
        public const string Statistics = "Statistics";
        public const string Mission = "Mission";
        public const string Story = "Story";
        public const string Branch = "Branch";
        public const string AboutUs = "AboutUs";

        #endregion

        public static string Upload(IFormFile file, string? folderName = null)
        {
            var wwwRootDirectory = Path.Combine(pLDirectory(), "wwwroot");

            var fileName = $"{GenerateUniqueFileName()}-{Path.GetFileName(file.FileName)}";

            string? filePath;

            if (!string.IsNullOrEmpty(folderName))
                filePath = Path.Combine(wwwRootDirectory, folderName, fileName);
            else
                filePath = Path.Combine(wwwRootDirectory, fileName);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }
        public static (string, int) UploadBase64(string base64File, string name, FileExtansion fileExtansions, string? folderName = null)
        {
            var wwwRootDirectory = Path.Combine(pLDirectory(), "wwwroot");

            var fileName = $"{GenerateUniqueFileName()}-{name}.{fileExtansions}";

            string? filePath;

            if (!string.IsNullOrEmpty(folderName))
                filePath = Path.Combine(wwwRootDirectory, folderName, fileName);
            else
                filePath = Path.Combine(wwwRootDirectory, fileName);

            byte[] fileBytes = Convert.FromBase64String(base64File);

            using var fileStream = new FileStream(filePath, FileMode.Create);

            fileStream.Write(fileBytes, 0, fileBytes.Length);

            return (fileName, fileBytes.Length);
        }
        public static void Delete(string fileName, string? folderName = null)
        {
            var wwwRootDirectory = Path.Combine(pLDirectory(), "wwwroot");

            string? filePath;

            if (!string.IsNullOrEmpty(folderName))
                filePath = Path.Combine(wwwRootDirectory, folderName, fileName);
            else
                filePath = Path.Combine(wwwRootDirectory, fileName);

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);
        }
        public static bool IsValidImage(IFormFile Image)
            => ImageExtensions.Contains(Path.GetExtension(Image.FileName).ToLower());
        public static bool IsValidVideo(IFormFile video)
            => VideoExtensions.Contains(Path.GetExtension(video.FileName).ToLower());
        public static string? MappFile(this string soruce, string folderName)
            => string.IsNullOrEmpty(soruce) ? string.Empty : $"{Helper.BaseUrl()}{folderName}/{soruce}";
        private static string pLDirectory()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var binIndex = baseDirectory.IndexOf("\\bin\\", StringComparison.OrdinalIgnoreCase);

            string pLDirectory = "";

            if (binIndex > 0)
                pLDirectory = baseDirectory.Substring(0, binIndex);

            return pLDirectory;
        }
        private static string GenerateUniqueFileName()
            => Guid.NewGuid().ToString();
    }
}
