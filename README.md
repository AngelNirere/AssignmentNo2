# Assignment No 2: C# Desktop Application (Windows Forms)

A Windows Forms application built with C# (.NET) that converts the Lab 1 console programs (Bicycle Rental and Mushroom Finder) into a desktop application.

**Name:** Nirere Angelique
**Student ID:** 26564

## Features

### Login
- Username and password cannot be empty (MessageBox warning if they are).
- After a successful login, the app opens the Choose form.

### Choose
- Two buttons: **Bicycle** and **Mushroom**.

### Bicycle Rental
- Enter a start hour (0-23) and an end hour (1-24).
- Only whole numbers are accepted, and the start time must be less than the end time.
- Hourly rates:

| Hours | Rate per hour |
|---|---|
| 0 - 7 and 21 - 24 | 500 RWF |
| 7 - 14 and 19 - 21 | 1000 RWF |
| 14 - 19 | 1500 RWF |

- The total is shown in the **Total** textbox and in a MessageBox.

### Mushroom Finder
- Think of one of six mushrooms: Agaric jaunissant, Amanite tue-mouche, Cepe de Bordeaux, Coprin chevelu, Girolle, Pied bleu.
- The app asks at most 3 yes/no questions and shows the mushroom in a MessageBox.

### Navigation
- **Back:** Bicycle or Mushroom returns to Choose.
- **Logout:** Bicycle or Mushroom returns to Login.

## Flow

```
Login -> Choose -> Bicycle  (Back -> Choose, Logout -> Login)
                -> Mushroom (Back -> Choose, Logout -> Login)
```

## Project Structure

| File | Purpose |
|---|---|
| `Program.cs` | Application entry point |
| `BaseForm.cs` | Shared theme (pink and black) and navigation |
| `LoginForm.cs` | Login form |
| `ChooseForm.cs` | Menu form |
| `BicycleForm.cs` | Bicycle rental form |
| `MushroomForm.cs` | Mushroom finder form |
| `Logic.cs` | Rental price calculation |

## How to Run

1. Install [Visual Studio](https://visualstudio.microsoft.com/) with the **.NET desktop development** workload.
2. Clone the repository:
   ```
   git clone https://github.com/AngelNirere/AssignmentNo2.git
   ```
3. Open `bicyclerentalF.sln` in Visual Studio.
4. Press **F5** to run.

## Technologies

- C#
- .NET (Windows Forms)
- Visual Studio
