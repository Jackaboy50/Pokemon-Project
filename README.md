# Pokemon-Project
This was my A-level computer science project that I still work on from time to time. There are two halves to this Pokemon battle simulator implementation, there is a console and a Unity UI version. The console implementation has many different aspects and features within it that include but are not limited to:

## Pokemon Class Structure
There are 7 different classes based upon storing Pokemon related data, these are:
- Pokemon 
- ActivePokemon 
- Team 
- Type 
- Move 
- Item
- Ability

I used a webscraping package known as [HtmlAgilityPack](https://www.nuget.org/packages/HtmlAgilityPack/) to gather all of the necessary data from [pokemondb.net](pokemondb.net) to be stored in various JSON files using Newtonsofts [Json.Net](https://www.newtonsoft.com/json) functionality. This method allows me to gather and store data for all classes which can then be quickly loaded on the launch of the application. I currently have data stored for all Pokemon, Types and Moves.

## Pokedex
I have implemented a class for the Pokedex which will take in user input to give a detailed description about any required Pokemon. This has built in filters so that the user can enter a type or move in order to filter down the results shown in the console menu.


The Unity implementation is rough and unfinished but has many different features inside of it such as:

## UI system

## Battle Scene

## TeamBuilder
There is a built in team builder in which the user can interact with a responsive user interface to create a custom Pokemon. This pokemon will then be temporarily stored in the program and put into a team of Pokemon. Pokemon can also be imported and exported through a text based format that is similar to the Pokemon file data used by [Pokemon Showdown](https://play.pokemonshowdown.com).
