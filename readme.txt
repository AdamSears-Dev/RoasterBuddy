RoasterBuddy by Adam Sears


RoasterBuddy is a .NET Core Razor Pages web application designed to manage coffee roasting orders. This application allows users to create, update, and delete clients, orders, and sources, ensuring an effective and streamlined order management. The app features a friendly user interface for easy navigation and usage. 
Code Louisville Requirements


Feature 1 - Use of Dictionary or List: This application employs dictionaries and lists to store and manage data. For instance, the information about orders and clients is stored in lists, which are populated, updated, and read throughout the codebase.
  
Feature 2 - Asynchronous Programming: RoasterBuddy utilizes async programming to handle requests and responses. For instance, `OnPostAsync()` is an asynchronous method used to submit data, preventing blocking while waiting for the operation to complete.
  
Feature 3 - Multiple Related Entities: RoasterBuddy includes several related entities (e.g., Order, Client, Source). These entities can be queried together, allowing for data retrieval from multiple tables, an operation equivalent to a SQL JOIN. 
  
Feature 4 - Use of Regular Expressions: The application uses Regular Expressions (Regex) to validate the client's contact information. This helps to ensure that the email address entered matches the standard format for email addresses. 
Getting Started


1. Clone the repository or download the source code.
2. Open the solution file in Visual Studio.
3. Build and run the project (*requires .NET 6.0 or later*).
4. Navigate through the application using the provided links.
5. Add, edit, and delete clients, orders, and sources as necessary.
6. Note for Mac users: make sure to change the location for the database file in appsettings.json 
	*example is provided in comment


Features


* User-friendly interface for managing coffee roasting orders.
* Ability to create, update, and delete clients, orders, and sources.
* Validations for user input, including email address format validation.


To-do


* Improve the user interface for a more intuitive user experience.
* Improve data validation and error handling.
* Add a feature for users to view their order history.
* Implement additional features such roast creation with multiple sources
* Add search functionality