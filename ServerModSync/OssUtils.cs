using Aliyun.OSS;

namespace ServerModSync {
    internal class OssUtils {
        static readonly string endpoint;
        static readonly string bucketName;
        static readonly string accessKeyId;
        static readonly string accessKeySecret;
        static readonly OssClient client;

        static OssUtils() {
            string config = File.ReadAllText("ossconfig.csv");
            endpoint = config.Split(',')[0];
            bucketName = config.Split(',')[1];
            accessKeyId = config.Split(",")[2];
            accessKeySecret = config.Split(",")[3];
            client = new(endpoint, accessKeyId, accessKeySecret);
        }
        public static void UploadFile(string file, string path) {
            client.PutObject(bucketName, path, file);
        }

        public static void DeleteFile(string path) {
            client.DeleteObject(bucketName, path);
        }
    }
}
