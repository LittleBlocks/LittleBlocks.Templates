# Solution templates for LittleBlocks

![Release](https://github.com/LittleBlocks/LittleBlocks.Templates/workflows/Release%20build%20on%20master/main/badge.svg) ![CI](https://github.com/LittleBlocks/LittleBlocks.Templates/workflows/CI%20on%20Branches%20and%20PRs/badge.svg)  ![](https://img.shields.io/nuget/v/LittleBlocks.API.svg?style=flat-square)

The repository contains the template to generate different solution for based on LittleBlocks framework. The template generates the required structure for WebAPI based solution using dotnet cli

## Installation

To install the template for the dotnet command line use the following command:

`dotnet new --install "LittleBlocks.API::*"`

it will add the template in list of available template for cli.

### Usage

To generate a sample solution such as Sample.API use the following command:

`dotnet new LittleBlocks-api -n "Sample.API"`
