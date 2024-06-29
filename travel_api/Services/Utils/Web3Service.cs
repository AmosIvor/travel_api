using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Contracts;
using Nethereum.Web3;
using travel_api.ViewModels.Responses.UtilViewModel;

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
                fromAddress,
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

        public async Task NewFeedback(FeedbackBCVM vm)
        {
            var contract = GetContract();
            var func = contract.GetFunction("submitRating");

            var fromAddress = "0x27DBAa578519cDAb01795400f5593Ee006BF28a7";
            var gas = await func.EstimateGasAsync(fromAddress, vm.UserId, vm.Comment, vm.Medias);

            var transactionReceipt = await func.SendTransactionAndWaitForReceiptAsync(
                fromAddress,
                gas,
                null,
                null,
                vm.FeedbackId,
                vm.FeedbackId,
                vm.UserId,
                vm.LocationId,
                vm.Score,
                vm.Comment,
                vm.Medias
            );

            Console.WriteLine(transactionReceipt);
            Console.WriteLine("Add new feedback to blockchain");
        }

        public async Task<Rating> GetFeedbackDetail(int feedbackId)
        {
            var contract = GetContract();
            var getFunc = contract.GetFunction("getRatings");

            var ratings = await getFunc.CallAsync<List<Rating>>(feedbackId);

            if (ratings == null) return null;

            return ratings.FirstOrDefault()!;
        }

        public async Task<List<Rating>> GetFeedbacks()
        {
            var contract = GetContract();
            var getFunc = contract.GetFunction("getRatings");

            var numOfBlocks = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

            var ratings = new List<Rating>();

            for (int i = 1; i <= (int)numOfBlocks.Value; i++)
            {
                var rate = await getFunc.CallAsync<List<Rating>>(i);
                ratings.AddRange(rate);
            }

            return ratings;
        }

        public async Task<FeedbackBC> GetBlockData(int feedbackId)
        {
            var contract = GetContract();
            var getFunc = contract.GetFunction("getRatings");

            var ratings = await getFunc.CallAsync<List<FeedbackBC>>(feedbackId);

            if (ratings == null) return null;

            return ratings.FirstOrDefault()!;
        }

        public async Task<List<FeedbackBC>> GetChainData()
        {
            var contract = GetContract();
            var getFunc = contract.GetFunction("getRatings");

            var numOfBlocks = await web3.Eth.Blocks.GetBlockNumber.SendRequestAsync();

            var ratings = new List<FeedbackBC>();

            for (int i = 1; i <= (int)numOfBlocks.Value; i++)
            {
                var rate = await getFunc.CallAsync<List<FeedbackBC>>(i);
                ratings.AddRange(rate);
            }

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

    [FunctionOutput]
    public class FeedbackBC
    {
        [Parameter("string", "feedbackId", 1)]
        public string FeedbackId { get; set; }

        [Parameter("string", "userId", 2)]
        public string UserId { get; set; }

        [Parameter("uint8", "locationId", 3)]
        public byte LocationId { get; set; }

        [Parameter("uint8", "score", 4)]
        public byte Score { get; set; }

        [Parameter("string", "comment", 5)]
        public string Comment { get; set; }

        [Parameter("string", "medias", 6)]
        public string Medias { get; set; }
    }
}
