using Google.Cloud.Vision.V1;

public class ImageAnalysisService
{
    public static async Task<List<string>> AnalyzeImage(string imagePath)
    {
        // Cấu hình đường dẫn tới file Service Account JSON
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"D:\Code\QLDiemrenluyen\ql_diemrenluyen\civil-decoder-439304-t3-f3979c000230.json");

        var client = ImageAnnotatorClient.Create();
        MessageBox.Show("Initialized client.");

        // Kiểm tra đường dẫn hình ảnh
        if (!File.Exists(imagePath))
        {
            MessageBox.Show($"Image file not found: {imagePath}");
            return new List<string>();
        }

        var image = Google.Cloud.Vision.V1.Image.FromFile(imagePath);
        MessageBox.Show("Image loaded.");

        try
        {
            // Phân tích văn bản
            MessageBox.Show("Starting text detection...");
            var response = await client.DetectTextAsync(image);
            MessageBox.Show("Text detection completed.");

            if (response == null || response.Count == 0)
            {
                MessageBox.Show("No text detected.");
                return new List<string>();
            }

            List<string> texts = new List<string>();

            foreach (var annotation in response)
            {
                string message = $"Detected text: {annotation.Description}";
                Console.WriteLine(message);
                texts.Add(annotation.Description);
                //MessageBox.Show(message); // Hoặc sử dụng Console.WriteLine nếu không cần hiển thị hộp thoại
            }

            return texts;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}\n{ex.StackTrace}");
            return new List<string>();
        }
    }
}
