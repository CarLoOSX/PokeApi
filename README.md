# LaSalle - Diseño del software II 🎓🏭

# PokeApi 🎮 


# Content 📇

* 1. Challenge 1 - Pokemons 
* 2. Challenge 2 - User Favorite 
* 3. Folder structuring
* 4. Install 
* 5. Results


# 1. Challenge - Pokemons 1️⃣🤔💭

### Requirements:

* API: https://pokeapi.co
* Given the name of the pokemon return the type by:
  * Console - Terminal
  * Via Endpoint Http Body Json
* Control exceptions (Pokemon not found, PokeApi is down).
* The input via argument has to continue to work even if the api is down.

### Design:

* Commits bounded
* One class per file
* Create the classes strictly necessary to avoid duplicating the logic of the use case.

# 2. Challenge 2️⃣ - User Favorite 👤❤️ 

### Requirements:

Enable management of a user's favorite pokemon via HTTP endpoint, use cases:

* Create new User (saving on local memory).
* Add pokemons to User. 
* Unit testing

Conditions:

* We assume that the user is authenticated and we receive his user_id in the header.
* A user cannot have the same pokemon as favorite more than once.
* We assume that the pokemon ID exists.

### Design:

* We generate a new **Bounded Content User**, to encapsulate funcionality in a single domain model.

Use cases:

* **AddPokemonToUserFavorite:** Requires UserId and PokemonName, verify that user exist to add the pokemon to favorite.
* **Create User:** Creates a new User from UserId (ValueObject) on local memory if not exist.
* **GetPokemonUserFavorite:** From a UserId return the list of favorite pokemons if exist.



# 3. Folder Structure 📂

* **Boundend context**: Objective to divide and isolate domain models.
  * **Module**: Concepts within a bounded context.
    * **Infraestructura Layer**
    * **Application Layer**
    * **Domain Layer**
      *  **Aggregator**
      *  **Entities**
      *  **Domain Services**
      *  **Value Objects**: Objects of our application.

  <img src="images/project-structure.png" width="50%" height="50%" alt="Structure"><img src="images/project-structure.png" width="50%" height="50%" alt="Structure">


**DDD Layers:**  

<p align="center">
 <img style="text-align:center" src="images/ddd.PNG" width="25%" height="25%" alt="DDD">
</p>

# 3. Install 🔧 

* Dotnet is required to build and run the app, you can downloand from official page (we recommend 5.0):
https://dotnet.microsoft.com/download/dotnet/5.0

---

## Console 🖥️
```git clone https://github.com/CarLoOSX/mdas-api-g3```
### Execute the following commands
```
cd mdas-api-g3
cd src/main/Pokedex/Context/Pokemons/Types/Infrastructure/Pokemons.Types.CliConsole/
```
### Compile the app
```dotnet build Pokemons.Types.CliConsole.csproj```
### Run the app and pass the pokemon as argument
```dotnet run charizard```

---

## Api Rest 🌐

## Pokemons API
### Execute the following commands
```
cd mdas-api-g3
cd src/main/Pokedex/Context/Pokemons/Types/Infrastructure/Pokemons.Types.Api
```
### Compile the app
```dotnet build Pokemons.Types.Api.csproj```
### Run the app
```dotnet run Pokemons.Types.Api.csproj```
### Go to
```https://localhost:{PORT}/swagger/index.html```

---

## Users API 👤
### Execute the following commands
```
cd mdas-api-g3
TODO
```
### Compile the app
```dotnet build TODO```
### Run the app
```dotnet run TODO```
### Go to
```https://localhost:{PORT}/swagger/index.html```

---

# 4. Results 📷

## Pokemons Results
## Charizard example 🔥:
## Console 🖥️
![Console CLI](images/console-result.PNG)

## Swagger - Api Rest 🌐
![SwaggerAPI](images/swagger.png)


## User Favorite Results

## Create User example 👤:
//NEED IMAGE UPLOAD
## Add favorite example ❤️:
//NEED IMAGE UPLOAD
## Get all favorites from user 🔍:
//NEED IMAGE UPLOAD

## Swagger User - Api Rest 🌐
//NEED IMAGE UPLOAD


