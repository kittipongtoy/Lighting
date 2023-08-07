using System.IO;

namespace Lighting.Extension
{
    public class FilesFolderHelper
    {
        public static void DeleteFile(IWebHostEnvironment _env, string path)
        {
            var p = Path.Combine(_env.WebRootPath, path);
            if (System.IO.File.Exists(p))
            {
                System.IO.File.Delete(p);
            }
        }
        public static async Task<string?> ReSaveFile(IWebHostEnvironment _env, IFormFile? newFile, string? oldPath)
        {
            try
            {
                var p = Path.Combine(_env.WebRootPath, oldPath);
                if (oldPath != null)
                {
                    if (System.IO.File.Exists(p))
                    {
                        System.IO.File.Delete(p);
                    }
                    var replacePath = Path.Combine(Path.GetDirectoryName(p), newFile.FileName);
                    using (var stream = new FileStream(replacePath, FileMode.Create))
                    {
                        await newFile.CopyToAsync(stream);
                    }
                    return replacePath;
                }

                var newPath = Path.Combine(Path.GetDirectoryName(p), newFile.FileName);
                using (var stream = new FileStream(newPath, FileMode.Create))
                {
                    await newFile.CopyToAsync(stream);
                }
                return newPath;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static async Task<string?> SaveFile(IWebHostEnvironment _env, string? path, IFormFile? file)
        {
            try
            {
                using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, file.FileName), FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return Path.Combine(path, file.FileName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async Task<List<string>?> SaveFile(IWebHostEnvironment _env, string? path, List<IFormFile>? files, bool isNewName = false, string renameTyp = ".jpg")
        {
            try
            {
                var listName = new List<string>();
                if (files != null)
                {
                    foreach (var file in files)
                    {
                        var newName = Guid.NewGuid().ToString() + renameTyp;
                        using (var stream = new FileStream(Path.Combine(_env.WebRootPath, path, isNewName == true ? newName : file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                        if (isNewName == true)
                        {
                            listName.Add(Path.Combine(path, newName));
                        }
                        else
                        {
                            listName.Add(Path.Combine(path, file.FileName));
                        }
                    }
                }

                return listName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<string>? GetFiles(IWebHostEnvironment _env, List<string> ignore_file_name, string path)
        {
            try
            {
                var file_name = Directory.GetFiles(Path.Combine(_env.WebRootPath, path))
                    .Where(filePath => !ignore_file_name.Contains(filePath.Split("\\").Reverse().First()))
                    .Select(file_name =>
                    {
                        return Path.Combine(path, file_name.Split("\\").Reverse().First());
                    })
                    .ToList();

                return file_name;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static List<string>? GetAllImageFileName(IWebHostEnvironment _env, string path)
        {

            try
            {
                return Directory.GetFiles(Path.Combine(_env.WebRootPath, path))
                        .Where(path => path.ToLower().EndsWith(".jpg") || path.ToLower().EndsWith(".png"))
                        .Select(path =>
                        {
                            var new_path = path.Split('\\').Reverse().Take(4).Reverse();
                            return string.Join("/", new_path);
                        })
                        .ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }

        }
    }
}
