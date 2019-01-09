# FiguresDemo
ASP.NET Core / React SPA Demo

The application calculates area of circle by radius, area of triangle by three sides.
input/output params are decimal type because it have overflow detection.

![screencast-localhost-5001-2019 01 09-22-00-48](https://user-images.githubusercontent.com/25413642/50922306-4133bd00-145b-11e9-8101-c7d10bda531f.gif)

## Project

   - Figures.Lib -- library for calculationg areas of figures
   - Figures.Test -- tests for library
   - Figures.Web -- WebApi + React application
      - Figures.Web/ClientApp -- client scripts
   - Figures.Console -- Console application for library
   - figures.json -- input file for console application

## Setup

Install the following:
   - [.NET Core 2.1](https://www.microsoft.com/net/core)
   - [Node.js >= v11](https://nodejs.org/en/download/)
   
## Running

To run tests

``` bash
dotnet test
```

To run web

``` bash
cd Figures.Web
dotnet run
```

Then open https://localhost:5001/

To run Console App

``` bash
cd Figures.Console
dotnet run
```
