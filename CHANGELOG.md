
# AGEPRO Changelog

## 4.3.0.5-beta5 (2017-02-2x)

## Fixed
- Unified behavior how parametric recruitment text boxes deal with blanks and values with non-numeric input. They will revert to previous value.

## Changed
- Bootstrap controls are resizeale
- Parametric Recruitment: Switched postions of KParm and Variance labels and textbox.
- CoreLib: Refactored Shepherd Curve code in ParametricCurve to subclass ParametricShepherdCurve. 

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