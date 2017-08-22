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

    cmd> dotnet build -r win10-x64
    cmd> dotnet publish -c release -r win10-x64
    
    cmd> [application] [market_file] [loan_amount]

### Example:

	cmd> quote.exe market.csv 1000
	Requested amount: £1000
	Rate: 7.0%
	Monthly repayment: £30.78
	Total repayment: £1108.10
