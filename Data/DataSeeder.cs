using IdeaHub.Enums;
using IdeaHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaHub.Data
{
    public class DataSeeder
    {
        public static void Seed() 
        {
            InMemoryDatabase.Users.Clear();
            InMemoryDatabase.Products.Clear();
            InMemoryDatabase.Suggestions.Clear();

            var adminUser = new User
            {
                Username = "admin",
                Password = "admin",
                FirstName = "Admin",
                LastName = "Admin",
                Email = "admin@ideahub.com",
                Role = UserRole.Admin,
                IsActive = true
            };
            InMemoryDatabase.AddUser(adminUser);

            var regularUser1 = new User
            {
                Username = "john.doe",
                Password = "password",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@ideahub.com",
                Role = UserRole.User,
                IsActive = true
            };
            InMemoryDatabase.AddUser(regularUser1);

            var regularUser2 = new User
            {
                Username = "jane.smith",
                Password = "password",
                FirstName = "Jane",
                LastName = "Smith",
                Email = "jane.smith@ideahub.com",
                Role = UserRole.User,
                IsActive = true
            };
            InMemoryDatabase.AddUser(regularUser2);

            var regularUser3 = new User
            {
                Username = "susan.adams",
                Password = "password",
                FirstName = "Susan",
                LastName = "Adams",
                Email = "susan.adams@ideahub.com",
                Role = UserRole.User,
                IsActive = true
            };
            InMemoryDatabase.AddUser(regularUser3);

            var regularUser4 = new User
            {
                Username = "peter.jones",
                Password = "password",
                FirstName = "Peter",
                LastName = "Jones",
                Email = "peter.jones@ideahub.com",
                Role = UserRole.User,
                IsActive = true
            };
            InMemoryDatabase.AddUser(regularUser4);

            var productApp = new Product
            {
                Name = "IdeaHub Application",
                Description = "Our core suggestion management application.",
                IsActive = true
            };
            InMemoryDatabase.AddProduct(productApp);

            var productWebsite = new Product
            {
                Name = "Company Website",
                Description = "External facing website for corporate information.",
                IsActive = true
            };
            InMemoryDatabase.AddProduct(productWebsite);

            var productCRM = new Product
            {
                Name = "Internal CRM System",
                Description = "Customer Relationship Management tool for sales and support.",
                IsActive = true
            };
            InMemoryDatabase.AddProduct(productCRM);

            var productMobile = new Product
            {
                Name = "Mobile App",
                Description = "Companion mobile application for iOS and Android.",
                IsActive = true
            };
            InMemoryDatabase.AddProduct(productMobile);

            var productBI = new Product
            {
                Name = "BI Dashboard",
                Description = "Business Intelligence dashboard for analytics.",
                IsActive = true 
            };
            InMemoryDatabase.AddProduct(productBI);

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser1.Id,
                ProductId = productApp.Id,
                Title = "Improve UI responsiveness",
                Description = "The application sometimes feels sluggish, especially on older machines. Consider optimizing rendering.",
                CreatedAt = DateTime.Now.AddDays(-10) // Example historical date
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser2.Id,
                ProductId = productWebsite.Id,
                Title = "Add a dark mode option",
                Description = "A dark mode would be easier on the eyes for late-night Browse and fits modern design trends.",
                CreatedAt = DateTime.Now.AddDays(-7)
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser1.Id,
                ProductId = productCRM.Id,
                Title = "Integrate with email client for direct sending",
                Description = "Allow sending emails directly from CRM records for faster communication and record keeping.",
                Status = SuggestionStatus.Accepted,
                CreatedAt = DateTime.Now.AddDays(-15),
                LastUpdatedDate = DateTime.Now.AddDays(-5)
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser2.Id,
                ProductId = productApp.Id,
                Title = "Change login screen color to purple",
                Description = "Purple is my favorite color and would make the app look cooler.",
                Status = SuggestionStatus.Rejected,
                CreatedAt = DateTime.Now.AddDays(-8),
                LastUpdatedDate = DateTime.Now.AddDays(-2)
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser3.Id,
                ProductId = productMobile.Id,
                Title = "Enable biometric login for mobile",
                Description = "Allow users to log in with their fingerprint or face ID on the mobile app.",
                Status = SuggestionStatus.UnderReview,
                CreatedAt = DateTime.Now.AddDays(-3)
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser4.Id,
                ProductId = productWebsite.Id,
                Title = "Update the careers page",
                Description = "The careers page lists outdated job openings. It should be updated with current roles.",
                Status = SuggestionStatus.Accepted,
                CreatedAt = DateTime.Now.AddDays(-20),
                LastUpdatedDate = DateTime.Now.AddDays(-10)
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser1.Id,
                ProductId = productMobile.Id,
                Title = "Offline mode for mobile app",
                Description = "It would be great if the mobile app could cache data and allow for offline viewing of suggestions.",
                Status = SuggestionStatus.UnderReview,
                CreatedAt = DateTime.Now.AddDays(-1)
            });

            InMemoryDatabase.AddSuggestion(new Suggestion
            {
                UserId = regularUser3.Id,
                ProductId = productCRM.Id,
                Title = "Export contacts to CSV",
                Description = "Add a feature to export a list of contacts from the CRM into a CSV file for use in other tools.",
                Status = SuggestionStatus.Rejected,
                CreatedAt = DateTime.Now.AddDays(-5),
                LastUpdatedDate = DateTime.Now.AddDays(-1)
            });
        }
    }
}
