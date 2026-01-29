# ParkingLotSystem (ASP.NET Core Razor Pages)

Web application for managing parking lots, subscription plans, subscribers and subscriptions.

This project is part of a bigger solution together with the mobile app **ParkingLotMAUI**.  
Both apps model the **same domain** (ParkingLots, SubscriptionPlans, Subscriptions) and follow the same logic, but use different UI frameworks and storage approaches.

---

## Features
- CRUD for:
  - Parking Lots
  - Subscription Plans
  - Subscribers
  - Subscriptions
- Relationships:
  - **SubscriptionPlan ↔ ParkingLot** (many-to-many): each plan can include multiple parking lots
- Search/sort (lab-style) on listing pages
- Dashboard (Home) with counters + upcoming expirations (if implemented)
- Authentication & Authorization:
  - ASP.NET Core Identity
  - Roles: **Admin** and **User**
  - Seed roles + admin user (lab-style)
  - Optional: protect pages (e.g. Subscribers/Subscriptions) for logged-in users

---

## Tech Stack
- ASP.NET Core Razor Pages
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity (with Roles)

---

## Project Structure (high level)
- `Models/` – entities (ParkingLot, SubscriptionPlan, Subscriber, Subscription, PlanParkingLot)
- `Data/` – EF Core DbContext + seed logic (roles/users)
- `Pages/` – Razor Pages CRUD
- `Areas/Identity/` – Identity UI scaffolding + Identity DbContext

---

## Configuration
### Connection strings
Set these in `appsettings.json`:
- `ParkingLotSystemContext` – app database (domain data)
- `ParkingLotSystemIdentityContext` – identity database (users/roles)
