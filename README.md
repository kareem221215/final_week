<!-- Intro-->

<!--
* Thanks for reviewing my Project-README-Template! 
* 
* Read the comments for an easy step by step guide. Enjoy!
-->

<!-- Shields Section--> <!-- Optional -->

<!-- 
* Insert project shields and badges through this link https://shields.io/
* 
*
-->

<div align="center">
    <a href="https://github.com/kareem221215/final_week/blob/main/LICENSE.txt"><img alt="GitHub license" src="https://img.shields.io/github/license/kareem221215/final_week?color=ff69b4&style=for-the-badge"></a>
    <a href="https://github.com/kareem221215/final_week/stargazers"><img alt="GitHub stars" src="https://img.shields.io/github/stars/kareem221215/final_week?color=yellow&label=Project%20Stars&style=for-the-badge"></a>
    <a href=https://github.com/kareem221215/final_week/issues><img alt="GitHub issues" src="https://img.shields.io/github/issues/kareem221215/final_week?color=brightgreen&label=issues&style=for-the-badge"></a>
    <a href=https://github.com/kareem221215/final_week/network><img alt="GitHub forks" src="https://img.shields.io/github/forks/kareem221215/final_week?color=9cf&label=forks&style=for-the-badge"></a>
</div>
<br>


<!-- Logo Section  --> <!-- Required -->

<!--
* Insert your github profile URL in the <a> "href" attribute bellow (line-25)
* 
* Insert an image URL in the <img> "src" attribute bellow. (line-26)
-->
<div align="center">
    <a href="kareem221215" target="_blank"><img src="https://github.com/kareem221215/patika-projects-week2/blob/main/oie_CfqoiAfbCyTJ.png" 
        alt="Logo" height="350" width="500">
    </a>
</div>


</div>


<!-- Project title 
* use a dynamic typing-SvG here https://readme-typing-svg.demolab.com/demo/
*
*  Instead you can type your project name after a # header
-->

<div align="center">
<img src="https://readme-typing-svg.demolab.com?font=Fira+Code&size=22&duration=4000&pause=3000&background=FFFFFF00&center=true&vCenter=true&multiline=true&width=435&lines=Patika-Bootcamp-Projects!&color=ffbf5e">
</div>


## About<!-- Required -->
Welcome to the repository for the projects completed in **Final week** of the bootcamp.
<!-- 
* information about the project 
* 
* keep it short and sweet
-->



<!-- 
* Here you may add information about how 
* 
* and why to use this project.
-->
# 📌 Weekly Progress Report

## Week 15: Final rpoject

---

# 🍽️ Restaurant Reservation System (ASP.NET Core)

This is a backend-only, modular, scalable restaurant reservation system built with **ASP.NET Core 8**, featuring **JWT-based Authentication**, **Role-based Authorization**, **Action Filters**, **Custom Middleware**, and **3-layer architecture** for production-grade structure and maintainability.

---

## 🏗️ Project Architecture

This project is structured using the **3-layer architecture** pattern for separation of concerns:


---

## ✅ Key Features

### 🔐 Authentication & Authorization
- **ASP.NET Core Identity** for user management
- **JWT** for secure token-based login
- **Role-based Access Control** (e.g., `Admin`, `User`)
- Swagger UI secured with JWT Bearer tokens

### 🗃️ Entity Framework Core
- **Code First** approach using `DbContext`
- **Migrations** and seed data setup
- Soft Delete with `IsDeleted` flag
- Automatic tracking of `CreatedDate` and `ModifiedDate`

### 🔄 CRUD Functionality
- Full `GET`, `POST`, `PUT`, `PATCH`, and `DELETE` support
- Properly implemented **DTOs** for request/response shaping
- PATCH requests support **partial updates**

### ⚙️ Middleware
- `ExceptionMiddleware` for global exception handling
- `MaintenanceModeMiddleware` to gracefully enable/disable access system-wide
- Middleware respects roles (e.g., Admins can still toggle maintenance)

### 🧪 Validation & Filters
- **Model validation** using `[Required]`, `[StringLength]`, etc.
- **Global Action Filters** for logging and cross-cutting concerns

### 🔁 Many-to-Many Support
- Restaurants and Features connected via `RestaurantFeature` join table
- Fully configured via Fluent API in `DbContext`

---

## 📁 Folder Breakdown

### `final_project.WebAPI`
- `Controllers`: API endpoints (e.g., `CustomerController`, `RestaurantController`)
- `Middlewares`: Custom request pipeline components
- `Program.cs`: Configures services, Swagger, auth, middleware

