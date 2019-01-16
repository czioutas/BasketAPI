# BasketAPI

## The main repo contains 3 projects
- the API (BasketAPI) 
- the API Test suite (BasketAPI.Tests)
- the API Class Library (BasketAPILibrary)

## Assumptions
Specific ommisions and assumptions have been made always in mind to provide a source code that can showcase important code design/parts but without fullfiling them to 100%.

- Test coverage was done against the BasketAPI to cover the main BasketService
- The Basket has no concept of a user. There would be many assumptions made if I did decide to handle a user such as, do we authenticate with a token? How far should this be mocked? Would the API accept just a user ID? 
- A seed database can been created under Data/DemoSeed.cs
- Focus of the code was to be self-descriptive without much documentation

## Configuration
- HTTP Port is 9005 
- HTTPS Port 44371
- Swagger is set by configuration as starting page of API or available at https://localhost:{port}/swagger/index.html

