# InventoryManagementSystem
The IMS have three modules.
- Products: Manage inventory with add, edit, and delete features.
- Sales: Record transactions and update inventory.
- Purchases: Track orders and update inventory on receipt.

## Backend
The backend is developed using .NET 7.

## Database
The Microsoft SQL Server is used for data persistance.

## Configuration
In program.cs file, CORS policy is modified according to requirements.
In Properties/launchsettings.js file, "profiles.http.applicationUrl" property value contains wildcard IP address "http://0.0.0.0:8000". Modify urls according to need.