### `final_project.Business`
- `Services`: Business logic interfaces and implementations
- `DTOs`: Strongly typed request/response models
- `Filters`: Global `ActionFilter` for logging actions

### `final_project.Data`
- `Entities`: EF Core entity models
- `Repositories`: Repository interfaces & generics (`IGenericRepository<T>`)
- `Settings`: `Setting` table to control maintenance mode toggle

### `final_project.Shared`
- `BaseEntity`: Abstract class with `CreatedDate`, `ModifiedDate`, `IsDeleted`

---

## 🔄 Maintenance Mode Logic

- Maintenance toggle is stored in a `Setting` table
- Custom middleware checks this flag before processing requests
- All requests (except toggle route or Admins) are blocked when ON

```csharp
if (maintenanceMode && !context.User.IsInRole("Admin"))
{
    context.Response.StatusCode = 503;
    await context.Response.WriteAsync("Service is under maintenance.");
}



<!--## Contents Table<!-- Optional -->
<!-- 
* This section is optional, yet having a contents table 
* helps keeping your README readable and more professional.
* 
* If you are not familiar with HTML, no worries we all been there :D 
* Review learning resources to create anchor links. 
-->


<dev align="center">
<!--<table align="center">
        <tr>
            <td><a href="#about style="text-decoration: none;">About</a></td>        
            <td><a href="#how-to-use-this-project style="text-decoration: none;">Getting started</td>
            <td><a href="#contributors style="text-decoration: none;">Contributors</a></td>
            <!--<td><a href="#demo style="text-decoration: none;">Demo</a></td>-->
            <!--<td><a href="#project-roadmap-- style="text-decoration: none;">Project Roadmap</a></td>-->
            <!--<td><a href="#documentation style="text-decoration: none;">Documentation</a></td>-->
        <!--</tr> 
        <tr>
            <!--<td><a href="#acknowledgments">Acknowledgments</a></td>-->
          <!--  <td><a href="#feedback style="text-decoration: none;">Feedback</a></td>
            <td><a href="#contact style="text-decoration: none;">Contact</a></td>
            <td><a href="#license style="text-decoration: none;">License</a></td> -->
      <!--  </tr>-->
<!--</table>
</dev> -->


<!-- - Use this html element to create a back to top button. -->
<!--<p align="right"><a href="#how-to-use-this-project">back to top ⬆️</a></p> 


<!--## Project Roadmap <!-- Optional --> <!-- add learning_Rs-->
<!-- 
* Add this section in case the project has different phases
* 
* Under production or will be updated.
-->

<!--<p align="right"><a href="#how-to-use-this-project">back to top ⬆️</a></p>-->



<!--## Documentation<!-- Optional -->
<!-- 
* You may add any documentation or Wikis here
* 
* 
-->


## Contributors<!-- Required -->
<!-- 
* Without contribution we wouldn't have open source. 
* 
* Generate github contributors Image here https://contrib.rocks/preview?repo=angular%2Fangular-ja
-->
<a href="https://github.com/kareem221215/patika-projects-week2/graphs/contributors">
  <img src="https://contrib.rocks/image?repo=kareem221215/patika-projects-week2" />
</a>

<!--## Acknowledgments<!-- Optional -->
<!-- 
* Credit where it's do 
* 
* Feel free to share your inspiration sources, Stackoverflow questions, github repos, tools etc.
-->


<!-- - Use this html element to create a back to top button. -->
<!--<p align="right"><a href="#how-to-use-this-project">back to top ⬆️</a></p>-->


## Feedback<!-- Required -->
<!-- 
* You can add contacts information like your email and social media account 
* 
* Also it's common to add some PR guidance.
-->


> If you have any suggestions, ideas, or spot any bugs, feel free to open an issue on this repository [Create an Issue](https://github.com/kareem221215/final_week/issues).
- Use the tag **"Correction"** for bugs or typos.
- If you want to share any ideas to help make this project better, use the tag **"Enhancement"**.
<details>
    <summary>Contact Me 📨</summary>

### Contact<!-- Required -->
Reach me via email: [kareem.s.sleman@gmail.com](mailto:kareem.s.sleman@gmail.com)
<!-- 
* add your email and contact info here
* 
* 
-->
</details>

## License<!-- Optional -->
<!-- 
* Here you can add project license for copyrights and distribution 
* 
* check this website for an easy reference https://choosealicense.com/)
-->
- [MIT License](../LICENSE.txt)

<!-- - Use this html element to create a back to top button. -->
<p align="right"><a href="#how-to-use-this-project">back to top ⬆️</a></p>
