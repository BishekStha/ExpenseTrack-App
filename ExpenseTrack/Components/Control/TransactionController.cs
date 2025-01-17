using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using ExpenseTrack.Components.Models;

namespace ExpenseTrack.Components.Control
{
    internal class TransactionController
    {
        public static void AddTransaction(UserTransactions userTransaction)
        {
            try
            {
                var allTransactions = GetAllTransaction();
                allTransactions.Add(userTransaction);
                var jsonData = JsonSerializer.Serialize(allTransactions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(Utils.TRANSACTIONS, jsonData);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in AddTransaction: {ex.Message}");
            }
        }

        public static List<UserTransactions> GetAllTransaction()
        {
            try
            {
                var fileContent = File.ReadAllText(Utils.TRANSACTIONS);

                if (string.IsNullOrWhiteSpace(fileContent))
                {
                    return new List<UserTransactions>();
                }

                return JsonSerializer.Deserialize<List<UserTransactions>>(fileContent) ?? new List<UserTransactions>();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetAllTransaction: {ex.Message}");
                return new List<UserTransactions>();
            }
        }

        public static bool SaveTransactionList(List<UserTransactions> userTransactions)
        {
            try
            {
                var jsonData = JsonSerializer.Serialize(userTransactions, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(Utils.TRANSACTIONS, jsonData);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in SaveTransactionList: {ex.Message}");
                return false;
            }
        }

        public static double GetTotalAmount(TransactionType transactionType)
        {
            try
            {
                var alltransactions = GetAllTransaction();
                double totalAmount = 0;

                foreach (var transaction in alltransactions)
                {
                    if (transaction.Type == transactionType)
                    {
                        totalAmount += (double)transaction.Amount;
                    }
                }
                return totalAmount;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetTotalAmount: {ex.Message}");
                return 0;

            }
        }

        public static double GetTotalAmount()
        {
            try
            {
                var alltransactions = GetAllTransaction();
                double totalAmount = 0;
                foreach (var transaction in alltransactions)
                {
                    totalAmount += (double)transaction.Amount;
                }
                return totalAmount;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetTotalAmount: {ex.Message}");
                return 0;
            }
        }
    }

}
