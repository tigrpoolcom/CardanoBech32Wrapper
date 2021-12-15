# CardanoBech32Wrapper based on bech32
## What is it ?
The CardanoBech32Wrapper is a C# Library which can be used to encode or decode bech32 strings.
This can be helpful if you want to see if multiple addresses belong to one stake key (e.g. wallet), even if they are not used yet on cardano.


## Current Possibilities
- Convert from Bech32 Addresses into Hex
- Convert from Hex Addresses into Hex 
- Support for mainnet and testnet
- No dependencies except for this library
- NetStandard 2.0

## Next Steps
- Include converter of PolicyId+Assetname into Asset Fingerprintsfingerprint
- Provide it as a nuget for easy integration in C# projects
- Embedd it into the [CutyMal Cardano API](https://github.com/tigrpoolcom/cardano-web-api) to open up tooling for non C# languages, via simple rest calls

