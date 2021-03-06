﻿AGEPRO Projection Samples
=====================================================================

The following descriptions for the first three examples are excerpt from the _AGEPRO Reference Manual_ (Brodziak 2018). Example 4 comes from _Stock Assessment of Uku (Aprion virescens) in Hawaii, 2020_ (Nadon et al. 2020). These examples are provided to illustrate projection options and features of AGEPRO. These projections use actual fishery data but are for the purposes for demostration only.

## Example 1

The first example is a fishing mortality and landings quota projection for
Acadian redfish. The time horizon is 2004-2009. The fishery is comprised of two fleets
that have identical fishing mortality rates in 2004, identical quotas in 2005, and fishing
mortality rates that differ by 2-fold during 2006-2009. This is standard projection
analysis with 1000 bootstraps and 100 simulations per bootstrap based on an ADAPT/VPA
stock assessment analysis. The model also outputs an R dataframe.

## Example 2

The second example is a fishing mortality and landings quota projection for
Gulf of Maine haddock with a PStar analysis in 2018. The time horizon is 2014-2020.
The fishery is comprised of one fleet. This is PStar projection analysis with 1000
bootstraps and 10 simulations per bootstrap based on an ASAP stock assessment analysis.
The model output shows that total allowable catch amounts in 2018 to produce
probabilities of overfishing of 10%, 20%, 30%, 40% and 50% at the overfishing level of
`F=0.35`. The total allowable catches to produce overfishing probabilities of 10%, 20%,
30%, 40% and 50% are calculated to be 1780, 1998, 2176, 2332, and 2497 mt,
respectively. The model output includes a stock summary of numbers at age and also
outputs a percentile analysis for key outputs at the 90th percentile.

## Example 3

The third example is a fishing mortality and landings quota projection for
Gulf of Maine haddock with a rebuilding analysis for 2014-2020. The fishery is
comprised of one fleet with process error in fishery selectivity. This is rebuilding
projection with 1000 bootstraps and 10 simulations per bootstrap based on an ASAP
stock assessment analysis. The model output shows the constant fishing mortality to
rebuild the stock is `F(REBUILD)=0.045`. The model output includes a stock summary of
numbers at age and also outputs a percentile analysis for key outputs at the 90th percentile.

## Example 4

The fourth example is a fishing mortality and stock biomass projection for the uku snapper in Hawaii. The projection was conducted using results from the base-case Stock Synthesis model to evaluate the probable impacts of constant catch quotas on future spawning stock biomass and yield with a time horizon of 2019-2026. This projection includes four fishing fleets with distinct landings quotas, mean weights at age, and fishery selectivities at age as well as using three recruitment models with different probabilities of being the future state of nature. The initial condition for the stochastic projection was based on the distribution of estimated initial population size-at-age in the year 2018. A total of 1000 simulations were run for each of 100 bootstrap replicates to characterize the effects of uncertainty in initial stock size as well as process errors on the distribution of future recruitment, life history, and fishery parameters.