# James' Products Web Api  

## Project Technology
• DotNetCore 2.1\
• Visual Studio for MacOS\
• SQLite database

## Project Architecture
• Product Model configured for required + optional properties\
• ProductsController called methods from ProductService\
• ProductService uses applicationContext (EntityFrameworkCore) to access database\
• Database (prepopulated with 2 items) is included: Development.db\
• Configured Swagger UI with annotations for /swagger endpoint

### How to run Project (DotNetCore 2.1 required)
Visual Studio:<br/>
  - Run<br/>
  
CLI:<br/> 
  - Navigate to project folder
  - Command: dotnet run
  - Browser: https://localhost:5001/swagger

## UnitTest Project
• Xunit and Moq\
• Mock data is generated and consumed within the scope of the test\
• GetAllProducts() and GetProductId() are Asserted for Product values\
• UpdateProductId() is Asserted for HttpStatusResponse (204 NoContent)

### How to run UnitTests
From the menu bar:<br/>
  - View > Test (test panel should now appear)<br/>
  
Run Tests:<br/>
  - Click the play button<br/>
  
Debug Tests:<br/>
  - Add breakpoints
  - Right-click on test panel
  - Debug Test
