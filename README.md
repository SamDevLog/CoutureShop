# SDL-Store Backend Project
SDL-Store is an ecommerce web app for a women's clothing brands, made using .NET 6 as the backend framework and React for the frontend.

## Stack Used

For this backend API service, a few technologies have been used in order to make it as powerful, secure and fast as possible. Namely the following:
* Entity Framework 6
* PostgreSQL Database
* Stripe
* ASP.NET Identity 6
* AutoMapper
* Docker

## How to Run

In order to successfully run the project locally, you must have Docker installed and Stripe CLI.
### Stripe Configuration
You will need to have a Stripe account in order to obtain Test Keys to connect stripe successfully, which are ***SecretKey***, ***WhSecret***, and ***PublishableKey***.
It is highly recommended to store them in Secret Manager tool provided by the .NET framework. This can be easily achieved by using the following commands:
!important: make sure you are inside the API directory before executing these commands.

```
dotnet user-secrets init
dotnet user-secrets set "StripeSettings:PublishableKey" "Copy Your Key Here"
```

### Docker and PostgreSQL DB Configuration

todo

## Live Demo

[SDL-Store](https://sdl-store.herokuapp.com/ "SDL-Store")
