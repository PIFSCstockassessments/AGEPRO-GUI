Age Structured Projection Model (AGEPRO)
========================================

# Getting Started
# Creating a new Case

# Opening an Existing AGEPRO Input Data File

# Saving AGEPRO input into file


 

# Using NFT Data Grids
NOAA Fisheries Toolbox data grids have many functions that are similar to spreadsheet software programs. However, there are a few differences and limitations. The following topics will  describe in detail how to perform common tasks.

Right-clicking on the cell to show the Cut, Copy, Paste and Delete options.

###  Selecting Cells
To select a single cell: Click the cell, or press one of the Arrow keys to move to the cell.

To select more than one cell: Click the on the cell, and while holding the mouse button drag the pointer to the cell in the range of cells you are interested in.

To select an entire row, click on the row heading.

To select the entire grid, do one of the following:
* Right-Click on the grid and select Select All from the context menu.
* Press CTRL+A.
* Click the top left grid cell.

### Edit Cell Contents
You can edit the contents of a cell directly in the cell.

To place the contents of a cell in editing mode:
* Double-click the cell that contains the data that you want to edit. Note that the cursor will be at the end of the cell's contents.
* Click the cell that contains the data that you want to edit, and then start typing. If the cell contained any data it will be erased when you start typing.

While the cell is still in edit mode, use **Esc** key to cancel the edit. It will revert to previous value before it was entered.

To commit the edits to the cell:
* Hit the **Enter** key to commit the changes and move the cell selection one cell below.
* Hit the **Up** Arrow key to commit the changes and move the cell selection one cell above.
* Hit the **Down** Arrow key to commit the changes and move to the cell selection one cell below.
* If you are at the last character, hitting the **Right** Arrow key will commit the edit and move the cell selection one cell to the right.
* If you are at the first character, hit the **Left** Arrow key will commit the edit and move the cell selection one cell to the left.

### Copy Grid Data
Select a cell or range of cells. Either **Right-Click** on the grid and select Copy from the context  menu, or use **CTRL+C**.

### Paste Grid Data
If you want to paste data from a spreadsheet program, select and copy the range of cells within  the spreadsheet program. The copied cells will be stored to the clipboard.  You can also paste data from a text file. Data in a text file should be tab-delimited, rows are line-delimited.

To select where you want the data to be pasted, do one of the following:
* If you have just one cell of data to paste, click on the cell where you want the data to go.
* If you have more than one cell of data to paste, click on the cell you want to be the topmost and leftmost cell of the pasted data. Pasted data will automatically be filled in to the right of and below the cell you select.

To paste the data, either **Right-Click** on the grid and select Copy from the context menu, or use **CTRL+V**.

### Cut Grid Data
Select a cell or range of cells. Either **Right-Click** on the grid and select Cut from the context menu, or use **CTRL+X**.

The selected cells will be cleared and will be sent to the Windows clipboard.

### Delete Grid Data
The Delete function clears all data in the selected cells. Unlike Cut, It does *not* copy the grid cells to the Windows clipboard.

Select a cell or range of cells. Either **Right-Click** on the grid and select Delete from the context menu, or use the **Delete** key.

### Fill Data in Grid Cells
Select Fill Blank Cells from the context menu. This will populate any blanks cell from the data grid with “0”.


 

# Stochastic Age
# Specifying Weights of Age
# Natural Mortality
# Biological
## Maturity
## Fraction Mortality Prior to Spawning
# Fishery Selectivity
# Discard Fraction

# Bootstrap
Bootstrapping input and options is located on the **Bootstrapping** panel.

The user must input the **Number of Bootstrap iterations**. Each line in the Bootstrap file represents a bootstrap iteration, consisting of space delimited stock values at age as double precision numeric values. The number of data values on each row line must be equal to the number of age classes.

The number of rows in the bootstrap file must be at least equal to the **number of bootstrap iterations**. Since it contains the population of the first year in the projection.

AGEPRO, will ignore additional iterations or bootstrap data intended for addtional projection years.

For each bootstrap iteration the stock values at age in the file will be multiplied by the **Population Scaling Factor**. For example, a population scale factor of `1000` means that a bootstrap file contains stock values at age equal to thousands of fish.

