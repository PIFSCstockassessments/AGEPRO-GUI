
# AGEPRO Changelog

## 4.3.5 (2022-09-15)

## Changes

- Include September 2022 revisions to AGEPRO Reference Manual.

## 4.3.4 (2021-06-15)

## Changes

- AGEPRO GUI and CoreLib code refactor (Overall changes)
  - Format public class members to Pascal Casing. (Private class members will have Underscore-Prefix Pascal Casing)
  - Renoved Unused Imports
  - Simplify (reduced) usage of the `this` keyword   
  - Replace `var` to explict types
  - Simplify Array Implementation
  - Refactored conditionals (if-else, null checks) to be more readable.    
  - Appplied standalone discards for existing methods that returns a value.
  - Enums refactored to own file
- Added new AGEPRO example model: Uku snapper Projection Base (2019-2026)
- AGEPRO user help manual
  - Inculded missing images to binary
  - Reverted stylesheet back to basic html style
  - Added AGEPRO Projection Samples section  
  - Minor updates to the Weights of Age Section
- CoreLib: Bootstrap, (Misc)Options, Recruitment, Harvest Scenario (HarvestCalcuation) uses generalized AgeproCoreLibProperty class for data binding.
- User Interface
  - Added Base class FormAgepro to handle ui startup, validation, load, save, create new Agepro model from user input.
  - Minor menu item size adjustment for Windows 10   
- Pstar/Rebuider
  - Use CoreLib to create PStar and Rebulider objects; Remove AGPERO GUI data object redundancy.
  - PStar/Rebuilder control defaults will now instantiate from its own classes rather from the ControlHarvestScenario constructor.
- Recruitment
  - CoreLib: Extract RecruitDictionary as class RecruitModelDictionary.
  - Removed AGEPRO GUI reduancy and reference usages to CoreLib object.
  - CoreLib: Invaild recruitment row coount error message claification.
- AgeproMiscOptions
  - Removed Util.GetAgeproInputDataTable; ControlMiscOptions.LoadRetroAdjustmentsFactorTable is the replacement method
  - CoreLib: Refactor Misc Option classes as indvidual "AgeproOptionProperty" subclass files
- Biological
  - Created ControlTSpawnPanel to encapsulate embeded 'Fraction Mortality' methods in ControlBiological;
- Stochastic/Weights Of Age
  - Fixed Null Input Data Stochastic Weight of Age Import Fix
- CoreLib: Moved code files into categorized src subdirectories. No changes to namespaces, new CoreLib scripts adjusted to `Nmfs.Agepro.CoreLib` namespacce
- Renames to AGEPRO GUI objects:
  - (src/ui/formAgepro subdirectory) home -> general-startup 
  - ControlStochasticAge.EnableTimeVaryingCheckBox -> ControlStochasticAge.EnableFromFilePanel
  - FormAgepro.CreateAgeproModel -> FormAgeproBase.SetAgeproModelFromUserInput
  - FormAgepro.LoadAgeproInputParameters -> LoadAgeproBase.LoadAgeproModelFromInputFile
  - ControlStochasticAge.EnableVaryingCheckBox -> ControlStochasticAge.EnableFromFilePanel
-Renames to AGEPRO CoreLib objects:
  - MiscOptionsParameter -> AgeproOptionsProperty
  - jan1Weight -> Jan1StockWeight
  - biological -> BiologicalTSpawn
  - maturity -> BiologicalMaturity
  - retroAdjustOption -> RetroAdjustments 
  - RecruitmentModel -> RecruitmeentModelProperty
  - FixedEmpiricalRecruitment -> EmpriricalFixedRecruitment
  - TwoStageEmpiricalRecruitment -> EmpriricalTwoStageRecruitment

## 4.3.3 (2021-03-22)

