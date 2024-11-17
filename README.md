# Blazor And Fluxor State Machine -  CRUD Application

This is a CRUD (Create, Read, Update, Delete) application built with **Blazor**, **Fluxor**, and **MudBlazor**. It uses Fluxor for state management, providing predictable state handling 
and efficient state updates, and MudBlazor for UI components, offering a Material Design-inspired user experience.

## Features

- **Fluxor State Management**: Centralized, predictable state using Fluxor, supporting actions, effects, reducers, and selectors.
  https://github.com/mrpmorris/Fluxor
- **MudBlazor UI Components**: Elegant and responsive Material Design components. 
https://mudblazor.com/

- **CRUD Operations**: using EF Core and MediatR: Implement robust Create, Read, Update, and Delete (CRUD) functionalities for managing a list of items using Entity Framework Core and MediatR. Leverage EF Core for efficient data access and mapping with your database, and utilize MediatR for handling commands and queries in a clean, CQRS-based architecture. This combination promotes a clear separation of concerns and helps in creating scalable, maintainable applications.

EF Core: A lightweight, extensible, and cross-platform ORM for .NET that simplifies database access and reduces boilerplate code.

Documentation: EF Core Overview
MediatR: A popular .NET library for implementing the Mediator pattern, allowing for easy decoupling of request processing from the main business logic.
https://learn.microsoft.com/en-us/ef/core/ 

GitHub: MediatR [Repository](https://github.com/jbogard/MediatR)

## Installation

1. **Clone the Repository**
   ```bash
   git clone https://github.com/yourusername/BlazorFluxor.git
   cd BlazorFluxor

2. ##Install Fluxor and MudBlazor

dotnet add package Fluxor
dotnet add package MudBlazor

3. ## Run the Application
   dotnet run

3. ## Access the Application
   Open a web browser and navigate to http://localhost:5000.

## Architecture
State Management with Fluxor
This application uses the Flux pattern implemented via Fluxor to manage the application's state.

## Actions: 
- **Define intents in the app, such as LoadItems, AddItem, UpdateItem, and DeleteItem.**
- **Reducers: Respond to actions and update the state.**
- **Effects: Handle side-effects, like making API calls to the backend.**
- **Selectors: Retrieve specific pieces of state for use in components.**

## UI with MudBlazor
- **MudBlazor components provide a clean UI based on Material Design. Some key components used:**
- **MudTable for listing items.**
- **MudButton for CRUD controls.**
- **MudDialog for modals**
- **MudTextField and other input components for forms.**

## Project Structure
- **/Actions - Defines all actions related to CRUD operations.**
- **/Reducers - Contains reducers to update state based on actions.**
- **/Effects - Includes effects to handle asynchronous operations (e.g., API calls).**
- **/State - Holds the application state and initial state setup.**
- **/Components - Contains Blazor components for the UI (e.g., ItemList.razor, ItemForm.razor).**

## CRUD Workflow
- **Create: Opens a dialog for adding a new item to the list.**
- **Read: Displays a list of items.**
- **Update: Opens a dialog for editing an item.**
- **Delete: Deletes an item from the list.**

## Connect with Me

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Profile-blue)](https://www.linkedin.com/in/spyros-ponaris-913a6937/)
