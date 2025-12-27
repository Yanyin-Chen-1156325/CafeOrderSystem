# CafeOrder System

## Project Overview

CafeOrder System is a full-stack web application designed for small cafés to manage online orders, payments, and order processing workflows.

The system allows customers to browse menus, place orders, and pay online, while administrators can manage products, monitor orders, and update order statuses.

This project focuses on clean architecture, real-world payment workflows, and role-based system design, with an emphasis on scalability and maintainability.

---

## Key Features

### Customer

- User registration and login with JWT authentication
- Browse menu categories and products
- Add items to cart and manage quantities
- Place orders with notes and order type (e.g. dine-in / takeaway)
- Online payment integration using Stripe PaymentIntent
- View order history and order details
- Receive order status updates

### Admin

- Manage menu items (create, update, delete)
- View all customer orders
- Update order status (Paid, Completed, Cancelled)
- Handle failed payments and manual cash payments

---

## System Architecture

The backend follows a layered architecture:

API Layer (Controllers)  
Application Layer (Services)  
Domain Layer (Entities, Enums)  
Infrastructure Layer (EF Core, Database)

DTOs are used to avoid exposing domain models directly and to prevent circular reference issues during serialization.

---

## Tech Stack

Backend

- .NET 10 Web API
- ASP.NET Core
- Entity Framework Core

Database

- SQLite (development)

Authentication

- JWT authentication
- Role-based authorization (Admin / Customer)

Frontend

- React + TypeScript

Realtime

- SignalR (order status updates) - planned

Payments

- Stripe (PaymentIntent-based payment flow)

---

## Payment Flow

- Orders are created in Pending status
- Stripe PaymentIntent is created on order placement
- Payment results are handled via Stripe Webhooks
- Order status is updated based on webhook events:
  - payment_intent.succeeded -> Paid
  - payment_intent.payment_failed -> Failed
- PaymentIntentId is stored in the Order for future refund support

---

## Authorization

- JWT-based authentication
- Role-based access control:
  - Customer: place orders and view own orders
  - Admin: manage products and orders

---

## Getting Started

### Prerequisites

- .NET SDK 10.0 or later
- Node.js
- Stripe CLI (for webhook testing)

## Future Improvements

- SignalR
- Refund
- Email notifications

