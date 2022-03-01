using System;

namespace FileCab.Documents
{
    public class Patent : Document
    {
        public string Authors { get; set; }

        public int UniqueId { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}
