namespace mktorrent_gui
{
    class TorrentInfo
    {
        public TorrentInfo(string sourcePath, string destPath, string trackers, string webURLs, string comments, string source, string name, int pieces, bool privateTorrent, bool date, bool subItems)
        {
            this.sourcePath = sourcePath;
            this.destPath = destPath;
            this.trackers = trackers;
            this.webURLs = webURLs;
            this.comments = comments;
            this.source = source;
            this.name = name;
            this.pieces = pieces;
            this.privateTorrent = privateTorrent;
            this.date = date;
            this.subItems = subItems;
        }
        public string sourcePath { get; set; }
        public string destPath { get; set; }
        public string trackers { get; set; }
        public string webURLs { get; set; }
        public string comments { get; set; }
        public string source { get; set; }
        public string name { get; set; }
        public int pieces { get; set; }
        public bool privateTorrent { get; set; }
        public bool date { get; set; }
        public bool subItems { get; set; }
    }
}
