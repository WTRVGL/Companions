<!-- Improved compatibility of back to top link: See: https://github.com/othneildrew/Best-README-Template/pull/73 -->
<a name="readme-top"></a>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->


<div align="center">
  <img src="https://user-images.githubusercontent.com/73450465/206665008-63dc06cb-13d5-422e-9b7f-fb21c471d88e.png" alt="logo" width="200" height="auto" />
 

<!-- Badges -->
</div>

<!-- PROJECT LOGO -->
<br />
<div align="center">
<h1 align="center">Companions</h1>

  <p align="center">
    <h3>A Multi Platform Application for taking care of your pets!</h3> 
    <!-- Badges -->
<p>
  <a href="">
    <img src="https://img.shields.io/github/contributors/WTRVGL/Companions" alt="contributors" />
  </a>
  <a href="">
    <img src="https://img.shields.io/github/last-commit/WTRVGL/Companions" alt="last update" />
  </a>
  <a href="https://github.com/Louis3797/awesome-readme-template/issues/">
    <img src="https://img.shields.io/github/issues/WTRVGL/Companions" alt="open issues" />
  </a>
</p>
</div>
    <p align=center>
    <a href="https://github.com/WTRVGL/Companions"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/WTRVGL/Companions">View Demo</a>
    ·
    <a href="https://github.com/WTRVGL/Companions/issues">Report Bug</a>
    ·
    <a href="https://github.com/WTRVGL/Companions/issues">Request Feature</a>
  </p>
</div>



<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Usage</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgments">Acknowledgments</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://user-images.githubusercontent.com/73450465/205472812-5027fa53-8151-4dac-9100-24b09c71ad59.png)


<p align="right">(<a href="#readme-top">back to top</a>)</p>


### Built With

