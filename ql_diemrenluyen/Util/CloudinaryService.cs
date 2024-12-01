using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

public class CloudinaryService
{
    private readonly Cloudinary _cloudinary;

    // Constructor để khởi tạo Cloudinary với thông tin tài khoản
    public CloudinaryService(string cloudName, string apiKey, string apiSecret)
    {
        var account = new Account(cloudName, apiKey, apiSecret);
        _cloudinary = new Cloudinary(account);
    }

    // Phương thức upload hình ảnh từ file path
    public string UploadImage(string filePath)
    {
        try
        {
            // Kiểm tra nếu file tồn tại
            if (!File.Exists(filePath))
                throw new FileNotFoundException("File không tồn tại", filePath);

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(filePath)
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();  // Trả về URL của hình ảnh
            }
            else
            {
                throw new Exception("Upload failed: " + uploadResult.Error.Message);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error uploading image: " + ex.Message);
        }
    }

    // Phương thức upload hình ảnh từ đối tượng Image
    public string UploadImage(Image image)
    {
        try
        {
            if (image == null)
                throw new ArgumentNullException(nameof(image), "Image không thể null");

            // Chuyển đổi Image thành byte array
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);  // Lưu hình ảnh vào MemoryStream
                byte[] imageBytes = ms.ToArray(); // Lấy byte array từ MemoryStream

                // Upload ảnh lên Cloudinary
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription("image.jpg", new MemoryStream(imageBytes))
                };

                var uploadResult = _cloudinary.Upload(uploadParams);

                if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return uploadResult.SecureUrl.ToString();  // Trả về URL của hình ảnh
                }
                else
                {
                    throw new Exception("Upload failed: " + uploadResult.Error.Message);
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error uploading image: " + ex.Message);
        }
    }

    // Phương thức upload hình ảnh từ byte array mà không yêu cầu fileName
    public string UploadImageFromBytes(byte[] imageBytes)
    {
        try
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription("image", new MemoryStream(imageBytes)) // Dùng "image" làm tên mặc định
            };

            var uploadResult = _cloudinary.Upload(uploadParams);

            if (uploadResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return uploadResult.SecureUrl.ToString();  // Trả về URL của hình ảnh
            }
            else
            {
                throw new Exception("Upload failed: " + uploadResult.Error.Message);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error uploading image: " + ex.Message);
        }
    }


    // Phương thức xóa hình ảnh từ Cloudinary theo public ID hoặc URL
    public bool DeleteImage(string imageUrl)
    {
        try
        {
            // Lấy public ID từ URL
            string publicId = ExtractPublicIdFromUrl(imageUrl);

            // Xóa hình ảnh theo public ID
            var deletionParams = new DeletionParams(publicId);
            var deletionResult = _cloudinary.Destroy(deletionParams);

            if (deletionResult.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;  // Xóa thành công
            }
            else
            {
                throw new Exception("Delete failed: " + deletionResult.Error.Message);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error deleting image: " + ex.Message);
        }
    }

    // Phương thức lấy public ID từ URL của ảnh
    private string ExtractPublicIdFromUrl(string imageUrl)
    {
        Uri uri = new Uri(imageUrl);
        string[] segments = uri.AbsolutePath.Split('/');

        // Public ID là phần cuối của URL (trước extension)
        string publicIdWithExtension = segments[segments.Length - 1];
        string publicId = publicIdWithExtension.Substring(0, publicIdWithExtension.LastIndexOf('.'));

        return publicId;
    }
}
