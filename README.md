# Metal Assay Management System

Metal Assay is a desktop application designed for precious metal testing laboratories to manage the complete assay workflow from sample registration to final report delivery.

## Features

### Core Functionality
- **Customer Management**: Add, edit, and manage customer information with billing and coupon tracking
- **Sample Tracking**: Track samples using formcodes and itemcodes with sample weight recording
- **Weight Measurements**: 
  - First weight recording
  - Last weight recording with automatic result calculation
  - Problematic result handling (Reject/Redo/Low)
- **Automated Calculations**: 
  - Loss percentage calculation based on configurable weight ranges
  - Final result computation with loss deduction
  - Sample return weight tracking
- **Report Generation**: PDF report generation with company branding using iTextSharp

### Distribution Channels
- **Email**: Direct email delivery to customer addresses
- **Fax**: Windows Fax Service integration for fax transmission
- **Print**: Direct printing to configured printers
- **Save**: Export to desktop with automatic filename generation

### Report Options
- Single or split reports (one PDF per item)
- Preview before sending
- Send to alternative recipients
- Batch processing for multiple items

### Administrative Features
- **User Authentication**: Secure login with password hashing (PBKDF2 with SHA256)
- **Role-Based Access**: Three user roles (Worker, Admin, Boss)
- **Settings Management**:
  - Loss percentage configuration by weight range
  - Company information management
  - Report orientation settings (Portrait/Landscape)
- **Date Range Reports**: Generate CSV reports with billing and coupon statistics by area (BW/PG)
- **Activity Logging**: Comprehensive logging of all operations to daily log files

### Area Management
- Support for multiple operational areas (BW, PG)
- Area-specific reporting and statistics
- Billing and coupon tracking per area

## Technology Stack

### Framework & Language
- **.NET Framework 4.7.2**
- **C# Windows Forms**

### Database
- **MySQL 8.1.0** - Primary data storage
- **MySql.Data 8.1.0** - Database connectivity

### Key Libraries
- **iTextSharp 4.1.6** - PDF generation and manipulation
- **BouncyCastle 1.9.0** - Cryptographic operations (password hashing)
- **SkiaSharp 2.88.6** - Graphics rendering for PDF images
- **HarfBuzzSharp 7.3.0** - Text shaping for PDF rendering
- **Windows FAX COM API** - Fax transmission functionality

## 📁 Project Structure

```
Metal_Assay/
├── Program.cs                    # Application entry point
├── GlobalConfig.cs               # Global configuration (connection string)
├── MainForm.cs                   # Main application window
├── LoginForm.cs                  # User authentication
│
├── Forms/
│   ├── AddForm.cs               # Add new assay records
│   ├── EditForm.cs              # Edit existing records
│   ├── NewForm.cs               # Create new formcode entries
│   ├── NewCustomer.cs           # Customer management
│   ├── ChooseItemForm.cs        # Item selection for reports
│   ├── PreviewForm.cs           # PDF preview before sending
│   ├── ResultForm.cs            # Final result calculation
│   ├── ProblematicResultForm.cs # Handle problematic results
│   ├── SendReportForm.cs        # Date range report generation
│   ├── SendToOther.cs           # Alternative recipient selection
│   └── SettingForm.cs           # Application settings
│
├── Resources/
│   ├── bar.ico                  # Application icon
│   └── [.resx files]            # Form resources
│
└── packages.config              # NuGet package configuration
```


## 📊 Workflow

### Typical Assay Process

1. **Customer Registration**
   - Add new customer or select existing
   - Configure billing and coupon settings
   - Set area assignment (BW/PG)

2. **Create New Formcode**
   - Generate new formcode for batch testing
   - Associate with customer

3. **Add Sample Items**
   - Enter itemcode and sample weight
   - System tracks up to 14 items per formcode

4. **Record Measurements**
   - Enter first weight measurements
   - Enter last weight measurements
   - System calculates average results

5. **Calculate Final Results**
   - System applies loss percentage based on weight
   - Calculate final result automatically
   - Handle problematic results if needed

6. **Generate and Distribute Reports**
   - Preview PDF report
   - Choose distribution method:
     - Save to desktop
     - Email to customer
     - Fax to customer
     - Print directly
   - Option to split into individual reports

7. **Track Sample Returns**
   - Record sample return weights
   - Update customer records
---

**Version**: 1.0  
**Last Updated**: 2025  
**Platform**: Windows Desktop (.NET Framework 4.7.2)