## Changes
- Removed Redundant `F-MULT` validation check preventing rebuilder projections to launch the AGEPRO Calculation Engine (#13)
- AGEPRO user help manual
  - Updated screenshots to Windows 10
  - Formatted with the Pandoc default html styleseet
  - Converted example Combined Catch Distrbution & Requested Percentile Report output as tables
  - Fixup help manual section links
- About: Updated NOAA Branding
- Minor refactoring
  - GUI & CoreLib: catergoized code in src subdirectories (no changes to namespaces)
 
## 4.3.2 (2019-07-24)

## Changes
- Fixed an issue preventing AGEPRO Input Files with tabular whitespace delimiters to be loaded to GUI. 
  - CoreLib: Replace space charcter to default (whitespace character delimitations) to split input fileline values. (#7)
- Refactored StochasticWeightAge Input Data file loading code to be consistent with StochasticAgeTable, in Loading AGEPRO Input Files and setting user generated new cases.
  - Call CreateStochasticAgeFallBackTable to handle Fleet Dependency and to remove redundancy. (#9)
  - Renamed LoadWeightAgeInputData -> LoadStochasticWeightAgeInputData. 
  - Set access to helper method CreateFallbackAgeTable to private.
  - Cleaned up null checks
- Replaced Nmfs.AGEPRO.GUI.ControlGeneral with Nmfs.AGEPRO.CoreLib.AgerproGeneral as the General Options class parameter of the  CreateStochasticParameterFallbackDataTable method to match consistency with Stochastic Data Tables.  
- Fixed data binding issues for PStar and Rebuilder values.
  - Fixed an issue where new/modified PStar or Rebuilder GUI input didn't save to input data file.
- Prioritize binding CoreLib General Options Data over other AGEPRO parameters when setting user generated new cases. 
- Simplfied the AGEPRO Input File Loading Exeception Dialog to error messages only.
- Fixed Rebuilder option's Harvest Specification validation to begin on the 3rd projection year row.   
- Minor help manual updates and format tweaks. 

## 4.3.1 (2019-03-29)

## Changes
- Ensure GUI input modifications, and GUI input from User generated new cases (initalized by submitting General Option values via 'SET' button) are written to AGEPRO input data files. (#1)
  - GUI input fixes to General Options, Stochastic Weights of Age, Stochastic Ages (Natural Mortality, Maturity, Fishery Selectivity), and Case ID. (#4, #5)
  - Fixed missing Natural Mortality data bindings.    
  - Fixed a data binding issue if the user submits (General options 'SET' button) a new case over a new case.
  - CoreLib: Added AgeproCoreLibProperty for generic Agepro Parameter Data Binding
- Implicitly set new case default values during initialization. (#1)
   - Case ID defaults to 'untitled' (#3) 
- Include AGEPRO [PARMETER] to NULL error message to indicate parameter found with blank/NULL stochastic age/weight or CV datatables. (#1, #4)
- Misc Options, P-Star, Rebulider, Parametric Recruitment: Tweaked binded values updates to OnPropertyChanged. (#1) 
- Helpfile: Clarifcations on the P-Star and Rebulider sections.
- Recuitment: increased default maxRecuitObs to 500  

## 4.3.0 (2018-03-27)

## Significant User Changes from AGEPRO 4.2.2
- New user interface. Replaced tabs with the a navigation Tree Node to navigate through AGEPRO parameters. 
- AGEPRO option parameters are scalable.  
- Consoldate recruitment model actions in single panel: Recruitment. 
  - Contains general "Recruitment" options and "Recruit Model" Type ("Emprical-R", "Parametric-R", "Predictor-R", "Markov Matrix-R" in ver 4.2.2).
  - "Recruit Model" handles multiple selections of varying model types. (Enforces the single Markov Matrix Recuitment Model rule.)
- Launching AGEPRO Calcuation Engine saves a copy of current GUI input, bootstrap data, and calculation engine output in a new folder located AGEPRO user's HOME or documents directory instead of overwriting input file.
- No output plot functionality for the calcuation engine output.
- AGEPRO Input File Compatibility: Only for version 4.0 
- AGEPRO Help Manual ('Using AGEPRO' in ver 4.2.2) is now in web page format.

## Other Changes
- Including 2018 revisions to Jon Brodizak's AGEPRO Reference Manual
- In the Biological panel, "Fraction Mortality Prior to Spawing" and "Maturity at Age" are seperated into their own tabs.
- Streamlined Menu options
  - Output File Viewer option in Misc options.
- Toolbar not included in this interface. 
- "Discard Weights" and "Discard Fraction" are accessible if the discards is not enabled, however GUI controls are disabled.
- Moved Time Varying Checkboxes.
- 'Fill Down' and 'Fill Right' functionality are replaced with 'Fill Blank Cells'
- README and LICENCE compliant with DOC Policy.

## Known Issues
- Misc Options Panel is not Scaleable.

# AGEPRO 4.3.0 Beta Changelog

## 4.3.0.11-beta11 (2018-03-16)

## Added
- Example Projection Model files: A Standard Projection Model Example, a Projection Model Example with PStar Analysis, and a Projection Model Example with a Rebuild Scenario. 

## Changes
- March 2018 revision of Jon Brodziak's AGEPRO Reference Manual
  - Includes AGEPRO Input data formats for available AGEPRO Recruitment Models (Table 4)
- Helpfile: Clarify how AGEPRO Model Calcuation Engine launches and how output is stored.
  - Renamed section 'AGEPRO Output Run Directory' to `Launching AGEPRO Model to Calcuation Engine'
  - Moved Section up the helpflie to help assoicate the AGEPRO workflow.
- Removed GetRandomFileName to substring for blank/null model output run directory 
  - Now 'untitled_' instead of the 'untitled_' + GetRandomFileName prefix in this case.
- CoreLib: Removed function GetRecruitModelName

## 4.3.0.10-beta10 (2018-01-31)

## Added
- AGEPRO v4.2 Reference Manual by Jon Brodziak.
- Added LICENSE.md 
- Added LICENSE information in About AGEPRO dialog box.
- CoreLib: Data binded Misc Option Parameters and added MiscOptionsParameter class. Moved embeded AgeproMiscOptions miscOption classes as MiscOptionsParameter subclasses. (#3)
- "Decimal-zero" format option for binded miscOptions textBoxes.  
- Default value for generalOptions modelID
 
## Changes
- Reference Points, Scale Factors, and Bounds text boxes use NftTextBox.

## Fixed
- Disable "Save AGEPRO Input Data As ..." menu option during startup/uninitialized phase.  
- CoreLib: More informative error messages with NullSelectRecruitment's input/output (ReadRecruitmentModel/WriteRecruitmentModel) functions. (#1)
- CoreLib: Assign defaults (non blank/null values) for Reference Points and Scale Factors. (#3)
- Ensure saved AGEPRO Input File path is diplayed on generalOptions InputFile textbox. (#2)

## 4.3.0.9-beta9 (2017-07-12)

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
