# LotteryApp
The application will simulate lottery draw. It will draw 5 numbers from 1-50. The number in the draw cannot 
repeat. The history of draws will be stored in the database. 

## Project
<p>Welcome to Lottery application, built with:</p>
<ul>
  <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
  <li><a href='https://angular.io/'>Angular</a> and <a href='http://www.typescriptlang.org/'>TypeScript</a> for client-side code</li>
  <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
</ul>

## Prerequisites
- Visual Studio 2019 Community and above
- .NET Core 3.1 SDK and above
- Angular CLI 6.0.0 and above
- SQL Server 2016 or above

## Getting Started
- Clone the repo.
- Restore all the dependencies.
- Open the project in Visual Studio.
- Replace connection string with your in config.json file.
```sh
"ConnectionStrings": {
    "LotteryAppDbContext": "Your connection string"
  }
```
-Run it with `F5`.
-The app will appear in browser after longer while


