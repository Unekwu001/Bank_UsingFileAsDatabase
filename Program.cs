using Microsoft.Extensions.DependencyInjection;
using Bank_UsingFileAsDatabase.Interfaces.Customer_Interfaces;
using Bank_UsingFileAsDatabase.Interfaces.Account_Interfaces;
using Bank_UsingFileAsDatabase.Implementations.Customer_Implementation;
using Bank_UsingFileAsDatabase.Implementations.Account_Implementation;
using Bank_UsingFileAsDatabase;


var services = new ServiceCollection();
services.AddScoped<IRegister, Register>();
services.AddScoped<ILogin, Login>();

services.AddScoped<IDashBoard, DashBoard>();
services.AddScoped<ICreateAccount, CreateAccount>();
services.AddScoped<IDeposit, Deposit>();
services.AddScoped<IWithdraw, Withdraw>();
services.AddScoped<ITransfer, Transfer>();
services.AddScoped<ICheckBalance, CheckBalance>();
services.AddScoped<IGetAccountStatement, GetAccountStatement>();
services.AddScoped<ILogOut, LogOut>();

services.AddSingleton<HomePage>();

var serviceProvider = services.BuildServiceProvider();
var home = serviceProvider.GetRequiredService<HomePage>();
 
home.RunMyHomePage();


 