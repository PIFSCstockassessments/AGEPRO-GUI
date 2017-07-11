
# AGEPRO Changelog

## 4.3.0.9-beta9 (2017-07-00)

## Added
- Html help feature (Reimplentation of 'Using AGEPRO' help feature from version 4.2.2)
- Interface and Calcuation Engine Versions in About AGEPRO dialog box. 

## Changes
- Disabled "Reference Manual (pdf)" menu item.

## Fixed
- Input Files: Implmented missing validation checks when the "Save AGEPRO input data as ..." menu option was selected from file menu.

## 4.3.0.8-beta8 (2017-06-13)

### Added
- Enumeration flags StochasticAgeFleetDepenendency and StochasticWeightOfAge

### Fixed
- Loading a stocahastic parameter via a new set cases wtih multiple fleets was causing interface crashes. 
- Non fleet-dependent Stochastic Parameters with cases that have more than 1 fleet, will not cause errors when loading their daia grids. 
- Refactored StochasticAge datatable loading/creation functions from FormAgepro to ControlStochasticAge classes.
- Flag Catch Weight of Age as a Fleet Dependent Stochastic Weight of Age parameter.
- Loading new stochastic parameters data grids from new set cases will have a default value (of "0").

## 4.3.0.7-beta7 (2017-05-24)

### Added
- ControlRecruitment: Null/'None Selected' fallback check on collectionAgeproRecruitmentModels when switching to "Recruit Model" Tab from the "Recruitment" tab.

### Fixed
- Corrected implementation issues loading recruitment parameters with the "Create new case" method
  - New "SET" cases recuritment list collectoion is now initalized properly.  
  - Passing default values for Recruitment Scaling Factor and SSB Scaling Factor. 
  - Unify ControlRecruitment GUI control parameter setup method in ControlRecruitment.cs. This also disposes the previous recruitment parameter panel (recruit model tab).
- Renamed CreateBlankDataTable in FormAgepro.cs to CreateRecruitProbTable in ControlRecruitment.cs
  - For compatiablity, copied the original CreateBlankDataTable functionallity to CreateFallbackAgeDataTable in FormAgepro.cs.

## 4.3.0.6-beta6 (2017-04-05)

### Added
- Added NftTextBox. Used for scale factor validation. 
- General options panel is now "resizible"

### Fixed
- If ValidateControlInputs is false/invalid, then it should now prevent AGEPRO calcuation engine from being launched.
- Program adheres to the user's cancellations (says "no") to launch the AGEPRO model, because the large file size/performace warning. 
- CoreLib: Opening a Shepherd Curve with Auto Corrected Lognormal Error (Model #12) recruitment model from file now loads the phi and Last Residual parameters.
- Misc. Options: Clarified Reference Point and Scaling Factors Check box Text

## 4.3.0.5-beta5 (2017-03-01)

### Added
- Validation for Recruitment Scale Factor, SSB Scale Factors, and Bootstrap Population Scale Factors.

### Fixed
- Validation behavior for all parametric recruitment paramerters whether or not the data type is nullible or not: They will revert to previous value.
- RecruitScaleFactor and SSBScalingFactor are now double floating-point data types instead of integers.
- Parametric Recruitment: Switched postions of KParm and Variance labels and textbox.
- CoreLib: Refactored Shepherd Curve code in ParametricCurve to subclass ParametricShepherdCurve. 
- Bootstrap controls (file textbox and button) now adjust to the size of its panel.

## 4.3.0.4-beta4 (2017-01-27)

### Added
- Validation data input checks.
- Bootstrap filename vailidation check. Dialog w/ option to load filename. 
- Namespace changes. AGEPRO.GUI is now 'Nmfs.Agepro.Gui', and AGEPRO.CoreLib is now 'Nmfs.Agepro.CoreLib'. 
- Recruitment: Empirical and Predictor Recruitment observation tables now have Row Headers 
- Recruitment: Markov Matrix Recruit/SSB level check to prevent zero/negative values. For these cases, use default recruit/SSB levels.

### Fixed
- Recruitment: Fixed Loading a new Parametric Recruitment model with either Autocorrelated Values and/or and K-Parm parameter for the first time are null/have no values shown.      
- Recruitment: Resolved issues where some of the AGEPRO model parameters were not properly created when generated from general options:
  - Properly check the MarkovRecruitment Data Table Set if they are null. Create a new Markov Matrix data set of tables as intended. 
  - Data binded Predictor parameters to the CoreLib Data Structure.
- Recruitment: Resolved an issue when a user selects the "None Selected" Recruitment to replace another recruitment model. It would then retain the controls/interfaces the replaced recruitment model used in the recruit model tab.
- Recruitment: Error where Level 2 Observation Table rows was sharing Level 1 Observation Table events. Led to errors when adding/removing level 2 and level 1 observation table rows.

## 4.3.0.3-beta3 (2016-12-22)

### Added
- Added Data Grid Context Menu.
- Clipboard functionality (Cut, Copy, Paste, Delete, etc.) to data grids.
  - Edit menu commands work with data grid cells.

### Fixed
- Resolved an issue pasting cells directly from Excel 
- Column headers follows the original GUI behavior by not sorting the data grid, if header is clicked.
- Harvest Scenario: Fixed an issue where user generated "SET" multi-fleet parameters generated a Harvest Scenario Table with only a single row.

## 4.3.0.2-beta2 (2016-11-29)

### Added
- P-star: Added Label 'P-Star Levels' on top of P-Star Levels Data Grid 

### Fixed
- Bootstrap: Implemented "Load File" button. 
- Bootstrap: Corrected the description for the AGEPRO Bootstrap File Filter in the Open File Dialog.
- P-star: Resolved an issue where model inputs without P-Star data (a.k.a. not loaded from the Input File) will have a blank/null PStar Data Grid Table. This issue consequently had lead to crashing to program if the user attempts to change the "Number of P-Star Levels" on these blank/null tables.
- Harvest Scenario: User-generated parameters ("SET" from general options instead from Input File) will generate a Harvest Scenario Table. 

### Removed
- Removed "Command Window Stays Open until run" menu command

## 4.3.0.1-beta1 (2016-11-22)
First release of GUI rewrite.
 
### Significant User Changes from AGEPRO 4.2.2
- Replace tabs with the a navigation Tree Node to navigate through AGEPRO parameters.    
- Launching AGEPRO Calcuation Engine saves a copy of current GUI input (along with a copy of the bootstrap and engine output) to the AGEPRO users document folder instead of overwriting input file.
- No output plot functionality for the calcuation engine output.
- AGEPRO Input File Compatibility: Only for version 4.0 
- Output File Viewer option now in Misc options.