[![MAUI][MAUI-Shield]][MAUI-url]
[![ASPCore][ASP.NET.Core-Shield]][ASP.NET.Core-url]
[![SQL][SQL-Shield]][SQL-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Stack
<ul>
    <li>
      <p>Frontend</p>
      <ul>
        <li>MAUI Android Application</li>
      </ul>
    </li>
    <li>
      <p>Backend</p>
      <ul>
        <li>ASP.NET Core REST Service
          <ul>
            <li>SQL Server</li>
            <li>Open API documented (Swagger)</li>
          </ul>
        </li>
        <li>ASP.NET Core Authentication Service
          <ul>
            <li>JWT Authentication</li>
            <li>Open API documented (Swagger)</li>
          </ul>
        </li>
        <li>ASP.NET Core Image Service
          <ul>
            <li>Google Cloud Bucket Storage</li>
            <li>Open API documented (Swagger)</li>
          </ul>
        </li>
      </ul>
    </li>
  </ul>

## Features

<!-- GETTING STARTED -->
## Getting Started

Companions is not fully released. You can however run this application in Development mode.
The architecture of Companions is a .NET MAUI Android application paired with a ASP.NET Core services:
<br>

### Prerequisites

This is an example of how to list things you need to use the software and how to install them.

<ul>
  <li>Visual Studio 2022 with .NET 7.0 & .NET 6.0 SDK</li>
  <li>Android Emulator (API 33 with Play Store required for Google Maps functionality)</li>
  <li>SQL Server (developer)</li>
</ul>

### Installation

1. Clone the repo
   ```sh
   git clone https://github.com/WTRVGL/Companions.git
   ```
2. Each project requires an `appsettings.Development.json` file. 

#### Companions.MAUI
   ```js
   {
  "GoogleMapsKey": "AIzaSyCc4DXdwoD5CFGONmfKTkuGvAmerQViKQs",
  "GoogleMapsBrowserKey": "AIzaSyBcQhN5RP3bDrXU6__K1rr3oYE9Xt8hGTA",
  "CompanionsAPIBaseURL": "http://10.0.2.2:5048",
  "CompanionsAuthBaseURL": "http://10.0.2.2:5176",
  "CompanionsImageBaseURL": "http://10.0.2.2:5209",
  "SFLicenseKey": "base64 string"
   }
   ```
  * `SFLicenseKey` needs to be a valid SyncFusion key. Can be an empty string but the MAUI app will display warning.
  * `GoogleMapsKey` and `GoogleMapsBrowserKey` are secured API keys.


  #### Companions.API
   ```js
  {
  "ConnectionStrings": {
    "SqlServer": "Server=localhost;Database=Companions;Trusted_Connection=True;TrustServerCertificate=Yes;"
  },
  "JWT": {
    "JWTHttpCookieName": "companions_user_jwt",
    "ValidAudience": "http://localhost:4200",
    "ValidIssuer": "http://localhost:61955",
    "Secret": "V0FaQUFBTE9MRVBJQ1NBRkVLRVlZT09PT08="
  },
  "CompanionsAuthenticationServiceURL": "https://localhost:7017",
  "CompanionsImageServiceURL": "https://localhost:7277"
  }
   ```
   * Make sure your connection string is present in `ConnetionStrings`
   * The `Secret` must match the `Secret` present in the configuration file of Companions.AuthenticationService

  #### Companions.AuthenticationService
   ```js
  {
    "JWT": {
    "JWTHttpCookieName": "companions_user_jwt",
    "ValidAudience": "http://localhost:4200",
    "ValidIssuer": "http://localhost:61955",
    "Secret": "V0FaQUFBTE9MRVBJQ1NBRkVLRVlZT09PT08="
  },
  "CompanionsAPIURL": "https://localhost:7048"
  }
   ```
* The `Secret` must match the `Secret` present in the configuration file of Companions.API

#### Companions.ImageService
   ```js
{
  "GoogleServiceKey": "google_service_key.json",
  "StorageBucket":  "companions_bucket01"
}
   ```
   * A Service Key for Bucket acces must be referenced in `GoogleServiceKey`. This service won't work without a key present.

<br>

3. Configure the solution to have all projects startup:

   <img src="https://user-images.githubusercontent.com/73450465/211178077-7fd89518-7c10-448f-8d32-a0eb748d99f6.png" />

4. Make sure that the MAUI project has an Android Emulator associated (Pixel 4 API 33 with Google Play Store was used during development)
<img src="https://user-images.githubusercontent.com/73450465/211181382-2c10ee8c-e050-48b0-b54e-e6ad4c9abd57.png" />

5. Run in Visual Studio in Development mode

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Usage
MAUI Android Application Demo Video (submission for grading at school).


https://user-images.githubusercontent.com/73450465/211187026-3e45d4af-2f49-4cf7-8d5a-64d61f8147a3.mp4



[YT link](https://youtu.be/Lc8CxbSNvtY)


<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE.txt` for more information.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Project Link: [https://github.com/WTRVGL/Companions](https://github.com/WTRVGL/Companions)

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- ACKNOWLEDGMENTS -->
## Acknowledgments

* Gert Vos (docent C# Mobile): Bedankt voor de boeiende lessen, hulp met het project en zeer goede manier van lesgeving!

<p align="right">(<a href="#readme-top">back to top</a>)</p>



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/WTRVGL/Companions.svg?style=for-the-badge
[contributors-url]: https://github.com/WTRVGL/Companions/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/WTRVGL/Companions.svg?style=for-the-badge
[forks-url]: https://github.com/WTRVGL/Companions/network/members
[stars-shield]: https://img.shields.io/github/stars/WTRVGL/Companions.svg?style=for-the-badge
[stars-url]: https://github.com/WTRVGL/Companions/stargazers
[issues-shield]: https://img.shields.io/github/issues/WTRVGL/Companions.svg?style=for-the-badge
[issues-url]: https://github.com/WTRVGL/Companions/issues
[license-shield]: https://img.shields.io/github/license/WTRVGL/Companions.svg?style=for-the-badge
[license-url]: https://github.com/WTRVGL/Companions/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: https://user-images.githubusercontent.com/73450465/205472812-5027fa53-8151-4dac-9100-24b09c71ad59.png
[Next.js]: https://img.shields.io/badge/next.js-000000?style=for-the-badge&logo=nextdotjs&logoColor=white
[Next-url]: https://nextjs.org/
[React.js]: https://img.shields.io/badge/React-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://reactjs.org/
[Vue.js]: https://img.shields.io/badge/Vue.js-35495E?style=for-the-badge&logo=vuedotjs&logoColor=4FC08D
[Vue-url]: https://vuejs.org/
[Angular.io]: https://img.shields.io/badge/Angular-DD0031?style=for-the-badge&logo=angular&logoColor=white
[Angular-url]: https://angular.io/
[Svelte.dev]: https://img.shields.io/badge/Svelte-4A4A55?style=for-the-badge&logo=svelte&logoColor=FF3E00
[Svelte-url]: https://svelte.dev/
[Laravel.com]: https://img.shields.io/badge/Laravel-FF2D20?style=for-the-badge&logo=laravel&logoColor=white
[Laravel-url]: https://laravel.com
[Bootstrap.com]: https://img.shields.io/badge/Bootstrap-563D7C?style=for-the-badge&logo=bootstrap&logoColor=white
[Bootstrap-url]: https://getbootstrap.com
[ASP.NET.Core-Shield]: https://img.shields.io/badge/ASP.NET.Core-20232A?style=for-the-badge&logo=data:image/svg%2bxml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiPz4KPHN2ZyBpZD0iTGF5ZXJfMSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB2aWV3Qm94PSIwIDAgNjQgNjQiPjxkZWZzPjxzdHlsZT4uY2xzLTF7ZmlsbDojNWMyZDkxO30uY2xzLTIsLmNscy0ze2ZpbGw6I2ZmZjt9LmNscy0ye29wYWNpdHk6MC4xO30uY2xzLTR7ZmlsbDojZjJmMmYyO308L3N0eWxlPjwvZGVmcz48dGl0bGU+bG9nb19ORVRjb3JlPC90aXRsZT48Y2lyY2xlIGNsYXNzPSJjbHMtMSIgY3g9IjMyIiBjeT0iMzIiIHI9IjMyIi8+PHBhdGggY2xhc3M9ImNscy0yIiBkPSJNOS44Miw5QTMyLDMyLDAsMSwwLDU1LDU0LjE4WiIvPjxwYXRoIGNsYXNzPSJjbHMtMyIgZD0iTTcuNCwzNy4yNWExLjM1LDEuMzUsMCwwLDEtMS0uNDIsMS4zOCwxLjM4LDAsMCwxLS40MS0xLDEuNCwxLjQsMCwwLDEsLjQxLTEsMS4zNCwxLjM0LDAsMCwxLDEtLjQzLDEuMzcsMS4zNywwLDAsMSwxLC40MywxLjM5LDEuMzksMCwwLDEsLjQyLDEsMS4zNywxLjM3LDAsMCwxLS40MiwxQTEuMzgsMS4zOCwwLDAsMSw3LjQsMzcuMjVaIi8+PHBhdGggY2xhc3M9ImNscy0zIiBkPSJNMjcuMjcsMzdIMjQuNjVMMTUuMjgsMjIuNDZhNiw2LDAsMCwxLS41OC0xLjE0aC0uMDhhMTguNzIsMTguNzIsMCwwLDEsLjEsMi41VjM3SDEyLjU5VjE4Ljc3aDIuNzdsOS4xMiwxNC4yOHEuNTcuODkuNzQsMS4yMmguMDVhMTkuMjgsMTkuMjgsMCwwLDEtLjEzLTIuNjhWMTguNzdoMi4xM1oiLz48cGF0aCBjbGFzcz0iY2xzLTMiIGQ9Ik00MS42OSwzN0gzMlYxOC43N2g5LjI0VjIwLjdIMzQuMTh2Ni4wNmg2LjU4djEuOTJIMzQuMThWMzVoNy41MloiLz48cGF0aCBjbGFzcz0iY2xzLTMiIGQ9Ik01NiwyMC43SDUwLjdWMzdINDguNTdWMjAuN0g0My4zM1YxOC43N0g1NloiLz48cGF0aCBjbGFzcz0iY2xzLTQiIGQ9Ik0yNi4xMiw0OS40YTQuOTMsNC45MywwLDAsMS0yLjMyLjQ5LDMuNzQsMy43NCwwLDAsMS0yLjg3LTEuMTUsNC4yNiw0LjI2LDAsMCwxLTEuMDgtMyw0LjQ2LDQuNDYsMCwwLDEsMS4yMS0zLjI2LDQuMTIsNC4xMiwwLDAsMSwzLjA4LTEuMjQsNC45Myw0LjkzLDAsMCwxLDIsLjM1djFhNCw0LDAsMCwwLTItLjUsMy4wNiwzLjA2LDAsMCwwLTIuMzUsMSwzLjY0LDMuNjQsMCwwLDAtLjksMi41OCwzLjQ3LDMuNDcsMCwwLDAsLjg0LDIuNDUsMi44NiwyLjg2LDAsMCwwLDIuMjEuOTEsNC4xNCw0LjE0LDAsMCwwLDIuMTktLjU2WiIvPjxwYXRoIGNsYXNzPSJjbHMtNCIgZD0iTTMwLjIxLDQ5Ljg5QTIuNzgsMi43OCwwLDAsMSwyOC4wOCw0OWEzLjExLDMuMTEsMCwwLDEtLjc5LTIuMjMsMy4yNCwzLjI0LDAsMCwxLC44My0yLjM2LDMsMywwLDAsMSwyLjIzLS44NSwyLjY5LDIuNjksMCwwLDEsMi4wOS44MywzLjI4LDMuMjgsMCwwLDEsLjc1LDIuMjksMy4yMiwzLjIyLDAsMCwxLS44MSwyLjNBMi44NCwyLjg0LDAsMCwxLDMwLjIxLDQ5Ljg5Wm0uMDctNS40N2ExLjgzLDEuODMsMCwwLDAtMS40Ni42MywyLjU5LDIuNTksMCwwLDAtLjU0LDEuNzQsMi40NSwyLjQ1LDAsMCwwLC41NCwxLjY4LDEuODUsMS44NSwwLDAsMCwxLjQ2LjYyLDEuNzYsMS43NiwwLDAsMCwxLjQzLS42LDIuNjIsMi42MiwwLDAsMCwuNS0xLjcyLDIuNjYsMi42NiwwLDAsMC0uNS0xLjczQTEuNzUsMS43NSwwLDAsMCwzMC4yOCw0NC40MloiLz48cGF0aCBjbGFzcz0iY2xzLTQiIGQ9Ik0zNy44Niw0NC43MmExLjE4LDEuMTgsMCwwLDAtLjczLS4xOSwxLjIzLDEuMjMsMCwwLDAtMSwuNTgsMi42OCwyLjY4LDAsMCwwLS40MSwxLjU4djMuMDZoLTF2LTZoMVY0NWgwYTIuMSwyLjEsMCwwLDEsLjYzLTEsMS40MywxLjQzLDAsMCwxLC45NC0uMzUsMS41NywxLjU3LDAsMCwxLC41Ny4wOFoiLz48cGF0aCBjbGFzcz0iY2xzLTQiIGQ9Ik00My43Miw0N0gzOS40OUEyLjI0LDIuMjQsMCwwLDAsNDAsNDguNTRhMS44NiwxLjg2LDAsMCwwLDEuNDIuNTQsMywzLDAsMCwwLDEuODYtLjY3di45YTMuNDgsMy40OCwwLDAsMS0yLjA5LjU3LDIuNTQsMi41NCwwLDAsMS0yLS44MiwzLjM1LDMuMzUsMCwwLDEtLjczLTIuMywzLjI4LDMuMjgsMCwwLDEsLjc5LTIuMjgsMi41NSwyLjU1LDAsMCwxLDItLjg4LDIuMjYsMi4yNiwwLDAsMSwxLjgyLjc2LDMuMTgsMy4xOCwwLDAsMSwuNjQsMi4xMlptLTEtLjgxYTIsMiwwLDAsMC0uNC0xLjI5LDEuMzcsMS4zNywwLDAsMC0xLjEtLjQ2LDEuNTUsMS41NSwwLDAsMC0xLjE1LjQ5LDIuMjEsMi4yMSwwLDAsMC0uNTksMS4yN1oiLz48L3N2Zz4=

[ASP.NET.Core-url]: https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0


[MAUI-Shield]: https://img.shields.io/badge/.NET_MAUI-20232A?style=for-the-badge

[MAUI-url]: https://github.com/dotnet/maui


[SQL-Shield]: https://img.shields.io/badge/SQL_Server-20232A?style=for-the-badge

[SQL-url]: https://www.microsoft.com/sql-server


