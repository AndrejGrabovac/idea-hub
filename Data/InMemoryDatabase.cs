using IdeaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Data
{
    public static class InMemoryDatabase
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Product> Products { get; set; } = new List<Product>();
        public static List<Suggestion> Suggestions { get; set; } = new List<Suggestion>();

        public static User GetUserById(Guid userId)
        {
            return Users.FirstOrDefault(u => u.Id == userId);
        }

        public static User GetUserByUsername(string username)
        {
            return Users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public static void AddUser(User user)
        {
            if (user != null && !Users.Any(u => u.Id == user.Id))
            {
                Users.Add(user);
            }
        }

        public static void UpdateUser(User user)
        {
            var existingUser = GetUserById(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Password = user.Password;
                existingUser.FirstName = user.FirstName;
                existingUser.LastName = user.LastName;
                existingUser.Email = user.Email;
                existingUser.Role = user.Role;
                existingUser.IsActive = user.IsActive;
            }
        }

        public static void DeleteUser(Guid userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                Users.Remove(user);
            }
        }

        public static Product GetProductById(Guid productId)
        {
            return Products.FirstOrDefault(p => p.Id == productId);
        }

        public static void AddProduct(Product product)
        {
            if (product != null && !Products.Any(p => p.Id == product.Id))
            {
                Products.Add(product);
            }
        }

        public static void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.IsActive = product.IsActive;
            }
        }

        public static void DeleteProduct(Guid productId)
        {
            var product = GetProductById(productId);
            if (product != null)
            {
                Products.Remove(product);
            }
        }

        public static Suggestion GetSuggestionById(Guid suggestionId)
        {
            return Suggestions.FirstOrDefault(s => s.Id == suggestionId);
        }

        public static void AddSuggestion(Suggestion suggestion)
        {
            if (suggestion != null && !Suggestions.Any(s => s.Id == suggestion.Id))
            {
                Suggestions.Add(suggestion);
            }
        }

        public static void UpdateSuggestion(Suggestion suggestion)
        {
            var existingSuggestion = GetSuggestionById(suggestion.Id);
            if (existingSuggestion != null)
            {
                existingSuggestion.UserId = suggestion.UserId;
                existingSuggestion.ProductId = suggestion.ProductId;
                existingSuggestion.Title = suggestion.Title;
                existingSuggestion.Description = suggestion.Description;
                existingSuggestion.Status = suggestion.Status;
                existingSuggestion.LastUpdatedDate = DateTime.Now;
            }
        }

        public static void DeleteSuggestion(Guid suggestionId)
        {
            var suggestion = GetSuggestionById(suggestionId);
            if (suggestion != null)
            {
                Suggestions.Remove(suggestion);
            }
        }
    }
}
