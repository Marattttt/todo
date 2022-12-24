# todo
The project is a web application, which allows clients to log in and have their to-do list\n
It also allows admins to view and manage users and their data

### *This is currently a work in progress*

<div style="height: 60px;"></div>

## Features to implement:

* Api for CRUD actions for clients
* Api for CRUD actions for admin users
* Single webpage for authorization for admins and clients via login and password
* Separate pages for admins and clients


## Present documentation:

### General:

The app is built on ASP.NET Core 6, uses Entity Framework Core 7 and works with PostreSQL database via Npgsql NuGet package

### Models:
User is a general model which has login info (is a separate class), first and last name (strings) and Id

LoginInfo consists of private login and password fields, as well as methods for verification and update

Admin users have a nullable watchlist for clients

Clients have a nullable profile (is a separate class)

Profile has a description (string)
