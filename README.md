# FiguresDemo
ASP.NET Core / React SPA Demo

The application calculates area of circle by radius, area of triangle by three sides.
input/output params are decimal type because it have overflow detection.

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

To run Console App

``` bash
cd Figures.Console
dotnet run
```
