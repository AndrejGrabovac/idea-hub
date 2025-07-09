# IdeaHub

## Architecture Overview

IdeaHub is a .NET Framework 4.8.1 Windows Forms application designed for internal employees to manage product improvement suggestions. The architecture is built upon the Model-View-Presenter (MVP) pattern, which separates the application's logic into three interconnected components. This separation enhances maintainability, testability, and scalability.

Dependency Injection (DI) is a core principle of this architecture, facilitated by the `Microsoft.Extensions.DependencyInjection` library. The DI container is configured at the application's entry point (`Program.cs`) to manage the lifecycle of services. This approach promotes loose coupling, as components (primarily Presenters) receive their dependencies through constructor injection, rather than creating them directly.

## Application Flow

The application flow begins with `Program.cs`, which sets up the DI container and launches the `AppContext`. `AppContext` manages the application's lifecycle, initially displaying the `LoginForm`. Upon successful authentication, it transitions to the `DashboardForm`, which serves as the main interface.

## Core Components

This section provides a high-level overview of the key components in the IdeaHub application.

### Main Entry & Configuration

*   **Program**: The main entry point of the application. It is responsible for configuring the dependency injection container and setting up the main application context.
*   **Helpers.AppContext**: Manages the overall application lifecycle and windowing flow. It handles displaying the initial login form, transitioning to the main dashboard, and managing the logout process.

### Models

*   **Models.User**: Represents a user in the system, containing properties that define a user's identity and role.
*   **Models.Product**: Represents a product that users can submit suggestions for.
*   **Models.Suggestion**: Represents a suggestion submitted by a user for a specific product.

### Views (Interfaces and Forms)

The View layer consists of interfaces defining the UI contract and Windows Forms that implement these interfaces.

*   **ILoginView / LoginForm**: The login screen for user authentication.
*   **IDashboardView / DashboardForm**: The main window after a user logs in.
*   **IProductsView / ProductsForm**: Displays a list of products.
*   **ISuggestionsView / SuggestionsForm**: Displays and manages suggestions.
*   **ICreateSuggestionView / CreateSuggestionForm**: A form for creating a new suggestion.
*   **Admin Views**: A set of views for administrative tasks, such as managing users and products (`IUsersView`, `ICreateProductView`, etc.).

### Presenters

Presenters contain the presentation logic, responding to view events and interacting with services.

*   **LoginPresenter**: Handles user authentication logic.
*   **DashboardPresenter**: Manages the logic for the main dashboard, including role-based UI visibility.
*   **ProductsPresenter**: Manages the presentation logic for the products form.
*   **SuggestionsPresenter**: Handles the logic for retrieving and filtering suggestions.
*   **Admin Presenters**: A set of presenters for handling administrative logic, such as creating/editing products and users.

### Services

Services encapsulate the core business logic and data access operations.

*   **IAuthService / AuthService**: Manages user authentication and session state.
*   **IUserService / UserService**: Handles all user-related operations.
*   **IProductService / ProductService**: Manages all product-related operations.
*   **ISuggestionService / SuggestionService**: Manages all suggestion-related operations.

### Data Transfer Objects (DTOs)

DTOs are used to transfer data between layers, decoupling the service layer from the model and view layers. DTOs exist for `Login`, `Product`, `Suggestion`, and `User` operations.

### Mappers

Mappers are responsible for converting data between domain models (e.g., `User`) and DTOs (e.g., `UserViewDto`).

## Relationships and Interactions

The MVP pattern orchestrates the interactions between components:

1.  **View -> Presenter**: The View captures user actions and notifies the Presenter by raising an event.
2.  **Presenter -> Service**: The Presenter executes business logic by calling methods on Services injected via DI.
3.  **Service -> Data**: The Service layer interacts with the in-memory database to retrieve or modify data.
4.  **Presenter -> View**: The Presenter formats data returned from a Service and updates the View.