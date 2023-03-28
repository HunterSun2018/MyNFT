# Create A NFT contract by Trffule and Ganache

## Install npm and nodejs
```
sudo apt-get install nodejs npm
```

## Install module n
```
sudo npm install -g n
```

## Update nodejs to the stable
```
n stable
```

## Update npm to the latest
```
sudo npm install npm@latest -g
```

## Install Truffle
```
sudo npm install -g truffle
```

## Install truffle-export-abi for exporting ABI
```
sudo npm install -g truffle-export-abi
truffle-export-abi
```

## Generate C# code
```
Nethereum.Generator.Console generate from-abi -abi ./ABI.json -o . -ns Sample.Ethereum
```

## Install Openzeppelin contracts
```
npm install @openzeppelin/contracts
```
## NFT contracts/MyNFT.sol
```
// contracts/MyNFT.sol
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

import "@openzeppelin/contracts/token/ERC721/ERC721.sol";

contract MyNFT is ERC721 {
    constructor() ERC721("MyNFT", "MyNFT") {
    }
}
```

## Migraion migrations/1_deploy_contract.js
```
const Migrations = artifacts.require("MyNFT");

module.exports = function (deployer) {
  deployer.deploy(Migrations);
};
```



## Deploy to Ganache
vim truffle-config.js
```
    network : {
        ganache: {
            host: "127.0.0.1", 
            port: 8545,
            network_id: "*",
        }
    }    
```

## Install and start Ganache
```
sudo npm install -g ganache-cli
ganache-cli
```

## Connect truffle consle to Ganache network, compile and migration contract
```
truffle consle --network ganache
migrate    
```

## Run contract functions
```
nft = await MyNFT.deployed()
nft.name()

let a = await nft.createToken(accounts[0])
```

## Save ABI
```
var fs = require('fs')
await fs.writeFile("nft.abi", JSON.stringify(nft.abi),  (err) => { })
```
