# E-Commerce product search Functionality

## Overview

This assignment demonstrates the use of **Data Structures and Search Algorithms** in Java by simulating a simple **E-Commerce product search** functionality. 

It allows users to:
- Search products by **name** using **linear search**.
- Search products by **category** using a **HashMap** for efficient lookup.
---

### Product Data Structure
### `Product` Class
Each product has:
- `name`: the product name (case-insensitive)
- `category`: the product category (case-insensitive)
- `price`: the product price (double)

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

## 💾 Sample Products

| Product | Category | Price   |
|---------|----------|---------|
| P1      | C1       | 79999   |
| P2      | C1       | 59999   |
| P3      | C2       | 4999    |
| P4      | C2       | 2999    |
| P5      | C3       | 39999   |

---

## How to Run
### Prerequisites
- Java JDK 8 or later must be installed
- Any terminal or command prompt

---

### Compilation

```bash
javac exercise3.java
```

### Execution
```bash
java exercise3
```

## Output
```bash
E-Commerce Product Search
1. Search by Product Name
2. Search by Category
0. Exit
Enter your choice: 1
Enter Product Name (P1 to P5): P2
Search Products by Product Name: P2
Product Name: p2, Category: c1, Price: 59999.0

E-Commerce Product Search
1. Search by Product Name
2. Search by Category
0. Exit
Enter your choice: 2
Enter Category (C1 to C3): C2
Search Products for Category: C2
Product Name: p3, Category: c2, Price: 4999.0
Product Name: p4, Category: c2, Price: 2999.0

Enter your choice: 0
Exiting the program. Thank you!
```