#  GrapheneTrace – Clinician Monitoring Dashboard  
ASP.NET Core MVC | SQL Server | C# | Bootstrap | Charts

GrapheneTrace is a web-based clinical monitoring system designed to help clinicians track patient risk levels, sensor readings, pressure metrics, heatmaps, alerts, and historical reports.  
This repository contains the group’s full implementation including all Clinician functionalities, services, controllers, models, and UI views.

---

##  Key Features

###  Clinician Role
- Secure login & authentication  
- Dashboard displaying all assigned patients  
- Real-time alerts for pressure risk  
- Heatmap and sensor data visualisation  
- Metrics graphs (pressure, posture, offloading, movement)  
- Notes/comments section for patients  
- Report generation screen  
- Clean MVC structure for controlled data flow  

---

##  Architecture Overview

GrapheneTrace follows the **ASP.NET Core MVC** pattern:

Controllers → Services (Logic Layer) → Models → Database
↓
Views (UI)

This ensures:
- Clear separation of logic  
- Maintainable code  
- Easy testing  
- Reusable components  

---

##  Project Folder Structure
WebApplication2/
│
├── Controllers/
│ ├── ClinicianController.cs
│ ├── DashboardController.cs
│ ├── AlertsController.cs
│ └── MetricsController.cs
│
├── Models/
│ ├── Patient.cs
│ ├── Metrics.cs
│ ├── Alert.cs
│ └── Clinician.cs
│
├── Views/
│ ├── Clinician/
│ ├── Dashboard/
│ ├── Alerts/
│ └── Metrics/
│
├── wwwroot/
│ ├── css/
│ ├── js/
│ └── images/
│
└── WebApplication2.sln


---

##  Metrics & Heatmap Visualisation

- Pressure trend graphs (Chart.js / internal charting)
- Daily/weekly summaries
- Real-time colour-coded heatmap visuals  
- Automatic risk detection alerts  

---

##  Alerts System

The system automatically displays alerts if:
- Pressure crosses a threshold  
- Patient remains still too long  
- Position change is required  

---

##  MVC Data Flow Example

Example: **Clinician Dashboard Loading**

1. **ClinicianController** receives request  
2. Calls service layer → fetches patient list  
3. Model is constructed  
4. View is rendered with graphs + alerts  

---

##  Screenshot Placeholders (Replace with real images)

### 🔷 Dashboard  
_Add a screenshot here_

### 🔷 Alerts Page  
_Add a screenshot here_

### 🔷 Metrics Graph  
_Add a screenshot here_

### 🔷 Heatmap View  
_Add a screenshot here_

---

##  Technologies Used

- C#  
- ASP.NET Core MVC  
- Entity Framework  
- SQL Server  
- Bootstrap  
- JavaScript  
- Chart.js / Graph libraries  

---

##  Contributors

- **Kirtan Patel** – Clinician Role UI & Logic  
- **Sagar** – Alerts, user authentication, logs  
- **Jainish** – Dashboard & login  
- **Smit** – Patient module  

---

##  How to Run

1. Clone repo  
2. Open in **Visual Studio 2022**  
3. Restore NuGet packages  
4. Update `appsettings.json` with your SQL Server connection  
5. Run the project  

---

##  Project Status  
✔️ Final submission build  
✔️ Fully functional Clinician role  
✔️ All pages + graphs working  
✔️ Code ready for documentation tools (CodeWiki / VSDocs)

---



