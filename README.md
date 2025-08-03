# Vending Machine Console Application

A `C# console-based vending machine` application. It supports coin insertion, product selection, change return, and message display logic, following solid principles and unit testing practices.

---

## 🛠 Features

- Accepts valid coins: **Nickels (0.05$)**, **Dimes (0.10$)**, **Quarters (0.25$)**
- Rejects invalid coins (e.g., **Pennies (0.01$)**)
- Allows product selection via product buttons
- Displays real-time:
  - Paid amount
  - Remaining amount
  - Product and pricing details
- Returns change if overpaid
- Clears display and resets after product dispense

---

## 🧾 Products & Pricing

| Product | Price  |
|---------|--------|
| Cola    | $1.00  |
| Chips   | $0.50  |
| Candy   | $0.65  |

---

## 🧪 Unit Testing

- Uses **NUnit** for test cases.
- Coverage includes:
  - Coin validation and acceptance
  - Product selection (valid and invalid)
  - Exact and insufficient payments
  - Display logic

Test classes:
- `DisplayTests.cs`
- `VendingMachineTests.cs`

---

## 🧑‍💻 How to Run

1. **Clone the repo**
   ```bash
   git clone https://github.com/your-username/vending-machine-app.git
   cd vending-machine-app

### 🖥 Sample Console Output
<img width="698" height="798" alt="image" src="https://github.com/user-attachments/assets/14ef38a5-fb8c-4252-9e7c-82a77cc7dca5" />

### 🧪 Unit Test Results
<img width="1187" height="740" alt="image" src="https://github.com/user-attachments/assets/cf6b6c9c-d373-467b-a175-f2ac5471b1e2" />

