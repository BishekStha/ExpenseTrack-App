using System;
using System.Collections.Generic;

namespace ExpenseTrack.Components.Models
{
    internal class UserTransactions
    {
        public enum TransactionType
        {
            Credit,
            Debit,
            Debt
        }

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public List<string> Tags { get; set; } = new List<string>();
        public string Notes { get; set; }
        public bool IsCleared { get; set; }
        public DateTime DueDate { get; set; }
        public string Source { get; set; } // Used for Debt or Credit source (e.g., "Salary", "Bank Loan")

        // Parameterless constructor for deserialization
        public UserTransactions() { }

        // Overloaded constructor for manual initialization
        public UserTransactions(string title, double amount, DateTime date, TransactionType type, List<string> tags = null, string notes = null, bool isCleared = false, DateTime? dueDate = null, string source = null)
        {
            Title = title;
            Amount = amount;
            Date = date;
            Type = type;
            Tags = tags ?? new List<string>();
            Notes = notes;
            IsCleared = isCleared;
            DueDate = dueDate ?? DateTime.MinValue;
            Source = source;
        }

        // Method to check if the debt is cleared
        public void ClearDebt()
        {
            if (Type == TransactionType.Debt && Amount > 0)
            {
                IsCleared = true;
            }
        }
    }
}
