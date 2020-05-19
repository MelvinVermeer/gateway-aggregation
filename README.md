# Gateway Aggregation

This repo shows an oversimplified implementation of the Gateway Aggregation pattern.
https://docs.microsoft.com/nl-nl/azure/architecture/patterns/gateway-aggregation

## How to run

Make sure you have .net core 3.1

```
git clone https://github.com/MelvinVermeer/gateway-aggregation.git
cd gateway-aggregation
dotnet run --project .\samples\Client\Client.csproj
```

Expected output

```
I Support the following features
appointments
I know the following appointments
Afspraak met verpleging
Afspraak met dokter
```

## Client

this project is intended to represent the a webapplication.

## Domain model / DTO / Object model

The DTO project contains objects that can be transferred between a broker and the web-app
this project can not have dependencies on other projects
this project can not contain business logic

this project should not have interfaces, prefer OpenApi
the interface here is jsut to proof the flow of the application.

it is in folder external to stress the fact the this would preferrably be imported a a nuget package

## Gateway

Responsable for knowing the endpoint addresses (interfaces in this example).
Always calls the aggregator with 1 or more endpoints.

Potentially provide an aggregation strategy.

## aggregator

Responsable for merging the data from the enpoints into the requested DTO.
May implement several merging strategies.

## config

Pulls endpoint configuration from file/database/cloud/whatever structure
returns a list a internal endpoints (api addresses) that implement the given feature

## Ehr

Here are the ehr sprecific implementations, they can never be aware of eachother.