AGEPRO versions 3.4 and later do not support recruitment ages beyond age 1, therefore the second bootstrap file with Bootstrap F's in earlier versions is no longer used.  

### Scaling factors with VPA(Virtual Population Analysis)
Typically, bootstrap files are generated by the **VPA(Virtual Population Analysis)** or **ASAP(Age Structured Assessment Program)** Models. It is imperative that the user be consistent between VPA or ASAP runs and AGEPRO.

In the following example, the **VPA program input** generates a bootstrap population file which uses a scaling factor of `1`. Thus, if this were the **VPA** file used to create for **AGEPRO** input, with AGEPRO's **Population Scaling Factor** of `1000`, then it will imply that the **VPA Catch data** was in **thousands** of fish.
![alt text](img/VPAExample_01.png "VPA Bootstrapping Output Options")

# Recruitment
# Specifying Recruitment
AGEPRO supports multiple recruitment methods. The number of recruitment methods can be specified in the **General Options** panel.

Under **Select Recruitment Models** is a DataGrid object with combo box(es). The number of recruitment methods determines the number of combobox selections.

The combobox will be populated with the following models:

* Model 1: Markov Matrix
* Model 2: Empirical Recruits per Spawning Biomass Distribution
* Model 3: Empirical Recruitment Distribution
* Model 4: Two-Stage Empirical Recruits per Spawning Biomass Distribution
* Model 5: Beverton-Holt Curve w/ Lognormal Error
* Model 6: Ricker Curve w/ Lognormal Error
* Model 7: Shepherd Curve w/ Lognormal Error
* Model 8: Lognormal Distribution
* Model 10: Beverton-Holt Curve w/ Autocorrected Lognormal Error
* Model 11: Ricker Curve w/ Autocorrected Lognormal Error
* Model 12: Shepherd Curve w/ Autocorrected Lognormal Error
* Model 13: Autocorrected Lognormal Distribution
* Model 14: Empirical Cumulative Distribution Function of Recruitment
* Model 15: Two-Stage Empirical Cumulative Distribution Function of Recruitment
* Model 16: Linear Recruits per Spawning Biomass Predictor w/ Normal Error
* Model 17: Loglinear Recruits per Spawning Biomass Predictor w/ Lognormal Error
* Model 18: Linear Recruitment Predictor w/ Normal Error
* Model 19: Loglinear Recruitment Predictor w/ Lognormal Error
* Model 20: Fixed Recruitment
* Model 21: Empirical Cumulative Distribution Function of Recruitment w/ Linear Decline to Zero

The user can choose multiple instances of a Recruitment Model (example: All 3 Recruitment Models can be a Beverton-Holt Curve Model). ***However, Only a single instance of the Markov Matrix model is allowed.***

Note: Model 9: Time-Varying Empirical Recruitment Distribution is not supported in AGEPRO version 4.0 and later. This model can be reimplemented by specifying multiple instances of Model 3.

## Recruitment Probability
Each model selection is given a probability in each year of the projection time horizon. In each realization, and each year in the projection time horizon, a single recruitment method is randomly selected from a multinomial distribution.   

For each year (row), the Recruitment Probably selections (columns) must sum up to 1.0.

## Specifying Scaling Factors for Recruitment and SSB
**Recruitment Scaling Factor** and **SSB Scaling Factor** are explicit scaling factors that is applied to recruitment models. The calculated recruitment from the model will be *multiplied by the Recruitment Scaling Factor* before it is outputted to the user. The calculated Spawning Stock Biomass will be *divided by the SSB Scaling Factor* for use within recruitment model calculations.

Recruitment Scaling Factor scales in number of fish (for recruit values in Recruitment Model parameters). SSB Scaling Factor scales in Metric Tons (for SSB/biomass values in Recruitment Model parameters).

## Specifying the First Recruitment Age class
The user has the option to select either **Age 0** or **Age 1** as the first recruitment age class in General options panel. The default is **Age 1** recruitment.

For **Age 1 Recruitment**, the calculated recruitment is introduced into the first Age Class in the subsequent year.  

