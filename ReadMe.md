# SOLID Principles

## Introduction
SOLID is an acronym representing a set of five design principles for writing maintainable and scalable software. Introduced by Robert C. Martin, these principles guide developers in creating systems that are easy to understand, extend, and maintain over time. Adhering to SOLID principles enables the development of robust and flexible software that can adapt to changing requirements.

## Why SOLID Principles?
SOLID principles address common challenges in software development, such as code maintenance, scalability, and adaptability. By following these principles, developers can create code that is more modular, easier to test, and less prone to bugs. This ultimately leads to a more sustainable and efficient development process.

## The SOLID Principles

### 1. Single Responsibility Principle (SRP)
Each class or module should have only one reason to change, promoting a modular design that is easier to understand and maintain.

#### Example:
```csharp
class Account
{
    public double Balance { get; private set; }

    public void Deposit(double amount)
    {
        // Deposit logic
        Balance += amount;
    }

    public void Withdraw(double amount)
    {
        // Withdraw logic
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

class NotificationService
{
    public void NotifyWithdrawal(Account account, double amount)
    {
        #Notification logic
        Console.WriteLine($"Withdrawal of {amount:C} from account. Remaining balance: {account.Balance:C}");
    }
}
```
### 2. Open/Closed Principle (OCP)
Software entities should be open for extension but closed for modification, fostering a design that is both flexible and robust.

#### Example:
```csharp
abstract class Transaction
{
    public abstract void Execute(Account account, double amount);
}

class DepositTransaction : Transaction
{
    public override void Execute(Account account, double amount)
    {
        // Deposit transaction logic
        account.Deposit(amount);
    }
}

class WithdrawalTransaction : Transaction
{
    public override void Execute(Account account, double amount)
    {
        // Withdrawal transaction logic
        if (amount <= account.Balance)
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}
```

### 3. Liskov Substitution Principle (LSP)
Objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program.

#### Example:
```csharp
interface IBankAccount
{
    double Balance { get; }
    void Deposit(double amount);
    void Withdraw(double amount);
}

class BankAccount : IBankAccount
{
    public double Balance { get; private set; }

    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}

class SavingsAccount : BankAccount
{
    public double InterestRate { get; private set; }

    public void ApplyInterest()
    {
        Balance += Balance * InterestRate;
    }

    // Override Withdraw method to allow for overdraft protection
    public override void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Insufficient funds. Overdraft protection applied.");
            // Apply overdraft protection logic here
        }
    }
}

```

### 4. Interface Segregation Principle (ISP)
A class should not be forced to implement interfaces it does not use, encouraging the creation of specific, client-focused interfaces.

#### Example:
```csharp
interface ITransactionable
{
    void Execute(Account account, double amount);
}

class DepositTransaction : ITransactionable
{
    public void Execute(Account account, double amount)
    {
        // Deposit transaction logic
        account.Deposit(amount);
    }
}

class WithdrawalTransaction : ITransactionable
{
    public void Execute(Account account, double amount)
    {
        // Withdrawal transaction logic
        if (amount <= account.Balance)
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}
```

### 5. Dependency Inversion Principle (DIP)
High-level modules should not depend on low-level modules, promoting the use of interfaces or abstract classes to decouple high-level and low-level modules.

[![Dependency inversion chart](https://springframework.guru/wp-content/uploads/2015/06/DIP_Img01.png)


#### Example:
```csharp
interface INotificationService
{
    void NotifyWithdrawal(Account account, double amount);
}

class EmailNotificationService : INotificationService
{
    public void NotifyWithdrawal(Account account, double amount)
    {
        // Email notification logic
        Console.WriteLine($"Sending email notification for withdrawal of {amount:C}. Remaining balance: {account.Balance:C}");
    }
}

class SMSNotificationService : INotificationService
{
    public void NotifyWithdrawal(Account account, double amount)
    {
        // SMS notification logic
        Console.WriteLine($"Sending SMS notification for withdrawal of {amount:C}. Remaining balance: {account.Balance:C}");
    }
}
```


### Application of SOLID Principles
SOLID principles can be applied at various levels of software development, from the design of individual classes to the architecture of entire systems. They provide a foundation for creating code that is modular, maintainable, and scalable.

## Why Implement SOLID Principles in Our Applications?
1. **Maintainability:** SOLID principles lead to code that is easier to understand and modify, reducing the cost of maintenance.
2. **Scalability:** The modular design facilitated by SOLID principles allows for easier scaling of applications as requirements evolve.
3. **Testability:** Code following SOLID principles is often more testable, leading to more reliable and robust software.
4. **Flexibility:** Adhering to SOLID principles promotes a flexible architecture, making it easier to adapt to changing business needs.

By embracing SOLID principles, developers can create software that not only meets current requirements but also remains adaptable to future changes, ensuring long-term success and sustainability.


