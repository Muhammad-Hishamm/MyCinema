
# 🛒 Complete E-Commerce ASP.NET MVC Application

A full-featured e-commerce web application built using **ASP.NET MVC 8.0**, **Entity Framework**, and **Microsoft SQL Server**. This project simulates a real online store with product management, user authentication, a shopping cart, and checkout functionality.

## 📌 Features

- ✅ User registration and login (with roles)
- 🛍️ Product listing by category
- 🔍 Search and filter functionality
- 🛒 Shopping cart management
- 💳 Checkout system
- 🔐 Role-based authorization (Admin vs Customer)
- 🗂️ Admin dashboard to manage:
  - Products
  - Categories
  - Orders
  - Users

## 🛠️ Tech Stack

- ASP.NET MVC 5
- Entity Framework 6
- MS SQL Server
- Razor Views
- HTML/CSS/JavaScript
- Bootstrap 4

## 📂 Project Structure

```plaintext
├── Controllers/         # MVC Controllers (Products, Account, Cart, Admin, etc.)
├── Models/              # Entity models and ViewModels
├── Views/               # Razor views for UI rendering
├── Scripts/             # Client-side JavaScript
├── Content/             # Styles and static assets
├── App_Start/           # Config files (RouteConfig, FilterConfig, etc.)
├── Migrations/          # EF Code First Migrations
└── Web.config           # Application configuration file
````

## 🚀 Getting Started

### Prerequisites

* Visual Studio 2019 or later
* .NET Framework 4.7.2+
* SQL Server (Express or LocalDB)

### Installation

1. **Clone the repository:**

```bash
git clone https://github.com/Muhammad-Hishamm/MyCinema.git
```

2. **Open in Visual Studio**

   Open the `.sln` file in Visual Studio.

3. **Restore NuGet Packages**

   Visual Studio will automatically restore the NuGet packages. If not:

```bash
Tools > NuGet Package Manager > Manage NuGet Packages for Solution > Restore
```

4. **Apply Migrations & Create Database**

   Open the **Package Manager Console** and run:

```powershell
Update-Database
```

> ⚠️ Ensure the database connection string in `Web.config` matches your local SQL Server setup.

5. **Run the Application**

   Press `F5` or click **Start** in Visual Studio.

## 🔐 Admin Access

* **Email:** `admin@gmail.com`
* **Password:** `Admin123!`

> You can create or seed the admin account in the database directly or update the seeding logic in `IdentityConfig.cs`.

## 📸 Screenshots

Coming soon...

