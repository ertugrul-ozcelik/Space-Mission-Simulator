# 🚀 Space Mission Simulator

A console-based resource management and space exploration strategy game developed in **C#**. 

This project was engineered as part of the **CME1211 (Introduction to Programming)** curriculum at **Dokuz Eylül University, Department of Computer Engineering**. 

---

## 🛠️ Engineering Challenge & Architecture

What makes this project unique from an engineering standpoint is the **strict architectural constraint** under which it was built:
* **Forbidden Features:** Arrays, Lists, Collections, Classes (OOP), File I/O, and User-Defined Methods/Functions were strictly prohibited.
* **The Solution (Single-Loop State Machine):** The entire 900+ lines of game logic, location transitions, inventory tracking, and resource validations are built solely using **primitive data types, boolean state switches, conditional blocks (`if-else`), and nested `while` loops**. 

A central main-loop (`mainMenuLoopController`) acts as the core engine, while boolean flags (`optionSwitchSpaceStation`, `optionSwitchMercury`, `optionSwitchMars`, `optionSwitchEuropa`, `optionSwtitchSupplyStation`) manage state transitions and location memory seamlessly without relying on external functions.

---

## 🎮 Game Overview & Mechanics

You are the commander of a spaceship starting at the **Space Station** with limited resources. Your ultimate objective is to manage your supplies across multiple mission days and successfully explore **Mercury**, **Mars**, and **Europa**.

### 📊 Initial Resources
* **Credits:** `100 C` (Used for purchasing supplies and repairing the hull)
* **Fuel:** `60 / 100` (Consumed during interplanetary travel)
* **Oxygen:** `70 / 100` (Consumed during travel and at the end of each day)
* **Energy:** `65 / 100` (Consumed during planetary exploration and mineral collection)
* **Spaceship Health:** `100 / 100` (Decreases during harsh planetary explorations)
* **Mission Score:** `0` (Accumulated through explorations and special bonuses)

---

## 🪐 Planetary Specifications & Unlock Rules

| Property | Mercury | Mars | Europa (Locked 🔒) |
| :--- | :---: | :---: | :---: |
| **Travel Fuel Cost** | 10 | 15 | 20 |
| **Travel Oxygen Cost** | 8 | 12 | 16 |
| **Exploration Energy Cost** | 12 | 18 | 25 |
| **Exploration Health Loss** | 5 | 10 | 15 |
| **Min. Health to Explore** | 31 | 50 | 60 |
| **Exploration Reward** | 15 C / 10 Pts | 25 C / 20 Pts | 40 C / 80 Pts |
| **Minerals per Collection** | +2 | +3 | +4 |
| **Collection Energy Cost** | 8 | 10 | 12 |

### 🔓 Unlocking Europa
Europa is initially locked. To travel to Europa, the commander must fulfill **three strict conditions**:
1. Successfully explore **Mercury**.
2. Successfully explore **Mars**.
3. Collect a cumulative total of at least **4 minerals from Mercury** (tracked permanently even if sold at the Supply Station).

---

## ⚙️ Key Features & Rules

* **Supply Station & Location Memory:** Accessible from any location without consuming a field operation. Using boolean location reminders (`locationReminderMercury`, etc.), the game remembers which planet you came from and returns you directly to your previous orbit upon exit.
* **Daily Operation Cycle:**
  * Players must complete at least **2 successful field operations** (exploration or mineral collection) to manually end the day.
  * Reaching **5 successful field operations** automatically triggers the end of the day.
  * Ending a day consumes `5 Oxygen`, restores `15 Energy` (capped at 100), and resets daily planetary mineral collection limits.
* **Special Oxygen Lifeline:** If oxygen drops to `15` or below for the first time, an emergency life-support protocol automatically triggers a one-time free boost of `+20 Oxygen`.
* **Consecutive Exploration Bonus:** Exploring two different planets on the same day without collecting minerals in between awards a `+10 Mission Score` bonus.
* **Input Validation:** Built with `short.TryParse` to ensure the simulation never crashes on invalid user inputs, negative numbers, or out-of-range menu selections.

---

## 🚀 How to Run

1. Clone this repository or download the source file (`2025510101_Ertugrul_Ozcelik.cs`).
2. Open the file in **Visual Studio** or any C# environment (.NET SDK).
3. Compile and run the program:
   ```bash
   dotnet run
   ```

---

## 👤 Author

**Ertuğrul Özçelik**  
*Computer Engineering Student @ Dokuz Eylül University*



