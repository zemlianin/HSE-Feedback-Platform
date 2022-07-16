using System.IO;

namespace APICommentBook {
    public class Logger {
        
        private StreamWriter _writer;

        public Logger(string path) {
            _writer = new StreamWriter(path);
        }

        public void LogInformation(string information)
        {
            _writer.Write(information);
        }
        ~Logger() {
            _writer.Dispose();
        }
    }
}
