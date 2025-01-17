using System;

namespace ExpenseTrack.Components.Models
{
    public enum TransactionType
    {
        Income,
        Expense,
        Debt
    }

    public class UserTransactions
    {
        public Guid Id { get; set; } = Guid.NewGuid(); // Automatically generated unique ID
        public string Title { get; set; } // Title of the transaction
        public double Amount { get; set; } // Amount involved in the transaction
        public string? Tag { get; set; } // Optional tag for categorizing the transaction
        public string? Note { get; set; } // Optional note for additional information
        public DateTime Date { get; set; } // Date of the transaction
        public TransactionType Type { get; set; } // Type of the transaction: Income, Expense, or Debt
        public DateTime? DueDate { get; set; } // Nullable due date, applicable for debts
        public string? Source { get; set; } // Optional source of the transaction
        public bool IsCleared { get; set; } = false; // Indicates whether the transaction is cleared

        // Updated constructor to allow nullable DueDate
        public UserTransactions(string title, double amount, DateTime date, DateTime? dueDate, TransactionType type, string? tag = null, string? note = null, string? source = null)
        {
            Title = title;
            Amount = amount;
            Date = date;
            DueDate = dueDate; // Supports nullable DateTime
            Type = type;
            Tag = tag;
            Note = note;
            Source = source;
        }

/*        // Overriding ToString for better debugging and logging
        public override string ToString()
        {
            return $"Transaction [Id={Id}, Title={Title}, Amount={Amount}, Date={Date}, Type={Type}, DueDate={(DueDate.HasValue ? DueDate.Value.ToString("yyyy-MM-dd") : "N/A")}, Source={Source}, IsCleared={IsCleared}]";
        }*/
    }
}
