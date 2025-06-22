# Financial Forecasting

## Overview

This assignment demonstrates how to **forecast future monthly revenue** based on historical data using **average growth rate**. It employs **DSA (Data Structures and Algorithms)** concepts like arrays, loops, and mathematical logic.

Key highlights:
- Takes revenue input for `n` past months.
- Calculates the **average month-to-month growth rate**.
- Forecasts the revenue for the next `m` months using this growth rate.
- Uses **primitive arrays** instead of collection-based `List<Double>` for space efficiency.
---

### Logic Used
### `calculateAvgGrowthRate(double[] monthlyRevenue, int size)`
- Computes the average growth rate using the formula:
  \[
  \text{growth} = \frac{\text{Revenue}_{i} - \text{Revenue}_{i-1}}{\text{Revenue}_{i-1}}
  \]
- Returns the average of these rates over the provided months.

### `forecast(double[] hist, int histSize, int n)`
- Allocates a new array of size `histSize + n`.
- Copies historical values.
- Uses the growth rate to forecast upcoming `n` months.

---

## Key Functionalities

### `addProduct(Product p)`
- Adds a product to the global list.
- Inserts it into the `HashMap` by category for fast access.

### `searchByName(String name)`
- Performs a **linear search** on the product list.
- Displays products whose names contain the search keyword.

### `searchByCategory(String category)`
- Fetches product set using a **HashMap**.
- Prints all products under the selected category.

---

## How to Run
### Prerequisites
- Java JDK 8 or later must be installed
- Any terminal or command prompt

---

### Compilation

```bash
javac exercise4.java
```

### Execution
```bash
java exercise4
```

## Input
```bash
Enter number of past months data: 
4
Enter revenue for month 1: 10000
Enter revenue for month 2: 20000
Enter revenue for month 3: 30000
Enter revenue for month 4: 40000
Enter number of months to forecast: 
4
```

## Output
```bash
Historical Revenue Data
        Month 1: Rs.10000.00
        Month 2: Rs.20000.00
        Month 3: Rs.30000.00
        Month 4: Rs.40000.00

Forecasted Revenue
        Month 5: Rs.64444.44
        Month 6: Rs.103827.16
        Month 7: Rs.167277.09
        Month 8: Rs.269501.98
```