In those methods in which Recruitment is a function of Spawning **Stock Biomass, the stock numbers in the first Age class in Year T+1 will be equal to the predicted recruitment based on SSB in Year T**.

If **Age 0 Recruitment** is selected, the calculated recruitment is introduced into the first Age Class in the current year for all years except the first year in the time horizon.

For those recruitment methods in which Recruitment is a function of Spawning Stock Biomass, the **stock numbers for Age 0 in Year T will be equal to The predicted recruitment based on SSB in the same Year.**  This rule applies to all years **except the first year** in the time horizon.

AGEPRO does not support first recruitment ages classes beyond 1. 

# Empirical Recruitment Models
When an Empirical Recruitment model type is selected in the the recruitment selection drop down list in the *Recruit Model* tab of the **Recruitment** panel, input parameters for this type of recruitment will appear below.

Empirical Recruitment Models include:

* Model 2. Empirical Recruits Per Spawning Biomass Distribution
* Model 3. Empirical Recruitment Distribution
* Model 4. Two-Stage Empirical Recruits Per Spawning Biomass Distribution
* Model 14. Empirical Cumulative Distribution Function of Recruitment
* Model 15. Two-Stage Empirical Cumulative Distribution Function of Recruitment
* Model 20. Fixed Recruitment
* Model 21. Empirical Cumulative Distribution Function of Recruitment with Linear Decline to Zero

Multiple instances of the same empirical model are allowed. Use the recruitment selection drop down list to toggle between input sets in the Recruit Model tab in the Recruitment panel.

Only numeric data is allowed for Empirical Recruitment models..

