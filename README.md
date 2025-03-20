# Triple DES Encryption & Decryption

This project implements **Triple DES (3DES) encryption and decryption** in C#. It supports **TDES-168** (three keys) and **TDES-112** (two keys) modes with **CBC and ECB** cipher modes.

## Features
✅ Supports **TDES-168 (24-byte key)** and **TDES-112 (16-byte key, K3 = K1)**  
✅ Supports **CBC (Cipher Block Chaining) and ECB (Electronic Codebook) modes**  
✅ Supports **PKCS7 and ZeroPadding**  
✅ Handles **HEX or Base64 encoding**  
✅ User input validation with **automatic key field disabling** for TDES-112  

---
## Getting Started

### Prerequisites
- .NET 8.0
- Windows OS (for running Windows Forms applications)

## Setup Instructions
### **1. Clone the Repository**
```sh
git clone https://github.com/YanuarGuo/TripleDESEncryption.git
```

### **2. Open in Visual Studio**
- Open the `.sln` file in **Visual Studio**.
- Ensure you have **.NET 8 or Higher** installed.

### **3. Build & Run**

---

## Usage
### **Encrypting a String**
```csharp
string encrypted = TripleDESEncryption.Encrypt(
    "Hello, World!",
    "12345678ABCDEFGH87654321", // Key (16 or 24 bytes)
    "ABCDEFGH",                 // IV (8 bytes, for CBC mode only)
    "PKCS7",                    // Padding mode
    "HEX",                       // Output format (HEX or Base64)
    "CBC",                       // Cipher mode (CBC or ECB)
    "TDES-168"                   // TDES Mode (TDES-168 or TDES-112)
);
Console.WriteLine($"Encrypted: {encrypted}");
```

### **Decrypting a String**
```csharp
string decrypted = TripleDESEncryption.Decrypt(
    encrypted,
    "12345678ABCDEFGH87654321",
    "ABCDEFGH",
    "PKCS7",
    "HEX",
    "CBC",
    "TDES-168"
);
Console.WriteLine($"Decrypted: {decrypted}");
```

---

## Key Handling
- **TDES-168** (3 keys, 24 bytes): Uses `K1-K2-K3`
- **TDES-112** (2 keys, 16 bytes): Uses `K1-K2-K1`

Your UI should disable **TxtKey3** when **TDES-112** is selected:
```csharp
private void CbMode3DES_SelectedIndexChanged(object sender, EventArgs e)
{
    if (CbMode3DES.Text == "TDES-112")
    {
        TxtKey3.Text = "";  // Clear Key3
        TxtKey3.Enabled = false;
    }
    else
    {
        TxtKey3.Enabled = true;
    }
}
```

---

## Author
Developed by **Yanuar Christy Ade Utama**.

## Contributions
Feel free to submit **issues, feature requests, or pull requests** to improve this project!
