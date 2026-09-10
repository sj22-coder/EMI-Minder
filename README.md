# 💰 EMI Minder

EMI Minder is a C# desktop application developed to help users calculate their Equated Monthly Installment (EMI) and manage basic loan-related information through a simple and user-friendly interface.

## ✨ Features

- 🧮 Calculate EMI based on loan amount, interest rate, and loan tenure
- 💵 Display monthly installment details
- 📋 Manage and view loan-related information
- 🖥️ Simple and intuitive desktop interface
- ⚡ Fast and accurate EMI calculations
- 🗄️ Database integration for storing application data

## 🛠️ Technologies Used

- **Language:** C#
- **Framework:** .NET
- **IDE:** Microsoft Visual Studio
- **Database:** SQL Server
- **UI:** Windows Forms

## 📂 Project Structure

```text
EMI-Minder/
│
├── emi.sln
│
├── emi/
│   ├── DBConnection.cs
│   ├── Form1.cs
│   ├── Form1.Designer.cs
│   ├── Form2.cs
│   ├── Form3.cs
│   ├── Form4.cs
│   ├── Form5.cs
│   ├── Form6.cs
│   ├── Program.cs
│   ├── emi.csproj
│   ├── Properties/
│   └── Resources/
│
└── README.md
🧮 EMI Calculation

EMI is calculated using the standard formula:

EMI = P × R × (1 + R)^N / ((1 + R)^N - 1)

Where:

P = Principal loan amount
R = Monthly interest rate
N = Loan tenure in months
🚀 Getting Started
Prerequisites

Make sure you have the following installed:

Microsoft Visual Studio
.NET Framework / .NET SDK compatible with the project
SQL Server (if required by the configured database)
Installation
Clone the repository:
git clone https://github.com/sj22-coder/EMI-Minder.git
Open emi.sln in Microsoft Visual Studio.
Restore the required dependencies.
Configure the database connection if required.
Build the solution.
Run the application.
🎯 Project Objectives

The main objective of EMI Minder is to provide a simple desktop-based solution for EMI calculation and basic loan management while demonstrating practical C# application development concepts.

The project demonstrates:

Object-Oriented Programming
Windows Forms development
Event-driven programming
Database connectivity
SQL operations
Input validation
Financial calculations
🔮 Future Enhancements
📊 Graphical visualization of loan repayment
📅 Detailed monthly repayment schedules
💳 Multiple loan comparison
📄 Export loan details and repayment schedules
🔔 EMI payment reminders
📱 Mobile/web version of the application
👩‍💻 Author

Simran Joshi

Diploma in Computer Engineering
SVKM's Shri Bhagubhai Mafatlal Polytechnic and College of Engineering, Mumbai