**Note**: [The Recruitment Scale Factor](#specifying-scaling-factors-for-recruitment-and-ssb) in the Recruitment tab should be consistent with empirical observations entered.  For example, if the data shown above are empirical observations in millions of fish then the Recruitment Scale Factor must be input as 1,000,000

Enter a new value for the number of observations and click on the SET button to resize the observation tables.

## Fixed Recruitment Method
In the datagrid, the user inputs fixed recruitment values for the projection time horizon **beginning with the 2nd Year.**  Recruitment in the 1st year of the projection time horizon is the value supplied in the bootstrap file for the first age class.

 

# Parametric Recruitment Models
When a Parametric Recruitment model type is selected in the the recruitment selection drop down list in the *Recruit Model* tab of the **Recruitment** panel, input parameters for this type of recruitment will appear below.

Parametric Recruitment Models Include:

* Model 5. Beverton-Holt Curve With Lognormal Error
* Model 6. Ricker Curve With Lognormal Error
* Model 7. Shepherd Curve With Lognormal Error
* Model 8. Lognormal Distribution
* Model 10. Beverton-Holt Curve With Autocorrelated Lognormal Error
* Model 11. Ricker Curve With Autocorrelated Lognormal Error
* Model 12. Shepherd Curve With Autocorrelated Lognormal Error
* Model 13. Autocorrelated Lognormal Distribution

Multiple instances of the same parametric model are allowed.  This would allow the user to, for example, set up multiple Beverton Holt models with different parameters. Use the recruitment selection drop down list to toggle between input sets.

**Note:** Make sure that the scaling of the parametric parameters is consistent with the [SSB and Recruitment Scaling Factors](#specifying-scaling-factors-for-recruitment-and-ssb) on the **Recruitment** tab.


 

# Predictor Recruitment Models
When a predictor recruitment model type is selected in the the recruitment selection drop down list in the *Recruit Model* tab of the **Recruitment** panel, input parameters for this type of recruitment will appear below.

The Predictor Models Include:

* Model 16. Linear Recruits per Spawning Biomass Predictor with Normal Error
* Model 17. Loglinear Recruits per Spawning Biomass Predictor with Lognormal Error
* Model 18. Linear Recruitment Predictor with Normal Error
* Model 19. Loglinear Recruitment Predictor with Lognormal Error

Multiple Instances of the same predictor model are allowed. Use the recruitment selection drop down list to toggle between input sets.

To change the number of predictors, set the value of the *number of recruitment predictors* parameter by typing the value in or using spinbox arrows, and then click on the SET button. The valid number of predictors range from 0-5.

 

# Markov Matrix Recruitment
When **Model 1: Markov Matrix** is selected in the the recruitment selection drop down list in the *Recruit Model* tab of the **Recruitment** panel, input parameters for this type of recruitment will appear below. Only one instance of Markov Matrix recruitment is allowed.

Use the SET button to change the number of levels.

**Note:** The probabilities of each SSB level row in the Probability table must sum up to **1.0**

**Note:** Make sure that the scaling of Recruitment and SSB cutpoint inputs is consistent with the [SSB and Recruitment Scaling Factors](#specifying-scaling-factors-for-recruitment-and-ssb) on the **Recruitment** tab.

 

# Harvest Scenario
The **Harvest Scenario** panel includes a data grid used to determine the level of population harvest for each year in the projection horizon.

In addition, the user may use this data grid for additional harvest calculations such as the **P-Star Analysis**, or Stock **Rebuilder Target**. By default, **None (only Harvest Scenario)** is selected.

## Harvest Scenario Table
In the Harvest Scenario data grid table, the user must specify the *Harvest Specfication* for each year in the projection time horizon. The choices are:
* Landings (MT)
* Removals (Landings and Discards) (MT)
* Total Fishing Mortality or "F-MULT"

For single fleet models, apply the *Harvrest Specfication* values under the *HARVEST VALUE* column. For multiple fleet models, input the values for the intended fleet (e.g. *F-MULT* specfic values for *FLEET-2*). In either case, harvest specification values must be *numeric*.

## Rebuilder Target Option
AGEPRO allows an option for the user to specify a Rebuilder target and calculate the Fishing Mortality level required to meet this target to a specified confidence level.  

Select the **Apply Rebuilder Target** option for *Additional calculations* box in the **Harvest Scenario** panel. The Rebuilder Option input will appear directly below.

> For the Harvest Scenario Table, the *Harvest Specification* from the second year (row 2) in the time horizon to the **Rebuild Target Year** must be set to **F-MULT**

For **Rebuilder Target Type**, the user may set the rebuilder target as:

* Spawning Stock Biomass
* Jan-1 Biomass
* Mean Biomass

If there is more than one fleet then the input estimates will be used to set the proportion of Fishing Mortality in each fleet. This proportion will be held constant as the F-Mult level changes to meet the target.

### Example
![alt text](img/rebuilderHarvestTable_01.png "Harvest Scenario Table")

In the example shown above the user has set a Landings Harvest Quota in the first year of **2,100 MT**.

The Rebuilder range begins with the second year in the time horizon and ends at the target year **2019**.

The user has also set the Harvest F-Mult in the Rebuilder Range at an initial guess.

The program will vary the F-MULT level in the Rebuilder range until the Rebuilder Specification in the Target Year is met to the confidence level requested.  In this case the user has specified that the Spawning Stock Biomass in 2019 will be at least 43,200 MT with a probability of 75%.

```
Total Fishing Mortality
Year       Average        StdDev
2009        0.0862        0.0154
2010        0.1656        0.0000
2011        0.1656        0.0000
2012        0.1656        0.0000
2013        0.1656        0.0000
2014        0.1656        0.0000
2015        0.1656        0.0000
2016        0.1656        0.0000
2017        0.1656        0.0000
2018        0.1656        0.0000
2019        0.1656        0.0000
2020        0.1670        0.0000
```

The program has set the F-Mult in all years of the rebuilder range to 0.1656

By using a Reference Point Threshold, the user may validate that the target was met (**year 2019**) to the confidence level requested:

```
Probability Spawning Stock Biomass Exceeds Threshold     43.200 (1000 MT)
Year    Probability
2009    0.024250
2010    0.069990
2011    0.159530
2012    0.303640
2013    0.409640
2014    0.521230
2015    0.612170
2016    0.668130
2017    0.705300
2018    0.731610
2019    0.749960
2020    0.761440
Probability Threshold Exceeded at Least Once =     0.9063
```

## P-Star Analysis
**P-Star Analysis** determines *P-Star* (risk of overfishing) at multiple levels.

Select the **Peform P-Star Analysis** option for *Additional calculations* box in the **Harvest Scenario** panel. The P-Star Analysis input will appear directly below. The specification allows the user to specify the number and values of P-Star levels, Overfishing F criteria, and P-Star Target Year. P-Star levels in should be entered in ascending order.

> For the Harvest Scenario Table, the user must set the column *Harvest Specification* to **REMOVALS** (landings and discards) *on the year (row) that* **P-Star Target Year** is set to.

For the multiple fleets scenario, the proportion of removals per fleet will be set by the initial guess and this proportion will be held constant as total removal values are varied to meet the P-Star criteria.

### Example
![alt text](img/pstarHarvestTable_01.png "Harvest Scenario Table")

In the above example, the user has provided an initial guess of total removals of 20,000 MT. The user has also specified that 70% of the removals are in Fleet-1 and 30 % in Fleet-2.

The Overfishing F is 0.3.  The program will vary the levels of total removals to determine the level of removals required to exceed a Total F of 0.3 with 10%, 25%, and 50% levels of confidence.  

A table of results is reported for all levels

```
PStar Summary Report
Overfishing F =     0.3000   Target Year = 2012
  PStar          TAC
  0.1000        18762
  0.2500        26874
  0.5000        40340
```
The highest P-Star level is used in the final output report.

The highest P-Star level is a combined catch equal to 40,340 MT
```
Probability Total Fishing Mortality Exceeds Threshold     0.3000
Year    Probability
2005    0.443400
2006    0.000000
2007    0.000000
2008    0.000000
2009    0.000000
2010    0.000000
2011    0.000000
2012    0.500000
2013    0.000000
2014    0.000000
Probability Threshold Exceeded at Least Once =     0.7015
```

```
Combined Catch Biomass  x 1000 MT
Year       Average        StdDev
2005       23.8159        0.5280
2006       58.2893       33.4187
2007       90.0363       66.6863
2008       83.3679       56.3227
2009       69.4739       38.4229
2010       57.6585       31.6780
2011       49.4235       26.5478
2012       40.3302        0.4501
2013       37.9428       21.5088
2014       18.6135       15.1005
```

```
Combined Catch Distribution
Year       1 %        5 %        10 %       25 %       50 %       75 %       90 %       95 %       99 %   
2005    23.0242    23.1791    23.2748    23.4553    23.7168    24.0544    24.4621    24.7863    25.6062
2006    20.5261    25.7774    29.6497    38.0500    50.1961    68.2416    92.9632   115.6090   189.9173
2007    24.7738    32.7074    38.7986    51.2893    71.8312   104.0114   160.1893   209.6707   356.1510
2008    24.5674    32.3727    38.1408    49.9449    68.0199    96.3123   145.6537   188.8369   303.7527
2009    23.2500    30.2112    35.0125    45.1508    60.0323    81.9444   112.9818   140.4948   217.4582
2010    19.9632    25.9880    29.9054    37.6155    49.3528    67.7771    95.3417   118.0018   174.5042
2011    18.4318    23.2325    26.2634    32.7304    42.4053    57.6223    80.5782    98.1937   152.4862
2012    40.3401    40.3401    40.3401    40.3401    40.3401    40.3401    40.3401    40.3401    40.3401
2013    10.0895    15.3514    18.2694    24.3797    32.6471    45.5232    63.8322    78.3229   113.7047
2014     2.9045     4.6582     6.0500     9.2075    14.5876    23.0587    35.2707    45.9843    75.4379
```

# Misc options
## Auxiliary Output Stochastic Files
## Summary Report of Stock Numbers of Age
### Export to R
### Specifying Alternate Percentile in Output Report

## Specifying Reference Point Threshold Values

## Specifying Bounds
This is an option to override the default maximum bounds values for *Weights of Age* (default: `10.0`) and *Natural Mortality* (default: `1.0`).
The user can enable or disable this by checking/unchecking the **Specify Bounds** check box.

## Specifying Retrospective Adjustment Factors
**Retrospective Adjustment Factors** are applied to the initial population numbers to correct for retrospective bias.
This is an optional parameter, and the user can enable or disable it by checking/unchecking the **Specify Retrospective Adjustment Factors** check box.

The stock numbers in the first year of the projection is read from the Bootstrap File on each bootstrap iteration will be **multiplied by** the retrospective adjustment factors.