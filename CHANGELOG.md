
# AGEPRO Changelog

## 4.3.0.3-beta3 (Unreleased)

### Added
- Added Data Grid Context Menu.
- Clipboard functionality (Cut, Copy, Paste, Delete, etc.) to data grids.
-- Edit menu commands work with data grid cells.

### Fixed
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