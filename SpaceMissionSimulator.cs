using System;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        //I defined basic game variables.
        int healthValue = 100;
        int creditValue = 100;
        int oxygenValue = 70;
        int energyValue = 65;
        int fuelValue = 60;
        int missionScore = 0;
        int mineralsValue = 0;

        //These are counters I use to check game flow  .
        int dayCounter = 1;
        int succesfullOperationsCounter = 0;
        int dailySuccesfullOperationCounter = 0;
        int dailyExploredPlanetsValue = 0;
        int mineralCollectionCounter = 0;

        //I use this to check player choose.
        short optionHolder = 0;

        //These are basic control switches
        bool specialLifeTimeController = true;
        bool mercuryMineralCollectionLimit = true;
        bool marsMineralCollectionLimit = true;
        bool europaMineralCollectionLimit = true;
        bool isValid = false;
        bool earnFourMineral = false;
        bool europaIsExplored = false;
        bool mercuryIsExplored = false;
        bool marsIsExplored = false;

        //That,switches shows core arcitechture of game 
        bool mainMenuLoopController = true;
        bool optionSwitchSpaceStation = true;
        bool championSwitch = false;
        bool optionSwitchMercury = false;
        bool optionSwitchMars = false;
        bool optionSwtitchSupplyStation = false;
        bool optionSwitchEuropa = false;

        //I use that switches for player came from which planet to Supply Station
        bool locationReminderMercury = false;
        bool locationReminderMars = false;
        bool locationReminderEuropa = false;
        bool locationReminderSpaceStation = false;

        string planetMercury = "Mercury";
        string planetMars = "Mars";
        string planetEuropa = "Europa";
        string spaceStation = "Space Station";

        while (mainMenuLoopController)
        {
            while (optionSwtitchSupplyStation)
            {
                if ( specialLifeTimeController && 0 < oxygenValue  && oxygenValue <= 15 )
                {
                    oxygenValue = oxygenValue + 20;
                    specialLifeTimeController = false;
                }

                Console.WriteLine();
                Console.WriteLine("--- SUPPLY STATİON ---");
                Console.WriteLine($"1. Buy fuel (5 fuel for 12 Credits)");
                Console.WriteLine($"2. Buy oxygen (5 oxygen for 10 Credits)");
                Console.WriteLine($"3. Recharge energy (20 energy for 10 Credits)");
                Console.WriteLine($"4. Repair spaceship (20 health for 15 Credits)");
                Console.WriteLine($"5. Sell all minerals (6 credit per mineral)");
                Console.WriteLine($"6. Return to main menu");
                isValid = short.TryParse(Console.ReadLine(), out optionHolder);

                if ( isValid && 0 < optionHolder && optionHolder < 7)
                {
                    if (optionHolder == 1 && 12 <= creditValue)
                    {
                        fuelValue = fuelValue + 5;
                        creditValue = creditValue - 12;
                        if ( 100 < fuelValue ) fuelValue = 100;
                    }

                    else if (optionHolder == 2 && 10 <= creditValue)
                    {
                        oxygenValue = oxygenValue + 5;
                        creditValue = creditValue - 10;
                        if ( 100 < oxygenValue ) oxygenValue = 100;
                    }

                    else if (optionHolder == 3 && 10 <= creditValue)
                    {
                        energyValue = energyValue + 20;
                        creditValue = creditValue - 10;
                        if( 100 < energyValue ) energyValue = 100;
                    }

                    else if (optionHolder == 4 && 15 <= creditValue)
                    {
                        healthValue = healthValue + 20;
                        creditValue = creditValue - 15;
                        if ( 100 < healthValue ) healthValue = 100;
                    }

                    else if (optionHolder == 5)
                    {
                        if(0 < mineralsValue)
                        {
                            creditValue = creditValue + (mineralsValue * 6);
                            mineralsValue = 0;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have mineral");
                        }
                    }

                    else if (optionHolder == 6)
                    {
                        if(locationReminderEuropa)
                        {
                            optionSwitchEuropa = true;
                            locationReminderEuropa = false;
                            optionSwtitchSupplyStation = false;
                        }

                        else if(locationReminderMars)
                        {
                            optionSwitchMars = true;
                            locationReminderMars = false;
                            optionSwtitchSupplyStation = false;
                        }

                        else if (locationReminderMercury)
                        {
                            optionSwitchMercury = true;
                            locationReminderMercury = false;
                            optionSwtitchSupplyStation=false;
                        }

                        else if(locationReminderSpaceStation)
                        {
                            optionSwitchSpaceStation = true;
                            locationReminderSpaceStation = false;
                            optionSwtitchSupplyStation = false;
                        }
                    }

                    else
                    {
                        Console.Clear ();
                        Console.WriteLine($"You doesn't have enough credit for option {optionHolder}");
                    }
                }
                
                else
                {
                    Console.Clear();
                    Console.WriteLine("You entered an invalid value please try again (1-6)");
                }
            }

            while (optionSwitchSpaceStation)
            {
                if (specialLifeTimeController && 0 < oxygenValue  && oxygenValue <= 15)
                {
                    oxygenValue = oxygenValue + 20;
                    specialLifeTimeController = false;
                }

                bool loopController = true;

                Console.WriteLine($"Day : {dayCounter}");
                Console.WriteLine($"Current Location : {spaceStation}");
                Console.WriteLine($"Credits : {creditValue}");
                Console.WriteLine($"Fuel : %{fuelValue}");
                Console.WriteLine($"Oxygen : %{oxygenValue}");
                Console.WriteLine($"Energy : %{energyValue}");
                Console.WriteLine($"Health : %{healthValue}");
                Console.WriteLine($"Mission Score : {missionScore}");
                Console.WriteLine($"Inventory : {mineralsValue} mineral");
                Console.WriteLine();
                Console.WriteLine($"1. Travel to a planet.");
                Console.WriteLine($"2. Supply Station.");
                Console.WriteLine($"3. Display Mission Status.");
                Console.WriteLine($"4. End Of The Day");
                Console.WriteLine($"5. Quit Mission");

                if (0 < oxygenValue && 0 < healthValue && dailySuccesfullOperationCounter < 5)
                {
                    isValid = short.TryParse(Console.ReadLine(), out optionHolder);
                }

                else if (dailySuccesfullOperationCounter == 5)
                {
                    optionHolder = 4;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    optionHolder = 4;
                }

                if (isValid && optionHolder < 6 && 0 < optionHolder)
                {
                    if (optionHolder == 5)
                    {
                        mainMenuLoopController = false;
                        optionSwitchSpaceStation = false;
                    }

                    else if (optionHolder == 4 && 2 < dailySuccesfullOperationCounter)
                    {
                        oxygenValue = oxygenValue - 5;
                        energyValue = energyValue + 15;
                        europaMineralCollectionLimit = true;
                        mercuryMineralCollectionLimit = true;
                        marsMineralCollectionLimit = true;
                        dayCounter++;
                        dailyExploredPlanetsValue = 0;
                        dailySuccesfullOperationCounter = 0;
                        if (100 < energyValue) energyValue = 100;
                    }

                    else if (optionHolder == 3)
                    {
                        Console.WriteLine($"Current succesful operation count : {succesfullOperationsCounter}");
                    }

                    else if (optionHolder == 2)
                    {
                        optionSwtitchSupplyStation = true;
                        locationReminderSpaceStation = true;
                        optionSwitchSpaceStation = false;
                    }

                    else
                        while (loopController)
                        {
                            Console.WriteLine("Please enter your destination (1-Mercury, 2-Mars ,3-Europa)");
                            isValid = short.TryParse(Console.ReadLine(), out optionHolder);

                            if (!isValid)
                            {
                                Console.Clear();
                                Console.WriteLine("You entered invalid value or zero, please try again (1-3)");
                            }

                            else if (optionHolder <= 0 || 3 < optionHolder)
                            {
                                Console.Clear();
                                Console.WriteLine("Please enter one of the current options (1-3)");
                            }

                            else
                            {
                                if (optionHolder == 1 && 10 <= fuelValue && 8 <= oxygenValue)
                                {
                                    fuelValue = fuelValue - 10;
                                    oxygenValue = oxygenValue - 8;
                                    optionSwitchMercury = true;
                                    Console.WriteLine("You succesfully traveled to Mercury");
                                    optionSwitchSpaceStation = false;
                                    loopController = false;
                                }

                                else if (optionHolder == 2 && 15 <= fuelValue && 12 <= oxygenValue)
                                {
                                    fuelValue = fuelValue - 15;
                                    oxygenValue = oxygenValue - 12;
                                    optionSwitchMars = true;
                                    Console.WriteLine("You succesfully traveled to Mars");
                                    optionSwitchSpaceStation = false;
                                    loopController = false;
                                }

                                else if (optionHolder == 3 && 20 <= fuelValue && 16 <= oxygenValue)
                                {
                                    if (earnFourMineral && marsIsExplored && mercuryIsExplored)
                                    {
                                        fuelValue = fuelValue - 20;
                                        oxygenValue = oxygenValue - 16;
                                        optionSwitchEuropa = true;
                                        Console.WriteLine("You succesfully traveled to Europa");
                                        optionSwitchSpaceStation = false;
                                        loopController = false;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Have you explored Mercury : {mercuryIsExplored}");
                                        Console.WriteLine($"Have you explored Mars : {marsIsExplored}");
                                        Console.WriteLine($"Have you earn 4 mineral : {earnFourMineral}");
                                        loopController = false;
                                    }
                                }

                                else if (!isValid)
                                {
                                    Console.Clear();
                                    Console.WriteLine("You entered invalid value please try again");
                                    loopController = false;
                                }

                                else 
                                {
                                    Console.Clear();
                                    Console.WriteLine("You doesn't have enough oxygen or fuel for travel.");
                                    loopController = false;
                                }

                            }

                        }

                }

                else if (optionHolder < 0 || 3 < optionHolder)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter one of the current options (1-4)");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("You entered invalid value or zero, please try again (1-4)");
                }
            }

            while (optionSwitchEuropa)
            {
                if (specialLifeTimeController && 0 < oxygenValue && oxygenValue <= 15)
                {
                    oxygenValue = oxygenValue + 20;
                    specialLifeTimeController = false;
                }

                bool loopController = true;
                Console.WriteLine();
                Console.WriteLine($"Day : {dayCounter}");
                Console.WriteLine($"Current Location : {planetEuropa}");
                Console.WriteLine($"Credits : {creditValue}");
                Console.WriteLine($"Fuel : %{fuelValue}");
                Console.WriteLine($"Oxygen : %{oxygenValue}");
                Console.WriteLine($"Energy : %{energyValue}");
                Console.WriteLine($"Health : %{healthValue}");
                Console.WriteLine($"Mission Score : {missionScore}");
                Console.WriteLine($"Inventory : {mineralsValue} mineral");
                Console.WriteLine();
                Console.WriteLine($"1. Travel to a planet.");
                Console.WriteLine($"2. Explore the planet");
                Console.WriteLine($"3. Collect minerals (+4)");
                Console.WriteLine($"4. Supply Station");
                Console.WriteLine($"5. Display mission status");
                Console.WriteLine($"6. End of the day");
                Console.WriteLine($"7. Quit mission");

                if (0 < oxygenValue && 0 < healthValue && dailySuccesfullOperationCounter < 5)
                {
                    isValid = short.TryParse(Console.ReadLine(), out optionHolder);
                }

                else if (dailySuccesfullOperationCounter == 5)
                {
                    optionHolder = 6;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    optionHolder = 7;
                }

                if (isValid && 0 < optionHolder && optionHolder < 8)
                {
                    if (optionHolder == 1)
                    {
                        while (loopController)
                        {
                            Console.WriteLine("Please enter your destination (1-Mercury, 2-Mars)");
                            isValid = short.TryParse(Console.ReadLine(), out optionHolder);

                            if (!isValid)
                            {
                                Console.Clear();
                                Console.WriteLine("You entered invalid value or zero, please try again (1-2)");
                            }

                            else if (optionHolder <= 0 || 2 < optionHolder)
                            {
                                Console.Clear();
                                Console.WriteLine("Please select one of the curretn options (1-2)");
                            }

                            else
                            {
                                if (optionHolder == 1 && 10 <= fuelValue && 8 <= oxygenValue)
                                {
                                    fuelValue = fuelValue - 10;
                                    oxygenValue = oxygenValue - 8;
                                    optionSwitchMercury = true;
                                    optionSwitchMars = false;
                                    optionSwitchEuropa = false;
                                    loopController = false;
                                }

                                else if (optionHolder == 2 && 15 <= fuelValue && 12 <= oxygenValue)
                                {
                                    fuelValue = fuelValue - 15;
                                    oxygenValue = oxygenValue - 12;
                                    optionSwitchMars = true;
                                    optionSwitchMercury = false;
                                    optionSwitchEuropa = false;
                                    loopController = false;
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You doesn't have enough oxygen or fuel for travel please travel to Supply Station");
                                    loopController = false;
                                }
                            }
                        }
                    }

                    else if (optionHolder == 2)
                    {
                        if (25 <= energyValue && 60 <= healthValue && !europaIsExplored)
                        {

                            energyValue = energyValue - 25;
                            healthValue = healthValue - 15;
                            creditValue = creditValue + 40;
                            missionScore = missionScore + 80;
                            europaIsExplored = true;
                            succesfullOperationsCounter++;
                            dailySuccesfullOperationCounter++;
                            dailyExploredPlanetsValue++;
                            Console.Clear();
                            if (2 <= dailyExploredPlanetsValue && mercuryMineralCollectionLimit && marsMineralCollectionLimit)
                            {
                                missionScore = missionScore + 10;
                                Console.WriteLine("Congratulations you earn extra 10 points for explore 2 planet in a day.");
                            }
                            Console.WriteLine("ALL PLANETS EXPLORED! FINAL BONUS +50 POINTS");
                            Console.WriteLine("MISSION ACCOMPLISHED");
                            Console.WriteLine($"Final mission score is : {missionScore}");
                            Console.WriteLine("Thank you for playing spaceship simulator if you want continue your adventure");
                            championSwitch = true;
                            optionSwitchMercury = false;
                            optionSwitchMars = false;
                            optionSwitchEuropa = false;
                            loopController = false;
                        }
                        else if (europaIsExplored)
                        {
                            Console.Clear();
                            Console.WriteLine("You have already explored this planet.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have enough energy or health for explore this planet");
                        }
                    }

                    else if (optionHolder == 3)
                    {
                        if (europaIsExplored && europaMineralCollectionLimit && 12 <= energyValue)
                        {
                            energyValue = energyValue - 12;
                            mineralsValue = mineralsValue + 4;
                            dailySuccesfullOperationCounter++;
                            succesfullOperationsCounter++;
                            europaMineralCollectionLimit = false;
                        }

                        else if (!europaIsExplored)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't make mineral collection at here before exploration");
                        }

                        else if (!europaMineralCollectionLimit)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't make collection 2 times a day.");
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have enough energy for collection.");
                        }
                    }

                    else if (optionHolder == 4)
                    {
                        optionSwtitchSupplyStation = true;
                        locationReminderEuropa = true;
                        optionSwitchEuropa = false;
                        optionSwitchMercury = false;
                        optionSwitchMars = false;
                    }

                    else if (optionHolder == 5)
                    {
                        Console.Clear();
                        Console.WriteLine($"Current succesful operation count : {succesfullOperationsCounter}");
                    }

                    else if (optionHolder == 6)
                    {
                        if (2 <= dailySuccesfullOperationCounter)
                        {
                            oxygenValue = oxygenValue - 5;
                            energyValue = energyValue + 15;
                            europaMineralCollectionLimit = true;
                            mercuryMineralCollectionLimit = true;
                            marsMineralCollectionLimit = true;
                            dayCounter++;
                            dailyExploredPlanetsValue = 0;
                            dailySuccesfullOperationCounter = 0;
                            if (100 < energyValue) energyValue = 100;
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please complete 2 succesfull operation for end of your day");
                        }

                    }

                    else
                    {
                        mainMenuLoopController = false;
                        optionSwitchEuropa = false;
                    }
                }

                else if (optionHolder < 0 || 7 < optionHolder)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter one of the current options (1-7)");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("You entered invalid value or zero, please try again (1-7)");
                }
            }


            while (optionSwitchMars)
            {
                if (specialLifeTimeController && 0 < oxygenValue && oxygenValue <= 15)
                {
                    oxygenValue = oxygenValue + 20;
                    specialLifeTimeController = false;
                }

                bool loopController = true;
                Console.WriteLine();
                Console.WriteLine($"Day : {dayCounter}");
                Console.WriteLine($"Current Location : {planetMars}");
                Console.WriteLine($"Credits : {creditValue}");
                Console.WriteLine($"Fuel : %{fuelValue}");
                Console.WriteLine($"Oxygen : %{oxygenValue}");
                Console.WriteLine($"Energy : %{energyValue}");
                Console.WriteLine($"Health : %{healthValue}");
                Console.WriteLine($"Mission Score : {missionScore}");
                Console.WriteLine($"Inventory : {mineralsValue}  mineral");
                Console.WriteLine();
                Console.WriteLine($"1. Travel to a planet.");
                Console.WriteLine($"2. Explore the planet");
                Console.WriteLine($"3. Collect minerals (+3)");
                Console.WriteLine($"4. Supply Station");
                Console.WriteLine($"5. Display mission status");
                Console.WriteLine($"6. End of the day");
                Console.WriteLine($"7. Quit mission");

                if (0 < oxygenValue && 0 < healthValue && dailySuccesfullOperationCounter < 5)
                {
                    isValid = short.TryParse(Console.ReadLine(), out optionHolder);
                }

                else if (dailySuccesfullOperationCounter == 5)
                {
                    optionHolder = 6;
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("GAME OVER");
                    optionHolder = 7;
                }

                if (isValid && 0 < optionHolder && optionHolder < 8)
                {
                    if (optionHolder == 1)
                    {
                        while (loopController)
                        {
                            Console.WriteLine("Please enter your destination (1-Mercury, 2-Europa)");
                            isValid = short.TryParse(Console.ReadLine(), out optionHolder);

                            if (!isValid)
                            {
                                Console.Clear();
                                Console.WriteLine("You entered invalid value or zero, please try again (1-2)");
                            }

                            else if (optionHolder <= 0 || 2 < optionHolder)
                            {
                                Console.Clear();
                                Console.WriteLine("Please select one of the curretn options (1-2)");
                            }

                            else
                            {
                                if (optionHolder == 1 && 10 <= fuelValue && 8 <= oxygenValue)
                                {
                                    fuelValue = fuelValue - 10;
                                    oxygenValue = oxygenValue - 8;
                                    optionSwitchMercury = true;
                                    optionSwitchEuropa = false;
                                    Console.WriteLine("You succesfully traveled to Mercury");
                                    optionSwitchMars = false;
                                    loopController = false;
                                }

                                else if (optionHolder == 2 && 20 <= fuelValue && 16 <= oxygenValue)
                                {
                                    if (earnFourMineral && marsIsExplored && mercuryIsExplored)
                                    {
                                        fuelValue = fuelValue - 20;
                                        oxygenValue = oxygenValue - 16;
                                        optionSwitchEuropa = true;
                                        optionSwitchMercury = false;
                                        Console.WriteLine("You succesfully traveled to Europa");
                                        optionSwitchMars = false;
                                        loopController = false;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Have you explored Mercury : {mercuryIsExplored}");
                                        Console.WriteLine($"Have you explored Mars : {marsIsExplored}");
                                        Console.WriteLine($"Have you earn 4 mineral : {earnFourMineral}");
                                        loopController = false;
                                    }
                                }

                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("You doesn't have enough oxygen or fuel for travel please travel to Supply Station");
                                    loopController = false;
                                }
                            }
                        }
                    }

                    else if (optionHolder == 2)
                    {
                        if (18 <= energyValue && 50 <= healthValue && !marsIsExplored)
                        {

                            energyValue = energyValue - 18;
                            healthValue = healthValue - 10;
                            marsIsExplored = true;
                            creditValue = creditValue + 25;
                            missionScore = missionScore + 20;
                            dailyExploredPlanetsValue++;
                            succesfullOperationsCounter++;
                            dailySuccesfullOperationCounter++;
                            if (2 <= dailyExploredPlanetsValue && mercuryMineralCollectionLimit && marsMineralCollectionLimit)
                            {
                                missionScore = missionScore + 10;
                                Console.WriteLine("Congratulations you earn extra 10 points for explore 2 planet in a day.");
                            }
                        }
                        else if (marsIsExplored)
                        {
                            Console.Clear();
                            Console.WriteLine("You have already explored this planet.");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have enough energy or health for explore this planet");
                        }
                    }

                    else if (optionHolder == 3)
                    {
                        if (marsIsExplored && marsMineralCollectionLimit && 10 <= energyValue)
                        {
                            energyValue = energyValue - 10;
                            mineralsValue = mineralsValue + 3;
                            dailySuccesfullOperationCounter++;
                            succesfullOperationsCounter++;
                            marsMineralCollectionLimit = false;
                        }

                        else if (!marsIsExplored)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't make mineral collection at here before exploration");
                        }

                        else if (!marsMineralCollectionLimit)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't make collection 2 times a day.");
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have enough energy for collection.");
                        }
                    }

                    else if (optionHolder == 4)
                    {
                        optionSwtitchSupplyStation = true;
                        locationReminderMars = true;
                        optionSwitchEuropa = false;
                        optionSwitchMercury = false;
                        optionSwitchMars = false;
                    }

                    else if (optionHolder == 5)
                    {
                        Console.Clear();
                        Console.WriteLine($"Current succesful operation count : {succesfullOperationsCounter}");
                    }

                    else if (optionHolder == 6)
                    {
                        if (2 <= dailySuccesfullOperationCounter)
                        {
                            oxygenValue = oxygenValue - 5;
                            energyValue = energyValue + 15;
                            europaMineralCollectionLimit = true;
                            mercuryMineralCollectionLimit = true;
                            marsMineralCollectionLimit = true;
                            dayCounter++;
                            dailyExploredPlanetsValue = 0;
                            dailySuccesfullOperationCounter = 0;
                            if (100 < energyValue) energyValue = 100;
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please complete 2 succesfull operation for end of your day");
                        }

                    }

                    else
                    {
                        mainMenuLoopController = false;
                        optionSwitchMars = false;
                    }
                }

                else if (optionHolder < 0 || 7 < optionHolder)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter one of the current options (1-7)");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("You entered invalid value or zero, please try again (1-7)");
                }
            }

            while (optionSwitchMercury)
            {
                if (specialLifeTimeController && 1 < oxygenValue && oxygenValue <= 15)
                {
                    oxygenValue = oxygenValue + 20;
                    specialLifeTimeController = false;
                }

                bool loopController = true;
                Console.WriteLine();
                Console.WriteLine($"Day : {dayCounter}");
                Console.WriteLine($"Current Location : {planetMercury}");
                Console.WriteLine($"Credits : {creditValue}");
                Console.WriteLine($"Fuel : %{fuelValue}");
                Console.WriteLine($"Oxygen : %{oxygenValue}");
                Console.WriteLine($"Energy : %{energyValue}");
                Console.WriteLine($"Health : %{healthValue}");
                Console.WriteLine($"Mission Score : {missionScore}");
                Console.WriteLine($"Inventory : {mineralsValue}  mineral");
                Console.WriteLine();
                Console.WriteLine($"1. Travel to a planet.");
                Console.WriteLine($"2. Explore the planet");
                Console.WriteLine($"3. Collect minerals (+2)");
                Console.WriteLine($"4. Supply Station");
                Console.WriteLine($"5. Display mission status");
                Console.WriteLine($"6. End of the day");
                Console.WriteLine($"7. Quit mission");


                if (0 < oxygenValue && 0 < healthValue && dailySuccesfullOperationCounter < 5)
                {
                    isValid = short.TryParse(Console.ReadLine(), out optionHolder);
                }

                else if (dailySuccesfullOperationCounter == 5)
                {
                    optionHolder = 6;
                }

                else
                {
                    Console.WriteLine("GAME OVER");
                    optionHolder = 7;
                }

                if (isValid && 0 < optionHolder && optionHolder < 8)
                {
                    if ( optionHolder == 1 )
                    {
                        while (loopController)
                        {
                            Console.WriteLine("Please enter your destination (1-Mars, 2-Europa)");
                            isValid = short.TryParse(Console.ReadLine(), out optionHolder);

                            if (!isValid)
                            {
                                Console.Clear();
                                Console.WriteLine("You entered invalid value or zero, please try again (1-2)");
                            }

                            else if (optionHolder <= 0 || 2 < optionHolder)
                            {
                                Console.Clear();
                                Console.WriteLine("Please select one of the curretn options (1-2)");
                            }

                            else
                            {
                                if (optionHolder == 1 && 15 <= fuelValue && 12 <= oxygenValue)
                                {
                                    fuelValue = fuelValue - 15;
                                    oxygenValue = oxygenValue - 12;
                                    optionSwitchMars = true;
                                    optionSwitchEuropa = false;
                                    Console.WriteLine("You succesfully traveled to Mars");
                                    optionSwitchMercury = false;
                                    loopController = false;
                                }

                                else if (optionHolder == 2 && 20 <= fuelValue && 16 <= oxygenValue)
                                {
                                    if (earnFourMineral && marsIsExplored && mercuryIsExplored)
                                    {
                                        fuelValue = fuelValue - 20;
                                        oxygenValue = oxygenValue - 16;
                                        optionSwitchEuropa = true;
                                        optionSwitchMars = false;
                                        Console.WriteLine("You succesfully traveled to Europa");
                                        optionSwitchMercury = false;
                                        loopController = false;
                                    }

                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine($"Have you explored Mercury : {mercuryIsExplored}");
                                        Console.WriteLine($"Have you explored Mars : {marsIsExplored}");
                                        Console.WriteLine($"Have you earn 4 mineral : {earnFourMineral}");
                                        loopController = false;
                                    }
                                }

                                else
                                {
                                    Console.Clear ();
                                    Console.WriteLine("You doesn't have enough oxygen or fuel for travel please travel to Supply Station");
                                    loopController = false;
                                }
                            }                            
                        }
                    }

                    else if (optionHolder == 2)
                    {
                        if (12 <= energyValue && 30 < healthValue && !mercuryIsExplored)
                        {
                            
                            energyValue = energyValue - 12;
                            healthValue = healthValue - 5;
                            mercuryIsExplored = true;
                            creditValue = creditValue + 15;
                            missionScore = missionScore + 10;
                            dailyExploredPlanetsValue++;
                            succesfullOperationsCounter++;
                            dailySuccesfullOperationCounter++;
                            if (2 <= dailyExploredPlanetsValue && mercuryMineralCollectionLimit && marsMineralCollectionLimit)
                            {
                                missionScore = missionScore + 10;
                                Console.WriteLine("Congratulations you earn extra 10 points for explore 2 planet in a day.");
                            }
                        }

                        else if (mercuryIsExplored)
                        {
                            Console.Clear();
                            Console.WriteLine("You have already explored this planet.");
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have enough energy or health for explore this planet");
                        }
                    }

                    else if (optionHolder == 3)
                    {
                        if(mercuryIsExplored && mercuryMineralCollectionLimit && 8 <= energyValue)
                        {
                            energyValue = energyValue - 8;
                            mineralsValue = mineralsValue + 2;
                            mineralCollectionCounter = mineralCollectionCounter + 2;
                            dailySuccesfullOperationCounter++;
                            succesfullOperationsCounter++;
                            mercuryMineralCollectionLimit = false;
                            if (4 <= mineralCollectionCounter) earnFourMineral = true;
                        }

                        else if (!mercuryIsExplored)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't make mineral collection at here before exploration");
                        }

                        else if (!mercuryMineralCollectionLimit)
                        {
                            Console.Clear();
                            Console.WriteLine("You can't make collection 2 times a day.");
                        }
                        
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("You doesn't have enough energy for collection.");
                        }
                    }

                    else if (optionHolder == 4)
                    {
                        optionSwtitchSupplyStation = true;
                        locationReminderMercury = true;
                        optionSwitchEuropa = false;
                        optionSwitchMars = false;
                        optionSwitchMercury = false;
                    }

                    else if (optionHolder == 5)
                    {
                        Console.Clear();
                        Console.WriteLine($"Current succesful operation count : {succesfullOperationsCounter}");
                    }

                    else if (optionHolder == 6)
                    {
                        if (2 <= dailySuccesfullOperationCounter)
                        {
                            oxygenValue = oxygenValue - 5;
                            energyValue = energyValue + 15;
                            europaMineralCollectionLimit = true;
                            mercuryMineralCollectionLimit = true;
                            marsMineralCollectionLimit = true;
                            dayCounter++;
                            dailyExploredPlanetsValue = 0;
                            dailySuccesfullOperationCounter = 0;
                            if (100 < energyValue) energyValue = 100;
                        }

                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Please complete 2 succesfull operation for end of your day");
                        }

                    }

                    else
                    {
                        mainMenuLoopController = false;
                        optionSwitchMercury = false;
                    }
                }

                else if (optionHolder < 0 || 7 < optionHolder)
                {
                    Console.Clear();
                    Console.WriteLine("Please enter one of the current options (1-7)");
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("You entered invalid value or zero, please try again (1-7)");
                }
            }
            
            while(championSwitch)
            {
                Console.WriteLine("İf you want to continue your adevnture please press 1 or you want to exit please press 2");
                isValid = short.TryParse(Console.ReadLine(), out optionHolder);
                 
                if (isValid && optionHolder == 2)
                {
                    mainMenuLoopController = false;
                    championSwitch = false;
                }

                else if (isValid && optionHolder == 1)
                {
                    optionSwitchSpaceStation = true;
                    championSwitch = false;
                }

                else
                {
                    Console.WriteLine("You entered invalid value please try again");
                }
            }
        }
    }
}
