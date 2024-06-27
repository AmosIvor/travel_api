using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Web3;

namespace travel_api.Services.Utils
{
    public class Web3Service
    {
        Web3 web3;

        string contractAddress = "0xC90b10B351d1afd6c483F942C73BE0487D98d41d";

        string abi = @"[
    {
      ""inputs"": [
        {
          ""internalType"": ""uint256"",
          ""name"": """",
          ""type"": ""uint256""
        },
        {
          ""internalType"": ""uint256"",
          ""name"": """",
          ""type"": ""uint256""
        }
      ],
      ""name"": ""itemRatings"",
      ""outputs"": [
        {
          ""internalType"": ""uint8"",
          ""name"": ""score"",
          ""type"": ""uint8""
        },
        {
          ""internalType"": ""string"",
          ""name"": ""userId"",
          ""type"": ""string""
        },
        {
          ""internalType"": ""string"",
          ""name"": ""comment"",
          ""type"": ""string""
        }
      ],
      ""stateMutability"": ""view"",
      ""type"": ""function"",
      ""constant"": true
    },
    {
      ""inputs"": [
        {
          ""internalType"": ""uint256"",
          ""name"": ""itemId"",
          ""type"": ""uint256""
        },
        {
          ""internalType"": ""uint8"",
          ""name"": ""score"",
          ""type"": ""uint8""
        },
        {
          ""internalType"": ""string"",
          ""name"": ""userId"",
          ""type"": ""string""
        },
        {
          ""internalType"": ""string"",
          ""name"": ""comment"",
          ""type"": ""string""
        }
      ],
      ""name"": ""submitRating"",
      ""outputs"": [],
      ""stateMutability"": ""nonpayable"",
      ""type"": ""function""
    },
    {
      ""inputs"": [
        {
          ""internalType"": ""uint256"",
          ""name"": ""itemId"",
          ""type"": ""uint256""
        }
      ],
      ""name"": ""getRatings"",
      ""outputs"": [
        {
          ""components"": [
            {
              ""internalType"": ""uint8"",
              ""name"": ""score"",
              ""type"": ""uint8""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""userId"",
              ""type"": ""string""
            },
            {
              ""internalType"": ""string"",
              ""name"": ""comment"",
              ""type"": ""string""
            }
          ],
          ""internalType"": ""struct RatingSystem.Rating[]"",
          ""name"": """",
          ""type"": ""tuple[]""
        }
      ],
      ""stateMutability"": ""view"",
      ""type"": ""function"",
      ""constant"": true
    }
  ]";

        public Web3Service()
        {
            if (web3 == null)
            {
                web3 = new Web3("http://127.0.0.1:7545");
            }
        }

        public Contract GetContract()
        {
            return web3.Eth.GetContract(abi, contractAddress);
        }

        public async Task SubmitAFeedback(int itemId, int score, string userId, string comment)
        {
            var contract = GetContract();
            var func = contract.GetFunction("submitRating");

            var fromAddress = "0x27DBAa578519cDAb01795400f5593Ee006BF28a7";
            var gas = await func.EstimateGasAsync(fromAddress, score, userId, comment);

            var transactionReceipt = await func.SendTransactionAndWaitForReceiptAsync(
                "0x27DBAa578519cDAb01795400f5593Ee006BF28a7",
                gas,
                null,
                null,
                itemId,
                score,
                userId,
                comment
            );

            Console.WriteLine(transactionReceipt);
            Console.WriteLine("Add new feedback to blockchain");
        }

        public async Task<List<Rating>> GetFeedbacks()
        {
            var contract = GetContract();
            var getFunc = contract.GetFunction("getRatings");

            var ratings = await getFunc.CallAsync<List<Rating>>(1);
            return ratings;
        }
    }

    [FunctionOutput]
    public class Rating
    {
        [Parameter("uint8", "score", 1)]
        public byte Score { get; set; }

        [Parameter("string", "userId", 2)]
        public string UserId { get; set; }

        [Parameter("string", "comment", 3)]
        public string Comment { get; set; }
    }
}
