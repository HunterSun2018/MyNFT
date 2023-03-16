using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using Sample.Ethereum.ABI.ContractDefinition;

namespace Sample.Ethereum.ABI
{
    public partial class AbiService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AbiDeployment abiDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AbiDeployment>().SendRequestAndWaitForReceiptAsync(abiDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AbiDeployment abiDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AbiDeployment>().SendRequestAsync(abiDeployment);
        }

        public static async Task<AbiService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AbiDeployment abiDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, abiDeployment, cancellationTokenSource);
            return new AbiService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AbiService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AbiService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterface1Function supportsInterface1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterface1Function, bool>(supportsInterface1Function, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterface1Function = new SupportsInterface1Function();
                supportsInterface1Function.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterface1Function, bool>(supportsInterface1Function, blockParameter);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOfFunction ownerOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOfFunction = new OwnerOfFunction();
                ownerOfFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURIFunction tokenURIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenURIFunction = new TokenURIFunction();
                tokenURIFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> GetApprovedQueryAsync(GetApprovedFunction getApprovedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApprovedFunction = new GetApprovedFunction();
                getApprovedFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Owner = owner;
                isApprovedForAllFunction.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom4Function safeTransferFrom4Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom4Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom4Function safeTransferFrom4Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom4Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom4Function = new SafeTransferFrom4Function();
                safeTransferFrom4Function.From = from;
                safeTransferFrom4Function.To = to;
                safeTransferFrom4Function.TokenId = tokenId;
                safeTransferFrom4Function.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom4Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom4Function = new SafeTransferFrom4Function();
                safeTransferFrom4Function.From = from;
                safeTransferFrom4Function.To = to;
                safeTransferFrom4Function.TokenId = tokenId;
                safeTransferFrom4Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom4Function, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterface2Function supportsInterface2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterface2Function, bool>(supportsInterface2Function, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterface2Function = new SupportsInterface2Function();
                supportsInterface2Function.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterface2Function, bool>(supportsInterface2Function, blockParameter);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterface3Function supportsInterface3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterface3Function, bool>(supportsInterface3Function, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterface3Function = new SupportsInterface3Function();
                supportsInterface3Function.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterface3Function, bool>(supportsInterface3Function, blockParameter);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOf1Function balanceOf1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOf1Function, BigInteger>(balanceOf1Function, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOf1Function = new BalanceOf1Function();
                balanceOf1Function.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOf1Function, BigInteger>(balanceOf1Function, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOf1Function ownerOf1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOf1Function, string>(ownerOf1Function, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOf1Function = new OwnerOf1Function();
                ownerOf1Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOf1Function, string>(ownerOf1Function, blockParameter);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom1Function safeTransferFrom1Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom1Function safeTransferFrom1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom5Function safeTransferFrom5Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom5Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom5Function safeTransferFrom5Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom5Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom5Function = new SafeTransferFrom5Function();
                safeTransferFrom5Function.From = from;
                safeTransferFrom5Function.To = to;
                safeTransferFrom5Function.TokenId = tokenId;
                safeTransferFrom5Function.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom5Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom5Function = new SafeTransferFrom5Function();
                safeTransferFrom5Function.From = from;
                safeTransferFrom5Function.To = to;
                safeTransferFrom5Function.TokenId = tokenId;
                safeTransferFrom5Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom5Function, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(TransferFrom1Function transferFrom1Function)
        {
             return ContractHandler.SendRequestAsync(transferFrom1Function);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFrom1Function transferFrom1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFrom1Function, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFrom1Function = new TransferFrom1Function();
                transferFrom1Function.From = from;
                transferFrom1Function.To = to;
                transferFrom1Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFrom1Function);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFrom1Function = new TransferFrom1Function();
                transferFrom1Function.From = from;
                transferFrom1Function.To = to;
                transferFrom1Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFrom1Function, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(Approve1Function approve1Function)
        {
             return ContractHandler.SendRequestAsync(approve1Function);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(Approve1Function approve1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approve1Function, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approve1Function = new Approve1Function();
                approve1Function.To = to;
                approve1Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approve1Function);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approve1Function = new Approve1Function();
                approve1Function.To = to;
                approve1Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approve1Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAll1Function setApprovalForAll1Function)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAll1Function);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAll1Function setApprovalForAll1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAll1Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAll1Function = new SetApprovalForAll1Function();
                setApprovalForAll1Function.Operator = @operator;
                setApprovalForAll1Function.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAll1Function);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAll1Function = new SetApprovalForAll1Function();
                setApprovalForAll1Function.Operator = @operator;
                setApprovalForAll1Function.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAll1Function, cancellationToken);
        }

        public Task<string> GetApprovedQueryAsync(GetApproved1Function getApproved1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApproved1Function, string>(getApproved1Function, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApproved1Function = new GetApproved1Function();
                getApproved1Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApproved1Function, string>(getApproved1Function, blockParameter);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAll1Function isApprovedForAll1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAll1Function, bool>(isApprovedForAll1Function, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAll1Function = new IsApprovedForAll1Function();
                isApprovedForAll1Function.Owner = owner;
                isApprovedForAll1Function.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAll1Function, bool>(isApprovedForAll1Function, blockParameter);
        }

        public Task<string> ApproveRequestAsync(Approve2Function approve2Function)
        {
             return ContractHandler.SendRequestAsync(approve2Function);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(Approve2Function approve2Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approve2Function, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approve2Function = new Approve2Function();
                approve2Function.To = to;
                approve2Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approve2Function);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approve2Function = new Approve2Function();
                approve2Function.To = to;
                approve2Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approve2Function, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOf2Function balanceOf2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOf2Function, BigInteger>(balanceOf2Function, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOf2Function = new BalanceOf2Function();
                balanceOf2Function.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOf2Function, BigInteger>(balanceOf2Function, blockParameter);
        }

        public Task<string> GetApprovedQueryAsync(GetApproved2Function getApproved2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApproved2Function, string>(getApproved2Function, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApproved2Function = new GetApproved2Function();
                getApproved2Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApproved2Function, string>(getApproved2Function, blockParameter);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAll2Function isApprovedForAll2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAll2Function, bool>(isApprovedForAll2Function, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAll2Function = new IsApprovedForAll2Function();
                isApprovedForAll2Function.Owner = owner;
                isApprovedForAll2Function.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAll2Function, bool>(isApprovedForAll2Function, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOf2Function ownerOf2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOf2Function, string>(ownerOf2Function, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOf2Function = new OwnerOf2Function();
                ownerOf2Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOf2Function, string>(ownerOf2Function, blockParameter);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom2Function safeTransferFrom2Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom2Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom2Function safeTransferFrom2Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom2Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFrom2Function = new SafeTransferFrom2Function();
                safeTransferFrom2Function.From = from;
                safeTransferFrom2Function.To = to;
                safeTransferFrom2Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom2Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom2Function = new SafeTransferFrom2Function();
                safeTransferFrom2Function.From = from;
                safeTransferFrom2Function.To = to;
                safeTransferFrom2Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom2Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom6Function safeTransferFrom6Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom6Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom6Function safeTransferFrom6Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom6Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom6Function = new SafeTransferFrom6Function();
                safeTransferFrom6Function.From = from;
                safeTransferFrom6Function.To = to;
                safeTransferFrom6Function.TokenId = tokenId;
                safeTransferFrom6Function.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom6Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom6Function = new SafeTransferFrom6Function();
                safeTransferFrom6Function.From = from;
                safeTransferFrom6Function.To = to;
                safeTransferFrom6Function.TokenId = tokenId;
                safeTransferFrom6Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom6Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAll2Function setApprovalForAll2Function)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAll2Function);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAll2Function setApprovalForAll2Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAll2Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAll2Function = new SetApprovalForAll2Function();
                setApprovalForAll2Function.Operator = @operator;
                setApprovalForAll2Function.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAll2Function);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAll2Function = new SetApprovalForAll2Function();
                setApprovalForAll2Function.Operator = @operator;
                setApprovalForAll2Function.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAll2Function, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterface4Function supportsInterface4Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterface4Function, bool>(supportsInterface4Function, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterface4Function = new SupportsInterface4Function();
                supportsInterface4Function.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterface4Function, bool>(supportsInterface4Function, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFrom2Function transferFrom2Function)
        {
             return ContractHandler.SendRequestAsync(transferFrom2Function);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFrom2Function transferFrom2Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFrom2Function, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFrom2Function = new TransferFrom2Function();
                transferFrom2Function.From = from;
                transferFrom2Function.To = to;
                transferFrom2Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFrom2Function);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFrom2Function = new TransferFrom2Function();
                transferFrom2Function.From = from;
                transferFrom2Function.To = to;
                transferFrom2Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFrom2Function, cancellationToken);
        }

        public Task<string> NameQueryAsync(Name1Function name1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Name1Function, string>(name1Function, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Name1Function, string>(null, blockParameter);
        }

        public Task<string> SymbolQueryAsync(Symbol1Function symbol1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Symbol1Function, string>(symbol1Function, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Symbol1Function, string>(null, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURI1Function tokenURI1Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURI1Function, string>(tokenURI1Function, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenURI1Function = new TokenURI1Function();
                tokenURI1Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenURI1Function, string>(tokenURI1Function, blockParameter);
        }

        public Task<string> OnERC721ReceivedRequestAsync(OnERC721ReceivedFunction onERC721ReceivedFunction)
        {
             return ContractHandler.SendRequestAsync(onERC721ReceivedFunction);
        }

        public Task<TransactionReceipt> OnERC721ReceivedRequestAndWaitForReceiptAsync(OnERC721ReceivedFunction onERC721ReceivedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC721ReceivedFunction, cancellationToken);
        }

        public Task<string> OnERC721ReceivedRequestAsync(string @operator, string from, BigInteger tokenId, byte[] data)
        {
            var onERC721ReceivedFunction = new OnERC721ReceivedFunction();
                onERC721ReceivedFunction.Operator = @operator;
                onERC721ReceivedFunction.From = from;
                onERC721ReceivedFunction.TokenId = tokenId;
                onERC721ReceivedFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(onERC721ReceivedFunction);
        }

        public Task<TransactionReceipt> OnERC721ReceivedRequestAndWaitForReceiptAsync(string @operator, string from, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var onERC721ReceivedFunction = new OnERC721ReceivedFunction();
                onERC721ReceivedFunction.Operator = @operator;
                onERC721ReceivedFunction.From = from;
                onERC721ReceivedFunction.TokenId = tokenId;
                onERC721ReceivedFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(onERC721ReceivedFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(Approve3Function approve3Function)
        {
             return ContractHandler.SendRequestAsync(approve3Function);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(Approve3Function approve3Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approve3Function, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approve3Function = new Approve3Function();
                approve3Function.To = to;
                approve3Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approve3Function);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approve3Function = new Approve3Function();
                approve3Function.To = to;
                approve3Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approve3Function, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOf3Function balanceOf3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOf3Function, BigInteger>(balanceOf3Function, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOf3Function = new BalanceOf3Function();
                balanceOf3Function.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOf3Function, BigInteger>(balanceOf3Function, blockParameter);
        }

        public Task<string> GetApprovedQueryAsync(GetApproved3Function getApproved3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApproved3Function, string>(getApproved3Function, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApproved3Function = new GetApproved3Function();
                getApproved3Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApproved3Function, string>(getApproved3Function, blockParameter);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAll3Function isApprovedForAll3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAll3Function, bool>(isApprovedForAll3Function, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAll3Function = new IsApprovedForAll3Function();
                isApprovedForAll3Function.Owner = owner;
                isApprovedForAll3Function.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAll3Function, bool>(isApprovedForAll3Function, blockParameter);
        }

        public Task<string> NameQueryAsync(Name2Function name2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Name2Function, string>(name2Function, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Name2Function, string>(null, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOf3Function ownerOf3Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOf3Function, string>(ownerOf3Function, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOf3Function = new OwnerOf3Function();
                ownerOf3Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOf3Function, string>(ownerOf3Function, blockParameter);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom3Function safeTransferFrom3Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom3Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom3Function safeTransferFrom3Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom3Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFrom3Function = new SafeTransferFrom3Function();
                safeTransferFrom3Function.From = from;
                safeTransferFrom3Function.To = to;
                safeTransferFrom3Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom3Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom3Function = new SafeTransferFrom3Function();
                safeTransferFrom3Function.From = from;
                safeTransferFrom3Function.To = to;
                safeTransferFrom3Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom3Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom7Function safeTransferFrom7Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom7Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom7Function safeTransferFrom7Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom7Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom7Function = new SafeTransferFrom7Function();
                safeTransferFrom7Function.From = from;
                safeTransferFrom7Function.To = to;
                safeTransferFrom7Function.TokenId = tokenId;
                safeTransferFrom7Function.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom7Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom7Function = new SafeTransferFrom7Function();
                safeTransferFrom7Function.From = from;
                safeTransferFrom7Function.To = to;
                safeTransferFrom7Function.TokenId = tokenId;
                safeTransferFrom7Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom7Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAll3Function setApprovalForAll3Function)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAll3Function);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAll3Function setApprovalForAll3Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAll3Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAll3Function = new SetApprovalForAll3Function();
                setApprovalForAll3Function.Operator = @operator;
                setApprovalForAll3Function.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAll3Function);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAll3Function = new SetApprovalForAll3Function();
                setApprovalForAll3Function.Operator = @operator;
                setApprovalForAll3Function.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAll3Function, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterface5Function supportsInterface5Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterface5Function, bool>(supportsInterface5Function, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterface5Function = new SupportsInterface5Function();
                supportsInterface5Function.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterface5Function, bool>(supportsInterface5Function, blockParameter);
        }

        public Task<string> SymbolQueryAsync(Symbol2Function symbol2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Symbol2Function, string>(symbol2Function, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<Symbol2Function, string>(null, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURI2Function tokenURI2Function, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURI2Function, string>(tokenURI2Function, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenURI2Function = new TokenURI2Function();
                tokenURI2Function.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenURI2Function, string>(tokenURI2Function, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFrom3Function transferFrom3Function)
        {
             return ContractHandler.SendRequestAsync(transferFrom3Function);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFrom3Function transferFrom3Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFrom3Function, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFrom3Function = new TransferFrom3Function();
                transferFrom3Function.From = from;
                transferFrom3Function.To = to;
                transferFrom3Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFrom3Function);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFrom3Function = new TransferFrom3Function();
                transferFrom3Function.From = from;
                transferFrom3Function.To = to;
                transferFrom3Function.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFrom3Function, cancellationToken);
        }
    }
}
