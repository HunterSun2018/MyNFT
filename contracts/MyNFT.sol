// contracts/MyNFT.sol
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";
import "@openzeppelin/contracts/utils/Counters.sol";

contract MyNFT is ERC721 {
    using Counters for Counters.Counter;
    Counters.Counter private _tokenIds;

    constructor() ERC721("MyNFT", "MyNFT") {}

    function createToken(address player) public returns (uint256) {
        _tokenIds.increment();
        uint256 newItemId = _tokenIds.current();
        _mint(player, newItemId);
        return newItemId;
    }
    
    function exists(uint256 tokenId) public view returns (bool) {
        return _exists(tokenId);
    }

    function ownerOf(uint256 tokenId) override public view returns (address) {
        return _ownerOf(tokenId);
    }

    function transferToken(address to, uint256 tokenId) public {
        _transfer(msg.sender, to, tokenId);
    }
}

