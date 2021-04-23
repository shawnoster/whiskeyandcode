# serverless.com

## Install

### Install node and npm via nvm

https://github.com/nvm-sh/nvm#installation

### Install serverless via npm

```bash
npm install -g serverless
```

### Install .NET SDK

https://dotnet.microsoft.com/download

### Install Azure CLI

https://docs.microsoft.com/en-us/cli/azure/install-azure-cli

### Install Azure Functions

https://docs.microsoft.com/en-us/azure/azure-functions/functions-run-local?tabs=linux%2Ccsharp%2Cbash#v2

---

## Create a C# function

```bash
sls create -t azure-dotnet -p shuffle
cd shuffle

# this fixes a build warning about versions
dotnet add package Microsoft.Azure.WebJobs.Extensions --version 3.0.6
```