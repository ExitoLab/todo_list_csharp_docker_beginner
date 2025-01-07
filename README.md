# Todo List API

This project is a RESTful API for managing a simple Todo List application, built using C# and Docker. The API allows users to add, update, delete, and view Todo items.

## Table of Contents
- [Project Overview](#project-overview)
- [Technologies Used](#technologies-used)
- [API Endpoints](#api-endpoints)
  - [GET /api/todo](#get-apitod)
  - [GET /api/todo/{id}](#get-apitod)
  - [POST /api/todo](#post-apitod)
  - [PUT /api/todo/{id}](#put-apitodid)
  - [DELETE /api/todo/{id}](#delete-apitodid)

## Project Overview

This project provides a simple API for a Todo List application. It supports the following operations:
- **Create**: Add a new Todo item.
- **Read**: Retrieve all Todo items and a single Todo item.
- **Update**: Update an existing Todo item.
- **Delete**: Remove a Todo item.

The API is built using **C#** and **.NET 9**, containerized using **Docker** for easy deployment and portability.

## Technologies Used
- C# / .NET 9
- Docker
- Swagger for API documentation