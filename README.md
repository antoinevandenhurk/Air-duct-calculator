Read [](file:///d%3A/LuchtkanaalCalculator/LuchtkanaalCalculator/MainWindow.xaml.cs#1-1), lines 1 to 30

Searched for text `Content=` (`**/MainWindow.xaml`), 11 results

<create_file>
<parameter name="filePath">d:\LuchtkanaalCalculator\README.md</parameter>
<parameter name="content"># Air Duct Calculator / Digitale Luchtschijf

A professional Windows desktop application for calculating air duct properties including flow rates and velocities for HVAC systems.

## Features

- **Multi-duct Type Support**: Calculate properties for:
  - Rectangular ducts (B x H)
  - Circular ducts
  - General duct geometries
  
- **Dual Calculation Modes**:
  - Calculate flow rate (Debiet) based on velocity and cross-sectional area
  - Calculate velocity based on known flow rate and area
  
- **User-Friendly Interface**:
  - Intuitive Dutch language interface
  - Color-coded input/output areas
  - Clearly organized calculation buttons
  - Fast and responsive calculations

- **Formula-Based Calculations**:
  - Standard HVAC flow rate formula: Q = v × A × 3600
  - Precise geometric area calculations for different duct shapes
  - Support for both metric (mm/m³/h) and imperial units

## Technical Details

- **Platform**: Windows Desktop (WPF)
- **Framework**: .NET 8.0+
- **Language**: C#
- **UI Framework**: Windows Presentation Foundation (WPF) with XAML
- **Target OS**: Windows 10 and later

## Requirements

- Windows 10 or later
- .NET 8.0 Runtime (or higher)

## Installation

### From Release

1. Download the latest release from the [Releases page](https://github.com/antoinevandenhurk/Air-duct-calculator/releases)
2. Extract the executable
3. Run `LuchtkanaalCalculator.exe`

### Build from Source

1. Clone the repository:
   ```bash
   git clone https://github.com/antoinevandenhurk/Air-duct-calculator.git
   cd Air-duct-calculator
   ```

2. Build the project:
   ```bash
   dotnet build LuchtkanaalCalculator.sln -c Release
   ```

3. Run the application:
   ```bash
   dotnet run -c Release
   ```

Or find the compiled executable at:
```
LuchtkanaalCalculator\bin\Release\net8.0-windows\LuchtkanaalCalculator.exe
```

## Usage

### Basic Workflow

1. Select the duct type you want to calculate
2. Enter the required dimensions (diameter for round ducts, width and height for rectangular ducts)
3. Enter either:
   - **Velocity** → Click "Bereken debiet" (Calculate Flow Rate)
   - **Flow Rate** → Click "Bereken snelheid" (Calculate Velocity)
4. View the calculated result

### Keyboard Navigation

- Use **Tab** key to navigate between input fields
- Use **Arrow keys** within input areas
- Press **Enter** on buttons to activate calculations

## UI Layout

- **Column 1-2**: Dimension inputs (diameter, width, height)
- **Column 3**: Velocity/Flow rate inputs
- **Column 4**: Calculation buttons
- **Column 5**: Additional operations (Clear, Exit, Info)

## Building for Release

To create a standalone release package:

```bash
dotnet clean LuchtkanaalCalculator.sln
dotnet publish LuchtkanaalCalculator.sln -c Release -r win-x64 --self-contained false
```

## License

See LICENSE file for details.

## About

Developed as a professional HVAC calculation tool. The VVA logo is included in the application title bar.

## Support

For issues, feature requests, or contributions, please visit the [GitHub repository](https://github.com/antoinevandenhurk/Air-duct-calculator).
</parameter>
</invoke>
