using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace travel_api.Models.BlockChain
{
    public class Block
    {
        [Key]
        public int BlockId { get; set; }
        public int Index { get; set; }
        public DateTime Timestamp { get; set; }
        public string PreviousHash { get; set; }
        public string Hash { get; set; }
        public string FeedbackHash { get; set; }
        public int FeedbackId { get; set; }
        public int Nonce { get; set; } = 1;


        public Block(DateTime timestamp, string feedbackHash, int feedbackId, string previousHash)
        {
            Timestamp = timestamp;
            FeedbackHash = feedbackHash;
            FeedbackId = feedbackId;
            PreviousHash = previousHash;
            Mine(2);
        }

        public string CalculateHash()
        {
            var sha256 = SHA256.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes($"{Timestamp}-{FeedbackHash}-{FeedbackId}-{PreviousHash}-{Nonce}");
            byte[] outputBytes = sha256.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }

        public void Mine(int difficulty)
        {
            string leadingZeros = new string('0', difficulty);
            while (!Hash.StartsWith(leadingZeros))
            {
                Nonce++;
                Hash = CalculateHash();
            }
        }
    }
}
