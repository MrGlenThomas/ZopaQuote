# ZopaQuote
.NET Core 2.0 console application to generate quotes for loans

## The application takes arguments in the form:

    cmd> dotnet run [market_file] [loan_amount]

### Example:

    cmd> dotnet run market.csv 1500

## The application produces output in the form:

    cmd> dotnet run [market_file] [loan_amount]
    Requested amount: £XXXX
    Rate: X.X%
    Monthly repayment: £XXXX.XX
    Total repayment: £XXXX.XX

### Example:

	cmd> dotnet run market.csv 1000
	Requested amount: £1000
	Rate: 7.0%
	Monthly repayment: £30.78
	Total repayment: £1108.10


## Or to build and run self-contained executable

#### Windows
    cmd> dotnet build -r win10-x64
    cmd> dotnet publish -c release -r win10-x64
    
#### OSX
    cmd> dotnet build -r osx.10.10-x64
    cmd> dotnet publish -c release -r osx.10.10-x64

#### Ubuntu
    cmd> dotnet build -r ubuntu.14.04-x64
    cmd> dotnet publish -c release -r ubuntu.14.04-x64

    cmd> [application] [market_file] [loan_amount]

### Example:

	cmd> quote.exe market.csv 1000
	Requested amount: £1000
	Rate: 7.0%
	Monthly repayment: £30.78
	Total repayment: £1108.10
