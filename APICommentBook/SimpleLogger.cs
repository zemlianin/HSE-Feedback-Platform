using System.IO;

namespace APICommentBook {
    public class SimpleLogger {
        public static SimpleLogger Instance { get; set; }
        private StreamWriter _writer;

        public SimpleLogger(string path) {
            _writer = new StreamWriter(path);
        }

        ~SimpleLogger() {
            _writer.Dispose();
        }
    }
}
